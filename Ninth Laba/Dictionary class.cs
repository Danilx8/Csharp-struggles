using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Ninth_Laba
{
    public class Syncronizations : SerializableDictionary<string, string[]>
    {
        protected override string ItemName
        {
            get { return "Session"; }
        }

        protected override string KeyName
        {
            get { return "Action_Type"; }
        }

        protected override string ValueName
        {
            get { return "File_name"; }
        }
    }

    public abstract class SerializableDictionary<TKey, TValue> :
        Dictionary<TKey, TValue>, IXmlSerializable
    {
        protected abstract string ItemName { get; }
        protected abstract string KeyName { get; }
        protected abstract string ValueName { get; }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader Reader)
        {
            XmlSerializer KeySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));

            bool WasEmpty = Reader.IsEmptyElement;
            Reader.Read();

            if (WasEmpty)
                return;

            while (Reader.NodeType != XmlNodeType.EndElement)
            {
                Reader.ReadStartElement(ItemName);

                Reader.ReadStartElement(KeyName);
                TKey Key = (TKey)KeySerializer.Deserialize(Reader);
                Reader.ReadEndElement();

                Reader.ReadStartElement(ValueName);
                TValue Value = (TValue)ValueSerializer.Deserialize(Reader);
                Reader.ReadEndElement();

                this.Add(Key, Value);

                Reader.ReadEndElement();
                Reader.MoveToContent();
            }
            Reader.ReadEndElement();
        }

        public void WriteXml(XmlWriter Writer)
        {
            XmlSerializer KeySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer ValueSerializer = new XmlSerializer(typeof(TValue));

            Writer.WriteStartElement(ItemName);
            foreach (TKey Key in this.Keys)
            {
                Writer.WriteStartElement(KeyName);
                KeySerializer.Serialize(Writer, Key);
                Writer.WriteEndElement();

                Writer.WriteStartElement(ValueName);
                TValue Value = this[Key];
                ValueSerializer.Serialize(Writer, Value);
                Writer.WriteEndElement();
            }
        }
    }
}
