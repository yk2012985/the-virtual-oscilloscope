using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;   //stopwatch
using Ivi.Visa;
using NationalInstruments.Visa;
namespace test_bed_oscilloscope
{
    public partial class Form1 : Form
    {
        //VISA相关
        private MessageBasedSession mbSession;
        private string lastResourceString = null;   //资源名称变量

        //计时相关
        System.Threading.Timer timer_get_data;  //设定一个timer变量用来承接Program.cs中的timer

        //System.Threading.Timer data_get_timer = new System.Threading.Timer();

        //BackgroundWorker相关
        

        //设备相关
        bool ch1 = false;
        bool ch2 = false;
        bool math = false;    //设置三个全局变量来表示CH1，CH2，MATH的状态初始化时为false


        //绘图相关
        public int[] wave1_data = new int[2500];       //CH1波形数据点数组
        public int[] wave2_data = new int[2500];      //CH2波形数据点数组
        public int[] wave_math_data = new int[2500]; //MATH波形数据点数组

        public int[] draw1_data = new int[2500];       //CH1波形数据点数组
        public int[] draw2_data = new int[2500];      //CH2波形数据点数组
        public int[] draw_math_data = new int[2500]; //MATH波形数据点数组

        public Color grid_color = Color.FromArgb(100, 255, 255, 255);
        public Pen grid_pen_1 = new Pen(Color.FromArgb(100, 255, 255, 255), 1);   //设置普通网格画笔的类型
        public Pen grid_pen_2 = new Pen(Color.FromArgb(255, 255, 255, 255), 1);    //设置中心十字画笔类型

        public Pen wave_pen_1 = new Pen(Color.Orange, 2);    //CH1的波形画笔
        public Pen wave_pen_2 = new Pen(Color.CadetBlue, 2);    //CH2的波形画笔
        public Pen wave_pen_3 = new Pen(Color.Red, 2);    //MATH的波形画笔

        System.Threading.Timer timer_wave_update;
        int timer_period;   //用于保存计时器当前的周期数便于恢复

        

        //测量相关（这里将测量序号和测量类型做成全局变量，方便服务请求处理函数访问）
        int meas;       //1-6
        int meas_type;   //测量类型

        public Form1()
        {
            InitializeComponent();
        }

        private void open_session_Click(object sender, EventArgs e)
        {
            using (Select_Resource sr = new Select_Resource())     //建立资源选择窗体实例
            {
                if (lastResourceString != null)
                {
                    sr.ResourceName = lastResourceString;       //已经选择过资源则默认为当前已选择的资源
                }
                DialogResult result = sr.ShowDialog(this);      //弹出资源选择窗体
                if (result == DialogResult.OK)
                {
                    lastResourceString = sr.ResourceName;    //资源名变量赋值为选择的资源
                    Cursor.Current = Cursors.WaitCursor;    //光标变等待状
                    try
                    {       //尝试建立Session
                        using (var rmSession = new ResourceManager())
                        {
                            mbSession = (MessageBasedSession)rmSession.Open(sr.ResourceName);
                            mbSession.SynchronizeCallbacks = true;

                            //Clear_measurements(mbSession);  //初始化时先将所有测量通道都关闭

                            mbSession.RawIO.Write("select:ch1 off");    //初始化时将CH1设为没有打开
                            mbSession.RawIO.Write("select:ch2 off");    //初始化时将CH2设为没有打开
                            mbSession.RawIO.Write("select:math off");    //初始化时将MATH设为没有打开

                            ch1_operational(false);     //CH1所有操作也不可用
                            ch2_operational(false);
                            math_operational(false);

                            mbSession.ServiceRequest += OutputReadyRequest;   //绑定服务请求处理程序


                            //mbSession.RawIO.Write("*SRE 16");   //*SRE 16命令会将寄存器SRER的第4位MAV置1，
                            //让仪器做好生成事件的准备

                            //SetupControlState(true);    //将按钮状态设为可用
                        }
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;   //将光标还原为普通状态
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //承接timer的函数
        public void timer1_get(ref System.Threading.Timer t1)
        {
            timer_get_data = t1;
            //timer_wave_update = t2;
        }


        //绘图部分
        //新的波形获取函数
        public void get_wave_data(object state)
        {
            //sw.Restart();  //启动计时器
                           //Draw_wave();
            if (ch1 == true)
            {
                get_ch1_wave_data("");
            }
            if (ch2 == true)
            {

                get_ch2_wave_data();
            }
            //if (math == true)
            //{

            //    get_math_wave_data();
            //}
            //sw.Stop();
            //MessageBox.Show(sw.Elapsed.TotalSeconds.ToString());
            //listBox1.Items.Add(sw.Elapsed.TotalSeconds.ToString());

            //用BackgroundWorker来绘图
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                while (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
                backgroundWorker1.RunWorkerAsync();
            }
        }

        //模式调节功能
        private void timer_shift()
        {
            if (ch1 && ch2 == true)
            {
                model2();   //转换为模式2
            }
            else
            {
                if (ch1 || ch2 == true)
                {
                    model1();
                }
                else
                {
                    model0();
                }
            }
        }

        private void model2()
        {
            timer_period = 2930;    //将当前的计时周期保存到全局变量中
            timer_get_data.Change(0, 2930);
        }

        private void model1()
        {
            timer_period = 1320;
            timer_get_data.Change(0, 1320);
        }

        private void model0()   //将timer_get_data设置为关闭
        {
            timer_get_data.Change(Timeout.Infinite, 2000);
        }

        

        
        private void draw_grid(Graphics e)
        {
            Graphics g = e;
            g.Clear(Color.Black);

            //建立网格坐标
            PointF[] points_X =
                {
                    new PointF(90, 480),
                    new PointF(180, 480),
                    new PointF(270, 480),
                    new PointF(360, 480),
                    new PointF(450, 480),
                    new PointF(540, 480),
                    new PointF(630, 480),
                    new PointF(720, 480),
                    new PointF(810, 480),
                };
            for (int i = 0; i < points_X.Length; i++)
            {
                if (i == 4)
                {
                    g.DrawLine(grid_pen_2, points_X[i], new PointF(points_X[i].X, 0));
                }
                g.DrawLine(grid_pen_1, points_X[i], new PointF(points_X[i].X, 0));
            }

            PointF[] points_Y =
                {
                    new PointF(900, 60),
                    new PointF(900, 120),
                    new PointF(900, 180),
                    new PointF(900, 240),
                    new PointF(900, 300),
                    new PointF(900, 360),
                    new PointF(900, 420),
                };
            for (int i = 0; i < points_Y.Length; i++)
            {
                if (i == 3)
                {
                    g.DrawLine(grid_pen_2, points_Y[i], new PointF(0, points_Y[i].Y));
                }
                g.DrawLine(grid_pen_1, points_Y[i], new PointF(0, points_Y[i].Y));
            }
        }
        private void screen_Paint(object sender, PaintEventArgs e)
        {
            draw_grid(e.Graphics);
        }

        

        public void get_ch1_wave_data(object state)    //这里加上object类型的参数state，为了符合计时器回调方法的签名
        {
            try
            {

                //SetupWaitingControlState(true); //进入等待模式
                //mbSession.RawIO.Write("*wai");
                mbSession.RawIO.Write("data:source ch1");   //将波形数据源设置成CH1
                string textToWrite = "curve?";    //开始读取波形数据
                mbSession.RawIO.Write(textToWrite); //这里用简单写入而不用异步写入
                try
                {
                    //SetupWaitingControlState(true);
                    //asyncHandle1 = mbSession.RawIO.BeginRead(    //异步读取
                    //    20000,
                    //    new VisaAsyncCallback(OnReadComplete),
                    //    null);

                    string responseString = mbSession.RawIO.ReadString(20000);  //此处改为同步读取
                    
                    string[] sArray = responseString.Split(',');
                    for (int i = 0; i < sArray.Length; i++)
                    {
                        int m = int.Parse(sArray[i]);
                        wave1_data[i] = m;
                    }
                    
                }
                catch (Exception exp)
                {
                    //MessageBox.Show(exp.Message);
                }
                //asyncHandle = mbSession.RawIO.BeginWrite(
                //    textToWrite,
                //    new VisaAsyncCallback(OnWriteComplete),
                //    (object)textToWrite.Length);
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
            }
        }

        private void get_ch2_wave_data()
        {
            try
            {

                //SetupWaitingControlState(true); //进入等待模式
                //mbSession.RawIO.Write("*wai");
                mbSession.RawIO.Write("data:source ch2");   //将波形数据源设置成CH2
                string textToWrite = "curve?";    //开始读取波形数据
                mbSession.RawIO.Write(textToWrite); //这里用简单写入而不用异步写入
                try
                {
                    //SetupWaitingControlState(true);

                    string responseString = mbSession.RawIO.ReadString(20000);  //此处改为同步读取
                    
                    string[] sArray = responseString.Split(',');
                    for (int i = 0; i < sArray.Length; i++)
                    {
                        int m = int.Parse(sArray[i]);
                        wave2_data[i] = m;
                    }
                    //draw2_data = wave2_data;
                    
                    //asyncHandle2 = mbSession.RawIO.BeginRead(    //异步读取
                    //    20000,
                    //    new VisaAsyncCallback(OnReadComplete2), //绑定的处理函数是
                    //    null);

                }
                catch (Exception exp)
                {
                   // MessageBox.Show(exp.Message);
                }
                //asyncHandle = mbSession.RawIO.BeginWrite(
                //    textToWrite, 
                //    new VisaAsyncCallback(OnWriteComplete),
                //    (object)textToWrite.Length);
            }
            catch (Exception exp)
            {
                //MessageBox.Show(exp.Message);
            }
        }

        private void get_math_wave_data()
        {
            try
            {

                //SetupWaitingControlState(true); //进入等待模式
                mbSession.RawIO.Write("data:source math");   //将波形数据源设置成math
                string textToWrite = "curve?";    //开始读取波形数据
                mbSession.RawIO.Write(textToWrite); //这里用简单写入而不用异步写入
                try
                {
                    //SetupWaitingControlState(true);

                    string responseString = mbSession.RawIO.ReadString(20000);  //此处改为同步读取
                    
                    string[] sArray = responseString.Split(',');
                    for (int i = 0; i < sArray.Length; i++)
                    {
                        int m = int.Parse(sArray[i]);
                        wave_math_data[i] = m;
                    }
                    
                    //asyncHandle3 = mbSession.RawIO.BeginRead(    //异步读取
                    //    20000,
                    //    new VisaAsyncCallback(OnReadComplete_math), //绑定处理程序是math波形数据
                    //    null);

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                //asyncHandle = mbSession.RawIO.BeginWrite(
                //    textToWrite,
                //    new VisaAsyncCallback(OnWriteComplete),
                //    (object)textToWrite.Length);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Graphics g = screen.CreateGraphics();
            draw_grid(g);
            float interval = (float)900 / (float)(2500);  //求得x轴间隙
            float pos_x = 0;
            //timer1.Enabled = true;
            while (!backgroundWorker1.CancellationPending)
            {
                //sw.Restart(); //开始统计时间
                for (int j = 0; j < 2500; j++)
                {
                    if (ch1)    //如果打开CH1通道就显示CH1的波形
                    {
                        //g.DrawRectangle(wave_pen_1, pos_x, 240 - wave1_data[j] * (float)(12 / 4.975), (float)1.5, (float)1.5);
                        g.DrawLine(wave_pen_1, pos_x, 240 - wave1_data[j] * (float)(12 / 4.975), pos_x + interval, 240 - wave1_data[j + 1] * (float)(12 / 4.975));
                    }
                    if (ch2)    //如果打开CH2通道就显示CH1的波形
                    {
                        //g.DrawRectangle(wave_pen_2, pos_x, 240 - wave2_data[j] * (float)(12 / 4.975), (float)1.5, (float)1.5);
                        g.DrawLine(wave_pen_2, pos_x, 240 - wave2_data[j] * (float)(12 / 4.975), pos_x + interval, 240 - wave2_data[j + 1] * (float)(12 / 4.975));
                    }
                    if (math)   //如果打开MATH通道就显示CH1的波形
                    {
                        if (math_source.SelectedIndex == 0)
                        {
                            g.DrawLine(wave_pen_3, pos_x, 240 - (wave1_data[j]+wave2_data[j]) * (float)(12 / 4.975),pos_x+interval, 240 - (wave1_data[j+1] + wave2_data[j+1]) * (float)(12 / 4.975));
                        }
                        else if (math_source.SelectedIndex == 1)
                        {
                            g.DrawLine(wave_pen_3, pos_x, 240 - (wave1_data[j] - wave2_data[j]) * (float)(12 / 4.975), pos_x + interval, 240 - (wave1_data[j + 1] - wave2_data[j + 1]) * (float)(12 / 4.975));
                        }
                        else if (math_source.SelectedIndex == 2)
                        {
                            g.DrawLine(wave_pen_3, pos_x, 240 - (wave2_data[j] - wave1_data[j]) * (float)(12 / 4.975), pos_x + interval, 240 - (wave2_data[j + 1] - wave1_data[j + 1]) * (float)(12 / 4.975));
                        }
                        else if (math_source.SelectedIndex == 3)
                        {
                            g.DrawLine(wave_pen_3, pos_x, 240 - (wave1_data[j] * wave2_data[j]) * (float)(12 / 4.975), pos_x + interval, 240 - (wave1_data[j + 1] * wave2_data[j + 1]) * (float)(12 / 4.975));
                        }
                    }
                    pos_x = pos_x + interval;
                }
                //sw.Stop();
                //listBox1.Items.Add(sw.Elapsed.TotalMilliseconds.ToString());
                //listBox1.Items.Add(sw.Elapsed.TotalSeconds.ToString());
            }
        }


        //测量部分
        private void do_measurement(int meas_number, int measurement_type)
        {
            mbSession.RawIO.Write("measurement:meas"+meas_number.ToString()+":source ch1"); //写入通道选择指令
            mbSession.RawIO.Write("*wai");
            
            switch (measurement_type)
            {
                case 0: //测量周期
                    mbSession.RawIO.Write("*SRE 16");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type period");
                    //MessageBox.Show("measurement:meas" + meas_number.ToString() + ":type period");    //测试用
                    //mbSession.RawIO.Write("*wai");  //同步化仪器

                    //测量和获取测量数据分开到两个不同的函数
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?"); //写入查询命令,用来触发第一次服务请求

                    meas = meas_number;
                    meas_type = 0;   //将全局变量更改为测周期
                    break;

                case 1: //测量频率
                    mbSession.RawIO.Write("*SRE 16");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type frequency");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 1;   //将全局变量更改为测频率
                    break;

                case 2: //测量峰-峰值
                    mbSession.RawIO.Write("*SRE 16");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type pk2pk");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 2;   //将全局变量更改为测峰-峰值
                    break;

                case 3: //测量最小值
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type minimum");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 3;   //将全局变量更改为测最小值
                    break;

                case 4: //测量最大值
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type maximum");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 4;   //将全局变量更改为测最大值
                    break;

                case 5: //测量平均值
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type mean");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 5;   //将全局变量更改为测平均值
                    break;

                case 6: //测量上升时间
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type rise");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 6;   //将全局变量更改为测上升时间
                    break;

                case 7: //测量下降时间
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type fall");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 7;   //将全局变量更改为测下降时间
                    break;

                case 8: //正占空比
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type pduty");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 8;   //将全局变量更改为测正占空比
                    break;

                case 9: //负占空比
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":type nduty");
                    mbSession.RawIO.Write("*wai");
                    mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?");

                    meas = meas_number;
                    meas_type = 9;   //将全局变量更改为测负占空比
                    break;

            }
        }

        private void get_measurement_result(int meas_number)    //用于重复查询测量结果
        {
            mbSession.RawIO.Write("measurement:meas"+meas_number.ToString()+":value?");
        }

        private void OutputReadyRequest(object sender, VisaEventArgs e) //请求服务处理程序
        {
            var mbs = (MessageBasedSession)sender;
            StatusByteFlags sb = mbs.ReadStatusByte();  //读取标志位
            if (sb.HasFlag(StatusByteFlags.MessageAvailable))
            {
                string textRead = mbs.RawIO.ReadString();
                if(textRead == "9.9E37\n")
                {
                    get_measurement_result(meas);
                }
                else
                {
                    //MessageBox.Show(textRead);
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    format_correct(meas, meas_type, textRead);
                    
                }
            }
        }

        private void format_correct(int meas, int meas_type, string data)   //数据格式修正函数（包含数据单位处理）
        {
            string[] data_array = data.Split('E');
            float number;
            switch (meas_type)
            {
                case 0: //时间单位转换
                case 6:
                case 7:
                    if (int.Parse(data_array[1]) < -3)
                    {
                        int exponent = int.Parse(data_array[1]) + 3;

                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5))) * 1000 * (float)Math.Pow(10, exponent);
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length))) * 1000 * (float)Math.Pow(10, exponent);
                        }

                        string final_result = number.ToString() + "us";
                        data_display(meas, meas_type, final_result);
                        break;
                    }
                    else if (int.Parse(data_array[1]) == -3)
                    {

                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5)));
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length)));
                        }

                        string final_result = number.ToString() + "ms";
                        data_display(meas, meas_type, final_result);
                        break;
                    }
                    else
                    {
                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5)));
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length)));
                        }

                        string final_result = number.ToString() + "s";
                        data_display(meas, meas_type, final_result);
                        break;

                    }
                case 1: //频率单位转换
                    if (int.Parse(data_array[1]) >= 6)  //指数在10的6次方及以上用MHz
                    {
                        int exponent = int.Parse(data_array[1]) - 6;
                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5))) * (float)Math.Pow(10, exponent);
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length))) * (float)Math.Pow(10, exponent);
                        }
                        string final_result = number.ToString() + "MHz";
                        data_display(meas, meas_type, final_result);
                        break;
                    }
                    else if (int.Parse(data_array[1]) < 6 && int.Parse(data_array[1]) >= 3)    //指数在10的6次方与3次方之间用KHz
                    {
                        int exponent = int.Parse(data_array[1]) - 3;
                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5))) * (float)Math.Pow(10, exponent);
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length))) * (float)Math.Pow(10, exponent);
                        }
                        string final_result = number.ToString() + "KHz";
                        data_display(meas, meas_type, final_result);
                        break;
                    }
                    else
                    {

                        int exponent = int.Parse(data_array[1]);
                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5))) * (float)Math.Pow(10, exponent);
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length))) * (float)Math.Pow(10, exponent);
                        }
                        string final_result = number.ToString() + "Hz";
                        data_display(meas, meas_type, final_result);
                        break;
                    }
                case 2:
                case 3:
                case 4:
                case 5://幅值电压单位
                    if (int.Parse(data_array[1]) <= -2)  //指数小于等于-2用mV
                    {

                        int exponent = int.Parse(data_array[1]) + 3;
                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5))) * (float)Math.Pow(10, exponent);
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length))) * (float)Math.Pow(10, exponent);
                        }
                        string final_result = number.ToString() + "mV";
                        data_display(meas, meas_type, final_result);
                        break;
                    }
                    else
                    {

                        int exponent = int.Parse(data_array[1]);
                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5))) * (float)Math.Pow(10, exponent);
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length))) * (float)Math.Pow(10, exponent);
                        }
                        string final_result = number.ToString() + "V";
                        data_display(meas, meas_type, final_result);
                        break;
                    }
                case 8:
                case 9:
                    if (int.Parse(data_array[1]) == 1)
                    {
                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5))) * 10;
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length))) * 10;
                        }
                        string final_result = number.ToString() + "%";
                        data_display(meas, meas_type, final_result);
                        break;
                    }
                    else
                    {
                        if (data_array[0].Length > 5)
                        {
                            number = (float.Parse(data_array[0].Substring(0, 5)));
                        }
                        else
                        {
                            number = (float.Parse(data_array[0].Substring(0, data_array[0].Length)));
                        }
                        string final_result = number.ToString() + "%";
                        data_display(meas, meas_type, final_result);
                        break;
                    }


            }
        }

        private void data_display(int meas, int meas_type, string data)  //数据显示函数，在此函数中进行对数据格式的修正并加入对应的单位
        {
            switch (meas)
            {
                case 1:
                    //switch (meas_type)
                    //{
                    //    case 0:

                    //}
                    measure_value_1.Text = data;
                    break;
                case 2:
                    measure_value_2.Text = data;
                    break;
                case 3:
                    measure_value_3.Text = data;
                    break;
                case 4:
                    measure_value_4.Text = data;
                    break;
                case 5:
                    measure_value_5.Text = data;
                    break;
                case 6:
                    measure_value_6.Text = data;
                    break;
            }
        }

        private void chanel_select_1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (chanel_select_1.SelectedIndex != -1 && measure_select_1.SelectedIndex != -1)
            {
                try
                {
                    MessageBox.Show(timer_period.ToString());
                    timer_get_data.Change(Timeout.Infinite, 200);   //锁死timer_get_data

                    Thread.Sleep(2000);   //无效
                    do_measurement(1, measure_select_1.SelectedIndex);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void chanel_select_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chanel_select_2.SelectedIndex != -1 && measure_select_2.SelectedIndex != -1)
                {
                    MessageBox.Show(timer_period.ToString());
                    timer_get_data.Change(Timeout.Infinite, 200);   //锁死timer_get_data

                    Thread.Sleep(2000);   //无效
                    do_measurement(2, measure_select_2.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void chanel_select_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chanel_select_3.SelectedIndex != -1 && measure_select_3.SelectedIndex != -1)
                {
                    MessageBox.Show(timer_period.ToString());
                    timer_get_data.Change(Timeout.Infinite, 200);   //锁死timer_get_data

                    Thread.Sleep(2000);   //无效
                    do_measurement(3, measure_select_3.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chanel_select_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chanel_select_4.SelectedIndex != -1 && measure_select_4.SelectedIndex != -1)
                {
                    MessageBox.Show(timer_period.ToString());
                    timer_get_data.Change(Timeout.Infinite, 200);   //锁死timer_get_data

                    Thread.Sleep(2000);   //无效
                    do_measurement(4, measure_select_4.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chanel_select_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chanel_select_5.SelectedIndex != -1 && measure_select_5.SelectedIndex != -1)
                {
                    MessageBox.Show(timer_period.ToString());
                    timer_get_data.Change(Timeout.Infinite, 200);   //锁死timer_get_data

                    Thread.Sleep(2000);   //无效
                    do_measurement(5, measure_select_5.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void chanel_select_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (chanel_select_6.SelectedIndex != -1 && measure_select_6.SelectedIndex != -1)
                {
                    MessageBox.Show(timer_period.ToString());
                    timer_get_data.Change(Timeout.Infinite, 200);   //锁死timer_get_data

                    Thread.Sleep(2000);   //无效
                    do_measurement(6, measure_select_6.SelectedIndex);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //操作部分
        //通道开关
        private void ch1_toogle_CheckedChanged(object sender, EventArgs e)
        {
            if (ch1_toogle.Checked == true)
            {
                try
                {
                    mbSession.RawIO.Write("select:ch1 on");                  
                    ch1 = true;
                    ch1_operational(true);
                    timer_shift();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                try
                {
                    mbSession.RawIO.Write("select:ch1 off");                  
                    ch1 = false;
                    ch1_operational(false);
                    timer_shift();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void ch2_toogle_CheckedChanged(object sender, EventArgs e)
        {
            if (ch2_toogle.Checked == true)
            {
                try
                {
                    mbSession.RawIO.Write("select:ch2 on");
                    
                    ch2 = true;
                    ch2_operational(true);
                    timer_shift();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                try
                {
                    mbSession.RawIO.Write("select:ch2 off");
                    
                    ch2 = false;
                    ch2_operational(false);
                    timer_shift();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void math_toogle_CheckedChanged(object sender, EventArgs e)
        {
            if (math_toogle.Checked == true)
            {
                try
                {
                    //mbSession.RawIO.Write("select:math on");  //系统自行计算math信号不用从示波器读取
                    
                    math = true;
                    math_operational(true);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                try
                {
                    //mbSession.RawIO.Write("select:math off");
                    
                    math = false;
                    math_operational(false);
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)  //测试用
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            MessageBox.Show("已经锁死");
        }

        //ch1通道操作

        private void ch1_operational(bool sign) //CH1通道可操作
        {
            coupling1_select.Enabled = sign;
            amp1_type.Enabled = sign;
            vertical1_scale.Enabled = sign;
            vertical1_position.Enabled = sign;
            probe1_select.Enabled = false;
        }

        private void coupling1_select_SelectedIndexChanged(object sender, EventArgs e)  //ch1耦合方式
        {           
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (coupling1_select.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("ch1:coupling dc");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 1:
                    mbSession.RawIO.Write("ch1:coupling ac");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 2:
                    mbSession.RawIO.Write("ch1:coupling gnd");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
            }
            
        }

        private void vertical1_scale_SelectedIndexChanged(object sender, EventArgs e)   //ch1垂直标度
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (vertical1_scale.SelectedIndex)
            {
                
                case 0:
                    mbSession.RawIO.Write("ch1:scale 5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 1:
                    mbSession.RawIO.Write("ch1:scale 2E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 2:
                    mbSession.RawIO.Write("ch1:scale 1E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 3:
                    mbSession.RawIO.Write("ch1:scale 5E-1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 4:
                    mbSession.RawIO.Write("ch1:scale 2E-1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 5:
                    mbSession.RawIO.Write("ch1:scale 1E-1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
            }
        }

        private void vertical1_position_SelectedIndexChanged(object sender, EventArgs e)    //ch1垂直位置
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (vertical1_position.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("ch1:position 5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 1:
                    mbSession.RawIO.Write("ch1:position 4.5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 2:
                    mbSession.RawIO.Write("ch1:position 4");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 3:
                    mbSession.RawIO.Write("ch1:position 3.5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 4:
                    mbSession.RawIO.Write("ch1:position 3");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 5:
                    mbSession.RawIO.Write("ch1:position 2.5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 6:
                    mbSession.RawIO.Write("ch1:position 2E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 7:
                    mbSession.RawIO.Write("ch1:position 1.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 8:
                    mbSession.RawIO.Write("ch1:position 1E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 9:
                    mbSession.RawIO.Write("ch1:position 0.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 10:
                    mbSession.RawIO.Write("ch1:position 0E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 11:
                    mbSession.RawIO.Write("ch1:position -0.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 12:
                    mbSession.RawIO.Write("ch1:position -1E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 13:
                    mbSession.RawIO.Write("ch1:position -1.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 14:
                    mbSession.RawIO.Write("ch1:position -2E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 15:
                    mbSession.RawIO.Write("ch1:position -2.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 16:
                    mbSession.RawIO.Write("ch1:position -3E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 17:
                    mbSession.RawIO.Write("ch1:position -3.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 18:
                    mbSession.RawIO.Write("ch1:position -4E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 19:
                    mbSession.RawIO.Write("ch1:position -4.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 20:
                    mbSession.RawIO.Write("ch1:position -5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
            }
        }

        private void amp1_type_SelectedIndexChanged(object sender, EventArgs e) //ch1幅值类型选择
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (amp1_type.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("ch1:yunit \"V\"");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    probe1_select.Items.Clear();    //修改衰减类型为电压
                    probe1_select.Items.Add("X1");
                    probe1_select.Items.Add("X10");
                    probe1_select.Items.Add("X20");
                    probe1_select.Items.Add("X50");
                    probe1_select.Items.Add("X100");
                    probe1_select.Items.Add("X500");
                    probe1_select.Items.Add("X1000");
                    probe1_select.Enabled = true;
                    break;
                case 1:
                    mbSession.RawIO.Write("ch1:yunit \"A\"");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    probe1_select.Items.Clear();    //修改衰减类型为电流
                    probe1_select.Items.Add("0.2");
                    probe1_select.Items.Add("1");
                    probe1_select.Items.Add("2");
                    probe1_select.Items.Add("5");
                    probe1_select.Items.Add("10");
                    probe1_select.Items.Add("50");
                    probe1_select.Items.Add("100");
                    probe1_select.Items.Add("1000");
                    probe1_select.Enabled = true;
                    break;
            }
            
        }

        private void probe1_select_SelectedIndexChanged(object sender, EventArgs e) //ch1衰减选择
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (probe1_select.SelectedItem)
            {
                case "X1":
                    mbSession.RawIO.Write("ch1:probe 1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X10":
                    mbSession.RawIO.Write("ch1:probe 10");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X20":
                    mbSession.RawIO.Write("ch1:probe 20");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X50":
                    mbSession.RawIO.Write("ch1:probe 50");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X100":
                    mbSession.RawIO.Write("ch1:probe 100");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X500":
                    mbSession.RawIO.Write("ch1:probe 500");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X1000":
                    mbSession.RawIO.Write("ch1:probe 1000");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;


                case "0.2":
                    mbSession.RawIO.Write("ch1:currentprobe 0.2");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "1":
                    mbSession.RawIO.Write("ch1:currentprobe 1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "2":
                    mbSession.RawIO.Write("ch1:currentprobe 2");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "5":
                    mbSession.RawIO.Write("ch1:currentprobe 5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "10":
                    mbSession.RawIO.Write("ch1:currentprobe 10");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "50":
                    mbSession.RawIO.Write("ch1:currentprobe 50");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "100":
                    mbSession.RawIO.Write("ch1:currentprobe 100");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "1000":
                    mbSession.RawIO.Write("ch1:currentprobe 1000");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
            }
        }


        //ch2通道操作
        private void ch2_operational(bool sign) //CH2通道可操作
        {
            coupling2_select.Enabled = sign;
            amp2_type.Enabled = sign;
            vertical2_scale.Enabled = sign;
            vertical2_position.Enabled = sign;
            probe2_select.Enabled = false;
        }

        private void coupling2_select_SelectedIndexChanged(object sender, EventArgs e)  //ch2耦合方式
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (coupling2_select.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("ch2:coupling dc");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 1:
                    mbSession.RawIO.Write("ch2:coupling ac");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 2:
                    mbSession.RawIO.Write("ch2:coupling gnd");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
            }
            
        }

        private void vertical2_scale_SelectedIndexChanged(object sender, EventArgs e)   //ch2垂直标度
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (vertical2_scale.SelectedIndex)
            {

                case 0:
                    mbSession.RawIO.Write("ch2:scale 5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 1:
                    mbSession.RawIO.Write("ch2:scale 2E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 2:
                    mbSession.RawIO.Write("ch2:scale 1E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 3:
                    mbSession.RawIO.Write("ch2:scale 5E-1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 4:
                    mbSession.RawIO.Write("ch2:scale 2E-1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 5:
                    mbSession.RawIO.Write("ch2:scale 1E-1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
            }
        }

        private void vertical2_position_SelectedIndexChanged(object sender, EventArgs e)    //ch2垂直位置
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (vertical2_position.SelectedIndex)
            {
                case 0:

                    mbSession.RawIO.Write("ch2:position 5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 1:
                    mbSession.RawIO.Write("ch2:position 4.5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 2:
                    mbSession.RawIO.Write("ch2:position 4");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 3:
                    mbSession.RawIO.Write("ch2:position 3.5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 4:
                    mbSession.RawIO.Write("ch2:position 3");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 5:
                    mbSession.RawIO.Write("ch2:position 2.5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 6:
                    mbSession.RawIO.Write("ch2:position 2E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 7:
                    mbSession.RawIO.Write("ch2:position 1.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 8:
                    mbSession.RawIO.Write("ch2:position 1E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 9:
                    mbSession.RawIO.Write("ch2:position 0.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 10:
                    mbSession.RawIO.Write("ch2:position 0E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 11:
                    mbSession.RawIO.Write("ch2:position -0.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 12:
                    mbSession.RawIO.Write("ch2:position -1E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 13:
                    mbSession.RawIO.Write("ch2:position -1.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 14:
                    mbSession.RawIO.Write("ch2:position -2E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 15:
                    mbSession.RawIO.Write("ch2:position -2.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 16:
                    mbSession.RawIO.Write("ch2:position -3E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 17:
                    mbSession.RawIO.Write("ch2:position -3.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 18:
                    mbSession.RawIO.Write("ch2:position -4E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 19:
                    mbSession.RawIO.Write("ch2:position -4.5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case 20:
                    mbSession.RawIO.Write("ch2:position -5E0");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
            }
        }

        private void amp2_type_SelectedIndexChanged(object sender, EventArgs e) //ch2测量类型
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (amp2_type.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("ch2:yunit \"V\"");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    probe2_select.Items.Clear();    //修改衰减类型为电压
                    probe2_select.Items.Add("X1");
                    probe2_select.Items.Add("X10");
                    probe2_select.Items.Add("X20");
                    probe2_select.Items.Add("X50");
                    probe2_select.Items.Add("X100");
                    probe2_select.Items.Add("X500");
                    probe2_select.Items.Add("X1000");
                    probe2_select.Enabled = true;
                    break;
                case 1:
                    mbSession.RawIO.Write("ch2:yunit \"A\"");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    probe2_select.Items.Clear();    //修改衰减类型为电流
                    probe2_select.Items.Add("0.2");
                    probe2_select.Items.Add("1");
                    probe2_select.Items.Add("2");
                    probe2_select.Items.Add("5");
                    probe2_select.Items.Add("10");
                    probe2_select.Items.Add("50");
                    probe2_select.Items.Add("100");
                    probe2_select.Items.Add("1000");
                    probe2_select.Enabled = true;
                    break;
            }
        }

        private void probe2_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer_get_data.Change(Timeout.Infinite, 200);
            Thread.Sleep(3000);
            switch (probe2_select.SelectedItem)
            {
                case "X1":
                    mbSession.RawIO.Write("ch2:probe 1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X10":
                    mbSession.RawIO.Write("ch2:probe 10");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X20":
                    mbSession.RawIO.Write("ch2:probe 20");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X50":
                    mbSession.RawIO.Write("ch2:probe 50");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X100":
                    mbSession.RawIO.Write("ch2:probe 100");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X500":
                    mbSession.RawIO.Write("ch2:probe 500");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "X1000":
                    mbSession.RawIO.Write("ch2:probe 1000");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;


                case "0.2":
                    mbSession.RawIO.Write("ch2:currentprobe 0.2");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "1":
                    mbSession.RawIO.Write("ch2:currentprobe 1");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "2":
                    mbSession.RawIO.Write("ch2:currentprobe 2");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "5":
                    mbSession.RawIO.Write("ch2:currentprobe 5");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "10":
                    mbSession.RawIO.Write("ch2:currentprobe 10");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "50":
                    mbSession.RawIO.Write("ch2:currentprobe 50");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "100":
                    mbSession.RawIO.Write("ch2:currentprobe 100");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
                case "1000":
                    mbSession.RawIO.Write("ch2:currentprobe 1000");
                    timer_get_data.Change(0, timer_period); //开启timer_get_data
                    break;
            }
        }


        //math通道操作
        private void math_operational(bool sign)    //math通道可操作
        {
            //if (sign)
            //{
            //    math_source.Items.Add("CH1+CH2");
            //    math_source.Items.Add("CH1-CH2");
            //    math_source.Items.Add("CH2-CH1");
            //    math_source.Items.Add("CH1*CH2");

            //}
            math_source.Enabled = sign;
            vertical_math_scale.Enabled = sign;
            vertical_math_position.Enabled = sign;
        }
    }
}
