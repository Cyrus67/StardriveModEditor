using System;
using System.Xml.Serialization;

using StardriveModEditor.Services.XMLParsing;

namespace StardriveModEditor.Models
{
    //For any elements that are named differently than a property here
    //Use [XmlElement("ElementName")] as an attrib
    //For properties that may not have values, use [CustomXMLIgnoreAttribute] to have it parse
    //  only if its value is not equal to the default value of its type.
    //[XmlRoot("Building")] use if root name is different from class name.
    [XmlRoot("Building")]
    public class Building
    {
        //[XmlElement("")]
        public string Name { get; set; }

        public int Cost { get; set; }

        [CustomXMLIgnore]
        public float PlusFlatFoodAmount { get; set; }

        [CustomXMLIgnore]
        [CustomDefaultValue(true)]
        public bool Scrappable { get; set; } = true;

        [CustomXMLIgnore]
        [XmlElement("ShortDescription")]
        public string Desc { get; set; }
    }
}
