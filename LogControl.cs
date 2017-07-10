using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace VirsualDevice
{
    public class LogControl : Button
    {
        [XmlIgnore]
        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimeProperty =
            DependencyProperty.Register("Time", typeof(string), typeof(LogControl), new PropertyMetadata(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")));


        [XmlIgnore]
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(LogControl), new PropertyMetadata(""));

    }
}
