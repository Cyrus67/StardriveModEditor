using System;
using System.Xml.Serialization;

using StardriveModEditor.Services.XMLParsing;

namespace StardriveModEditor.Models
{
    //For any elements that are named differently than a property here
    //  use [XmlElement("ElementName")] as an attrib
    //For properties that may not have values, use [CustomXMLIgnoreAttribute] to have it parse
    //  only if its value is not equal to the default value of its type.

    //[XmlRoot("Building")] use if root name is different from class name.
    public class Building
    {
        #region Basic Properties

        public string Name { get; set; }

        public int Cost { get; set; }

        /// <summary>
        /// The Path to the building's XML file.
        /// </summary>
        [XmlIgnore]
        public string Path { get; set; }
        #endregion

        #region Resource Properties
        
        [CustomXMLIgnore]
        public float PlusFlatFoodAmount { get; set; }
        #endregion

        [CustomXMLIgnore]
        [CustomDefaultValue(true)]
        public bool Scrappable { get; set; } = true;

        [CustomXMLIgnore]
        [XmlElement("ShortDescription")]
        public string Desc { get; set; }
    }
}
