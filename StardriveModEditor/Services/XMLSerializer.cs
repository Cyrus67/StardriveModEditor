using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Reflection;

using StardriveModEditor.Models;
using StardriveModEditor.Services.XMLParsing;

namespace StardriveModEditor.Services
{
    public static class XMLSerializer
    {
        public static T Deserialize<T>(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            T ret;
            using (TextReader reader = new StreamReader(filePath))
            {
                ret = (T)serializer.Deserialize(reader);
            }
            return ret;
        }

        public static void Serialize<T>(T objToSerialize, string pathToWrite)
        {
            //For the custom attribute!
            //If it's present, check if it's equal to the default value.
            //If so, ignore it, else serialize it.
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();
            XmlAttributes attributes = new XmlAttributes();
            attributes.XmlIgnore = true;

            foreach(PropertyInfo prop in (typeof(T)).GetProperties())
            {
                //Check for the ignore attribute
                if(prop.GetCustomAttribute<CustomXMLIgnoreAttribute>() != null)
                {
                    Type propType = prop.PropertyType;
                    //Get default value
                    object defaultValue = null;
                    CustomDefaultValueAttribute defaultAttribute = prop.GetCustomAttribute<CustomDefaultValueAttribute>();
                    if(defaultAttribute != null)
                    {
                        defaultValue = defaultAttribute.DefaultValue;
                    }
                    else if (propType.IsValueType)
                    {
                        defaultValue = Convert.ChangeType(Activator.CreateInstance(propType), propType);
                    }

                    //Equals the type default.
                    if (prop.GetValue(objToSerialize).Equals(defaultValue))
                    {
                        Console.WriteLine("Found an object with a default value!");
                        //Make sure to save it with proper name if it has a different one.
                        XmlElementAttribute elementNameAttribute = prop.GetCustomAttribute<XmlElementAttribute>();
                        string elementName = prop.Name;
                        if (elementNameAttribute != null)
                        {
                            elementName = elementNameAttribute.ElementName;
                        }
                        attributes.XmlElements.Add(new XmlElementAttribute(elementName));
                        overrides.Add(typeof(T), elementName, attributes);
                    }
                }
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T), overrides);

            //Write it.
            using (TextWriter writer = new StreamWriter(pathToWrite))
            {
                serializer.Serialize(writer, objToSerialize);
            }

        }
    }
}
