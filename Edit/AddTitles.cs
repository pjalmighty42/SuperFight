using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.Edit.Titles
{
    public partial class AddTitles : Form
    {
        public AddTitles()
        {
            InitializeComponent();
        }

        private void btnCreateChamp_Click(object sender, EventArgs e)
        {
            btnCreateChamp.Enabled = false;
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            cbxAsscOrg.Enabled = true;
            cbxSpec.Enabled = true;
            cbxGenre.Enabled = true;
            btnAddWrest.Enabled = true;
        }

        private void btnEditChamp_Click(object sender, EventArgs e)
        {
            btnCreateChamp.Enabled = false;
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            cbxAsscOrg.Enabled = true;
            cbxSpec.Enabled = true;
            cbxGenre.Enabled = true;
            btnAddWrest.Enabled = true;
            btnEditChamp.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void btnAddWrest_Click(object sender, EventArgs e)
        {
            AddTitlesAssignWrest wrest = new AddTitlesAssignWrest();
            wrest.Show();
        }
    }
}
