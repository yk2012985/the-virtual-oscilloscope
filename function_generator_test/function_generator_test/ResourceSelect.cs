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
    public partial class ResourceSelect : Form
    {
        public ResourceSelect()
        {
            InitializeComponent();
        }

        private void ResourceSelect_Load(object sender, EventArgs e)
        {
            try
            {
                using (var rmSession = new ResourceManager())
                {
                    foreach (string s in rmSession.Find("(USB)?*INSTR*"))
                    {
                        availableResourcesListBox.Items.Add(s);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.No;
            }
            
        }

        public string ResourceName
        {
            get
            {
                return visaResourceNameTextBox.Text;
            }
            set
            {
                visaResourceNameTextBox.Text = value;
            }
        }

        private void availableResourcesListBox_DoubleClick(object sender, EventArgs e)
        {
            string selectedString = (string)availableResourcesListBox.SelectedItem;
            ResourceName = selectedString;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
