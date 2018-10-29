using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SandBox.Math
{
    public abstract class LocalSave<T>
    {
        public T _obj { get; private set; }
        public string _fileName { get; }

        public string GetFullName => _fileName + ".bin";

        protected LocalSave(T obj, string fileName)
        {
            _obj = obj;
            _fileName = fileName;
        }

        public async Task Save()
        {
            if (File.Exists(GetFullName))
                File.Delete(GetFullName);

            using (Stream stream = new FileStream(GetFullName,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None))
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _obj);
            }
        }

        public void Load()
        {
            if (File.Exists(GetFullName))
            {
                using (Stream stream = new FileStream(GetFullName,
                    FileMode.Open,
                    FileAccess.Read,
                    FileShare.Read))
                {
                    IFormatter formatter = new BinaryFormatter();
                    _obj = (T)formatter.Deserialize(stream);
                }
            }
        }
    }
}
