using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Fourth_Laba
{
    internal class TextInfoClass
    {
        private string Keywords { get; set; }

        public TextInfoClass(string KeyWords)
        {
            this.Keywords = KeyWords;
        }

        public void BinarySerialization(FileStream fs) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, this);
            fs.Flush();
            fs.Close();
        }

        public void BinaryDeserialization(FileStream fs) 
        {
            BinaryFormatter bf = new BinaryFormatter();
            TextInfoClass deserialized = (TextInfoClass)bf.Deserialize(fs);
            Keywords = deserialized.Keywords;
            fs.Close();
        }

        public void XmlSerialization(FileStream fs) 
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(TextInfoClass));
            xmlserializer.Serialize(fs, this);
            fs.Flush();
            fs.Close();
        }

        public void XmlDeserialization(FileStream fs) 
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(TextInfoClass));
            TextInfoClass deserialized = (TextInfoClass)xmlserializer.Deserialize(fs);
            Keywords = deserialized.Keywords;
            fs.Close();
        }
    }
}
