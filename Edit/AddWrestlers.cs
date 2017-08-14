using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Edit.Wrestlers.SelectTitles;

namespace Super_Fight.Edit.Wrestlers
{
    public partial class AddWrestlers : Form
    {
        public AddWrestlers()
        {
            InitializeComponent();
        }

        private void rbIsCo_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscCo.Enabled = true;
        }

        private void rbIsBrand_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscBrand.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void rbIsTitle_CheckedChanged(object sender, EventArgs e)
        {
            btnSelTitles.Enabled = true;
        }

        private void btnCreateWrest_Click(object sender, EventArgs e)
        {
            btnCreateWrest.Enabled = false;
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            rbIsCo.Enabled = true;
            rbIsTitle.Enabled = true;
            rbIsBrand.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
        }

        private void btnEditWrestler_Click(object sender, EventArgs e)
        {
            btnCreateWrest.Enabled = false;
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            rbIsCo.Enabled = true;
            rbIsTitle.Enabled = true;
            rbIsBrand.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            btnEditWrestler.Enabled = false;
        }

        private void btnSelTitles_Click(object sender, EventArgs e)
        {
            WrestlerSelTitles selTitles = new WrestlerSelTitles();
            selTitles.Show();
        }
    }
}
