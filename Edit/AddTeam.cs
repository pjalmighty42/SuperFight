using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Entities;

namespace Super_Fight.Edit.Teams
{
    public partial class AddTeam : Form
    {
        List<Wrestlers> wrests = new List<Wrestlers>();
        List<Teams> teams = new List<Teams>();
        List<Titles> titles = new List<Titles>();

        WrestlerHelper wHelper = new WrestlerHelper();
        TeamHelper tHelper = new TeamHelper();
        TitleHelper tlHelper = new TitleHelper();

        public AddTeam()
        {
            InitializeComponent();

            wrests = wHelper.PopulateWrestlersList();

            if (wrests.Count == 0)
            {
                button4.Enabled = false;
                btnEditTeam.Enabled = false;
                btnCreateWrest.Enabled = false;
                tbNewName.Enabled = false;
                tbWins.Enabled = false;
                tbLosses.Enabled = false;
                tbDraws.Enabled = false;
                rbIsCo.Enabled = false;
                rbIsTitle.Enabled = false;
            }

            teams = tHelper.PopulateTeamsList();


        }

        private void btnCreateWrest_Click(object sender, EventArgs e)
        {
            btnCreateWrest.Enabled = false;
            tbNewName.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            rbIsCo.Enabled = true;
            rbIsTitle.Enabled = true;
            btnSelMembers.Enabled = true;
        }

        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            btnCreateWrest.Enabled = false;
            tbNewName.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            rbIsCo.Enabled = true;
            rbIsTitle.Enabled = true;
            btnSelMembers.Enabled = true;
            btnEditTeam.Enabled = false;
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

        private void rbIsCo_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscCo.Enabled = true;
        }

        private void rbIsTitle_CheckedChanged(object sender, EventArgs e)
        {
            btnSelTitles.Enabled = true;
        }

        private void btnSelTitles_Click(object sender, EventArgs e)
        {
            TeamSelTitles selTitles = new TeamSelTitles();
            selTitles.Show();
        }

        private void btnSelMembers_Click(object sender, EventArgs e)
        {
            TeamAddWrestlers wrest = new TeamAddWrestlers();
            wrest.Show();
        }
    }
}
