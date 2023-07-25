using System;
using System.IO;
using System.Xml;
using UnityEngine;

namespace _Root.Scripts.SaveSystem
{
    public class XMLData : IData<SavedData>
    {
        public void Save(SavedData data, string path = null)
        {
            var xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Name");
            element.SetAttribute("value", data.Name);
            rootNode.AppendChild(element);
            
            element = xmlDoc.CreateElement("PosX");
            element.SetAttribute("value", data.Position.X.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PosY");
            element.SetAttribute("value", data.Position.Y.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PosZ");
            element.SetAttribute("value", data.Position.Z.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("IsEnabled");
            element.SetAttribute("value", data.IsEnabled.ToString());
            rootNode.AppendChild(element);

            XmlNode userNode = xmlDoc.CreateElement("info");
            var attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System language: " + Application.systemLanguage;
            rootNode.AppendChild(userNode);

            xmlDoc.Save(path);
        }

        public SavedData Load(string path = null)
        {
            var result = new SavedData();
            if (!File.Exists(path))
            {
                return result;
            }

            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var key = "Name";
                    if (reader.IsStartElement(key))
                    {
                        result.Name = reader.GetAttribute("value");
                    }

                    key = "PosX";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.X = float.Parse(reader.GetAttribute("value"));
                    }
                
                    key = "PosY";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Y = float.Parse(reader.GetAttribute("value"));
                    }

                    key = "PosZ";
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Z = float.Parse(reader.GetAttribute("value"));
                    }

                    key = "IsEnabled";
                    if (reader.IsStartElement(key))
                    {
                        result.IsEnabled = bool.Parse(reader.GetAttribute("value"));
                    }
                    
                }
            }

            return result;
        }
    }
}