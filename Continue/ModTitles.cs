using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.Continue.Modify.Titles
{
    public partial class ModTitles : Form
    {
        public ModTitles()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain();
            main.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            rbIsBrand.Enabled = true;
            cbxSpec.Enabled = true;
            cbxGenre.Enabled = true;
        }

        private void rbIsBrand_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscBrand.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain();
            main.Show();
            this.Hide();
        }
    }
}
