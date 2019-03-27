
namespace Imbick.StarCitizen.Keybind.Serialiser {
    using System.IO;
    using System.Xml.Serialization;
    using Model;

    public class ActionMapsSerialiser {
        public ActionMaps DeserialiseFile(string filename) {
            using (var fileStream = File.OpenRead(filename)) {
                return Deserialise(fileStream);
            }
        }

        public ActionMaps Deserialise(string rawXml) {
            var serialiser = new XmlSerializer(typeof(ActionMaps));
            using (var reader = new StringReader(rawXml)) {
                return serialiser.Deserialize(reader) as ActionMaps;
            }
        }

        public ActionMaps Deserialise(Stream stream) {
            var serialiser = new XmlSerializer(typeof(ActionMaps));
            return serialiser.Deserialize(stream) as ActionMaps;
        }
    }
}