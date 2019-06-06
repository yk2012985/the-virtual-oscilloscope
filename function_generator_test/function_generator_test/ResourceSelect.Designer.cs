namespace function_generator_test
{
    partial class ResourceSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.availableResourcesListBox = new System.Windows.Forms.ListBox();
            this.visaResourceNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Resources:";
            // 
            // availableResourcesListBox
            // 
            this.availableResourcesListBox.FormattingEnabled = true;
            this.availableResourcesListBox.ItemHeight = 12;
            this.availableResourcesListBox.Location = new System.Drawing.Point(15, 41);
            this.availableResourcesListBox.Name = "availableResourcesListBox";
            this.availableResourcesListBox.Size = new System.Drawing.Size(325, 88);
            this.availableResourcesListBox.TabIndex = 1;
            this.availableResourcesListBox.DoubleClick += new System.EventHandler(this.availableResourcesListBox_DoubleClick);
            // 
            // visaResourceNameTextBox
            // 
            this.visaResourceNameTextBox.Location = new System.Drawing.Point(15, 173);
            this.visaResourceNameTextBox.Name = "visaResourceNameTextBox";
            this.visaResourceNameTextBox.Size = new System.Drawing.Size(325, 21);
            this.visaResourceNameTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resource String";
            // 
            // ResourceSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 230);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.visaResourceNameTextBox);
            this.Controls.Add(this.availableResourcesListBox);
            this.Controls.Add(this.label1);
            this.Name = "ResourceSelect";
            this.Text = "ResourceSelect";
            this.Load += new System.EventHandler(this.ResourceSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox availableResourcesListBox;
        private System.Windows.Forms.TextBox visaResourceNameTextBox;
        private System.Windows.Forms.Label label2;
    }
}