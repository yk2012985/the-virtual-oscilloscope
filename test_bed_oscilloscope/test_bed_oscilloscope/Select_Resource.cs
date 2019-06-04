using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NationalInstruments.Visa;
namespace test_bed_oscilloscope
{
    public partial class Select_Resource : Form
    {
        public Select_Resource()
        {
            InitializeComponent();
        }

        private void availableResourcesListBox_DoubleClick(object sender, EventArgs e)
        {
            string selectedString = (string)availableResourcesListBox.SelectedItem;
            ResourceName = selectedString;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Select_Resource_Load(object sender, EventArgs e)
        {
            using (var rmSession = new ResourceManager())
            {
                foreach (string s in rmSession.Find("(USB)?*INSTR*"))
                {
                    availableResourcesListBox.Items.Add(s);
                }
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

        private void availableResourcesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedString = (string)availableResourcesListBox.SelectedItem;
            ResourceName = selectedString;
        }
    }
}
