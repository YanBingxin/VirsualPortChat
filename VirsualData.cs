using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VirsualDevice
{
    [XmlRoot]
    public class VirsualData
    {
        /// <summary>
        /// 功能命令集合
        /// </summary>
        private ObservableCollection<Function> _funcs = new ObservableCollection<Function>();
        [XmlArray(ElementName = "功能集合")]
        public ObservableCollection<Function> Funcs
        {
            get
            {
                return _funcs;
            }
            set
            {
                if (_funcs == value)
                {
                    return;
                }
                _funcs = value;
            }
        }
        /// <summary>
        /// 功能命令集合
        /// </summary>
        private ObservableCollection<AutoResponse> _responses = new ObservableCollection<AutoResponse>();
        [XmlArray(ElementName = "自动回复集合")]
        public ObservableCollection<AutoResponse> Responses
        {
            get
            {
                return _responses;
            }
            set
            {
                if (_responses == value)
                {
                    return;
                }
                _responses = value;
            }
        }
    }
}
