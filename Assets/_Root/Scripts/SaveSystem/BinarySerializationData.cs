using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _Root.Scripts.SaveSystem
{
    public class BinarySerializationData<T> : IData<T>
    {
        private static BinaryFormatter _binaryFormatter;

        public BinarySerializationData()
        {
            _binaryFormatter = new BinaryFormatter();
        }
        
        public void Save(T data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path))
            {
                return;
            }

            if (!typeof(T).IsSerializable)
            {
                return;
            }

            using (var fs = new FileStream(path, FileMode.Create))
            {
                _binaryFormatter.Serialize(fs, data);
            }
        }

        public T Load(string path = null)
        {
            T result;
            if (!File.Exists(path))
            {
                return default(T);
            }

            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (T)_binaryFormatter.Deserialize(fs);
            }

            return result;
        }
    }
}