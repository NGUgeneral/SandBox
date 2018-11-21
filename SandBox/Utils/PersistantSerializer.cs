using Newtonsoft.Json;
using System;
using System.IO;

namespace SandBox.Utils
{
	public class PersistantSerializer<T>
	{
		public static void Save(string name, T obj)
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

				var encoded = JsonConvert.SerializeObject(obj, Formatting.None, settings);

				file.Write(encoded);
			}
		}

		public static T Load(string name)
		{
			name = name + ".json";
			if (!File.Exists(name))
				throw new Exception($"File {name} does not exists in the assembly.");

			return JsonConvert.DeserializeObject<T>(File.ReadAllText(name));
		}
	}
}