Okay so
Each model is just public properties. NO METHODS OR OTHER SHENANIGANS!
There are a couple attributes that are important to ensure proper XML serialization!
[XmlIgnore] will ignore the property during serialization both ways.
[CustomXMLIgnore] will ignore the property if it is not changed from the default (more later)
[CustomDefaultValue(value)] will change the default value of the property for serialization purposes.
[XmlElement("ElementName")] will change the serialized tag name.
[XmlRoot("RootName")] will set the root name different from class name.

ON [CustomXMLIgnore]:
This is a bit of a hack. It will check if it's null or a value type default, if so it will ignore the property
If not, it will go ahead and serialize. If CustomDefaultValue is set, will use that default value instead of the others.

[CustomXMLIgnore]
[CustomDefaultValue(true)]
public bool Scrappable { get; set; } = true;

This property will be ignored if it equals true at serialization time. Make sure to actually set it's default!

DUNNO IF IT WORKS FOR LISTS!