using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.Continue.Modify.Wrestlers
{
    public partial class ModWrestler : Form
    {
        public ModWrestler()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            rbIsBrand.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            rbIsTitle.Enabled = true;
        }

        private void rbIsBrand_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscBrand.Enabled = true;
        }

        private void rbIsTitle_CheckedChanged(object sender, EventArgs e)
        {
            btnSelTitles.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain();
            main.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain();
            main.Show();
            this.Hide();
        }

        private void btnSelTitles_Click(object sender, EventArgs e)
        {
            ModWrestlerTitles title = new ModWrestlerTitles();
            title.Show();
        }
    }
}
