using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace VirsualDevice
{

    public class PortPara : INotifyPropertyChanged
    {

        /// <summary>
        /// 串口名称
        /// </summary>
        private string _portIndex = "COM1";
        [XmlElement(ElementName = "串口名称")]
        public string PortIndex
        {
            get
            {
                return _portIndex;
            }
            set
            {
                if (_portIndex == value)
                {
                    return;
                }
                _portIndex = value;
                RaisePropertyChanged("PortIndex");
            }
        }


        /// <summary>
        /// 编码
        /// </summary>
        private string _encodingIndex = "BYTE";
        [XmlElement(ElementName = "编码格式")]
        public string EncodingIndex
        {
            get
            {
                return _encodingIndex;
            }
            set
            {
                if (_encodingIndex == value)
                {
                    return;
                }
                _encodingIndex = value;
                RaisePropertyChanged("EncodingIndex");
            }
        }

        private int _baudRate = 9600;
        [XmlElement(ElementName = "波特率")]
        public int BaudRate
        {
            get
            {
                return _baudRate;
            }
            set
            {
                _baudRate = value;
                RaisePropertyChanged("BaudRate");
            }
        }
        private int _dataBits = 8;
        [XmlElement(ElementName = "数据位")]
        public int DataBits
        {
            get
            {
                return _dataBits;
            }
            set
            {
                _dataBits = value;
                RaisePropertyChanged("DataBits");
            }
        }
        private int _parityIndex = 2;
        [XmlElement(ElementName = "奇偶校验")]
        public int ParityIndex
        {
            get
            {
                return _parityIndex;
            }
            set
            {
                _parityIndex = value;
                RaisePropertyChanged("ParityIndex");
            }
        }
        private int _stopBitsIndex = 1;
        [XmlElement(ElementName = "停止位")]
        public int StopBitsIndex
        {
            get
            {
                return _stopBitsIndex;
            }
            set
            {
                _stopBitsIndex = value;
                RaisePropertyChanged("StopBitsIndex");
            }
        }
        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
