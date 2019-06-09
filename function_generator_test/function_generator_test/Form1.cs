using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NationalInstruments.Visa;
using Ivi.Visa;
using System.Windows.Forms;

namespace function_generator_test
{
    public partial class Form1 : Form
    {
        //Visa相关
        private MessageBasedSession mbSession;
        private string lastResourceString = null;   //资源名称变量

        //绘图相关
        public Pen grid_pen_1 = new Pen(Color.FromArgb(100, 255, 255, 255), 1);   //设置网格画笔的类型
        public Pen wave_pen_1 = new Pen(Color.Orange, 2);    //CH1的波形画笔
        public Pen wave_pen_2 = new Pen(Color.CadetBlue, 2);    //CH2的波形画笔

        public Form1()
        {
            InitializeComponent();
        }

        private void draw_grid(Graphics e)
        {
            Graphics g = e;
            g.Clear(Color.Black);

            //建立网格坐标
            PointF[] points_X =
            {
                new PointF(90,260),
                new PointF(180,260),
                new PointF(270,260),

            };
            for (int i = 0; i < points_X.Length; i++)
            {
                g.DrawLine(grid_pen_1, points_X[i], new PointF(points_X[i].X, 0));
            }

            g.DrawLine(grid_pen_1, new PointF(0, 130), new PointF(360, 130));
        }

        //画正弦波
        private void draw_sine(int ch_number, Pen draw_pen)
        {
            Graphics g;
            switch (ch_number)
            {
                case 1:
                    g = pictureBox1.CreateGraphics();
                    break;
                case 2:
                    g = pictureBox1.CreateGraphics();
                    break;
                default:
                    g = pictureBox1.CreateGraphics();
                    break;
            }
            

            draw_grid(g);

            PointF[] points_sin =
            {
                new PointF(0,130),
                new PointF(45,0),
                new PointF(90,130),
                new PointF(135,260),
                new PointF(180,130),
                new PointF(225,0),
                new PointF(270,130),
                new PointF(315,260),
                new PointF(360,130)

            };
            g.DrawCurve(draw_pen, points_sin);


        }

        //画矩形波
        private void draw_square(int ch_number, Pen draw_pen)
        {
            Graphics g;
            switch (ch_number)
            {
                case 1:
                    g = pictureBox1.CreateGraphics();
                    break;
                case 2:
                    g = pictureBox1.CreateGraphics();
                    break;
                default:
                    g = pictureBox1.CreateGraphics();
                    break;
                
            }
            draw_grid(g);

            PointF[] points_square =
            {
                new PointF(5,258),
                new PointF(5,2),
                new PointF(90,2),
                new PointF(90,258),
                new PointF(180,258),
                new PointF(180,2),
                new PointF(270,2),
                new PointF(270,258),
                new PointF(360,258)

            };

            g.DrawLines(draw_pen, points_square);
            
            
        }

        private void draw_ramp(int ch_number, Pen draw_pen) //绘制三角波
        {
            Graphics g;
            switch (ch_number)
            {
                case 1:
                    g = pictureBox1.CreateGraphics();
                    break;
                case 2:
                    g = pictureBox1.CreateGraphics();
                    break;
                default:
                    g = pictureBox1.CreateGraphics();
                    break;

            }
            draw_grid(g);

            PointF[] points_ramp =
            {
                new PointF(0,130),
                new PointF(45,0),
                new PointF(90,130),
                new PointF(135,260),
                new PointF(180,130),
                new PointF(225,0),
                new PointF(270,130),
                new PointF(315,260),
                new PointF(360,130)

            };

            g.DrawLines(draw_pen, points_ramp);


        }

        private void draw_pulse(int ch_number, Pen draw_pen, float duty_petcent) //绘制脉冲波
        {
            Graphics g;
            switch (ch_number)
            {
                case 1:
                    g = pictureBox1.CreateGraphics();
                    break;
                case 2:
                    g = pictureBox1.CreateGraphics();
                    break;
                default:
                    g = pictureBox1.CreateGraphics();
                    break;

            }
            draw_grid(g);
            int high = (int)(180 * duty_petcent*0.01);   //由占空比算出高电平宽度

            PointF[] points_ramp =
            {
                new PointF(1,258),
                new PointF(1,2),
                new PointF(1+high,2),
                new PointF(1+high,258),
                new PointF(180,258),
                new PointF(180,2),
                new PointF(180+high,2),
                new PointF(180+high,258),
                new PointF(360,258)

            };

            g.DrawLines(draw_pen, points_ramp);


        }

        //上电自检程序
        private void self_check()
        {
            try
            {
                mbSession.RawIO.Write("output1:state?");    //检查ch1输出状态
                string output_response = mbSession.RawIO.ReadString();
                //MessageBox.Show(output_response); //测试用
                if (output_response == "1")
                {
                    this.ch1_toogle.Checked = true;
                }
                else
                {
                    ch1_toogle.Checked = false;
                }

                mbSession.RawIO.Write("source1:function:shape?");    //检查ch1波形
                string waveform_response = mbSession.RawIO.ReadString();
                //MessageBox.Show(waveform_response);
                switch (waveform_response)
                {
                    case "SIN":
                        ch1_wave_select.SelectedIndex = 0;
                        break;
                    case "SQU":
                        ch1_wave_select.SelectedIndex = 1;
                        break;
                    case "RAMP":
                        ch1_wave_select.SelectedIndex = 2;
                        break;
                    case "PULS":
                        ch1_wave_select.SelectedIndex = 3;
                        break;
                    case "PRN":
                        ch1_wave_select.SelectedIndex = 5;
                        break;
                    //default:
                    //    ch1_wave_select.SelectedIndex = 4;
                    //    break;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (ResourceSelect sr = new ResourceSelect())     //建立资源选择窗体实例
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
                            
                        }

                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show(exp.Message);
                    }
                    finally
                    {
                        
                        Cursor.Current = Cursors.Default;   //将光标还原为普通状态
                        //self_check(); //自检程序放在此处无效
                    }
                }
                else //没有检测到可用资源不显示此窗体
                {
                    //Application.Exit();
                }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            draw_grid(e.Graphics);
            
        }

        //操作部分
        private void ch1_toogle_CheckedChanged(object sender, EventArgs e)  //ch1通道开关
        {
            if(ch1_toogle.Checked == true)
            {
                try
                {
                    mbSession.RawIO.Write("output1:state on");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    mbSession.RawIO.Write("output1:state off");
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ch1_wave_select_SelectedIndexChanged(object sender, EventArgs e)   //ch1通道波形选择
        {
            switch (ch1_wave_select.SelectedIndex)
            {
                case 0:
                    if (duty_cycle1.Visible == true && duty_cycle1_text.Visible == true)
                    {
                        duty_cycle1.Visible = false;
                        duty_cycle1_text.Visible = false;
                    }
                    try
                    {
                        mbSession.RawIO.Write("source1:function:shape sin");
                        //MessageBox.Show("正弦波");   //测试用
                        //mbSession.RawIO.Write("source1:function:shape?");

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    draw_sine(1, wave_pen_1);
                    break;
                case 1:
                    if (duty_cycle1.Visible == true && duty_cycle1_text.Visible == true)
                    {
                        duty_cycle1.Visible = false;
                        duty_cycle1_text.Visible = false;
                    }
                    try
                    {
                        mbSession.RawIO.Write("source1:function:shape squ");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    draw_square(1, wave_pen_1);
                    break;
                case 2:
                    if (duty_cycle1.Visible == true && duty_cycle1_text.Visible == true)
                    {
                        duty_cycle1.Visible = false;
                        duty_cycle1_text.Visible = false;
                    }
                    try
                    {
                        mbSession.RawIO.Write("source1:function:shape ramp");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    draw_ramp(1, wave_pen_1);
                    break;
                case 3:
                    
                    try
                    {
                        mbSession.RawIO.Write("source1:function:shape puls");
                        mbSession.RawIO.Write("source1:pulse:dcycle?");
                        string duty_response = mbSession.RawIO.ReadString();
                        duty_cycle1.Visible = true;
                        duty_cycle1_text.Visible = true; //显示占空比栏
                        duty_cycle1_text.Text = duty_response;   //将占空比填入
                        float duty = float.Parse(duty_response);
                        MessageBox.Show(duty_response);
                        draw_pulse(1, wave_pen_1, duty);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }                    
                    
                    break;
            }
        }



        //频率修改部分

        private void freq_handling(int ch_num)  //频率处理函数
        {
            try
            {
                mbSession.RawIO.Write("source1:frequency:cw?");
                string freq_response = mbSession.RawIO.ReadString();    //得到当前的频率
                string[] data_array = freq_response.Split('e');
                //MessageBox.Show(data_array[0] + "," + data_array[1]);   //测试
                freq1.Text = data_array[0];
                string[] freq_unit = data_array[1].Split('0');
                //MessageBox.Show(freq_unit[1]);    //test
                if (freq_unit[0] == "+")
                {
                    try
                    {
                        switch (int.Parse(freq_unit[1]))
                        {
                            case 3:
                                fre1_unit.SelectedIndex = 1;    //kHz
                                break;
                            case 6:
                                fre1_unit.SelectedIndex = 2;    //MHz
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        fre1_unit.SelectedIndex = 0;    //Hz
                    }
                }
                else
                {
                    MessageBox.Show("频率小于1Hz");    //mHz
                }
                float period = 1/float.Parse(freq_response);    //用频率求得周期
                if (period > 1) //周期为s
                {
                    period1_text.Text = period.ToString();  //将周期填入
                    period1_unit.SelectedIndex = 1;
                    time_unit.Text = "s";

                    //修改横坐标
                    x_1.Text = (period / 2).ToString();
                    x_2.Text = period.ToString();
                    x_3.Text = (period * 1.5).ToString();
                    x_4.Text = (period * 2).ToString();
                }
                else    //周期为ms
                {
                    period1_text.Text = (period * 1000).ToString();
                    period1_unit.SelectedIndex = 0;
                    time_unit.Text = "ms";
                    //修改横坐标
                    x_1.Text = (period *500).ToString();
                    x_2.Text = (period*1000).ToString();
                    x_3.Text = (period * 1500).ToString();
                    x_4.Text = (period * 2000).ToString();
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void freq1_TextChanged(object sender, EventArgs e)
        {
            //if (freq1.Text == "")
            //{
            //    mbSession.RawIO.Write("source1:frequency:cw?");
            //    string freq_response = mbSession.RawIO.ReadString();
            //    string[] data_array = freq_response.Split('e');
            //    MessageBox.Show(data_array[0] + "," + data_array[1]);
            //}
        }

        private void freq1_Leave(object sender, EventArgs e)    //ch1频率文本框失去焦点
        {
            if (freq1.Text == "")       //用户没有填入数据
            {
                freq_handling(1);

            }
            else    //用户填入数据
            {
                try
                {
                    mbSession.RawIO.Write("source1:frequency:cw " + freq1.Text +fre1_unit.SelectedItem.ToString()); //修改频率指令
                    freq_handling(1);

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void fre1_unit_SelectedIndexChanged(object sender, EventArgs e) //改变频率
        {
            if (freq1.Text == "")       //用户没有填入数据
            {
                freq_handling(1);

            }
            else    //用户填入数据
            {
                try
                {
                    mbSession.RawIO.Write("source1:frequency:cw " + freq1.Text + fre1_unit.SelectedItem.ToString()); //修改频率指令
                    freq_handling(1);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


        //幅度部分

        private void y_axis_handling(int ch)    //纵坐标处理
        {
            try
            {
                mbSession.RawIO.Write("source1:voltage:level:immediate:amplitude?");
                string amplitude_response = mbSession.RawIO.ReadString();
                mbSession.RawIO.Write("source1:voltage:level:immediate:offset?");
                string offset_response = mbSession.RawIO.ReadString();
                y_axis_formating(ch, amplitude_response, offset_response);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //幅值组数据及纵坐标格式修正
        private void y_axis_formating(int ch, string amplitude, string offset)
        {
            float amplitude_f = float.Parse(amplitude); //将幅值转为浮点数
            float offset_f = float.Parse(offset);   //将偏置转为浮点数

            double high_level = offset_f + 0.5 * amplitude_f;   //计算高电平
            double low_level = offset_f - 0.5 * amplitude_f;    //计算低电平

            //string[] amp_array = amplitude.Split('e');  //对幅值进行处理
            //string[] vpp_unit = amp_array[1].Split('0');

            if (amplitude_f*1000>1000)
            {
                amplitude1.Text = amplitude_f.ToString();
                vpp_u.SelectedIndex = 1;
                //amplitude_unit.Text = "V";

            }
            else
            {
                amplitude1.Text = (amplitude_f*1000).ToString();
                
                vpp_u.SelectedIndex = 0;
                //amplitude_unit.Text = "mV";
            }


            //string[] offset_array = offset.Split('e');   //对偏执进行处理
            //string[] offset_unit = offset_array[1].Split('0');

            if(offset_f*1000>1000)
            {
                offset1.Text = offset_f.ToString();
                offset1_u.SelectedIndex = 1;
                
            }
            else
            {
                y_1.Text = offset1.Text = (offset_f*1000).ToString(); //同时赋值偏置文本和中心纵坐标
                offset1_u.SelectedIndex = 0;
            }

            if (high_level * 1000 > 1000)
            {
                high_level1.Text = high_level.ToString();
                high_level1_u.SelectedIndex = 1;
                y_2.Text = high_level.ToString();
            }
            else
            {
                high_level1.Text = (high_level * 1000).ToString();
                high_level1_u.SelectedIndex = 0;
                y_2.Text = (high_level * 1000).ToString();
            }

            if (low_level * 1000 > 1000)
            {
                low_level1.Text = low_level.ToString();
                low_level1_u.SelectedIndex = 1;
                y_0.Text = low_level.ToString();
            }
            else
            {
                low_level1.Text = (low_level * 1000).ToString();
                low_level1_u.SelectedIndex = 0;
                y_0.Text = (low_level * 1000).ToString();
            }

        }

        private void amplitude1_Leave(object sender, EventArgs e)
        {
            if (amplitude1.Text == "")
            {
                y_axis_handling(1);
            }
            else
            {
                try
                {
                    mbSession.RawIO.Write("source1:voltage:level:immediate:amplitude "+amplitude1.Text+vpp_u.SelectedItem.ToString());
                    y_axis_handling(1);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        //偏置操作

        private void offset_handling(int ch)
        {

        }
        private void offset_Leave(object sender, EventArgs e)
        {
            if (offset1.Text == "")
            {
                y_axis_handling(1);
            }
            else
            {
                try
                {
                    mbSession.RawIO.Write("source1:voltage:level:immediate:offset " + offset1.Text + offset1_u.SelectedItem.ToString());
                    y_axis_handling(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void low_level1_Leave(object sender, EventArgs e)   //
        {
            if (low_level1.Text == "")
            {
                y_axis_handling(1);
            }
            else
            {
                float amp = float.Parse(high_level1.Text) - float.Parse(low_level1.Text);
                try
                {
                    mbSession.RawIO.Write("source1:voltage:level:immediate:amplitude " + amp.ToString() + low_level1_u.SelectedItem.ToString());
                    y_axis_handling(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void high_level1_Leave(object sender, EventArgs e)
        {
            if (high_level1.Text == "")
            {
                y_axis_handling(1);
            }
            else
            {
                float amp = float.Parse(high_level1.Text) - float.Parse(low_level1.Text);
                try
                {
                    mbSession.RawIO.Write("source1:voltage:level:immediate:amplitude " + amp.ToString() + high_level1_u.SelectedItem.ToString());
                    y_axis_handling(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void phase1_Leave(object sender, EventArgs e)   //相位调整
        {
            if (phase1.Text == "")
            {
                y_axis_handling(1);
            }
            else
            {
                float amp = float.Parse(phase1.Text);
                try
                {
                    mbSession.RawIO.Write("source1:voltage:level:immediate:amplitude " + amp.ToString() + high_level1_u.SelectedItem.ToString());
                    y_axis_handling(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
