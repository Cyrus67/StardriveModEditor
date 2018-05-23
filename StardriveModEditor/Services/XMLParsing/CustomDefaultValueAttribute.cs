using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StardriveModEditor.Services.XMLParsing
{
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
