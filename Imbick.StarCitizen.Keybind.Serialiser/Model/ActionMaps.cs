namespace Imbick.StarCitizen.Keybind.Serialiser.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public partial class ActionMaps {
        public static ActionMaps Default => DeserialiseDefaults();

        public ActionMaps() {
            actionmap = new List<ActionMapsActionmap>();
        }

        public void Apply(ActionMaps overrides) {
            if (overrides == null)
                return;

            foreach (var actionMap in overrides.actionmap) {
                var targetActionMap = this.actionmap.FirstOrDefault(a => a.name == actionMap.name);
                if (targetActionMap == null) { //we are adding a whole new action map
                    Add(actionMap);
                } else {
                    foreach (var action in actionMap.action) {
                        var targetAction = targetActionMap.action.FirstOrDefault(a => a.name == action.name);
                        if (targetAction == null) { //this is a new action being added to an existing action map
                            targetActionMap.Add(action);
                        } else {
                            targetAction.Overwrite(action); //this is a change to an existing action inside an existing action map
                        }
                    }
                }
            }
        }

        public void Add(ActionMapsActionmap actionMap) {
            var copy = actionMap.Copy();
            this.actionmap.Add(copy);
        }

        private ActivationMode ToActivationMode(string am) {
            if (string.IsNullOrEmpty(am))
                return (ActivationMode) 0;
            return (ActivationMode) Enum.Parse(typeof(ActivationMode), am);
        }

        public ActionMapsDictionary ToDictionary() {
            var result = new ActionMapsDictionary();
            foreach (var actionMap in this.actionmap.Where(m => m.action.Any())) {
                result.Add(actionMap.name, new Dictionary<string, RebindModel>());
                foreach (var action in actionMap.action) {
                    try {
                        result[actionMap.name].Add(action.name,
                            new RebindModel(action.rebind.input, ToActivationMode(action.rebind.activationMode)));
                    } catch (NotSupportedException e) {
                        throw new NotSupportedException($"Action {action.name} encountered with unsupported input whilst converting to dictionary. See inner exception for specific input.", e);
                    }
                }
            }

            return result;
        }

        private static ActionMaps DeserialiseDefaults() {
            var deserialiser = new ActionMapsSerialiser();
            var assembly = typeof(ActionMaps).GetTypeInfo().Assembly;
            var file = assembly.GetManifestResourceStream("Imbick.StarCitizen.Keybind.Serialiser.default-actionmaps.xml");
            return deserialiser.Deserialise(file);
        }
    }

    public partial class ActionMapsActionmap {
        public ActionMapsActionmap() {
            action = new List<ActionMapsActionmapAction>();
        }

        public void Add(ActionMapsActionmapAction action) {
            var copy = action.Copy();
            this.action.Add(copy);
        }

        public ActionMapsActionmap Copy() {
            var copy = new ActionMapsActionmap {
                name = this.name
            };
            copy.action.AddRange(this.action.Select(a => a.Copy()));
            return copy;
        }
    }

    public partial class ActionMapsActionmapAction {
        public ActionMapsActionmapAction() {
            rebind = new ActionMapsActionmapActionRebind();
        }

        public void Overwrite(ActionMapsActionmapAction action) {
            if (action == null)
                return;
            this.rebind.input = action.rebind.input;
            this.rebind.activationMode = action.rebind.activationMode;
            this.rebind.multiTap = action.rebind.multiTap;
            this.rebind.multiTapSpecified = action.rebind.multiTapSpecified;
        }

        public ActionMapsActionmapAction Copy() {
            return new ActionMapsActionmapAction {
                name = this.name,
                rebind = new ActionMapsActionmapActionRebind {
                    input = this.rebind.input,
                    activationMode = this.rebind.activationMode,
                    multiTap = this.rebind.multiTap,
                    multiTapSpecified = this.rebind.multiTapSpecified
                }
            };
        }
    }
}