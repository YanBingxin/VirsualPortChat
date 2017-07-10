using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VirsualDevice
{
    [XmlRoot(ElementName = "快捷功能")]
    public class Function
    {
        [XmlElement(ElementName = "功能名称")]
        public string Content
        {
            set;
            get;
        }
        [XmlElement(ElementName = "命令")]
        public string Command
        {
            set;
            get;
        }
    }
}
