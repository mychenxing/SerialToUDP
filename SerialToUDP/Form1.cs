using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SerialFormsApp
{
    public partial class SerialToUDP : Form
    {
        public SerialToUDP()
        {
            InitializeComponent();
            string[] AA = SerialPort.GetPortNames();
            foreach (var item in AA)
            {
                Console.WriteLine(item);
            }

        }

        #region 设置和转发：声明和定义

        /// <summary>
        /// 本机IP
        /// </summary>
        string LocalIp;

        /// <summary>
        /// 本机端口号
        /// </summary>
        int LocalPort;

        /// <summary>
        /// 远程IP
        /// </summary>
        string RemoteIp;

        /// <summary>
        /// 远程端口
        /// </summary>
        int RemotePort;

        /// <summary>
        /// 串口号COM
        /// </summary>
        string Com;

        /// <summary>
        /// 波特率
        /// </summary>
        int BandR;

        /// <summary>
        /// 数据位
        /// </summary>
        int DataB;

        /// <summary>
        /// 停止位
        /// </summary>
        int StopB;

        /// <summary>
        /// 校验位
        /// </summary>
        string DPaity;

        /// <summary>
        /// 存储串口匹配字符数组
        /// </summary>
        string[] strRecives;

        /// <summary>
        /// 存储串口转发字符串数组
        /// </summary>
        string[] strSends;

        #endregion

        #region 串口相关的声明和定义

        /// <summary>
        /// 定义串口
        /// </summary>
        SerialPort serialPort = new SerialPort();

        /// <summary>
        /// 判断串口是否打开
        /// </summary>
        bool spIsOpen;

        /// <summary>
        /// 判断是否找到配置文件的串口号
        /// </summary>
        bool IsComNum;

        /// <summary>
        /// 定义socket
        /// </summary>
        static Socket client;

        /// <summary>
        /// 定义UDP接收消息的线程
        /// </summary>
        Thread tUdpRecive;

        /// <summary>
        /// 读取串口的线程
        /// </summary>
        Thread tComRecive;

        #endregion

        /// <summary>
        /// 加载窗体是执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerialForm_Load(object sender, EventArgs e)
        {

            //读取set.txt设置文件
            StreamReader readerSet = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "set.txt");
            //读取list.txt转发文件
            StreamReader readerList = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "list.txt");
            //临时存储设置文件的数据
            string tempSet = readerSet.ReadToEnd();
            //临时存储转发文件的数据
            string tempList = readerList.ReadToEnd();

            readerSet.Close();
            readerList.Close();

            //打印文件信息
            //Console.WriteLine(tempSet);
            //Console.WriteLine();
            //Console.WriteLine(tempList);

            //分配读取的设置数据
            string[] tempSetData = tempSet.Split('\r');

            for (int i = 0; i < tempSetData.Length; i++)
            {
                //临时存储变量
                string[] tempSetStr = tempSetData[i].Split('=');
                tempSetData[i] = tempSetStr[1];
                tempSetStr = null;

                Console.WriteLine(tempSetData[i]);
            }

            //分配读取的转发文件数据
            string[] tempListData = tempList.Split('\r');
            strRecives = new string[tempListData.Length];  //临时存储匹配数据
            strSends = new string[tempListData.Length];     //临时存储转发数据

            for (int j = 0; j < tempListData.Length; j++)
            {
                //临时存储变量
                string[] tempListStr = tempListData[j].Split(';');
                strRecives[j] = tempListStr[0];//匹配字符数组
                strSends[j] = tempListStr[1];   //转发字符串数组
                tempListStr = null;

                string[] tmpStr = new string[2];
                tmpStr = strRecives[j].Split('=');
                strRecives[j] = tmpStr[1];

                tmpStr = new string[2];
                tmpStr = strSends[j].Split('=');
                strSends[j] = tmpStr[1];
                tmpStr = null;
                Console.WriteLine(strRecives[j] + " --> " + strSends[j]);
            }

            //分配转存各个数据
            //tempSetData
            LocalIp = tempSetData[0];                       //本机IP
            LocalPort = Convert.ToInt32(tempSetData[1]);    //本机端口
            RemoteIp = tempSetData[2];                      //目标IP
            RemotePort = Convert.ToInt32(tempSetData[3]);   //目标端口
            Com = tempSetData[4];                           //串口号
            BandR = Convert.ToInt32(tempSetData[5]);        //波特率
            DPaity = tempSetData[6];                        //校验位
            DataB = Convert.ToInt32(tempSetData[7]);        //数据位
            StopB = Convert.ToInt32(tempSetData[8]);        //停止位


            txt_LocalIP.Text = LocalIp;
            txt_LocalPort.Text = "" + LocalPort;
            txt_RemoteIP.Text = RemoteIp;
            txt_RemotePort.Text = "" + RemotePort;
            txt_PortNum.Text = Com;
            txt_BandR.Text = "" + BandR;
            txt_DPaity.Text = DPaity;
            txt_DataB.Text = "" + DataB;
            txt_StopB.Text = "" + StopB;

            lb_Recive.Items.AddRange(strRecives);
            lb_Send.Items.AddRange(strSends);




            //初始化串口配置参数
            SerialLoadData(txt_PortNum.Text, txt_BandR.Text, txt_DPaity.Text, txt_DataB.Text, txt_StopB.Text);
            serialPort.DataReceived += new SerialDataReceivedEventHandler(Com_DataReceived);//绑定事件

            tComRecive = new Thread(OpenSerial);
            tComRecive.IsBackground = true;
            tComRecive.Start();

            //初始化socket通信
            client = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            client.Bind(new IPEndPoint(IPAddress.Parse(txt_LocalIP.Text.Trim()), Convert.ToInt32(txt_LocalPort.Text.Trim())));
            tUdpRecive = new Thread(ReciveMsg);
            tUdpRecive.IsBackground = true;
            tUdpRecive.Start();

            open_SerialPort.Enabled = false;
            close_SerialPort.Enabled = true;
        }

        /// <summary>
        /// 串口载入参数
        /// </summary>
        /// <param name="PortNum">串口号</param>
        /// <param name="txt_BandR">波特率</param>
        /// <param name="txt_DPaity">校验位</param>
        /// <param name="txt_DataB">数据位</param>
        /// <param name="txt_StopB">停止位</param>
        private void SerialLoadData(string PortNum, string txt_BandR, string txt_DPaity, string txt_DataB, string txt_StopB)
        {
            try
            {
                //IsComNum = new bool();//判断是否找到配置文件的串口号

                string[] serialName = SerialPort.GetPortNames();
                for (int i = 0; i < serialName.Length; i++)
                {
                    if (serialName[i] == PortNum)
                    {
                        serialPort.PortName = serialName[i];
                        IsComNum = true;
                        break;
                    }
                    else
                    {
                        IsComNum = false;
                    }
                }

                if (IsComNum == false)
                {
                    MessageBox.Show("配置参数不正确,没找到配置的串口号:\n PortNum=" + PortNum, "Error：串口号参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }

                //波特率
                switch (txt_BandR)
                {
                    case "4800": serialPort.BaudRate = 4800; break;
                    case "9600": serialPort.BaudRate = 9600; break;
                    case "19200": serialPort.BaudRate = 19200; break;
                    case "115200": serialPort.BaudRate = 115200; break;
                    default:
                        {
                            MessageBox.Show("可设置波特率：\n BandR=4800\n BandR=9600\n BandR=19200\n BandR=115200", "Error：波特率参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                        break;
                }
                //校验位
                switch (txt_DPaity)
                {
                    case "NONE": serialPort.Parity = Parity.None; break;
                    case "ODD": serialPort.Parity = Parity.Odd; break;
                    case "EVEN": serialPort.Parity = Parity.Even; break;
                    default:
                        {
                            MessageBox.Show("可设置校验位：\n DPaity=NONE\n DPaity=ODD\n DPaity=EVEN\n", "Error：校验位参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                        break;
                }

                //数据位
                switch (txt_DataB)
                {
                    case "5": serialPort.DataBits = 5; break;
                    case "6": serialPort.DataBits = 6; break;
                    case "7": serialPort.DataBits = 7; break;
                    case "8": serialPort.DataBits = 8; break;
                    default:
                        {
                            MessageBox.Show("可设置数据位：\n DataB=5\n DataB=6\n DataB=7\n DataB=8", "Error：数据位参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                        break;
                }

                //停止位
                switch (txt_StopB)
                {
                    case "1": serialPort.StopBits = StopBits.One; break;
                    case "1.5": serialPort.StopBits = StopBits.OnePointFive; break;
                    case "2": serialPort.StopBits = StopBits.Two; break;
                    default:
                        {
                            MessageBox.Show("可设置停止位：\n StopB=1\n StopB=1.5\n StopB=2", "Error：停止位参数错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                        }
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error：" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Exit();
            }
        }

        /// <summary>
        /// 接收发送给本机ip对应端口的数据报
        /// </summary>
        private void ReciveMsg()
        {
            while (serialPort.IsOpen)
            {
                try
                {
                    //用来保持发送方的IP和端口号
                    EndPoint point = new IPEndPoint(IPAddress.Any, 0);
                    byte[] buffer = new byte[1024];
                    //接收数据报
                    int length = client.ReceiveFrom(buffer, ref point);
                    string strBuf = Encoding.Default.GetString(buffer, 0, length);

                    Console.WriteLine("【" + point.ToString() + "】" + strBuf);

                    byte[] strBufs = Encoding.Default.GetBytes(strBuf);
                    AddData(strBufs, false);//转发至UDP
                }
                catch (Exception)
                {
                    break;
                }


            }
        }

        /// <summary>
        /// 向特定ip的主机的端口发送数据报
        /// </summary>
        /// <param name="data">字节数组</param>
        private void SendMsg(byte[] data)
        {
            EndPoint point = new IPEndPoint(IPAddress.Parse(txt_RemoteIP.Text.Trim()), Convert.ToInt32(txt_RemotePort.Text.Trim()));
            try
            {
                client.SendTo(data, point);
            }
            catch (Exception ex)
            {
                MessageBox.Show("目标IP错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }


        /// <summary>
        /// 串口接收数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Com_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                byte[] ReDatas = new byte[serialPort.BytesToRead];
                serialPort.Read(ReDatas, 0, ReDatas.Length);//读取数据
                AddData(ReDatas, true);//添加数据
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <param name="Bool">发送到（UDP端口(true) 或 串口(false)）</param>
        private void AddData(byte[] data, bool Bool)
        {

            string sR = null;
            sR = Encoding.UTF8.GetString(data);
            byte[] sW;
            if (Bool)
            {
                //读取到串口数据
                for (int i = 0; i < strRecives.Length; i++)
                {
                    if (sR == strRecives[i])
                    {
                        Console.WriteLine("读取到串口数据: " + strRecives[i] + " 转发数据-->UDP端口: " + strSends[i]);
                        sW = null;
                        sW = Encoding.UTF8.GetBytes(strSends[i]);
                        SendData(sW, true);//发送数据 --> UDP端口
                    }
                }
            }
            else
            {
                //读取到UDP端口数据
                for (int i = 0; i < strRecives.Length; i++)
                {
                    if (sR == strRecives[i])
                    {
                        Console.WriteLine("读取到UDP端口数据: " + strRecives[i] + " 转发数据-->串口: " + strSends[i]);
                        sW = null;
                        sW = Encoding.UTF8.GetBytes(strSends[i]);
                        SendData(sW, false);//发送数据 --> 串口
                    }
                }
            }
        }


        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="data">字节数组</param>
        /// <param name="Bool">发送到（UDP端口(true) 或 串口(false)）</param>
        private void SendData(byte[] data, bool Bool)
        {
            if (serialPort.IsOpen)
            {
                if (Bool)
                {
                    //发送到UDP端口
                    Console.WriteLine("发送到UDP端口: " + new UTF8Encoding().GetString(data));
                    SendMsg(data);//使用UDP模式发送

                }
                else
                {
                    //发送到串口
                    Console.WriteLine("发送到串口: " + new UTF8Encoding().GetString(data));
                    if (serialPort.IsOpen)
                    {
                        try
                        {
                            serialPort.Write(new UTF8Encoding().GetString(data));//(data, 0, data.Length);//向串口写入数据
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("串口未打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        private void OpenSerial()
        {

            if (!serialPort.IsOpen)
            {
                try
                {
                    serialPort.Open();//打开串口
                }
                catch (Exception)
                {
                    MessageBox.Show("串口打开失败！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }
        }
        /// <summary>
        /// 关闭串口
        /// </summary>
        private void CloseSerial()
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    serialPort.Close();//关闭串口
                }
                catch (Exception ex)
                {
                    MessageBox.Show("串口关闭失败！", "Error：" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void open_SerialPort_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen)
            {
                OpenSerial();
                open_SerialPort.Enabled = false;
                close_SerialPort.Enabled = true;

                tUdpRecive = new Thread(ReciveMsg);
                tUdpRecive.IsBackground = true;
                tUdpRecive.Start();
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void close_SerialPort_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                CloseSerial();
                open_SerialPort.Enabled = true;
                close_SerialPort.Enabled = false;
                tUdpRecive.Abort();
            }
        }

        /// <summary>
        /// 退出软件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            tUdpRecive.Abort();    //读取UDP线程
            client.Close();     //socket连接
            tComRecive.Abort(); //串口线程
            CloseSerial();      //关闭串口方法
            Application.Exit();
        }
        /// <summary>
        /// 窗口关闭按钮X
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Exit_Click(object sender, FormClosingEventArgs e)
        {

            if (IsComNum == true)
            {
                tComRecive.Abort(); //串口线程
                tUdpRecive.Abort();    //读取UDP线程
                client.Close();     //socket连接
            }

            CloseSerial();      //关闭串口方法
        }
    }
}
