using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SandBox.Algorithms.TreeDataStructure;

namespace SandBox.DataContractSerialize
{
    class DataContractSerializeInterface
    {
        public DataContractSerializeInterface()
        {
            var save = false;
            
            BinaryTree<int> tree;
            if (save)
            {
                tree = NodeInterface.GenerateBinaryTree();

                Save("tree", tree);
                Console.WriteLine("Tree saved successfully");
            }
            else
            {
                tree = Load<BinaryTree<int>>("tree");
                Console.WriteLine("Tree loaded successfully");
            }

            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        protected void Save<T>(string name, T _obj)
        {
            name = name + ".json";
            if (File.Exists(name))
                File.Delete(name);

            using (StreamWriter file = File.CreateText(name))
            {
                var settings = new JsonSerializerSettings
                                {
                                    PreserveReferencesHandling = PreserveReferencesHandling.All
                                };

                var encoded = JsonConvert.SerializeObject(_obj, Formatting.None, settings);

                file.Write(encoded);
            }
        }

        protected T Load<T>(string name)
        {
            name = name + ".json";
            if (!File.Exists(name))
                throw new Exception($"File {name} does not exists in the assembly.");

            return JsonConvert.DeserializeObject<T>(File.ReadAllText(name));
        }
    }

    [DataContract]
    public class Dummy
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        protected int Version { get; set; }
        [DataMember]
        private int Token { get; set; }
        [DataMember]
        internal bool Suspicious { get; set; }
        [DataMember]
        public List<Bummy> Bummies { get; set; }
        [DataMember]
        private static int _dummiesCounter { get; set; }= 1;

        public int BummiesAmount => Bummies.Count;
        private static object _lock = new object();

        public static Dummy GenerateDummy()
        {
            var bummies = new List<Bummy>();
            for(int i = 0; i < 50; i++)
                bummies.Add(Bummy.GenerateBummy());

            lock (_lock)
            {
                var dummy = new Dummy
                {
                    Id = _dummiesCounter,
                    Version = 1,
                    Token = 32 + _dummiesCounter,
                    Suspicious = true,
                    Bummies = bummies
                };

                _dummiesCounter++;

                return dummy;
            }
        }
    }

    [DataContract]
    public class Bummy
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        private string Name { get; set; }
        [DataMember]
        private static int _bummiesCounter = 1;
        [DataMember]
        public Dummy Parent { get; set; }

        private static object _lock = new object();

        public static Bummy GenerateBummy()
        {
            lock (_lock)
            {
                var bummy = new Bummy
                {
                    Id = _bummiesCounter,
                    Name = $"Bummy_{_bummiesCounter}"
                };

                _bummiesCounter++;
                return bummy;
            }
        }
    }
}
