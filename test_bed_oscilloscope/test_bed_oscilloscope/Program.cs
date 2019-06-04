using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_bed_oscilloscope
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form1 = new Form1();
            //System.Threading.Timer timer_wave_update = new System.Threading.Timer(form1.wave_update, "", 2000, 300);
            System.Threading.Timer timer_get_data = new System.Threading.Timer(form1.get_wave_data, "", 5000, 2000);//计时器初始化时默认关闭
            
            form1.timer1_get( ref timer_get_data);   //将timer_get_data传入到Form1.cs用于修改模式
            Application.Run(form1);
            
        }
    }
}
