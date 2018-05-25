using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardriveModEditor.Services.XMLParsing
{
    /// <summary>
    /// A custom attribute to denote a user-defined default value for XML serialization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    class CustomDefaultValueAttribute : Attribute
    {
        public object DefaultValue { get; private set; }

        public CustomDefaultValueAttribute(object defaultValue)
        {
            DefaultValue = defaultValue;
        }
    }
}
