using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;

namespace SandBox.Utils
{
    public abstract class LocalSave<T>
    {
        public T _obj { get; private set; }
        public string _fileName { get; }

        public virtual string GetFullName => _fileName + ".bin";

        protected LocalSave(T obj, string fileName)
        {
            _obj = obj;
            _fileName = fileName;
        }

        public virtual void Save()
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

        public virtual void Load()
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
