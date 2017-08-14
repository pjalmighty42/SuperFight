using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.Continue.Modify.Teams
{
    public partial class ModTeams : Form
    {
        public ModTeams()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain();
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain();
            main.Show();
            this.Hide();
        }

        private void rbIsBrand_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscBrand.Enabled = true;
        }

        private void rbIsTitle_CheckedChanged(object sender, EventArgs e)
        {
            btnSelTitles.Enabled = true;
        }

        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            btnEditTeam.Enabled = false;
            btnDelTeam.Enabled = false;
            btnDisbandTeam.Enabled = true;
            tbNewName.Enabled = true;
            rbIsBrand.Enabled = true;
            rbIsTitle.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            btnAdjustTeam.Enabled = true;
        }

        private void btnAdjustTeam_Click(object sender, EventArgs e)
        {
            ModTeamsAdjMems aMems = new ModTeamsAdjMems();
            aMems.Show();
        }

        private void btnSelTitles_Click(object sender, EventArgs e)
        {
            ModTeamsTitles aTitles = new ModTeamsTitles();
            aTitles.Show();
        }
    }
}
