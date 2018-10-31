using System.IO;
using System.Xml.Serialization;

namespace SandBox.Utils
{
    public class XmlCacheService<T>
    {
        protected T _obj { get; private set; }
        protected string _fileName { get; }

        private string FullName => _fileName + ".xml";

        protected XmlCacheService(T obj, string fileName)
        {
            _obj = obj;
            _fileName = fileName;
        }

        protected void Save()
        {
            if (File.Exists(FullName))
                File.Delete(FullName);

            XmlSerializer writer = new XmlSerializer(typeof(T));
            FileStream file = File.Create(FullName);
            writer.Serialize(file, _obj);
            file.Close();
        }

        protected void Load()
        {
            if (!File.Exists(FullName)) return;

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StreamReader reader = new StreamReader(FullName);
            _obj = (T)serializer.Deserialize(reader);
            reader.Close();
        }
    }
}
