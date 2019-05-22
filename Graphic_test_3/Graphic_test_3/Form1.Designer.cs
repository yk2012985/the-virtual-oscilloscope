namespace Graphic_test_3
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
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
        protected override void Dispose(bool disposing)
        {
            if (disposing)
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.openSessionButton = new System.Windows.Forms.Button();
            this.closeSessionButton = new System.Windows.Forms.Button();
            this.writeButton = new System.Windows.Forms.Button();
            this.readButton = new System.Windows.Forms.Button();
            this.readTextBox = new System.Windows.Forms.TextBox();
            this.writeTextBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.elementsTransferedTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lastIOStatusTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chanel_select_1 = new System.Windows.Forms.ComboBox();
            this.messure_select_1 = new System.Windows.Forms.ComboBox();
            this.measure_value_1 = new System.Windows.Forms.TextBox();
            this.get_wave = new System.Windows.Forms.Button();
            this.chanel_select_2 = new System.Windows.Forms.ComboBox();
            this.messure_select_2 = new System.Windows.Forms.ComboBox();
            this.measure_value_2 = new System.Windows.Forms.TextBox();
            this.chanel_select_3 = new System.Windows.Forms.ComboBox();
            this.chanel_select_4 = new System.Windows.Forms.ComboBox();
            this.chanel_select_5 = new System.Windows.Forms.ComboBox();
            this.chanel_select_6 = new System.Windows.Forms.ComboBox();
            this.messure_select_3 = new System.Windows.Forms.ComboBox();
            this.messure_select_4 = new System.Windows.Forms.ComboBox();
            this.messure_select_5 = new System.Windows.Forms.ComboBox();
            this.messure_select_6 = new System.Windows.Forms.ComboBox();
            this.measure_value_3 = new System.Windows.Forms.TextBox();
            this.measure_value_4 = new System.Windows.Forms.TextBox();
            this.measure_value_5 = new System.Windows.Forms.TextBox();
            this.measure_value_6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chanel1_toogle = new System.Windows.Forms.CheckBox();
            this.chanel2_toogle = new System.Windows.Forms.CheckBox();
            this.coupling1_select = new System.Windows.Forms.ComboBox();
            this.probe1_select = new System.Windows.Forms.ComboBox();
            this.vertical1_scale = new System.Windows.Forms.ComboBox();
            this.vertical1_position = new System.Windows.Forms.ComboBox();
            this.coupling2_select = new System.Windows.Forms.ComboBox();
            this.probe2_select = new System.Windows.Forms.ComboBox();
            this.vertical2_scale = new System.Windows.Forms.ComboBox();
            this.vertical2_position = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.math_toogle = new System.Windows.Forms.CheckBox();
            this.math_source = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.vertical_math_position = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.vertical_math_scale = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.amp1_type = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.amp2_type = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 480);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // openSessionButton
            // 
            this.openSessionButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.openSessionButton.Location = new System.Drawing.Point(13, 510);
            this.openSessionButton.Name = "openSessionButton";
            this.openSessionButton.Size = new System.Drawing.Size(128, 23);
            this.openSessionButton.TabIndex = 1;
            this.openSessionButton.Text = "Open Session";
            this.openSessionButton.UseVisualStyleBackColor = true;
            this.openSessionButton.Click += new System.EventHandler(this.openSessionButton_Click);
            // 
            // closeSessionButton
            // 
            this.closeSessionButton.Location = new System.Drawing.Point(199, 510);
            this.closeSessionButton.Name = "closeSessionButton";
            this.closeSessionButton.Size = new System.Drawing.Size(128, 23);
            this.closeSessionButton.TabIndex = 2;
            this.closeSessionButton.Text = "Close Session";
            this.closeSessionButton.UseVisualStyleBackColor = true;
            this.closeSessionButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // writeButton
            // 
            this.writeButton.Location = new System.Drawing.Point(13, 540);
            this.writeButton.Name = "writeButton";
            this.writeButton.Size = new System.Drawing.Size(75, 23);
            this.writeButton.TabIndex = 3;
            this.writeButton.Text = "Write";
            this.writeButton.UseVisualStyleBackColor = true;
            this.writeButton.Click += new System.EventHandler(this.writeButton_Click);
            // 
            // readButton
            // 
            this.readButton.Location = new System.Drawing.Point(133, 540);
            this.readButton.Name = "readButton";
            this.readButton.Size = new System.Drawing.Size(75, 23);
            this.readButton.TabIndex = 4;
            this.readButton.Text = "Read";
            this.readButton.UseVisualStyleBackColor = true;
            this.readButton.Click += new System.EventHandler(this.readButton_Click);
            // 
            // readTextBox
            // 
            this.readTextBox.Location = new System.Drawing.Point(333, 510);
            this.readTextBox.Multiline = true;
            this.readTextBox.Name = "readTextBox";
            this.readTextBox.Size = new System.Drawing.Size(579, 127);
            this.readTextBox.TabIndex = 5;
            // 
            // writeTextBox
            // 
            this.writeTextBox.Location = new System.Drawing.Point(13, 581);
            this.writeTextBox.Name = "writeTextBox";
            this.writeTextBox.Size = new System.Drawing.Size(314, 21);
            this.writeTextBox.TabIndex = 6;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(245, 539);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // elementsTransferedTextBox
            // 
            this.elementsTransferedTextBox.Location = new System.Drawing.Point(975, 616);
            this.elementsTransferedTextBox.Name = "elementsTransferedTextBox";
            this.elementsTransferedTextBox.Size = new System.Drawing.Size(132, 21);
            this.elementsTransferedTextBox.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(976, 598);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "Elements Transferred:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(926, 551);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "Last I/O Status";
            // 
            // lastIOStatusTextBox
            // 
            this.lastIOStatusTextBox.Location = new System.Drawing.Point(926, 567);
            this.lastIOStatusTextBox.Name = "lastIOStatusTextBox";
            this.lastIOStatusTextBox.Size = new System.Drawing.Size(287, 21);
            this.lastIOStatusTextBox.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(922, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "测量";
            // 
            // chanel_select_1
            // 
            this.chanel_select_1.FormattingEnabled = true;
            this.chanel_select_1.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_1.Location = new System.Drawing.Point(922, 44);
            this.chanel_select_1.Name = "chanel_select_1";
            this.chanel_select_1.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_1.TabIndex = 13;
            this.chanel_select_1.SelectedIndexChanged += new System.EventHandler(this.chanel_select_1_SelectedIndexChanged);
            // 
            // messure_select_1
            // 
            this.messure_select_1.FormattingEnabled = true;
            this.messure_select_1.Items.AddRange(new object[] {
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
            this.messure_select_1.Location = new System.Drawing.Point(1023, 44);
            this.messure_select_1.Name = "messure_select_1";
            this.messure_select_1.Size = new System.Drawing.Size(121, 20);
            this.messure_select_1.TabIndex = 14;
            // 
            // measure_value_1
            // 
            this.measure_value_1.Location = new System.Drawing.Point(1150, 44);
            this.measure_value_1.Name = "measure_value_1";
            this.measure_value_1.Size = new System.Drawing.Size(143, 21);
            this.measure_value_1.TabIndex = 15;
            // 
            // get_wave
            // 
            this.get_wave.BackColor = System.Drawing.Color.Tomato;
            this.get_wave.ForeColor = System.Drawing.SystemColors.Info;
            this.get_wave.Location = new System.Drawing.Point(1119, 218);
            this.get_wave.Name = "get_wave";
            this.get_wave.Size = new System.Drawing.Size(72, 24);
            this.get_wave.TabIndex = 16;
            this.get_wave.Text = "获取波形";
            this.get_wave.UseVisualStyleBackColor = false;
            this.get_wave.Click += new System.EventHandler(this.get_wave_Click);
            // 
            // chanel_select_2
            // 
            this.chanel_select_2.FormattingEnabled = true;
            this.chanel_select_2.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_2.Location = new System.Drawing.Point(922, 70);
            this.chanel_select_2.Name = "chanel_select_2";
            this.chanel_select_2.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_2.TabIndex = 17;
            this.chanel_select_2.SelectedIndexChanged += new System.EventHandler(this.chanel_select_2_SelectedIndexChanged);
            // 
            // messure_select_2
            // 
            this.messure_select_2.FormattingEnabled = true;
            this.messure_select_2.Items.AddRange(new object[] {
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
            this.messure_select_2.Location = new System.Drawing.Point(1024, 70);
            this.messure_select_2.Name = "messure_select_2";
            this.messure_select_2.Size = new System.Drawing.Size(120, 20);
            this.messure_select_2.TabIndex = 18;
            // 
            // measure_value_2
            // 
            this.measure_value_2.Location = new System.Drawing.Point(1150, 69);
            this.measure_value_2.Name = "measure_value_2";
            this.measure_value_2.Size = new System.Drawing.Size(143, 21);
            this.measure_value_2.TabIndex = 19;
            // 
            // chanel_select_3
            // 
            this.chanel_select_3.FormattingEnabled = true;
            this.chanel_select_3.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_3.Location = new System.Drawing.Point(922, 96);
            this.chanel_select_3.Name = "chanel_select_3";
            this.chanel_select_3.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_3.TabIndex = 20;
            this.chanel_select_3.SelectedIndexChanged += new System.EventHandler(this.chanel_select_3_SelectedIndexChanged);
            // 
            // chanel_select_4
            // 
            this.chanel_select_4.FormattingEnabled = true;
            this.chanel_select_4.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_4.Location = new System.Drawing.Point(922, 123);
            this.chanel_select_4.Name = "chanel_select_4";
            this.chanel_select_4.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_4.TabIndex = 21;
            this.chanel_select_4.SelectedIndexChanged += new System.EventHandler(this.chanel_select_4_SelectedIndexChanged);
            // 
            // chanel_select_5
            // 
            this.chanel_select_5.FormattingEnabled = true;
            this.chanel_select_5.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_5.Location = new System.Drawing.Point(922, 150);
            this.chanel_select_5.Name = "chanel_select_5";
            this.chanel_select_5.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_5.TabIndex = 22;
            this.chanel_select_5.SelectedIndexChanged += new System.EventHandler(this.chanel_select_5_SelectedIndexChanged);
            // 
            // chanel_select_6
            // 
            this.chanel_select_6.FormattingEnabled = true;
            this.chanel_select_6.Items.AddRange(new object[] {
            "CH1",
            "CH2"});
            this.chanel_select_6.Location = new System.Drawing.Point(922, 177);
            this.chanel_select_6.Name = "chanel_select_6";
            this.chanel_select_6.Size = new System.Drawing.Size(95, 20);
            this.chanel_select_6.TabIndex = 23;
            this.chanel_select_6.SelectedIndexChanged += new System.EventHandler(this.chanel_select_6_SelectedIndexChanged);
            // 
            // messure_select_3
            // 
            this.messure_select_3.FormattingEnabled = true;
            this.messure_select_3.Items.AddRange(new object[] {
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
            this.messure_select_3.Location = new System.Drawing.Point(1023, 97);
            this.messure_select_3.Name = "messure_select_3";
            this.messure_select_3.Size = new System.Drawing.Size(121, 20);
            this.messure_select_3.TabIndex = 24;
            // 
            // messure_select_4
            // 
            this.messure_select_4.FormattingEnabled = true;
            this.messure_select_4.Items.AddRange(new object[] {
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
            this.messure_select_4.Location = new System.Drawing.Point(1023, 123);
            this.messure_select_4.Name = "messure_select_4";
            this.messure_select_4.Size = new System.Drawing.Size(121, 20);
            this.messure_select_4.TabIndex = 25;
            // 
            // messure_select_5
            // 
            this.messure_select_5.FormattingEnabled = true;
            this.messure_select_5.Items.AddRange(new object[] {
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
            this.messure_select_5.Location = new System.Drawing.Point(1023, 149);
            this.messure_select_5.Name = "messure_select_5";
            this.messure_select_5.Size = new System.Drawing.Size(121, 20);
            this.messure_select_5.TabIndex = 26;
            // 
            // messure_select_6
            // 
            this.messure_select_6.FormattingEnabled = true;
            this.messure_select_6.Items.AddRange(new object[] {
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
            this.messure_select_6.Location = new System.Drawing.Point(1023, 176);
            this.messure_select_6.Name = "messure_select_6";
            this.messure_select_6.Size = new System.Drawing.Size(121, 20);
            this.messure_select_6.TabIndex = 27;
            // 
            // measure_value_3
            // 
            this.measure_value_3.Location = new System.Drawing.Point(1150, 96);
            this.measure_value_3.Name = "measure_value_3";
            this.measure_value_3.Size = new System.Drawing.Size(143, 21);
            this.measure_value_3.TabIndex = 28;
            // 
            // measure_value_4
            // 
            this.measure_value_4.Location = new System.Drawing.Point(1150, 121);
            this.measure_value_4.Name = "measure_value_4";
            this.measure_value_4.Size = new System.Drawing.Size(143, 21);
            this.measure_value_4.TabIndex = 29;
            // 
            // measure_value_5
            // 
            this.measure_value_5.Location = new System.Drawing.Point(1150, 147);
            this.measure_value_5.Name = "measure_value_5";
            this.measure_value_5.Size = new System.Drawing.Size(143, 21);
            this.measure_value_5.TabIndex = 30;
            // 
            // measure_value_6
            // 
            this.measure_value_6.Location = new System.Drawing.Point(1150, 174);
            this.measure_value_6.Name = "measure_value_6";
            this.measure_value_6.Size = new System.Drawing.Size(143, 21);
            this.measure_value_6.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("黑体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(922, 213);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 24);
            this.label4.TabIndex = 32;
            this.label4.Text = "垂直与水平操作";
            // 
            // chanel1_toogle
            // 
            this.chanel1_toogle.AutoSize = true;
            this.chanel1_toogle.Location = new System.Drawing.Point(922, 252);
            this.chanel1_toogle.Name = "chanel1_toogle";
            this.chanel1_toogle.Size = new System.Drawing.Size(42, 16);
            this.chanel1_toogle.TabIndex = 33;
            this.chanel1_toogle.Text = "CH1";
            this.chanel1_toogle.UseVisualStyleBackColor = true;
            this.chanel1_toogle.CheckedChanged += new System.EventHandler(this.chanel1_toogle_CheckedChanged);
            // 
            // chanel2_toogle
            // 
            this.chanel2_toogle.AutoSize = true;
            this.chanel2_toogle.Location = new System.Drawing.Point(922, 361);
            this.chanel2_toogle.Name = "chanel2_toogle";
            this.chanel2_toogle.Size = new System.Drawing.Size(42, 16);
            this.chanel2_toogle.TabIndex = 34;
            this.chanel2_toogle.Text = "CH2";
            this.chanel2_toogle.UseVisualStyleBackColor = true;
            this.chanel2_toogle.CheckedChanged += new System.EventHandler(this.chanel2_toogle_CheckedChanged);
            // 
            // coupling1_select
            // 
            this.coupling1_select.FormattingEnabled = true;
            this.coupling1_select.Items.AddRange(new object[] {
            "DC",
            "AC",
            "GND"});
            this.coupling1_select.Location = new System.Drawing.Point(985, 274);
            this.coupling1_select.Name = "coupling1_select";
            this.coupling1_select.Size = new System.Drawing.Size(121, 20);
            this.coupling1_select.TabIndex = 35;
            this.coupling1_select.SelectedIndexChanged += new System.EventHandler(this.coupling1_select_SelectedIndexChanged);
            // 
            // probe1_select
            // 
            this.probe1_select.FormattingEnabled = true;
            this.probe1_select.Location = new System.Drawing.Point(1172, 300);
            this.probe1_select.Name = "probe1_select";
            this.probe1_select.Size = new System.Drawing.Size(121, 20);
            this.probe1_select.TabIndex = 36;
            this.probe1_select.SelectedIndexChanged += new System.EventHandler(this.probe1_select_SelectedIndexChanged);
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
            this.vertical1_scale.Location = new System.Drawing.Point(985, 300);
            this.vertical1_scale.Name = "vertical1_scale";
            this.vertical1_scale.Size = new System.Drawing.Size(121, 20);
            this.vertical1_scale.TabIndex = 37;
            this.vertical1_scale.SelectedIndexChanged += new System.EventHandler(this.vertical1_scale_SelectedIndexChanged);
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
            "0V",
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
            this.vertical1_position.Location = new System.Drawing.Point(985, 326);
            this.vertical1_position.Name = "vertical1_position";
            this.vertical1_position.Size = new System.Drawing.Size(121, 20);
            this.vertical1_position.TabIndex = 38;
            this.vertical1_position.SelectedIndexChanged += new System.EventHandler(this.vertical1_position_SelectedIndexChanged);
            // 
            // coupling2_select
            // 
            this.coupling2_select.FormattingEnabled = true;
            this.coupling2_select.Items.AddRange(new object[] {
            "DC",
            "AC",
            "GND"});
            this.coupling2_select.Location = new System.Drawing.Point(985, 379);
            this.coupling2_select.Name = "coupling2_select";
            this.coupling2_select.Size = new System.Drawing.Size(121, 20);
            this.coupling2_select.TabIndex = 39;
            this.coupling2_select.SelectedIndexChanged += new System.EventHandler(this.coupling2_select_SelectedIndexChanged);
            // 
            // probe2_select
            // 
            this.probe2_select.FormattingEnabled = true;
            this.probe2_select.Location = new System.Drawing.Point(1172, 405);
            this.probe2_select.Name = "probe2_select";
            this.probe2_select.Size = new System.Drawing.Size(121, 20);
            this.probe2_select.TabIndex = 40;
            this.probe2_select.SelectedIndexChanged += new System.EventHandler(this.probe2_select_SelectedIndexChanged);
            // 
            // vertical2_scale
            // 
            this.vertical2_scale.FormattingEnabled = true;
            this.vertical2_scale.Items.AddRange(new object[] {
            "50V",
            "20V",
            "10V",
            "5V",
            "1V",
            "500mV",
            "200mV",
            "100mV"});
            this.vertical2_scale.Location = new System.Drawing.Point(985, 405);
            this.vertical2_scale.Name = "vertical2_scale";
            this.vertical2_scale.Size = new System.Drawing.Size(121, 20);
            this.vertical2_scale.TabIndex = 41;
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
            "0V",
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
            this.vertical2_position.Location = new System.Drawing.Point(986, 431);
            this.vertical2_position.Name = "vertical2_position";
            this.vertical2_position.Size = new System.Drawing.Size(121, 20);
            this.vertical2_position.TabIndex = 42;
            this.vertical2_position.SelectedIndexChanged += new System.EventHandler(this.vertical2_position_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(926, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 43;
            this.label5.Text = "耦合方式";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1113, 303);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 44;
            this.label6.Text = "探测衰减";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(926, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 45;
            this.label7.Text = "垂直标度";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(926, 329);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 46;
            this.label8.Text = "垂直位置";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(928, 386);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 47;
            this.label9.Text = "耦合方式";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(930, 412);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 48;
            this.label10.Text = "垂直标度";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1115, 412);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 49;
            this.label11.Text = "探测衰减";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(931, 438);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 50;
            this.label12.Text = "垂直位置";
            // 
            // math_toogle
            // 
            this.math_toogle.AutoSize = true;
            this.math_toogle.Location = new System.Drawing.Point(922, 466);
            this.math_toogle.Name = "math_toogle";
            this.math_toogle.Size = new System.Drawing.Size(48, 16);
            this.math_toogle.TabIndex = 51;
            this.math_toogle.Text = "MATH";
            this.math_toogle.UseVisualStyleBackColor = true;
            this.math_toogle.CheckedChanged += new System.EventHandler(this.math_toogle_CheckedChanged);
            // 
            // math_source
            // 
            this.math_source.FormattingEnabled = true;
            this.math_source.Items.AddRange(new object[] {
            "CH1+CH2",
            "CH1-CH2",
            "CH2-CH1",
            "CH2*CH1"});
            this.math_source.Location = new System.Drawing.Point(986, 486);
            this.math_source.Name = "math_source";
            this.math_source.Size = new System.Drawing.Size(121, 20);
            this.math_source.TabIndex = 52;
            this.math_source.SelectedIndexChanged += new System.EventHandler(this.math_source_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(928, 489);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 53;
            this.label13.Text = "操作方式";
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
            this.vertical_math_position.Location = new System.Drawing.Point(986, 512);
            this.vertical_math_position.Name = "vertical_math_position";
            this.vertical_math_position.Size = new System.Drawing.Size(121, 20);
            this.vertical_math_position.TabIndex = 54;
            this.vertical_math_position.SelectedIndexChanged += new System.EventHandler(this.vertical_math_position_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(928, 520);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 55;
            this.label14.Text = "垂直位置";
            // 
            // vertical_math_scale
            // 
            this.vertical_math_scale.FormattingEnabled = true;
            this.vertical_math_scale.Items.AddRange(new object[] {
            "50V",
            "20V",
            "10V",
            "5V",
            "2V",
            "1V",
            "500mV",
            "200mV",
            "100mV"});
            this.vertical_math_scale.Location = new System.Drawing.Point(1172, 485);
            this.vertical_math_scale.Name = "vertical_math_scale";
            this.vertical_math_scale.Size = new System.Drawing.Size(121, 20);
            this.vertical_math_scale.TabIndex = 56;
            this.vertical_math_scale.SelectedIndexChanged += new System.EventHandler(this.vertical_math_scale_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1115, 493);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 57;
            this.label15.Text = "垂直标度";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(1115, 281);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 58;
            this.label16.Text = "幅值类型";
            // 
            // amp1_type
            // 
            this.amp1_type.FormattingEnabled = true;
            this.amp1_type.Items.AddRange(new object[] {
            "电压V",
            "电流A"});
            this.amp1_type.Location = new System.Drawing.Point(1172, 277);
            this.amp1_type.Name = "amp1_type";
            this.amp1_type.Size = new System.Drawing.Size(121, 20);
            this.amp1_type.TabIndex = 59;
            this.amp1_type.SelectedIndexChanged += new System.EventHandler(this.amp1_type_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1117, 386);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 12);
            this.label17.TabIndex = 60;
            this.label17.Text = "幅值类型";
            // 
            // amp2_type
            // 
            this.amp2_type.FormattingEnabled = true;
            this.amp2_type.Items.AddRange(new object[] {
            "电压V",
            "电流A"});
            this.amp2_type.Location = new System.Drawing.Point(1172, 378);
            this.amp2_type.Name = "amp2_type";
            this.amp2_type.Size = new System.Drawing.Size(121, 20);
            this.amp2_type.TabIndex = 61;
            this.amp2_type.SelectedIndexChanged += new System.EventHandler(this.amp2_type_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1313, 638);
            this.Controls.Add(this.amp2_type);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.amp1_type);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.vertical_math_scale);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.vertical_math_position);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.math_source);
            this.Controls.Add(this.math_toogle);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.vertical2_position);
            this.Controls.Add(this.vertical2_scale);
            this.Controls.Add(this.probe2_select);
            this.Controls.Add(this.coupling2_select);
            this.Controls.Add(this.vertical1_position);
            this.Controls.Add(this.vertical1_scale);
            this.Controls.Add(this.probe1_select);
            this.Controls.Add(this.coupling1_select);
            this.Controls.Add(this.chanel2_toogle);
            this.Controls.Add(this.chanel1_toogle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.measure_value_6);
            this.Controls.Add(this.measure_value_5);
            this.Controls.Add(this.measure_value_4);
            this.Controls.Add(this.measure_value_3);
            this.Controls.Add(this.messure_select_6);
            this.Controls.Add(this.messure_select_5);
            this.Controls.Add(this.messure_select_4);
            this.Controls.Add(this.messure_select_3);
            this.Controls.Add(this.chanel_select_6);
            this.Controls.Add(this.chanel_select_5);
            this.Controls.Add(this.chanel_select_4);
            this.Controls.Add(this.chanel_select_3);
            this.Controls.Add(this.measure_value_2);
            this.Controls.Add(this.messure_select_2);
            this.Controls.Add(this.chanel_select_2);
            this.Controls.Add(this.get_wave);
            this.Controls.Add(this.measure_value_1);
            this.Controls.Add(this.messure_select_1);
            this.Controls.Add(this.chanel_select_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lastIOStatusTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.elementsTransferedTextBox);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.writeTextBox);
            this.Controls.Add(this.readTextBox);
            this.Controls.Add(this.readButton);
            this.Controls.Add(this.writeButton);
            this.Controls.Add(this.closeSessionButton);
            this.Controls.Add(this.openSessionButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "示波器";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button openSessionButton;
        private System.Windows.Forms.Button closeSessionButton;
        private System.Windows.Forms.Button writeButton;
        private System.Windows.Forms.Button readButton;
        private System.Windows.Forms.TextBox readTextBox;
        private System.Windows.Forms.TextBox writeTextBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.TextBox elementsTransferedTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox lastIOStatusTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox chanel_select_1;
        private System.Windows.Forms.ComboBox messure_select_1;
        private System.Windows.Forms.TextBox measure_value_1;
        private System.Windows.Forms.Button get_wave;
        private System.Windows.Forms.ComboBox chanel_select_2;
        private System.Windows.Forms.ComboBox messure_select_2;
        private System.Windows.Forms.TextBox measure_value_2;
        private System.Windows.Forms.ComboBox chanel_select_3;
        private System.Windows.Forms.ComboBox chanel_select_4;
        private System.Windows.Forms.ComboBox chanel_select_5;
        private System.Windows.Forms.ComboBox chanel_select_6;
        private System.Windows.Forms.ComboBox messure_select_3;
        private System.Windows.Forms.ComboBox messure_select_4;
        private System.Windows.Forms.ComboBox messure_select_5;
        private System.Windows.Forms.ComboBox messure_select_6;
        private System.Windows.Forms.TextBox measure_value_3;
        private System.Windows.Forms.TextBox measure_value_4;
        private System.Windows.Forms.TextBox measure_value_5;
        private System.Windows.Forms.TextBox measure_value_6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chanel1_toogle;
        private System.Windows.Forms.CheckBox chanel2_toogle;
        private System.Windows.Forms.ComboBox coupling1_select;
        private System.Windows.Forms.ComboBox probe1_select;
        private System.Windows.Forms.ComboBox vertical1_scale;
        private System.Windows.Forms.ComboBox vertical1_position;
        private System.Windows.Forms.ComboBox coupling2_select;
        private System.Windows.Forms.ComboBox probe2_select;
        private System.Windows.Forms.ComboBox vertical2_scale;
        private System.Windows.Forms.ComboBox vertical2_position;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox math_toogle;
        private System.Windows.Forms.ComboBox math_source;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox vertical_math_position;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox vertical_math_scale;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox amp1_type;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox amp2_type;
    }
}

