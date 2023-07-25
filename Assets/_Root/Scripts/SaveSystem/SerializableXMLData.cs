using System;
using System.IO;
using System.Xml.Serialization;

namespace _Root.Scripts.SaveSystem
{
    public class SerializableXMLData<T> : IData<T>
    {
        private static XmlSerializer _xmlSerializer;

        public SerializableXMLData()
        {
            _xmlSerializer = new XmlSerializer(typeof(T));
        }
        
        public void Save(T data, string path = null)
        {
            if (data == null && !String.IsNullOrEmpty(path))
            {
                return;
            }

            using (var fs = new FileStream(path, FileMode.Create))
            {
                _xmlSerializer.Serialize(fs, data);
            }
        }

        public T Load(string path = null)
        {
            T result;
            if (!File.Exists(path))
            {
                return default;
            }

            using (var fs = new FileStream(path, FileMode.Open))
            {
                result = (T)_xmlSerializer.Deserialize(fs);
            }

            return result;
        }
    }
}