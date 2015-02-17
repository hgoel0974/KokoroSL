using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
namespace Kokoro.ColladaLL
{
	[System.SerializableAttribute()]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
	public partial class Grendgine_Collada_Targets
	{

	    [XmlElement(ElementName = "input")]
		public Grendgine_Collada_Input_Unshared[] Input;
		
	    [XmlElement(ElementName = "extra")]
		public Grendgine_Collada_Extra[] Extra;
	}
}

