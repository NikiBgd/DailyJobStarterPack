using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DailyJobStarterPack.Web.ViewModels.Objects
{
    [XmlRoot(ElementName = "valuta")]
    public class Valuta
    {
        [XmlAttribute(AttributeName = "oznaka")]
        public string Oznaka { get; set; }
        [XmlAttribute(AttributeName = "kup")]
        public string Kup { get; set; }
        [XmlAttribute(AttributeName = "sre")]
        public string Sre { get; set; }
        [XmlAttribute(AttributeName = "pro")]
        public string Pro { get; set; }
    }

    [XmlRoot(ElementName = "kursnalista")]
    public class Kursnalista
    {
        [XmlElement(ElementName = "valuta")]
        public List<Valuta> Valuta { get; set; }
        [XmlAttribute(AttributeName = "datum")]
        public string Datum { get; set; }
    }

    [XmlRoot(ElementName = "result")]
    public class Result
    {
        [XmlAttribute(AttributeName = "date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "from")]
        public string From { get; set; }
        [XmlAttribute(AttributeName = "to")]
        public string To { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(AttributeName = "value")]
        public string Value { get; set; }
    }

    [XmlRoot(ElementName = "konvertor_valuta")]
    public class Konvertor_valuta
    {
        [XmlElement(ElementName = "result")]
        public Result Result { get; set; }
    }

}
