using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ivi.Visa;
using NationalInstruments.Visa;

namespace Graphic_test_3
{
    public partial class Form1 : Form
    {
        //VISA相关
        private MessageBasedSession mbSession;
        private string lastResourceString = null;   //资源名称变量
        

        //设备相关
        bool ch1 = false;
        bool ch2 = false;
        bool math = false;    //设置三个全局变量来表示CH1，CH2，MATH的状态初始化时为false
       

        //绘图相关
        public int[] wave1_data = new int[2500];       //CH1波形数据点数组
        public int[] wave2_data = new int[2500];      //CH2波形数据点数组
        public int[] wave_math_data = new int[2500]; //MATH波形数据点数组
        

        public Color grid_color = Color.FromArgb(100, 255, 255, 255);
        public Pen grid_pen_1 = new Pen(Color.FromArgb(100, 255, 255, 255), 1);   //设置普通网格画笔的类型
        public Pen grid_pen_2 = new Pen(Color.FromArgb(255, 255, 255, 255), 1);    //设置中心十字画笔类型

        public Pen wave_pen_1 = new Pen(Color.Orange, 1);    //CH1的波形画笔
        public Pen wave_pen_2 = new Pen(Color.CadetBlue, 1);    //CH2的波形画笔
        public Pen wave_pen_3 = new Pen(Color.Red, 1);    //MATH的波形画笔

        //测量相关（这里将测量序号和测量类型做成全局变量，方便服务请求处理函数访问）
        int meas;       //1-6
        int meas_type;   //测量类型

        public Form1()
        {
            InitializeComponent();
            SetupControlState(false);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            draw_grid(e.Graphics);
            //for (int j = 0; j < points_wave_Y_1.Length; j++)
            //{

            //    g.DrawRectangle(wave_pen_1, pos_x, points_wave_Y_1[j] + 240, (float)2, (float)2);
            //    //g.DrawLine(wave_pen_1, pos_x, points_wave_Y[j] + 240, pos_x+interval, points_wave_Y[j+1]+240);
            //    g.DrawRectangle(wave_pen_2, pos_x, points_wave_Y_1[j] + 300, (float)2, (float)2);
            //    pos_x = pos_x + interval;  //当前点的横坐标
            //}
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



            //int[] points_wave_Y_1 = { 63, 63, 63, 63, 62, 63, 63, 40, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 61, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 62, 63, 9, 1, 1, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 46, 62, 62, 63, 63, 62, 63, 63, 62, 63, 63, 62, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 57, 62, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 58, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 61, 62, 63, 63, 63, 63, 63, 63, 63, 63, 62, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 62, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 62, 62, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 17, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, -1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 33, 62, 63, 62, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 62, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 62, 63, 63, 63, 62, 63, 63, 63, 63, 63, 63, 63, 63, 63, 63, 4, 0, 1, 0, 0, 0, 0, 0, 0 };
            //float interval = (float)900 / (float)points_wave_Y_1.Length;   //求得每个点之间的横向间隔

            //float pos_x = 0;  //初始化点横坐标
            //for (int j = 0; j < points_wave_Y_1.Length; j++)
            //{

            //    g.DrawRectangle(wave_pen_1, pos_x, 240 - points_wave_Y_1[j] * (float)(12 / 4.975), (float)1.5, (float)1.5);   //4.975是肉眼推算的比例，为的是能和真实示波器上显示的效果接近
            //    //g.DrawLine(wave_pen_1, pos_x, points_wave_Y[j] + 240, pos_x+interval, points_wave_Y[j+1]+240);
            //    //g.DrawRectangle(wave_pen_2, pos_x, points_wave_Y_1[j] + 300, (float)2, (float)2);
            //    pos_x = pos_x + interval;  //当前点的横坐标
            //}
        }

        //绘制波形函数
        private void Draw_wave()
        {
            //pictureBox1.Invalidate();
            Graphics g = pictureBox1.CreateGraphics();
            draw_grid(g);
            float interval = (float)900 / (float)(2500);  //求得x轴间隙
            float pos_x = 0;
            for(int j = 0; j < 2500; j++)
            {
                if (ch1)    //如果打开CH1通道就显示CH1的波形
                {
                    g.DrawRectangle(wave_pen_1, pos_x, 240 - wave1_data[j] * (float)(12 / 4.975), (float)1.5, (float)1.5);
                }
                if (ch2)    //如果打开CH2通道就显示CH1的波形
                {
                    g.DrawRectangle(wave_pen_2, pos_x, 240 - wave2_data[j] * (float)(12 / 4.975), (float)1.5, (float)1.5);
                }
                if (math)   //如果打开MATH通道就显示CH1的波形
                {
                    g.DrawRectangle(wave_pen_3, pos_x, 240 - wave_math_data[j] * (float)(12 / 4.975), (float)1.5, (float)1.5);
                }
                pos_x = pos_x + interval;
            }
            //pictureBox1.Update();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.Clear(Color.Gray);
        }

        private void SetupControlState(bool isSessionOpen)
        {
            openSessionButton.Enabled = !isSessionOpen;
            closeSessionButton.Enabled = isSessionOpen;
            writeButton.Enabled = isSessionOpen;
            readButton.Enabled = isSessionOpen;
            writeTextBox.Enabled = isSessionOpen;
            clearButton.Enabled = isSessionOpen;
            if (isSessionOpen)
            {
                ClearControls();
                writeTextBox.Focus();
            }
        }

        private void ClearControls()
        {
            readTextBox.Text = String.Empty;
            elementsTransferedTextBox.Text = String.Empty;
            lastIOStatusTextBox.Text = String.Empty;
        }
        private void button2_Click(object sender, EventArgs e)  //closeSession按钮按下
        {
            SetupControlState(false);   //将按钮变成不可用状态
            mbSession.Dispose();
        }

        private void openSessionButton_Click(object sender, EventArgs e)
        {
            using(SelectResource sr = new SelectResource())     //建立资源选择窗体实例
            {
                if (lastResourceString != null)
                {
                    sr.ResourceName = lastResourceString;       //已经选择过资源则默认为当前已选择的资源
                }
                DialogResult result = sr.ShowDialog(this);      //弹出资源选择窗体
                if(result == DialogResult.OK)
                {
                    lastResourceString = sr.ResourceName;    //资源名变量赋值为选择的资源
                    Cursor.Current = Cursors.WaitCursor;    //光标变等待状
                    try
                    {       //尝试建立Session
                        using(var rmSession = new ResourceManager())
                        {
                            mbSession = (MessageBasedSession)rmSession.Open(sr.ResourceName);
                            mbSession.SynchronizeCallbacks = true;

                            Clear_measurements(mbSession);  //初始化时先将所有测量通道都关闭

                            mbSession.RawIO.Write("select:ch1 off");    //初始化时将CH1设为没有打开
                            mbSession.RawIO.Write("select:ch2 off");    //初始化时将CH2设为没有打开
                            mbSession.RawIO.Write("select:math off");    //初始化时将MATH设为没有打开

                            ch1_operational(false);     //CH1所有操作也不可用
                            ch2_operational(false);
                            math_operational(false);

                            mbSession.ServiceRequest += OutputReadyRequest;   //绑定服务请求处理程序


                            //mbSession.RawIO.Write("*SRE 16");   //*SRE 16命令会将寄存器SRER的第4位MAV置1，
                                                                //让仪器做好生成事件的准备
                            
                            SetupControlState(true);    //将按钮状态设为可用
                        }
                    }
                    catch(Exception exp)
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

        private void Clear_measurements(MessageBasedSession mbSession)
        {
            //将各通道的测量都关闭
            mbSession.RawIO.Write("measurement:meas1:type none");
            mbSession.RawIO.Write("*wai");

            mbSession.RawIO.Write("measurement:meas2:type none");
            mbSession.RawIO.Write("*wai");

            mbSession.RawIO.Write("measurement:meas3:type none");
            mbSession.RawIO.Write("*wai");

            mbSession.RawIO.Write("measurement:meas4:type none");
            mbSession.RawIO.Write("*wai");

            mbSession.RawIO.Write("measurement:meas5:type none");
            mbSession.RawIO.Write("*wai");

            mbSession.RawIO.Write("measurement:meas6:type none");
            mbSession.RawIO.Write("*wai");
        }

        private void SetupWaitingControlState(bool operationIsInProgress)
        {
            if (operationIsInProgress)
            {
                readTextBox.Text = String.Empty;
                elementsTransferedTextBox.Text = String.Empty;
                lastIOStatusTextBox.Text = String.Empty;

            }
            writeButton.Enabled = !operationIsInProgress;
            readButton.Enabled = !operationIsInProgress;
        }

        private void writeButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetupWaitingControlState(true); //进入等待模式
                string textToWrite = ReplaceCommonEscapeSequences(writeTextBox.Text);
                //asyncHandle = mbSession.RawIO.BeginWrite(
                //    textToWrite,
                //    new VisaAsyncCallback(OnWriteComplete),
                //    (object)textToWrite.Length);
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }

        
        private void OnWriteComplete(IVisaAsyncResult result)
        {
            try
            {
                SetupWaitingControlState(false);    //退出等待模式
                mbSession.RawIO.EndWrite(result);
                lastIOStatusTextBox.Text = "Success";
                try
                {
                    SetupWaitingControlState(true);
                    //asyncHandle = mbSession.RawIO.BeginRead(
                    //    20000,
                    //    new VisaAsyncCallback(OnReadComplete),
                    //    null);

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            catch(Exception exp)
            {
                lastIOStatusTextBox.Text = exp.Message;

            }
            elementsTransferedTextBox.Text = ((int)result.Count).ToString();
        }


        //波形绘制相关
        private void OnReadComplete(IVisaAsyncResult result)
        {
            try
            {
                //int[] wave_data_1 = new int[2500];      //用于装chanel_1波形数据的数组
                
                SetupWaitingControlState(false);        //退出等待模式
                string responseString = mbSession.RawIO.EndReadString(result);  //取到返回字符串
                string[] sArray = responseString.Split(',');
                for(int i = 0; i < sArray.Length; i++)
                {
                    int m = int.Parse(sArray[i]);
                    wave1_data[i] = m;
                }
                //Draw_wave();
                


                readTextBox.Text = responseString;
                lastIOStatusTextBox.Text = "Success";
                
            }
            catch(Exception exp)
            {
                lastIOStatusTextBox.Text = exp.Message;
            }
            elementsTransferedTextBox.Text = ((int)result.Count).ToString();
        }

        private void OnReadComplete2(IVisaAsyncResult result)
        {
            try
            {
                //int[] wave_data_1 = new int[2500];      //用于装chanel_1波形数据的数组

                SetupWaitingControlState(false);        //退出等待模式
                string responseString = mbSession.RawIO.EndReadString(result);  //取到返回字符串
                string[] sArray = responseString.Split(',');
                for (int i = 0; i < sArray.Length; i++)
                {
                    int m = int.Parse(sArray[i]);
                    wave2_data[i] = m;
                }
                //Draw_wave();
                


                readTextBox.Text = responseString;
                lastIOStatusTextBox.Text = "Success";
                
            }
            catch (Exception exp)
            {
                lastIOStatusTextBox.Text = exp.Message;
            }
            elementsTransferedTextBox.Text = ((int)result.Count).ToString();
        }

        private void OnReadComplete_math(IVisaAsyncResult result)
        {
            try
            {
                //int[] wave_data_1 = new int[2500];      //用于装chanel_1波形数据的数组

                SetupWaitingControlState(false);        //退出等待模式
                string responseString = mbSession.RawIO.EndReadString(result);  //取到返回字符串
                string[] sArray = responseString.Split(',');
                for (int i = 0; i < sArray.Length; i++)
                {
                    int m = int.Parse(sArray[i]);
                    wave_math_data[i] = m;
                }
                //Draw_wave();
              


                readTextBox.Text = responseString;
                lastIOStatusTextBox.Text = "Success";
                
            }
            catch (Exception exp)
            {
                lastIOStatusTextBox.Text = exp.Message;
            }
            elementsTransferedTextBox.Text = ((int)result.Count).ToString();
        }

        private string ReplaceCommonEscapeSequences(string s)
        {
            return (s != null) ? s.Replace("\\n", "\n").Replace("\\r", "\r") : s;
        }

        private string InsertCommonEscapeSequences(string s)
        {
            return (s != null) ? s.Replace("\n", "\\n").Replace("\r", "\\r") : s;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void readButton_Click(object sender, EventArgs e)
        {
            try
            {
                SetupWaitingControlState(true);
                //asyncHandle = mbSession.RawIO.BeginRead(
                //    20000,
                //    new VisaAsyncCallback(OnReadComplete),
                //    null);

            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void get_wave_Click(object sender, EventArgs e)     //一键获取波形程序
        {
            if (ch1 == true)
            {
               
                    get_ch1_wave_data();
                
                
            }
            if (ch2 == true)
            {
               
                get_ch2_wave_data();
            }
            if (math == true)
            {
                
                get_math_wave_data();
            }
            Draw_wave();
            
        }

        private void get_ch1_wave_data()
        {
            try
            {
                
                //SetupWaitingControlState(true); //进入等待模式
                //mbSession.RawIO.Write("*wai");
                mbSession.RawIO.Write("data:source ch1");   //将波形数据源设置成CH1
                string textToWrite = ReplaceCommonEscapeSequences("curve?");    //开始读取波形数据
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

        private void get_ch2_wave_data()
        {
            try
            {
                
                //SetupWaitingControlState(true); //进入等待模式
                mbSession.RawIO.Write("*wai");
                mbSession.RawIO.Write("data:source ch2");   //将波形数据源设置成CH2
                string textToWrite = ReplaceCommonEscapeSequences("curve?");    //开始读取波形数据
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

                    //asyncHandle2 = mbSession.RawIO.BeginRead(    //异步读取
                    //    20000,
                    //    new VisaAsyncCallback(OnReadComplete2), //绑定的处理函数是
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

        private void get_math_wave_data()
        {
            try
            {
                
                //SetupWaitingControlState(true); //进入等待模式
                mbSession.RawIO.Write("data:source math");   //将波形数据源设置成math
                string textToWrite = ReplaceCommonEscapeSequences("curve?");    //开始读取波形数据
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


        //测量相关
        //
        //通道选择栏操作
        private void chanel_select_1_SelectedIndexChanged(object sender, EventArgs e)
        {   
            if (chanel_select_1.SelectedIndex != -1 && messure_select_1.SelectedIndex != -1)
            {
                
                do_measurement(1, messure_select_1.SelectedIndex);
                //MessageBox.Show(messure_select_1.SelectedIndex.ToString());
            }
        }

        private void chanel_select_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chanel_select_2.SelectedIndex != -1 && messure_select_2.SelectedIndex != -1)
            {
                do_measurement(2, messure_select_2.SelectedIndex);
            }
        }

        private void chanel_select_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chanel_select_3.SelectedIndex != -1 && messure_select_3.SelectedIndex != -1)
            {
                do_measurement(3, messure_select_3.SelectedIndex);
            }
        }

        private void chanel_select_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chanel_select_4.SelectedIndex != -1 && messure_select_4.SelectedIndex != -1)
            {
                do_measurement(4, messure_select_4.SelectedIndex);
            }
        }

        private void chanel_select_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chanel_select_5.SelectedIndex != -1 && messure_select_5.SelectedIndex != -1)
            {
                do_measurement(5, messure_select_5.SelectedIndex);
            }
        }

        private void chanel_select_6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chanel_select_6.SelectedIndex != -1 && messure_select_6.SelectedIndex != -1)
            {
                do_measurement(6, messure_select_6.SelectedIndex);
            }
        }

        private void measurement_conflict(int meas_num) //测量冲突检测函数，输入参数是所操作的通道序号
        {
            string measurement_meas = "1,2,3,4,5,6";

            
        }

        private void do_measurement(int meas_number, int measurement_type)    //执行测量函数
        {
            //mbSession.RawIO.Write("*SRE 16");
            mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":source " + chanel_select_1.SelectedItem.ToString());    //写入通道选择命令
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

        private void get_measurement_result(int meas_number)       //获取测量数据
        {
            mbSession.RawIO.Write("measurement:meas" + meas_number.ToString() + ":value?"); //写入查询命令
        }

        

        private void OutputReadyRequest(object sender, VisaEventArgs e)   //请求服务事件发生后执行以下程序
        {
            //MessageBox.Show("执行到事件处理程序");
            try
            {
                var mbs = (MessageBasedSession)sender;
                StatusByteFlags sb = mbs.ReadStatusByte();  //读取标志位
                if (sb.HasFlag(StatusByteFlags.MessageAvailable))
                {
                    string textRead = mbs.RawIO.ReadString();
                    if (textRead == "9.9E37\n") //
                    {
                        //MessageBox.Show("读取失败");
                        //do_measurement(meas, meas_type);
                        get_measurement_result(meas);//读取失败要重新读取，后期加入实时刷新功能后要加入一个量来限制重新读取次数，不能一直卡在这里重新读取
                    }
                    else   //成功读取到数据，调用数据显示函数来将数据显示到控件上
                    {

                        //MessageBox.Show(textRead);//测试，先看看能否正确度到数据
                        //data_display(meas, meas_type, textRead);
                        format_correct(meas, meas_type, textRead);
                    }
                    //switch (meas)
                    //{
                    //    case 1:
                            
                    //}
                }
                else
                {
                    MessageBox.Show("呵呵哒");
                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
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
                        
                        if(data_array[0].Length > 5)
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
                        if(data_array[0].Length > 5)
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
                        if(data_array[0].Length > 5)
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
                        if(data_array[0].Length > 5)
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
                        if(data_array[0].Length > 5)
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
                        if(data_array[0].Length > 5)
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

        private void chanel1_toogle_CheckedChanged(object sender, EventArgs e)
        {
            if(chanel1_toogle.Checked == true)
            {
                try
                {
                    mbSession.RawIO.Write("select:ch1 on");
                    ch1_operational(true);
                    ch1 = true;
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            else
            {
                try
                {
                    mbSession.RawIO.Write("select:ch1 off");
                    ch1_operational(false);
                    ch1 = false;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void ch1_operational(bool sign)
        {
            coupling1_select.Enabled = sign;
            amp1_type.Enabled = sign;
            vertical1_scale.Enabled = sign;
            vertical1_position.Enabled = sign;
            probe1_select.Enabled = false;
        }

        private void coupling1_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(chanel1_toogle.Checked != true)
            {
                MessageBox.Show("CH1通道关闭");
            }
            else
            {
                switch (coupling1_select.SelectedIndex)
                {
                    case 0:
                        mbSession.RawIO.Write("ch1:coupling dc");
                        break;
                    case 1:
                        mbSession.RawIO.Write("ch1:coupling ac");
                        break;
                    case 2:
                        mbSession.RawIO.Write("ch1:coupling gnd");
                        break;
                }
            }
        }

        private void amp1_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chanel1_toogle.Checked != true)
            {
                MessageBox.Show("CH1通道关闭");
            }
            else
            {
                switch (amp1_type.SelectedIndex)
                {
                    case 0:
                        mbSession.RawIO.Write("ch1:yunit \"V\"");
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
        }

        private void probe1_select_SelectedIndexChanged(object sender, EventArgs e)     //选择衰减系数
        {
            switch (probe1_select.SelectedItem)
            {
                case "X1":
                    mbSession.RawIO.Write("ch1:probe 1");
                    break;
                case "X10":
                    mbSession.RawIO.Write("ch1:probe 10");
                    break;
                case "X20":
                    mbSession.RawIO.Write("ch1:probe 20");
                    break;
                case "X50":
                    mbSession.RawIO.Write("ch1:probe 50");
                    break;
                case "X100":
                    mbSession.RawIO.Write("ch1:probe 100");
                    break;
                case "X500":
                    mbSession.RawIO.Write("ch1:probe 500");
                    break;
                case "X1000":
                    mbSession.RawIO.Write("ch1:probe 1000");
                    break;


                case "0.2":
                    mbSession.RawIO.Write("ch1:currentprobe 0.2");
                    break;
                case "1":
                    mbSession.RawIO.Write("ch1:currentprobe 1");
                    break;
                case "2":
                    mbSession.RawIO.Write("ch1:currentprobe 2");
                    break;
                case "5":
                    mbSession.RawIO.Write("ch1:currentprobe 5");
                    break;
                case "10":
                    mbSession.RawIO.Write("ch1:currentprobe 10");
                    break;
                case "50":
                    mbSession.RawIO.Write("ch1:currentprobe 50");
                    break;
                case "100":
                    mbSession.RawIO.Write("ch1:currentprobe 100");
                    break;
                case "1000":
                    mbSession.RawIO.Write("ch1:currentprobe 1000");
                    break;
            }
            
        }

        private void vertical1_scale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (vertical1_scale.SelectedIndex)
            {
                
                case 0:
                    mbSession.RawIO.Write("ch1:scale 5E0");
                    break;
                case 1:
                    mbSession.RawIO.Write("ch1:scale 2E0");
                    break;
                case 2:
                    mbSession.RawIO.Write("ch1:scale 1E0");
                    break;
                case 3:
                    mbSession.RawIO.Write("ch1:scale 5E-1");
                    break;
                case 4:
                    mbSession.RawIO.Write("ch1:scale 2E-1");
                    break;
                case 5:
                    mbSession.RawIO.Write("ch1:scale 1E-1");
                    break;
            }
        }

        private void vertical1_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (vertical1_position.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("ch1:position 5");
                    break;
                case 1:
                    mbSession.RawIO.Write("ch1:position 4.5");
                    break;
                case 2:
                    mbSession.RawIO.Write("ch1:position 4");
                    break;
                case 3:
                    mbSession.RawIO.Write("ch1:position 3.5");
                    break;
                case 4:
                    mbSession.RawIO.Write("ch1:position 3");
                    break;
                case 5:
                    mbSession.RawIO.Write("ch1:position 2.5");
                    break;
                case 6:
                    mbSession.RawIO.Write("ch1:position 2E0");
                    break;
                case 7:
                    mbSession.RawIO.Write("ch1:position 1.5E0");
                    break;
                case 8:
                    mbSession.RawIO.Write("ch1:position 1E0");
                    break;
                case 9:
                    mbSession.RawIO.Write("ch1:position 0.5E0");
                    break;
                case 10:
                    mbSession.RawIO.Write("ch1:position 0E0");
                    break;
                case 11:
                    mbSession.RawIO.Write("ch1:position -0.5E0");
                    break;
                case 12:
                    mbSession.RawIO.Write("ch1:position -1E0");
                    break;
                case 13:
                    mbSession.RawIO.Write("ch1:position -1.5E0");
                    break;
                case 14:
                    mbSession.RawIO.Write("ch1:position -2E0");
                    break;
                case 15:
                    mbSession.RawIO.Write("ch1:position -2.5E0");
                    break;
                case 16:
                    mbSession.RawIO.Write("ch1:position -3E0");
                    break;
                case 17:
                    mbSession.RawIO.Write("ch1:position -3.5E0");
                    break;
                case 18:
                    mbSession.RawIO.Write("ch1:position -4E0");
                    break;
                case 19:
                    mbSession.RawIO.Write("ch1:position -4.5E0");
                    break;
                case 20:
                    mbSession.RawIO.Write("ch1:position -5E0");
                    break;
            }
        }

        private void chanel2_toogle_CheckedChanged(object sender, EventArgs e)
        {
            if (chanel2_toogle.Checked == true)
            {
                try
                {
                    mbSession.RawIO.Write("select:ch2 on");
                    ch2_operational(true);
                    ch2 = true;
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
                    ch2_operational(false);
                    ch2 = false;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void ch2_operational(bool sign) //CH2可用
        {
            coupling2_select.Enabled = sign;
            amp2_type.Enabled = sign;
            vertical2_scale.Enabled = sign;
            vertical2_position.Enabled = sign;
            probe2_select.Enabled = false;
        }


        private void coupling2_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chanel2_toogle.Checked != true)
            {
                MessageBox.Show("CH2通道关闭");
            }
            else
            {
                switch (coupling2_select.SelectedIndex)
                {
                    case 0:
                        mbSession.RawIO.Write("ch2:coupling dc");
                        break;
                    case 1:
                        mbSession.RawIO.Write("ch2:coupling ac");
                        break;
                    case 2:
                        mbSession.RawIO.Write("ch2:coupling gnd");
                        break;
                }
            }
        }

        private void amp2_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chanel2_toogle.Checked != true)
            {
                MessageBox.Show("CH2通道关闭");
            }
            else
            {
                switch (amp2_type.SelectedIndex)
                {
                    case 0:
                        mbSession.RawIO.Write("ch2:yunit \"V\"");
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
        }

        private void vertical2_scale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (vertical2_scale.SelectedIndex)
            {

                case 0:
                    mbSession.RawIO.Write("ch2:scale 5E0");
                    break;
                case 1:
                    mbSession.RawIO.Write("ch2:scale 2E0");
                    break;
                case 2:
                    mbSession.RawIO.Write("ch2:scale 1E0");
                    break;
                case 3:
                    mbSession.RawIO.Write("ch2:scale 5E-1");
                    break;
                case 4:
                    mbSession.RawIO.Write("ch2:scale 2E-1");
                    break;
                case 5:
                    mbSession.RawIO.Write("ch2:scale 1E-1");
                    break;
            }
        }

        private void vertical2_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (vertical2_position.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("ch2:position 5");
                    break;
                case 1:
                    mbSession.RawIO.Write("ch2:position 4.5");
                    break;
                case 2:
                    mbSession.RawIO.Write("ch2:position 4");
                    break;
                case 3:
                    mbSession.RawIO.Write("ch2:position 3.5");
                    break;
                case 4:
                    mbSession.RawIO.Write("ch2:position 3");
                    break;
                case 5:
                    mbSession.RawIO.Write("ch2:position 2.5");
                    break;
                case 6:
                    mbSession.RawIO.Write("ch2:position 2E0");
                    break;
                case 7:
                    mbSession.RawIO.Write("ch2:position 1.5E0");
                    break;
                case 8:
                    mbSession.RawIO.Write("ch2:position 1E0");
                    break;
                case 9:
                    mbSession.RawIO.Write("ch2:position 0.5E0");
                    break;
                case 10:
                    mbSession.RawIO.Write("ch2:position 0E0");
                    break;
                case 11:
                    mbSession.RawIO.Write("ch2:position -0.5E0");
                    break;
                case 12:
                    mbSession.RawIO.Write("ch2:position -1E0");
                    break;
                case 13:
                    mbSession.RawIO.Write("ch2:position -1.5E0");
                    break;
                case 14:
                    mbSession.RawIO.Write("ch2:position -2E0");
                    break;
                case 15:
                    mbSession.RawIO.Write("ch2:position -2.5E0");
                    break;
                case 16:
                    mbSession.RawIO.Write("ch2:position -3E0");
                    break;
                case 17:
                    mbSession.RawIO.Write("ch2:position -3.5E0");
                    break;
                case 18:
                    mbSession.RawIO.Write("ch2:position -4E0");
                    break;
                case 19:
                    mbSession.RawIO.Write("ch2:position -4.5E0");
                    break;
                case 20:
                    mbSession.RawIO.Write("ch2:position -5E0");
                    break;
            }
        }

        private void probe2_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (probe2_select.SelectedItem)
            {
                case "X1":
                    mbSession.RawIO.Write("ch2:probe 1");
                    break;
                case "X10":
                    mbSession.RawIO.Write("ch2:probe 10");
                    break;
                case "X20":
                    mbSession.RawIO.Write("ch2:probe 20");
                    break;
                case "X50":
                    mbSession.RawIO.Write("ch2:probe 50");
                    break;
                case "X100":
                    mbSession.RawIO.Write("ch2:probe 100");
                    break;
                case "X500":
                    mbSession.RawIO.Write("ch2:probe 500");
                    break;
                case "X1000":
                    mbSession.RawIO.Write("ch2:probe 1000");
                    break;


                case "0.2":
                    mbSession.RawIO.Write("ch2:currentprobe 0.2");
                    break;
                case "1":
                    mbSession.RawIO.Write("ch2:currentprobe 1");
                    break;
                case "2":
                    mbSession.RawIO.Write("ch2:currentprobe 2");
                    break;
                case "5":
                    mbSession.RawIO.Write("ch2:currentprobe 5");
                    break;
                case "10":
                    mbSession.RawIO.Write("ch2:currentprobe 10");
                    break;
                case "50":
                    mbSession.RawIO.Write("ch2:currentprobe 50");
                    break;
                case "100":
                    mbSession.RawIO.Write("ch2:currentprobe 100");
                    break;
                case "1000":
                    mbSession.RawIO.Write("ch2:currentprobe 1000");
                    break;
            }
        }

        private void math_toogle_CheckedChanged(object sender, EventArgs e)     //MATH信号的开关
        {
            if (chanel2_toogle.Checked == true)
            {
                try
                {
                    mbSession.RawIO.Write("select:math on");
                    math_operational(true);
                    math = true;
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
                    mbSession.RawIO.Write("select:math off");
                    math_operational(false);
                    math = false;
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
        }

        private void math_operational(bool sign)
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

        private void math_source_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (math_source.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("math:define \"CH1+CH2\"");
                    break;
                case 1:
                    mbSession.RawIO.Write("math:define \"CH1-CH2\"");
                    break;
                case 2:
                    mbSession.RawIO.Write("math:define \"CH2-CH1\"");
                    break;
                case 3:
                    mbSession.RawIO.Write("math:define \"CH1*CH2\"");
                    break;
            }
        }

        private void vertical_math_scale_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (vertical_math_scale.SelectedIndex)
            {

                case 0:
                    mbSession.RawIO.Write("math:scale 5E0");
                    break;
                case 1:
                    mbSession.RawIO.Write("math:scale 2E0");
                    break;
                case 2:
                    mbSession.RawIO.Write("math:scale 1E0");
                    break;
                case 3:
                    mbSession.RawIO.Write("math:scale 5E-1");
                    break;
                case 4:
                    mbSession.RawIO.Write("math:scale 2E-1");
                    break;
                case 5:
                    mbSession.RawIO.Write("math:scale 1E-1");
                    break;
            }
    }

        private void vertical_math_position_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (vertical_math_position.SelectedIndex)
            {
                case 0:
                    mbSession.RawIO.Write("math:vertical:position 5");
                    break;
                case 1:
                    mbSession.RawIO.Write("math:vertical:position 4.5");
                    break;
                case 2:
                    mbSession.RawIO.Write("math:vertical:position 4");
                    break;
                case 3:
                    mbSession.RawIO.Write("math:vertical:position 3.5");
                    break;
                case 4:
                    mbSession.RawIO.Write("math:vertical:position 3");
                    break;
                case 5:
                    mbSession.RawIO.Write("math:vertical:position 2.5");
                    break;
                case 6:
                    mbSession.RawIO.Write("math:vertical:position 2");
                    break;
                case 7:
                    mbSession.RawIO.Write("math:vertical:position 1.5");
                    break;
                case 8:
                    mbSession.RawIO.Write("math:vertical:position 1");
                    break;
                case 9:
                    mbSession.RawIO.Write("math:vertical:position 0.5");
                    break;
                case 10:
                    mbSession.RawIO.Write("math:vertical:position 0");
                    break;
                case 11:
                    mbSession.RawIO.Write("math:vertical:position -5E-1");
                    break;
                case 12:
                    mbSession.RawIO.Write("math:vertical:position -1");
                    break;
                case 13:
                    mbSession.RawIO.Write("math:vertical:position -15E-1");
                    break;
                case 14:
                    mbSession.RawIO.Write("math:vertical:position -2E0");
                    break;
                case 15:
                    mbSession.RawIO.Write("math:vertical:position -2.5");
                    break;
                case 16:
                    mbSession.RawIO.Write("math:vertical:position -3");
                    break;
                case 17:
                    mbSession.RawIO.Write("math:vertical:position -3.5");
                    break;
                case 18:
                    mbSession.RawIO.Write("math:vertical:position -4");
                    break;
                case 19:
                    mbSession.RawIO.Write("math:vertical:position -4.5");
                    break;
                case 20:
                    mbSession.RawIO.Write("math:vertical:position -5");
                    break;
            }
        }
    }
}
