using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Fourth_Laba
{
    class Memento
    {
        public Dictionary<string, string> Content { get; set; }
        public List<string> FileName { get; set; }
    }

    public class Caretaker
    {
        private object memento;
        public void SaveState(IOriginator Originator)
        {
            Originator.SetMemento(memento);
        }

        public void RestoreState(IOriginator Originator)
        {
            memento = Originator.GetMemento();
        }
    }

    [Serializable]
    class TextClass: IOriginator
    {
        public Dictionary<string, string> Content { get; set; }
        public List<string> FileName { get; set; }

        public TextClass() 
        {
            Content = new Dictionary<string, string>();
            FileName = new List<string>();
        }
        public TextClass(string Content, string FileName)
        {
            this.Content.Add(FileName, Content);
            this.FileName.Add(FileName);
        }

        public void BinarySerialization(FileStream FileStream) 
        {
            BinaryFormatter BinaryFormatter = new BinaryFormatter();
            BinaryFormatter.Serialize(FileStream, this);
            FileStream.Flush();
            FileStream.Close();
        }

        public void BinaryDeserialization(FileStream Filestream) 
        {
            BinaryFormatter BinaryFormatter = new BinaryFormatter();
            TextClass Deserialized = (TextClass)BinaryFormatter.Deserialize(Filestream);
            Content = Deserialized.Content;
            FileName = Deserialized.FileName;
            Filestream.Close();
        }

        public void XmlSerialization(FileStream FileStream) 
        {
            XmlSerializer Xmlserializer = new XmlSerializer(typeof(TextClass));
            Xmlserializer.Serialize(FileStream, this);
            FileStream.Flush();
            FileStream.Close();
        }

        public void XmlDeserialization(FileStream FileStream) 
        {
            XmlSerializer Xmlserializer = new XmlSerializer(typeof(TextClass));
            TextClass Deserialized = (TextClass)Xmlserializer.Deserialize(FileStream);
            Content = Deserialized.Content;
            FileName = Deserialized.FileName;
            FileStream.Close();
        }

        object IOriginator.GetMemento()
        {
            return new Memento { Content = this.Content, FileName = this.FileName };
        }

        void IOriginator.SetMemento(object Memento)
        {
            if (Memento is Memento)
            {
                var TempMemento = Memento as Memento;
                Content = TempMemento.Content;
                FileName = TempMemento.FileName;
            }
        }
    }
}
