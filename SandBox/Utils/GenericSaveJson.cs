using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace SandBox.Utils
{
    static class GenericSaveJson
    {
        public static void Save<T>(string fileName, T obj)
        {
            fileName = fileName.GetFullName();
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (StreamWriter file = File.CreateText(fileName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, obj);
            }
        }

        public static T Load<T>(string fileName) where T : new()
        {
            fileName = fileName.GetFullName();
            if (!File.Exists(fileName)) return new T();

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
        }

        private static string GetFullName(this string fileName)
            => fileName + ".json";
    }

    static class GenericSaveXml
    {
        public static void Save<T>(string fileName, T obj)
        {
            fileName = fileName.GetFullName();
            if (File.Exists(fileName))
                File.Delete(fileName);

            using (FileStream file = File.Create(fileName))
            {
                XmlSerializer writer = new XmlSerializer(typeof(T));
                writer.Serialize(file, obj);
            }
        }

        public static T Load<T>(string fileName) where T :new()
        {
            fileName = fileName.GetFullName();
            if (!File.Exists(fileName)) return new T();

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(fileName))
            {
                return (T)serializer.Deserialize(reader);
            }
        }

        private static string GetFullName(this string fileName)
            => fileName + ".xml";
    }
}
