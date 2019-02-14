namespace Imbick.StarCitizen.Keybind.Serialiser.Model {
    using System.Collections.Generic;
    using System.Linq;

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
                if (targetActionMap == null) {
                    Add(actionMap);
                } else {
                    foreach (var action in actionMap.action) {
                        var targetAction = targetActionMap.action.FirstOrDefault(a => a.name == action.name);
                        if (targetAction == null) {
                            targetActionMap.Add(action);
                        } else {
                            targetAction.Overwrite(action);
                        }
                    }
                }
            }
        }

        public void Add(ActionMapsActionmap actionMap) {
            var copy = actionMap.Copy();
            this.actionmap.Add(copy);
        }

        private static ActionMaps DeserialiseDefaults() {
            var deserialiser = new ActionMapsSerialiser();
            return deserialiser.Deserialise("default-actionmaps.xml");
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