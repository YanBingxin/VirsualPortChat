using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VirsualDevice
{
    public class AutoResponse
    {
        [XmlElement(ElementName = "问句")]
        public string Ask
        {
            set;
            get;
        }
        [XmlElement(ElementName = "答复")]
        public string Answer
        {
            set;
            get;
        }
    }
}
