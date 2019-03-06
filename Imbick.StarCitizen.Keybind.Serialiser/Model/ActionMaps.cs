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

        private KeyBindInput ToKeyBindInput(string kb) => (KeyBindInput) Enum.Parse(typeof(KeyBindInput), kb);

        public IDictionary<string, IDictionary<string, IEnumerable<KeyBindInput>>> ToDictionary() {
            var result = new Dictionary<string, IDictionary<string, IEnumerable<KeyBindInput>>>();
            foreach (var actionMap in this.actionmap.Where(m => m.action.Any())) {
                result.Add(actionMap.name, new Dictionary<string, IEnumerable<KeyBindInput>>());
                foreach (var action in actionMap.action) {
                    var keyBinds = action.rebind.input.Split('+')
                        .Select(ToKeyBindInput);
                    result[actionMap.name].Add(action.name, keyBinds);
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