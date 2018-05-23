using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardriveModEditor.Services.XMLParsing
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    class CustomXMLIgnoreAttribute : Attribute
    {

    }
}
