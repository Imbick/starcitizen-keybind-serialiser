
namespace Imbick.StarCitizen.Keybind.Serialiser {
    using System.IO;
    using System.Xml.Serialization;
    using Model;

    public class ActionMapsSerialiser {
        public ActionMaps Deserialise(string filename) {
            using (var fileStream = File.OpenRead(filename)) {
                return Deserialise(fileStream);
            }
        }

        public ActionMaps Deserialise(Stream stream) {
            var serialiser = new XmlSerializer(typeof(ActionMaps));
            return serialiser.Deserialize(stream) as ActionMaps;
        }
    }
}