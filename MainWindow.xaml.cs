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
        bool _continue;
        SerialPort _serialPort;
        Thread _readThread;
        #endregion

        #region 属性


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
        public List<string> Encodings
        {
            get
            {
                return new List<string>()
                {
                    "ASCII",
                    "BYTE",
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
            this.Loaded += delegate { Data = SerialHelper.LoadFromFile<VirsualData>("VirsualData.xml"); };
            this.Closing += delegate { ClosePort(); SerialHelper.SaveToFile(Data, "VirsualData.xml"); };
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
            try
            {
                if (_continue)
                    Write(this.txtSend.Text);
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, FlowDirection.RightToLeft, Brushes.Yellow);
            }
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
                LogMessage(ex.Message, FlowDirection.RightToLeft, Brushes.Yellow);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtContent.Text) || string.IsNullOrEmpty(txtSend.Text))
            {
                MessageBox.Show("功能名称|命令均不能为空");
                return;
            }
            if (Data.Funcs.FirstOrDefault(f => f.Content == txtContent.Text && f.Command == txtSend.Text) != null)
            {
                MessageBox.Show("已存在相同的项");
                return;
            }
            Data.Funcs.Add(new Function() { Content = txtContent.Text, Command = txtSend.Text });
            txtSend.Text = "";
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
                MessageBox.Show("问句|答复均不能为空");
                return;
            }
            if (Data.Responses.FirstOrDefault(r => r.Ask == txtAsk.Text) != null)
            {
                MessageBox.Show("列表中已存在与该问句相同的项");
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
            _serialPort = new SerialPort((string)cboPortNames.SelectedItem, Data.PortPara.BaudRate, (Parity)cboParities.SelectedItem, Data.PortPara.DataBits, (StopBits)cboStopBites.SelectedItem);
            _serialPort.Encoding = Encoding.ASCII;
            _serialPort.WriteTimeout = 1000;
            _serialPort.ReadTimeout = 1000;
            _serialPort.Open();
            _readThread.Start();

            _continue = true;
            btnClose.IsEnabled = true;
            LogMessage("串口已启动", FlowDirection.RightToLeft, Brushes.LightGreen);
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
                if (!_readThread.Join(500))
                {
                    _readThread.Abort();
                }
                _serialPort.Close();

                btnOpen.IsEnabled = true;
                LogMessage("串口已关闭", FlowDirection.RightToLeft, Brushes.Pink);
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
                    string message = string.Empty;
                    if (Data.PortPara.EncodingIndex.ToUpper() == "BYTE")
                    {
                        byte[] messes = new byte[1024];
                        int len = _serialPort.Read(messes, 0, 1024);
                        while (_serialPort.BytesToRead > 0)
                        {
                            len += _serialPort.Read(messes, len, 1024 - len);
                        }
                        for (int i = 0; i < len; i++)
                        {
                            message += messes[i].ToString("X2") + " ";
                        }
                        message = message.Trim();
                    }
                    else
                    {
                        message = _serialPort.ReadLine();
                    }
                    Dispatcher.Invoke(new Action(() =>
                    {
                        LogMessage(message, FlowDirection.LeftToRight, Brushes.LightBlue);
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
            if (!string.IsNullOrEmpty(mess) && mess.Contains(';'))
            {
                string[] messes = mess.Split(';');
                int tick = Convert.ToInt32(messes[messes.Length - 1]);
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 0, 0, tick);
                int i = 0;
                Send(messes[i]);
                timer.Tick += delegate
                {
                    i++;
                    if (i < messes.Length - 1)
                        Send(messes[i]);
                    else
                        timer.Stop();
                };
                timer.Start();

            }
            else
            {
                Send(mess);
            }
        }

        private void Send(string mess)
        {
            try
            {
                if (cboEncodings.Text == "BYTE")
                {
                    string[] messes = mess.Trim().Split(' ');
                    byte[] mes = new byte[messes.Length];
                    for (int i = 0; i < messes.Length; i++)
                    {
                        mes[i] = Convert.ToByte(messes[i], 16);
                    }
                    _serialPort.Write(mes, 0, mes.Length);
                }
                else
                {
                    _serialPort.WriteLine(mess);
                }
                LogMessage(mess, FlowDirection.RightToLeft, Brushes.LightGreen);

            }
            catch (TimeoutException ex)
            {
                LogMessage(ex.Message, FlowDirection.RightToLeft, Brushes.Yellow);
            }
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="direction"></param>
        private void LogMessage(string message, FlowDirection direction, SolidColorBrush brush)
        {
            Paragraph paragraph = new Paragraph();
            paragraph.FlowDirection = direction;
            LogControl con = new LogControl();
            con.FlowDirection = FlowDirection.LeftToRight;
            con.Background = brush;
            con.Time = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            con.Message = message;
            con.Template = (ControlTemplate)this.Resources["LogTemplate"];
            paragraph.Inlines.Add(con);
            flLog.Blocks.Add(paragraph);
            //if (!rchtxt.IsMouseOver && !ugd.IsMouseOver && this.IsMouseOver)
            //    rchtxt.ScrollToEnd();
            if (flLog.Blocks.Count > 7)
            {
                flLog.Blocks.Remove(flLog.Blocks.ToList()[0]);
            }
        }
        /// <summary>
        /// 自动回复
        /// </summary>
        /// <param name="message"></param>
        private void AutoResponseMessage(string message)
        {
            try
            {
                AutoResponse res = Data.Responses.FirstOrDefault(a => string.Compare(a.Ask, message, true) == 0);
                if (res != null)
                {
                    Write(res.Answer);
                }
            }
            catch (Exception ex)
            {
                LogMessage(ex.Message, FlowDirection.RightToLeft, Brushes.Yellow);
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
