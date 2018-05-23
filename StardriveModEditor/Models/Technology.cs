using System;
using System.Collections.Generic;
using System.Xml.Serialization;

using StardriveModEditor.Services.XMLParsing;

namespace StardriveModEditor.Models
{
    public class Technology
    {
        #region Basic Properties
        public string UID { get; set; }
        public float Cost { get; set; }

        [CustomXMLIgnore]
        public List<LeadsToTech> LeadsTo { get; set; } = new List<LeadsToTech>();
        #endregion


        public class LeadsToTech
        {
            public string UID { get; set; }
        }
    }

    
}
