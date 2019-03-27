
namespace Imbick.StarCitizen.Keybind.Serialiser.Model {
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public enum ActivationMode {
        none,
        press,
        double_tap
    }

    public class RebindModel
    { 
        public ReadOnlyCollection<KeyBindInput> Inputs { get; }

        public ActivationMode ActivationMode { get; }

        public RebindModel(string input, ActivationMode activationMode)
            : this(Convert(input), activationMode) { }

        public RebindModel(IEnumerable<KeyBindInput> inputs, ActivationMode activationMode) { 
            Inputs = new ReadOnlyCollection<KeyBindInput>(inputs.ToList());
            ActivationMode = activationMode;
        }

        private static KeyBindInput ToKeyBindInput(string kb) => (KeyBindInput) Enum.Parse(typeof(KeyBindInput), kb);

        private static IList<KeyBindInput> Convert(string input) {
            return input.Split('+')
                .Select(ToKeyBindInput)
                .ToList();
        }
    }

    public class ActionMapsDictionary
        : Dictionary<string, Dictionary<string, RebindModel>> {

    }
}
