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

namespace Graphic_test_3
{
    public partial class SelectResource : Form
    {
        public SelectResource()
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

        private void SelectResource_Load(object sender, EventArgs e)
        {
            using(var rmSession = new ResourceManager())
            {
                foreach(string s in rmSession.Find("(USB)?*INSTR*"))
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
