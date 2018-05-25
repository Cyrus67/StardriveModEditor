using System;
using System.Xml.Serialization;

namespace StardriveModEditor.Models
{
    [XmlRoot("ModInformation")]
    public class ModConfiguration
    {
        public string ModName { get; set; }
        public string ModDescription { get; set; }
        public string Version { get; set; }

        [XmlIgnore]
        public string Path { get; set; }
    }
}