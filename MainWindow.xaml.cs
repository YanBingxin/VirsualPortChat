using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace VirsualDevice
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region 字段
        static bool _continue;
        static SerialPort _serialPort;
        static Thread _readThread;
        #endregion

        #region 属性
        private int _baudRate = 9600;
        /// <summary>
        /// 波特率
        /// </summary>
        public int BaudRate
        {
            get
            {
                return _baudRate;
            }
            set
            {
                _baudRate = value;
                Notify("BaudRate");
            }
        }
        private int _dataBits = 8;
        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBits
        {
            get
            {
                return _dataBits;
            }
            set
            {
                _dataBits = value;
                Notify("DataBits");
            }
        }
        /// <summary>
        /// 本机端口列表
        /// </summary>
        public List<string> PortNames
        {
            get
            {
                return SerialPort.GetPortNames().ToList();
            }
        }
        public List<Encoding> Encodings
        {
            get
            {
                return new List<Encoding>()
                {
                    Encoding.ASCII,
                    Encoding.BigEndianUnicode,
                    Encoding.Default,
                    Encoding.Unicode,
                    Encoding.UTF32,
                    Encoding.UTF7,
                    Encoding.UTF8,
                };
            }
        }
        public List<Parity> Parities
        {
            get
            {
                return new List<Parity>()
                {
                    Parity.Even,
                    Parity.Mark,
                    Parity.None,
                    Parity.Odd,
                    Parity.Space,
                };

            }
        }
        public List<StopBits> StopBitses
        {
            get
            {
                return new List<StopBits>()
                {
                    StopBits.None,
                    StopBits.One,
                    StopBits.OnePointFive,
                    StopBits.Two,
                };

            }
        }


        ///// <summary>
        ///// 功能命令集合
        ///// </summary>
        //private ObservableCollection<Function> _funcs = new ObservableCollection<Function>();
        //[XmlArray(ElementName = "功能集合")]
        //public ObservableCollection<Function> Funcs
        //{
        //    get
        //    {
        //        return _funcs;
        //    }
        //    set
        //    {
        //        if (_funcs == value)
        //        {
        //            return;
        //        }
        //        _funcs = value;
        //        Notify("Funcs");
        //    }
        //}
        ///// <summary>
        ///// 功能命令集合
        ///// </summary>
        //private ObservableCollection<AutoResponse> _responses = new ObservableCollection<AutoResponse>()
        //{
        //    new AutoResponse() {Ask="asdfasdf",Answer="asdfjsdf" },
        //};
        //[XmlArray(ElementName = "自动回复集合")]
        //public ObservableCollection<AutoResponse> Responses
        //{
        //    get
        //    {
        //        return _responses;
        //    }
        //    set
        //    {
        //        if (_responses == value)
        //        {
        //            return;
        //        }
        //        _responses = value;
        //        Notify("Responses");
        //    }
        //}
        private VirsualData _data = new VirsualData();
        /// <summary>
        /// 数据位
        /// </summary>
        public VirsualData Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                Notify("Data");
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += delegate { Data = SerialHelper.LoadFromFile<VirsualData>("D:\\VirsualData.xml"); };
            this.Closing += delegate { ClosePort(); SerialHelper.SaveToFile(Data, "D:\\VirsualData.xml"); };
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            btnOpen.IsEnabled = false;
            try
            {
                OpenSerialPort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                ugd.IsEnabled = btnOpen.IsEnabled = true;
            }
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            ClosePort();
        }
        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (_continue)
                Write(this.txtSend.Text);
        }
        private void btnCommand_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (sender as Button);
                if (!string.IsNullOrEmpty(btn.Tag.ToString()) && _continue)
                {
                    Write(btn.Tag.ToString());
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, FlowDirection.RightToLeft);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.Text) || string.IsNullOrEmpty(txtCommand.Text))
            {
                return;
            }
            Data.Funcs.Add(new Function() { Content = txtContent.Text, Command = txtCommand.Text });
            txtCommand.Text = "";
            txtContent.Text = "";
        }

        private void btndel_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Function fun = btn.DataContext as Function;
            if (fun != null && MessageBox.Show("确实要删除该功能按钮吗？", "询问", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Data.Funcs.Remove(fun);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            AutoResponse res = btn.DataContext as AutoResponse;
            if (res != null)
            {
                Data.Responses.Remove(res);
            }
        }

        private void btnAddAutoRes_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAsk.Text) || string.IsNullOrEmpty(txtAnswer.Text))
            {
                return;
            }
            Data.Responses.Add(new AutoResponse() { Ask = txtAsk.Text, Answer = txtAnswer.Text });
            txtAnswer.Text = "";
            txtAsk.Text = "";
        }
        #region 方法
        /// <summary>
        /// 打开端口
        /// </summary>
        private void OpenSerialPort()
        {
            _readThread = new Thread(Read);
            _serialPort = new SerialPort((string)cboPortNames.SelectedItem, BaudRate, (Parity)cboParities.SelectedItem, DataBits, (StopBits)cboStopBites.SelectedItem);
            _serialPort.Encoding = (Encoding)cboEncodings.SelectedItem;
            _serialPort.WriteTimeout = 500;
            _serialPort.ReadTimeout = 500;
            _serialPort.Open();
            _readThread.Start();

            _continue = true;
            btnClose.IsEnabled = true;
            LogMessage("串口已启动", FlowDirection.RightToLeft);
            MessageBox.Show("串口已启动。");
        }
        /// <summary>
        /// 关闭端口
        /// </summary>
        private void ClosePort()
        {
            if (!_continue)
            {
                return;
            }
            btnClose.IsEnabled = false;
            try
            {
                _continue = false;
                _readThread.Join();
                _serialPort.Close();

                btnOpen.IsEnabled = true;
                LogMessage("串口已关闭", FlowDirection.RightToLeft);
                MessageBox.Show("串口已关闭");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnClose.IsEnabled = true;
            }
        }
        /// <summary>
        /// 读取消息
        /// </summary>
        public void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Dispatcher.Invoke(new Action(() =>
                    {
                        LogMessage(message, FlowDirection.LeftToRight);
                        AutoResponseMessage(message);
                    }));

                }
                catch (TimeoutException) { }
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="mess"></param>
        public void Write(string mess)
        {
            try
            {
                _serialPort.WriteLine(mess);
                LogMessage(mess, FlowDirection.RightToLeft);

            }
            catch (TimeoutException ex)
            {
                LogMessage(ex.Message, FlowDirection.RightToLeft);
            }
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="direction"></param>
        private void LogMessage(string message, FlowDirection direction)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.FlowDirection = direction;
            LogControl con = new LogControl();
            con.Message = message;
            con.Template = (ControlTemplate)this.Resources["LogTemplate"];
            paragraph.Inlines.Add(con);
            flLog.Blocks.Add(paragraph);
            rchtxt.ScrollToEnd();
        }
        /// <summary>
        /// 自动回复
        /// </summary>
        /// <param name="message"></param>
        private void AutoResponseMessage(string message)
        {
            AutoResponse res = Data.Responses.FirstOrDefault(a => a.Ask == message);
            if (res != null)
            {
                Write(res.Answer);
            }
        }

        #endregion

        #region INotifyPropertyChanged 成员

        public event PropertyChangedEventHandler PropertyChanged;

        public void Notify(string propertyName)
        {
            if (PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

    }
}
