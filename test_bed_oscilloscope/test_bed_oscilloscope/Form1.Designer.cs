namespace test_bed_oscilloscope
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                if (mbSession != null)
                {
                    mbSession.Dispose();
                }
                
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.screen = new System.Windows.Forms.Panel();
            this.open_session = new System.Windows.Forms.Button();
            this.ch1_toogle = new System.Windows.Forms.CheckBox();
            this.ch2_toogle = new System.Windows.Forms.CheckBox();
            this.math_toogle = new System.Windows.Forms.CheckBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.chanel_select_1 = new System.Windows.Forms.ComboBox();
            this.chanel_select_2 = new System.Windows.Forms.ComboBox();
            this.chanel_select_3 = new System.Windows.Forms.ComboBox();
            this.chanel_select_4 = new System.Windows.Forms.ComboBox();
            this.chanel_select_5 = new System.Windows.Forms.ComboBox();
            this.chanel_select_6 = new System.Windows.Forms.ComboBox();
            this.measure_select_1 = new System.Windows.Forms.ComboBox();
            this.measure_select_2 = new System.Windows.Forms.ComboBox();
            this.measure_select_3 = new System.Windows.Forms.ComboBox();
            this.measure_select_4 = new System.Windows.Forms.ComboBox();
            this.measure_select_5 = new System.Windows.Forms.ComboBox();
            this.measure_select_6 = new System.Windows.Forms.ComboBox();
            this.measure_value_1 = new System.Windows.Forms.TextBox();
            this.measure_value_2 = new System.Windows.Forms.TextBox();
            this.measure_value_3 = new System.Windows.Forms.TextBox();
            this.measure_value_4 = new System.Windows.Forms.TextBox();
            this.measure_value_5 = new System.Windows.Forms.TextBox();
            this.measure_value_6 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.coupling1_select = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.vertical1_scale = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.amp1_type = new System.Windows.Forms.ComboBox();
            this.probe1_select = new System.Windows.Forms.ComboBox();
            this.vertical1_position = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.coupling2_select = new System.Windows.Forms.ComboBox();
            this.vertical2_scale = new System.Windows.Forms.ComboBox();
            this.vertical2_position = new System.Windows.Forms.ComboBox();
            this.amp2_type = new System.Windows.Forms.ComboBox();
            this.probe2_select = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.math_source = new System.Windows.Forms.ComboBox();
            this.vertical_math_scale = new System.Windows.Forms.ComboBox();
            this.vertical_math_position = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // screen
            // 
            this.screen.Location = new System.Drawing.Point(13, 13);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(900, 480);
            this.screen.TabIndex = 0;
            this.screen.Paint += new System.Windows.Forms.PaintEventHandler(this.screen_Paint);
            // 
            // open_session
            // 
            this.open_session.Location = new System.Drawing.Point(13, 510);
            this.open_session.Name = "open_session";
            this.open_session.Size = new System.Drawing.Size(95, 23);
            this.open_session.TabIndex = 1;
            this.open_session.Text = "open";
            this.open_session.UseVisualStyleBackColor = true;
            this.open_session.Click += new System.EventHandler(this.open_session_Click);
            // 
            // ch1_toogle
            // 
            this.ch1_toogle.AutoSize = true;
            this.ch1_toogle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.ch1_toogle.Location = new System.Drawing.Point(931, 253);
            this.ch1_toogle.Name = "ch1_toogle";
            this.ch1_toogle.Size = new System.Drawing.Size(42, 16);
            this.ch1_toogle.TabIndex = 9;
            this.ch1_toogle.Text = "CH1";
            this.ch1_toogle.UseVisualStyleBackColor = false;
            this.ch1_toogle.CheckedChanged += new System.EventHandler(this.ch1_toogle_CheckedChanged);
            // 
            // ch2_toogle
            // 
            this.ch2_toogle.AutoSize = true;
            this.ch2_toogle.BackColor = System.Drawing.Color.Aqua;
            this.ch2_toogle.Location = new System.Drawing.Point(931, 364);
            this.ch2_toogle.Name = "ch2_toogle";
            this.ch2_toogle.Size = new System.Drawing.Size(42, 16);
            this.ch2_toogle.TabIndex = 10;
            this.ch2_toogle.Text = "CH2";
            this.ch2_toogle.UseVisualStyleBackColor = false;
            this.ch2_toogle.CheckedChanged += new System.EventHandler(this.ch2_toogle_CheckedChanged);
            // 
            // math_toogle
            // 
            this.math_toogle.AutoSize = true;
            this.math_toogle.BackColor = System.Drawing.Color.Red;
            this.math_toogle.ForeColor = System.Drawing.SystemColors.Control;
            this.math_toogle.Location = new System.Drawing.Point(931, 467);
            this.math_toogle.Name = "math_toogle";
            this.math_toogle.Size = new System.Drawing.Size(48, 16);
            this.math_toogle.TabIndex = 11;
            this.math_toogle.Text = "MATH";
            this.math_toogle.UseVisualStyleBackColor = false;
            this.math_toogle.CheckedChanged += new System.EventHandler(this.math_toogle_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(981, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "测量";
            // 
            // chanel_select_1
            // 
            this.chanel_select_1.FormattingEnabled = true;
            this.chanel_select_1.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_1.Location = new System.Drawing.Point(925, 53);
            this.chanel_select_1.Name = "chanel_select_1";
            this.chanel_select_1.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_1.TabIndex = 13;
            this.chanel_select_1.SelectedIndexChanged += new System.EventHandler(this.chanel_select_1_SelectedIndexChanged);
            // 
            // chanel_select_2
            // 
            this.chanel_select_2.FormattingEnabled = true;
            this.chanel_select_2.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_2.Location = new System.Drawing.Point(925, 80);
            this.chanel_select_2.Name = "chanel_select_2";
            this.chanel_select_2.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_2.TabIndex = 14;
            this.chanel_select_2.SelectedIndexChanged += new System.EventHandler(this.chanel_select_2_SelectedIndexChanged);
            // 
            // chanel_select_3
            // 
            this.chanel_select_3.FormattingEnabled = true;
            this.chanel_select_3.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_3.Location = new System.Drawing.Point(925, 107);
            this.chanel_select_3.Name = "chanel_select_3";
            this.chanel_select_3.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_3.TabIndex = 15;
            this.chanel_select_3.SelectedIndexChanged += new System.EventHandler(this.chanel_select_3_SelectedIndexChanged);
            // 
            // chanel_select_4
            // 
            this.chanel_select_4.FormattingEnabled = true;
            this.chanel_select_4.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_4.Location = new System.Drawing.Point(925, 134);
            this.chanel_select_4.Name = "chanel_select_4";
            this.chanel_select_4.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_4.TabIndex = 16;
            this.chanel_select_4.SelectedIndexChanged += new System.EventHandler(this.chanel_select_4_SelectedIndexChanged);
            // 
            // chanel_select_5
            // 
            this.chanel_select_5.FormattingEnabled = true;
            this.chanel_select_5.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_5.Location = new System.Drawing.Point(925, 161);
            this.chanel_select_5.Name = "chanel_select_5";
            this.chanel_select_5.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_5.TabIndex = 17;
            this.chanel_select_5.SelectedIndexChanged += new System.EventHandler(this.chanel_select_5_SelectedIndexChanged);
            // 
            // chanel_select_6
            // 
            this.chanel_select_6.FormattingEnabled = true;
            this.chanel_select_6.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_6.Location = new System.Drawing.Point(925, 188);
            this.chanel_select_6.Name = "chanel_select_6";
            this.chanel_select_6.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_6.TabIndex = 18;
            this.chanel_select_6.SelectedIndexChanged += new System.EventHandler(this.chanel_select_6_SelectedIndexChanged);
            // 
            // measure_select_1
            // 
            this.measure_select_1.FormattingEnabled = true;
            this.measure_select_1.Items.AddRange(new object[] {
            "周期",
            "频率",
            "峰-峰值",
            "最小值",
            "最大值",
            "平均值",
            "上升时间",
            "下降时间",
            "正占空比",
            "负占空比"});
            this.measure_select_1.Location = new System.Drawing.Point(1027, 52);
            this.measure_select_1.Name = "measure_select_1";
            this.measure_select_1.Size = new System.Drawing.Size(95, 20);
            this.measure_select_1.TabIndex = 19;
            // 
            // measure_select_2
            // 
            this.measure_select_2.FormattingEnabled = true;
            this.measure_select_2.Items.AddRange(new object[] {
            "周期",
            "频率",
            "峰-峰值",
            "最小值",
            "最大值",
            "平均值",
            "上升时间",
            "下降时间",
            "正占空比",
            "负占空比"});
            this.measure_select_2.Location = new System.Drawing.Point(1027, 79);
            this.measure_select_2.Name = "measure_select_2";
            this.measure_select_2.Size = new System.Drawing.Size(95, 20);
            this.measure_select_2.TabIndex = 20;
            // 
            // measure_select_3
            // 
            this.measure_select_3.FormattingEnabled = true;
            this.measure_select_3.Items.AddRange(new object[] {
            "周期",
            "频率",
            "峰-峰值",
            "最小值",
            "最大值",
            "平均值",
            "上升时间",
            "下降时间",
            "正占空比",
            "负占空比"});
            this.measure_select_3.Location = new System.Drawing.Point(1027, 106);
            this.measure_select_3.Name = "measure_select_3";
            this.measure_select_3.Size = new System.Drawing.Size(95, 20);
            this.measure_select_3.TabIndex = 21;
            // 
            // measure_select_4
            // 
            this.measure_select_4.FormattingEnabled = true;
            this.measure_select_4.Items.AddRange(new object[] {
            "周期",
            "频率",
            "峰-峰值",
            "最小值",
            "最大值",
            "平均值",
            "上升时间",
            "下降时间",
            "正占空比",
            "负占空比"});
            this.measure_select_4.Location = new System.Drawing.Point(1027, 133);
            this.measure_select_4.Name = "measure_select_4";
            this.measure_select_4.Size = new System.Drawing.Size(95, 20);
            this.measure_select_4.TabIndex = 22;
            // 
            // measure_select_5
            // 
            this.measure_select_5.FormattingEnabled = true;
            this.measure_select_5.Items.AddRange(new object[] {
            "周期",
            "频率",
            "峰-峰值",
            "最小值",
            "最大值",
            "平均值",
            "上升时间",
            "下降时间",
            "正占空比",
            "负占空比"});
            this.measure_select_5.Location = new System.Drawing.Point(1027, 160);
            this.measure_select_5.Name = "measure_select_5";
            this.measure_select_5.Size = new System.Drawing.Size(95, 20);
            this.measure_select_5.TabIndex = 23;
            // 
            // measure_select_6
            // 
            this.measure_select_6.FormattingEnabled = true;
            this.measure_select_6.Items.AddRange(new object[] {
            "周期",
            "频率",
            "峰-峰值",
            "最小值",
            "最大值",
            "平均值",
            "上升时间",
            "下降时间",
            "正占空比",
            "负占空比"});
            this.measure_select_6.Location = new System.Drawing.Point(1026, 188);
            this.measure_select_6.Name = "measure_select_6";
            this.measure_select_6.Size = new System.Drawing.Size(96, 20);
            this.measure_select_6.TabIndex = 24;
            // 
            // measure_value_1
            // 
            this.measure_value_1.Location = new System.Drawing.Point(1129, 53);
            this.measure_value_1.Name = "measure_value_1";
            this.measure_value_1.Size = new System.Drawing.Size(143, 21);
            this.measure_value_1.TabIndex = 25;
            // 
            // measure_value_2
            // 
            this.measure_value_2.Location = new System.Drawing.Point(1129, 78);
            this.measure_value_2.Name = "measure_value_2";
            this.measure_value_2.Size = new System.Drawing.Size(143, 21);
            this.measure_value_2.TabIndex = 26;
            // 
            // measure_value_3
            // 
            this.measure_value_3.Location = new System.Drawing.Point(1129, 107);
            this.measure_value_3.Name = "measure_value_3";
            this.measure_value_3.Size = new System.Drawing.Size(143, 21);
            this.measure_value_3.TabIndex = 27;
            // 
            // measure_value_4
            // 
            this.measure_value_4.Location = new System.Drawing.Point(1129, 135);
            this.measure_value_4.Name = "measure_value_4";
            this.measure_value_4.Size = new System.Drawing.Size(143, 21);
            this.measure_value_4.TabIndex = 28;
            // 
            // measure_value_5
            // 
            this.measure_value_5.Location = new System.Drawing.Point(1129, 159);
            this.measure_value_5.Name = "measure_value_5";
            this.measure_value_5.Size = new System.Drawing.Size(143, 21);
            this.measure_value_5.TabIndex = 29;
            // 
            // measure_value_6
            // 
            this.measure_value_6.Location = new System.Drawing.Point(1129, 187);
            this.measure_value_6.Name = "measure_value_6";
            this.measure_value_6.Size = new System.Drawing.Size(143, 21);
            this.measure_value_6.TabIndex = 30;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(594, 533);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 31;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(982, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 24);
            this.label2.TabIndex = 32;
            this.label2.Text = "垂直与水平操作";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(929, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 33;
            this.label3.Text = "耦合方式";
            // 
            // coupling1_select
            // 
            this.coupling1_select.FormattingEnabled = true;
            this.coupling1_select.Items.AddRange(new object[] {
            "DC",
            "AC",
            "GND"});
            this.coupling1_select.Location = new System.Drawing.Point(986, 279);
            this.coupling1_select.Name = "coupling1_select";
            this.coupling1_select.Size = new System.Drawing.Size(95, 20);
            this.coupling1_select.TabIndex = 34;
            this.coupling1_select.SelectedIndexChanged += new System.EventHandler(this.coupling1_select_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(929, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 35;
            this.label4.Text = "垂直标度";
            // 
            // vertical1_scale
            // 
            this.vertical1_scale.FormattingEnabled = true;
            this.vertical1_scale.Items.AddRange(new object[] {
            "5V",
            "2V",
            "1V",
            "500mV",
            "200mV",
            "100mV"});
            this.vertical1_scale.Location = new System.Drawing.Point(986, 305);
            this.vertical1_scale.Name = "vertical1_scale";
            this.vertical1_scale.Size = new System.Drawing.Size(95, 20);
            this.vertical1_scale.TabIndex = 36;
            this.vertical1_scale.SelectedIndexChanged += new System.EventHandler(this.vertical1_scale_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(929, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 37;
            this.label5.Text = "垂直位置";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1087, 282);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "幅值类型";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1087, 308);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 39;
            this.label7.Text = "探测衰减";
            // 
            // amp1_type
            // 
            this.amp1_type.FormattingEnabled = true;
            this.amp1_type.Items.AddRange(new object[] {
            "电压V",
            "电流A"});
            this.amp1_type.Location = new System.Drawing.Point(1146, 279);
            this.amp1_type.Name = "amp1_type";
            this.amp1_type.Size = new System.Drawing.Size(95, 20);
            this.amp1_type.TabIndex = 40;
            this.amp1_type.SelectedIndexChanged += new System.EventHandler(this.amp1_type_SelectedIndexChanged);
            // 
            // probe1_select
            // 
            this.probe1_select.FormattingEnabled = true;
            this.probe1_select.Location = new System.Drawing.Point(1146, 306);
            this.probe1_select.Name = "probe1_select";
            this.probe1_select.Size = new System.Drawing.Size(95, 20);
            this.probe1_select.TabIndex = 41;
            this.probe1_select.SelectedIndexChanged += new System.EventHandler(this.probe1_select_SelectedIndexChanged);
            // 
            // vertical1_position
            // 
            this.vertical1_position.FormattingEnabled = true;
            this.vertical1_position.Items.AddRange(new object[] {
            "5",
            "4.5",
            "4",
            "3.5",
            "3",
            "2.5",
            "2",
            "1.5",
            "1",
            "0.5",
            "0",
            "-0.5",
            "-1",
            "-1.5",
            "-2",
            "-2.5",
            "-3",
            "-3.5",
            "-4",
            "-4.5",
            "-5"});
            this.vertical1_position.Location = new System.Drawing.Point(986, 333);
            this.vertical1_position.Name = "vertical1_position";
            this.vertical1_position.Size = new System.Drawing.Size(95, 20);
            this.vertical1_position.TabIndex = 42;
            this.vertical1_position.SelectedIndexChanged += new System.EventHandler(this.vertical1_position_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(931, 387);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 43;
            this.label8.Text = "耦合类型";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(931, 409);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 44;
            this.label9.Text = "垂直标度";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(931, 436);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 45;
            this.label10.Text = "垂直位置";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1087, 386);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 46;
            this.label11.Text = "幅值类型";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1087, 409);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 47;
            this.label12.Text = "探测衰减";
            // 
            // coupling2_select
            // 
            this.coupling2_select.FormattingEnabled = true;
            this.coupling2_select.Items.AddRange(new object[] {
            "DC",
            "AC",
            "GND"});
            this.coupling2_select.Location = new System.Drawing.Point(986, 378);
            this.coupling2_select.Name = "coupling2_select";
            this.coupling2_select.Size = new System.Drawing.Size(95, 20);
            this.coupling2_select.TabIndex = 48;
            this.coupling2_select.SelectedIndexChanged += new System.EventHandler(this.coupling2_select_SelectedIndexChanged);
            // 
            // vertical2_scale
            // 
            this.vertical2_scale.FormattingEnabled = true;
            this.vertical2_scale.Items.AddRange(new object[] {
            "5V",
            "2V",
            "1V",
            "500mV",
            "200mV",
            "100mV"});
            this.vertical2_scale.Location = new System.Drawing.Point(986, 406);
            this.vertical2_scale.Name = "vertical2_scale";
            this.vertical2_scale.Size = new System.Drawing.Size(95, 20);
            this.vertical2_scale.TabIndex = 49;
            this.vertical2_scale.SelectedIndexChanged += new System.EventHandler(this.vertical2_scale_SelectedIndexChanged);
            // 
            // vertical2_position
            // 
            this.vertical2_position.FormattingEnabled = true;
            this.vertical2_position.Items.AddRange(new object[] {
            "5",
            "4.5",
            "4",
            "3.5",
            "3",
            "2.5",
            "2",
            "1.5",
            "1",
            "0.5",
            "0",
            "-0.5",
            "-1",
            "-1.5",
            "-2",
            "-2.5",
            "-3",
            "-3.5",
            "-4",
            "-4.5",
            "-5"});
            this.vertical2_position.Location = new System.Drawing.Point(986, 432);
            this.vertical2_position.Name = "vertical2_position";
            this.vertical2_position.Size = new System.Drawing.Size(95, 20);
            this.vertical2_position.TabIndex = 50;
            this.vertical2_position.SelectedIndexChanged += new System.EventHandler(this.vertical2_position_SelectedIndexChanged);
            // 
            // amp2_type
            // 
            this.amp2_type.FormattingEnabled = true;
            this.amp2_type.Items.AddRange(new object[] {
            "电压V",
            "电流A"});
            this.amp2_type.Location = new System.Drawing.Point(1146, 378);
            this.amp2_type.Name = "amp2_type";
            this.amp2_type.Size = new System.Drawing.Size(95, 20);
            this.amp2_type.TabIndex = 51;
            this.amp2_type.SelectedIndexChanged += new System.EventHandler(this.amp2_type_SelectedIndexChanged);
            // 
            // probe2_select
            // 
            this.probe2_select.FormattingEnabled = true;
            this.probe2_select.Location = new System.Drawing.Point(1146, 406);
            this.probe2_select.Name = "probe2_select";
            this.probe2_select.Size = new System.Drawing.Size(95, 20);
            this.probe2_select.TabIndex = 52;
            this.probe2_select.SelectedIndexChanged += new System.EventHandler(this.probe2_select_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(933, 501);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 53;
            this.label13.Text = "操作方式";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(933, 524);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 54;
            this.label14.Text = "垂直位置";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1087, 501);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 55;
            this.label15.Text = "垂直标度";
            // 
            // math_source
            // 
            this.math_source.FormattingEnabled = true;
            this.math_source.Items.AddRange(new object[] {
            "CH1+CH2",
            "CH1-CH2",
            "CH2-CH1",
            "CH1*CH2"});
            this.math_source.Location = new System.Drawing.Point(986, 498);
            this.math_source.Name = "math_source";
            this.math_source.Size = new System.Drawing.Size(95, 20);
            this.math_source.TabIndex = 56;
            // 
            // vertical_math_scale
            // 
            this.vertical_math_scale.FormattingEnabled = true;
            this.vertical_math_scale.Items.AddRange(new object[] {
            "5V",
            "2V",
            "1V",
            "500mV",
            "200mV",
            "100mV"});
            this.vertical_math_scale.Location = new System.Drawing.Point(1146, 498);
            this.vertical_math_scale.Name = "vertical_math_scale";
            this.vertical_math_scale.Size = new System.Drawing.Size(95, 20);
            this.vertical_math_scale.TabIndex = 57;
            // 
            // vertical_math_position
            // 
            this.vertical_math_position.FormattingEnabled = true;
            this.vertical_math_position.Items.AddRange(new object[] {
            "5",
            "4.5",
            "4",
            "3.5",
            "3",
            "2.5",
            "2",
            "1.5",
            "1",
            "0.5",
            "0",
            "-0.5",
            "-1",
            "-1.5",
            "-2",
            "-2.5",
            "-3",
            "-3.5",
            "-4",
            "-4.5",
            "-5"});
            this.vertical_math_position.Location = new System.Drawing.Point(986, 524);
            this.vertical_math_position.Name = "vertical_math_position";
            this.vertical_math_position.Size = new System.Drawing.Size(95, 20);
            this.vertical_math_position.TabIndex = 58;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1285, 610);
            this.Controls.Add(this.vertical_math_position);
            this.Controls.Add(this.vertical_math_scale);
            this.Controls.Add(this.math_source);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.probe2_select);
            this.Controls.Add(this.amp2_type);
            this.Controls.Add(this.vertical2_position);
            this.Controls.Add(this.vertical2_scale);
            this.Controls.Add(this.coupling2_select);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.vertical1_position);
            this.Controls.Add(this.probe1_select);
            this.Controls.Add(this.amp1_type);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.vertical1_scale);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.coupling1_select);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.measure_value_6);
            this.Controls.Add(this.measure_value_5);
            this.Controls.Add(this.measure_value_4);
            this.Controls.Add(this.measure_value_3);
            this.Controls.Add(this.measure_value_2);
            this.Controls.Add(this.measure_value_1);
            this.Controls.Add(this.measure_select_6);
            this.Controls.Add(this.measure_select_5);
            this.Controls.Add(this.measure_select_4);
            this.Controls.Add(this.measure_select_3);
            this.Controls.Add(this.measure_select_2);
            this.Controls.Add(this.measure_select_1);
            this.Controls.Add(this.chanel_select_6);
            this.Controls.Add(this.chanel_select_5);
            this.Controls.Add(this.chanel_select_4);
            this.Controls.Add(this.chanel_select_3);
            this.Controls.Add(this.chanel_select_2);
            this.Controls.Add(this.chanel_select_1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.math_toogle);
            this.Controls.Add(this.ch2_toogle);
            this.Controls.Add(this.ch1_toogle);
            this.Controls.Add(this.open_session);
            this.Controls.Add(this.screen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Button open_session;
        private System.Windows.Forms.CheckBox ch1_toogle;
        private System.Windows.Forms.CheckBox ch2_toogle;
        private System.Windows.Forms.CheckBox math_toogle;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox chanel_select_1;
        private System.Windows.Forms.ComboBox chanel_select_2;
        private System.Windows.Forms.ComboBox chanel_select_3;
        private System.Windows.Forms.ComboBox chanel_select_4;
        private System.Windows.Forms.ComboBox chanel_select_5;
        private System.Windows.Forms.ComboBox chanel_select_6;
        private System.Windows.Forms.ComboBox measure_select_1;
        private System.Windows.Forms.ComboBox measure_select_2;
        private System.Windows.Forms.ComboBox measure_select_3;
        private System.Windows.Forms.ComboBox measure_select_4;
        private System.Windows.Forms.ComboBox measure_select_5;
        private System.Windows.Forms.ComboBox measure_select_6;
        private System.Windows.Forms.TextBox measure_value_1;
        private System.Windows.Forms.TextBox measure_value_2;
        private System.Windows.Forms.TextBox measure_value_3;
        private System.Windows.Forms.TextBox measure_value_4;
        private System.Windows.Forms.TextBox measure_value_5;
        private System.Windows.Forms.TextBox measure_value_6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox coupling1_select;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox vertical1_scale;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox amp1_type;
        private System.Windows.Forms.ComboBox probe1_select;
        private System.Windows.Forms.ComboBox vertical1_position;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox coupling2_select;
        private System.Windows.Forms.ComboBox vertical2_scale;
        private System.Windows.Forms.ComboBox vertical2_position;
        private System.Windows.Forms.ComboBox amp2_type;
        private System.Windows.Forms.ComboBox probe2_select;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox math_source;
        private System.Windows.Forms.ComboBox vertical_math_scale;
        private System.Windows.Forms.ComboBox vertical_math_position;
    }
}

