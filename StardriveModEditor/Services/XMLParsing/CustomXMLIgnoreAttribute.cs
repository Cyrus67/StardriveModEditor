using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardriveModEditor.Services.XMLParsing
{
    /// <summary>
    /// A marker attribute that tells the XML serializer to not serialize if the property is still it's default value.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    class CustomXMLIgnoreAttribute : Attribute
    {

    }
}
