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
        public string Keywords { get; set; }
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
    class TextInfoClass: IOriginator
    {
        public string Keywords { get; set; }
        public string FileName { get; set; }

        public TextInfoClass(string Keywords, string FileName)
        {
            this.Keywords = Keywords;
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
            TextInfoClass deserialized = (TextInfoClass)bf.Deserialize(fs);
            Keywords = deserialized.Keywords;
            FileName = deserialized.FileName;
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
            FileName = deserialized.FileName;
            fs.Close();
        }

        object IOriginator.GetMemento()
        {
            return new Memento { Keywords = this.Keywords, FileName = this.FileName };
        }

        void IOriginator.SetMemento(object memento)
        {
            if (memento is Memento)
            {
                var mem = memento as Memento;
                Keywords = mem.Keywords;
                FileName = mem.FileName;
            }
        }
    }
}
