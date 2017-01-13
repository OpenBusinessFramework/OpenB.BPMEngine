using System.IO;
using System.Xml.Serialization;

namespace OpenB.BPM.Core
{

    public class XmlConfigurationService
    {
        internal T ReadConfiguration<T>(string xmlFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            StreamReader reader = new StreamReader(xmlFilePath);

            T result = (T)serializer.Deserialize(reader);
            reader.Close();

            return result;
        }
    }
}