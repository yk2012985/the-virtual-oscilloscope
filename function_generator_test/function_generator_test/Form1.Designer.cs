namespace function_generator_test
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
            this.ch1_toogle = new System.Windows.Forms.CheckBox();
            this.ch2_toogle = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ch1_wave_select = new System.Windows.Forms.ComboBox();
            this.freq1 = new System.Windows.Forms.TextBox();
            this.amplitude1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.offset1 = new System.Windows.Forms.TextBox();
            this.period1_text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.high_level1 = new System.Windows.Forms.TextBox();
            this.low_level1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.duty_cycle1 = new System.Windows.Forms.Label();
            this.duty_cycle1_text = new System.Windows.Forms.TextBox();
            this.x_0 = new System.Windows.Forms.Label();
            this.x_1 = new System.Windows.Forms.Label();
            this.x_2 = new System.Windows.Forms.Label();
            this.x_3 = new System.Windows.Forms.Label();
            this.x_4 = new System.Windows.Forms.Label();
            this.time_unit = new System.Windows.Forms.Label();
            this.fre1_unit = new System.Windows.Forms.ComboBox();
            this.period1_unit = new System.Windows.Forms.ComboBox();
            this.y_0 = new System.Windows.Forms.Label();
            this.y_1 = new System.Windows.Forms.Label();
            this.y_2 = new System.Windows.Forms.Label();
            this.amplitude_unit = new System.Windows.Forms.Label();
            this.vpp_u = new System.Windows.Forms.ComboBox();
            this.offset1_u = new System.Windows.Forms.ComboBox();
            this.high_level1_u = new System.Windows.Forms.ComboBox();
            this.low_level1_u = new System.Windows.Forms.ComboBox();
            this.label_phase = new System.Windows.Forms.Label();
            this.phase1 = new System.Windows.Forms.TextBox();
            this.phase1_u = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ch1_toogle
            // 
            this.ch1_toogle.AutoSize = true;
            this.ch1_toogle.Location = new System.Drawing.Point(91, 377);
            this.ch1_toogle.Name = "ch1_toogle";
            this.ch1_toogle.Size = new System.Drawing.Size(42, 16);
            this.ch1_toogle.TabIndex = 0;
            this.ch1_toogle.Text = "CH1";
            this.ch1_toogle.UseVisualStyleBackColor = true;
            this.ch1_toogle.CheckedChanged += new System.EventHandler(this.ch1_toogle_CheckedChanged);
            // 
            // ch2_toogle
            // 
            this.ch2_toogle.AutoSize = true;
            this.ch2_toogle.Location = new System.Drawing.Point(534, 357);
            this.ch2_toogle.Name = "ch2_toogle";
            this.ch2_toogle.Size = new System.Drawing.Size(42, 16);
            this.ch2_toogle.TabIndex = 1;
            this.ch2_toogle.Text = "CH2";
            this.ch2_toogle.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(230, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "波形";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 424);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "频率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 458);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "幅度";
            // 
            // ch1_wave_select
            // 
            this.ch1_wave_select.FormattingEnabled = true;
            this.ch1_wave_select.Items.AddRange(new object[] {
            "正弦波",
            "方波",
            "三角波",
            "脉冲波",
            "调制波",
            "噪声波"});
            this.ch1_wave_select.Location = new System.Drawing.Point(278, 381);
            this.ch1_wave_select.Name = "ch1_wave_select";
            this.ch1_wave_select.Size = new System.Drawing.Size(121, 20);
            this.ch1_wave_select.TabIndex = 5;
            this.ch1_wave_select.SelectedIndexChanged += new System.EventHandler(this.ch1_wave_select_SelectedIndexChanged);
            // 
            // freq1
            // 
            this.freq1.Location = new System.Drawing.Point(91, 424);
            this.freq1.Name = "freq1";
            this.freq1.Size = new System.Drawing.Size(75, 21);
            this.freq1.TabIndex = 6;
            this.freq1.TextChanged += new System.EventHandler(this.freq1_TextChanged);
            this.freq1.Leave += new System.EventHandler(this.freq1_Leave);
            // 
            // amplitude1
            // 
            this.amplitude1.Location = new System.Drawing.Point(91, 458);
            this.amplitude1.Name = "amplitude1";
            this.amplitude1.Size = new System.Drawing.Size(75, 21);
            this.amplitude1.TabIndex = 7;
            this.amplitude1.Leave += new System.EventHandler(this.amplitude1_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 489);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "偏置";
            // 
            // offset1
            // 
            this.offset1.Location = new System.Drawing.Point(91, 486);
            this.offset1.Name = "offset1";
            this.offset1.Size = new System.Drawing.Size(75, 21);
            this.offset1.TabIndex = 9;
            this.offset1.Leave += new System.EventHandler(this.offset_Leave);
            // 
            // period1_text
            // 
            this.period1_text.Location = new System.Drawing.Point(278, 423);
            this.period1_text.Name = "period1_text";
            this.period1_text.Size = new System.Drawing.Size(74, 21);
            this.period1_text.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "周期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(230, 458);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "高电平";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(230, 492);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "低电平";
            // 
            // high_level1
            // 
            this.high_level1.Location = new System.Drawing.Point(278, 458);
            this.high_level1.Name = "high_level1";
            this.high_level1.Size = new System.Drawing.Size(74, 21);
            this.high_level1.TabIndex = 14;
            this.high_level1.Leave += new System.EventHandler(this.high_level1_Leave);
            // 
            // low_level1
            // 
            this.low_level1.Location = new System.Drawing.Point(278, 492);
            this.low_level1.Name = "low_level1";
            this.low_level1.Size = new System.Drawing.Size(74, 21);
            this.low_level1.TabIndex = 15;
            this.low_level1.Leave += new System.EventHandler(this.low_level1_Leave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(360, 260);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // duty_cycle1
            // 
            this.duty_cycle1.AutoSize = true;
            this.duty_cycle1.Location = new System.Drawing.Point(230, 523);
            this.duty_cycle1.Name = "duty_cycle1";
            this.duty_cycle1.Size = new System.Drawing.Size(41, 12);
            this.duty_cycle1.TabIndex = 17;
            this.duty_cycle1.Text = "占空比";
            this.duty_cycle1.Visible = false;
            // 
            // duty_cycle1_text
            // 
            this.duty_cycle1_text.Location = new System.Drawing.Point(278, 522);
            this.duty_cycle1_text.Name = "duty_cycle1_text";
            this.duty_cycle1_text.Size = new System.Drawing.Size(121, 21);
            this.duty_cycle1_text.TabIndex = 18;
            this.duty_cycle1_text.Visible = false;
            // 
            // x_0
            // 
            this.x_0.AutoSize = true;
            this.x_0.Location = new System.Drawing.Point(41, 313);
            this.x_0.Name = "x_0";
            this.x_0.Size = new System.Drawing.Size(11, 12);
            this.x_0.TabIndex = 19;
            this.x_0.Text = "0";
            // 
            // x_1
            // 
            this.x_1.AutoSize = true;
            this.x_1.Location = new System.Drawing.Point(131, 313);
            this.x_1.Name = "x_1";
            this.x_1.Size = new System.Drawing.Size(17, 12);
            this.x_1.TabIndex = 20;
            this.x_1.Text = "x1";
            // 
            // x_2
            // 
            this.x_2.AutoSize = true;
            this.x_2.Location = new System.Drawing.Point(221, 313);
            this.x_2.Name = "x_2";
            this.x_2.Size = new System.Drawing.Size(17, 12);
            this.x_2.TabIndex = 21;
            this.x_2.Text = "x2";
            // 
            // x_3
            // 
            this.x_3.AutoSize = true;
            this.x_3.Location = new System.Drawing.Point(311, 313);
            this.x_3.Name = "x_3";
            this.x_3.Size = new System.Drawing.Size(17, 12);
            this.x_3.TabIndex = 22;
            this.x_3.Text = "x3";
            // 
            // x_4
            // 
            this.x_4.AutoSize = true;
            this.x_4.Location = new System.Drawing.Point(401, 313);
            this.x_4.Name = "x_4";
            this.x_4.Size = new System.Drawing.Size(17, 12);
            this.x_4.TabIndex = 23;
            this.x_4.Text = "x4";
            // 
            // time_unit
            // 
            this.time_unit.AutoSize = true;
            this.time_unit.Location = new System.Drawing.Point(205, 336);
            this.time_unit.Name = "time_unit";
            this.time_unit.Size = new System.Drawing.Size(41, 12);
            this.time_unit.TabIndex = 24;
            this.time_unit.Text = "label8";
            // 
            // fre1_unit
            // 
            this.fre1_unit.FormattingEnabled = true;
            this.fre1_unit.Items.AddRange(new object[] {
            "Hz",
            "kHz",
            "MHz"});
            this.fre1_unit.Location = new System.Drawing.Point(172, 425);
            this.fre1_unit.Name = "fre1_unit";
            this.fre1_unit.Size = new System.Drawing.Size(40, 20);
            this.fre1_unit.TabIndex = 25;
            this.fre1_unit.SelectedIndexChanged += new System.EventHandler(this.fre1_unit_SelectedIndexChanged);
            // 
            // period1_unit
            // 
            this.period1_unit.FormattingEnabled = true;
            this.period1_unit.Items.AddRange(new object[] {
            "ms",
            "s"});
            this.period1_unit.Location = new System.Drawing.Point(357, 424);
            this.period1_unit.Name = "period1_unit";
            this.period1_unit.Size = new System.Drawing.Size(42, 20);
            this.period1_unit.TabIndex = 26;
            // 
            // y_0
            // 
            this.y_0.AutoSize = true;
            this.y_0.Location = new System.Drawing.Point(5, 298);
            this.y_0.Name = "y_0";
            this.y_0.Size = new System.Drawing.Size(17, 12);
            this.y_0.TabIndex = 27;
            this.y_0.Text = "y0";
            // 
            // y_1
            // 
            this.y_1.AutoSize = true;
            this.y_1.Location = new System.Drawing.Point(5, 180);
            this.y_1.Name = "y_1";
            this.y_1.Size = new System.Drawing.Size(17, 12);
            this.y_1.TabIndex = 28;
            this.y_1.Text = "y1";
            // 
            // y_2
            // 
            this.y_2.AutoSize = true;
            this.y_2.Location = new System.Drawing.Point(-1, 50);
            this.y_2.Name = "y_2";
            this.y_2.Size = new System.Drawing.Size(17, 12);
            this.y_2.TabIndex = 29;
            this.y_2.Text = "y2";
            // 
            // amplitude_unit
            // 
            this.amplitude_unit.AutoSize = true;
            this.amplitude_unit.Location = new System.Drawing.Point(3, 104);
            this.amplitude_unit.Name = "amplitude_unit";
            this.amplitude_unit.Size = new System.Drawing.Size(41, 12);
            this.amplitude_unit.TabIndex = 30;
            this.amplitude_unit.Text = "label8";
            // 
            // vpp_u
            // 
            this.vpp_u.FormattingEnabled = true;
            this.vpp_u.Items.AddRange(new object[] {
            "mVpp",
            "Vpp"});
            this.vpp_u.Location = new System.Drawing.Point(172, 458);
            this.vpp_u.Name = "vpp_u";
            this.vpp_u.Size = new System.Drawing.Size(40, 20);
            this.vpp_u.TabIndex = 31;
            // 
            // offset1_u
            // 
            this.offset1_u.FormattingEnabled = true;
            this.offset1_u.Items.AddRange(new object[] {
            "mV",
            "V"});
            this.offset1_u.Location = new System.Drawing.Point(172, 489);
            this.offset1_u.Name = "offset1_u";
            this.offset1_u.Size = new System.Drawing.Size(40, 20);
            this.offset1_u.TabIndex = 32;
            // 
            // high_level1_u
            // 
            this.high_level1_u.FormattingEnabled = true;
            this.high_level1_u.Items.AddRange(new object[] {
            "mV",
            "V"});
            this.high_level1_u.Location = new System.Drawing.Point(357, 458);
            this.high_level1_u.Name = "high_level1_u";
            this.high_level1_u.Size = new System.Drawing.Size(42, 20);
            this.high_level1_u.TabIndex = 33;
            // 
            // low_level1_u
            // 
            this.low_level1_u.FormattingEnabled = true;
            this.low_level1_u.Items.AddRange(new object[] {
            "mV",
            "V"});
            this.low_level1_u.Location = new System.Drawing.Point(357, 492);
            this.low_level1_u.Name = "low_level1_u";
            this.low_level1_u.Size = new System.Drawing.Size(42, 20);
            this.low_level1_u.TabIndex = 34;
            // 
            // label_phase
            // 
            this.label_phase.AutoSize = true;
            this.label_phase.Location = new System.Drawing.Point(45, 520);
            this.label_phase.Name = "label_phase";
            this.label_phase.Size = new System.Drawing.Size(29, 12);
            this.label_phase.TabIndex = 35;
            this.label_phase.Text = "相位";
            // 
            // phase1
            // 
            this.phase1.Location = new System.Drawing.Point(91, 520);
            this.phase1.Name = "phase1";
            this.phase1.Size = new System.Drawing.Size(75, 21);
            this.phase1.TabIndex = 36;
            this.phase1.Leave += new System.EventHandler(this.phase1_Leave);
            // 
            // phase1_u
            // 
            this.phase1_u.FormattingEnabled = true;
            this.phase1_u.Items.AddRange(new object[] {
            "弧度",
            "角度"});
            this.phase1_u.Location = new System.Drawing.Point(173, 520);
            this.phase1_u.Name = "phase1_u";
            this.phase1_u.Size = new System.Drawing.Size(39, 20);
            this.phase1_u.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 614);
            this.Controls.Add(this.phase1_u);
            this.Controls.Add(this.phase1);
            this.Controls.Add(this.label_phase);
            this.Controls.Add(this.low_level1_u);
            this.Controls.Add(this.high_level1_u);
            this.Controls.Add(this.offset1_u);
            this.Controls.Add(this.vpp_u);
            this.Controls.Add(this.amplitude_unit);
            this.Controls.Add(this.y_2);
            this.Controls.Add(this.y_1);
            this.Controls.Add(this.y_0);
            this.Controls.Add(this.period1_unit);
            this.Controls.Add(this.fre1_unit);
            this.Controls.Add(this.time_unit);
            this.Controls.Add(this.x_4);
            this.Controls.Add(this.x_3);
            this.Controls.Add(this.x_2);
            this.Controls.Add(this.x_1);
            this.Controls.Add(this.x_0);
            this.Controls.Add(this.duty_cycle1_text);
            this.Controls.Add(this.duty_cycle1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.low_level1);
            this.Controls.Add(this.high_level1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.period1_text);
            this.Controls.Add(this.offset1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.amplitude1);
            this.Controls.Add(this.freq1);
            this.Controls.Add(this.ch1_wave_select);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ch2_toogle);
            this.Controls.Add(this.ch1_toogle);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ch1_toogle;
        private System.Windows.Forms.CheckBox ch2_toogle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox ch1_wave_select;
        private System.Windows.Forms.TextBox freq1;
        private System.Windows.Forms.TextBox amplitude1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox offset1;
        private System.Windows.Forms.TextBox period1_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox high_level1;
        private System.Windows.Forms.TextBox low_level1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label duty_cycle1;
        private System.Windows.Forms.TextBox duty_cycle1_text;
        private System.Windows.Forms.Label x_0;
        private System.Windows.Forms.Label x_1;
        private System.Windows.Forms.Label x_2;
        private System.Windows.Forms.Label x_3;
        private System.Windows.Forms.Label x_4;
        private System.Windows.Forms.Label time_unit;
        private System.Windows.Forms.ComboBox fre1_unit;
        private System.Windows.Forms.ComboBox period1_unit;
        private System.Windows.Forms.Label y_0;
        private System.Windows.Forms.Label y_1;
        private System.Windows.Forms.Label y_2;
        private System.Windows.Forms.Label amplitude_unit;
        private System.Windows.Forms.ComboBox vpp_u;
        private System.Windows.Forms.ComboBox offset1_u;
        private System.Windows.Forms.ComboBox high_level1_u;
        private System.Windows.Forms.ComboBox low_level1_u;
        private System.Windows.Forms.Label label_phase;
        private System.Windows.Forms.TextBox phase1;
        private System.Windows.Forms.ComboBox phase1_u;
    }
}

