using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Fourth_Laba
{
    class Memento
    {
        public string Content { get; set; }
        public string FileName { get; set; }
    }

    public class Caretaker
    {
        private object memento;
        public void SaveState(IOriginator originator)
        {
            memento = originator.GetMemento();
        }

        public void RestoreState(IOriginator originator)
        {
            originator.SetMemento(memento);
        }
    }

    [Serializable]
    class TextClass: IOriginator
    {
        public string Content { get; set; }
        public string FileName { get; set; }

        public TextClass() { }
        public TextClass(string Content, string FileName)
        {
            this.Content = Content;
            this.FileName = FileName;
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
            TextClass deserialized = (TextClass)bf.Deserialize(fs);
            Content = deserialized.Content;
            FileName = deserialized.FileName;
            fs.Close();
        }

        public void XmlSerialization(FileStream fs) 
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(TextClass));
            xmlserializer.Serialize(fs, this);
            fs.Flush();
            fs.Close();
        }

        public void XmlDeserialization(FileStream fs) 
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(TextClass));
            TextClass deserialized = (TextClass)xmlserializer.Deserialize(fs);
            Content = deserialized.Content;
            FileName = deserialized.FileName;
            fs.Close();
        }

        object IOriginator.GetMemento()
        {
            return new Memento { Content = this.Content, FileName = this.FileName };
        }

        void IOriginator.SetMemento(object memento)
        {
            if (memento is Memento)
            {
                var mem = memento as Memento;
                Content = mem.Content;
                FileName = mem.FileName;
            }
        }
    }
}
