using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rightClick
{
    public partial class Option : Form
    {
        private string[] toReturn;
        public Option(string[] toReturn)
        {
            InitializeComponent();
            this.toReturn = toReturn;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if(cbxMonth.Text != null && cbxMonth.SelectedIndex >= 0) toReturn[0] = cbxMonth.Text;
            toReturn[1] = "0";
            toReturn[2] = "0";
            toReturn[3] = "0";
            if (cbxSprint.Checked) toReturn[1] = "1";
            if (cbxGeneric.Checked) toReturn[2] = "1";
            if (cbxDirectory.Checked) toReturn[3] = "1";

            this.Close();
        }
    }
}
