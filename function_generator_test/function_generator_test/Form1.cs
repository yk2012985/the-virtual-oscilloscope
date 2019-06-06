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
        private void ch1_toogle_CheckedChanged(object sender, EventArgs e)
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

        private void ch1_wave_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ch1_wave_select.SelectedIndex)
            {
                case 0:
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
    }
}
