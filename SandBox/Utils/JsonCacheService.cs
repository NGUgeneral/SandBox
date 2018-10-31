using System.IO;
using Newtonsoft.Json;

namespace SandBox.Utils
{
    public class JsonCacheService<T>
    {
        protected T _obj { get; private set; }
        protected string _fileName { get; }

        private string FullName => _fileName + ".json";

        protected JsonCacheService(T obj, string fileName)
        {
            _obj = obj;
            _fileName = fileName;
        }

        protected void Save()
        {
            if (File.Exists(FullName))
                File.Delete(FullName);

            using (StreamWriter file = File.CreateText(FullName))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, _obj);
            }
        }

        protected void Load()
        {
            if (!File.Exists(FullName)) return;

            _obj = JsonConvert.DeserializeObject<T>(File.ReadAllText(FullName));
        }
    }
}