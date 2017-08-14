using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Entities;
using Super_Fight.Helpers;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Continue.Modify.Teams
{
    public partial class ModTeams : Form
    {
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        TeamHelper tHelper = new TeamHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public ModTeams(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);

            storeHelper.BrandsList = bHelper.PopulateBrandsList().Where(b => b.ConnOrgName == promo.Name).ToList();
            storeHelper.TeamsList = tHelper.PopulateTeamsList().Where(t => t.OrgName == promo.Name).ToList();

            foreach (TeamsEntity t in storeHelper.TeamsList)
            {
                cbxTeams.Items.Add(t.TeamName);
            }

            foreach (BrandsEntity b in storeHelper.BrandsList)
            {
                cbxAsscBrand.Items.Add(b.Name);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain(OrgName);
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TeamsEntity team = storeHelper.TeamsList.FirstOrDefault(t => t.TeamName == cbxTeams.SelectedItem.ToString());

            team.TeamName = tbNewName.Text;
            team.BrandName = cbxAsscBrand.SelectedItem.ToString();
            team.Wins = Convert.ToInt32(tbWins.Text);
            team.Losses = Convert.ToInt32(tbLosses.Text);
            team.Draws = Convert.ToInt32(tbDraws.Text);

            tHelper.SaveTeamsList(team);

            ModifyMain main = new ModifyMain(OrgName);
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
            tbNewName.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            btnAdjustTeam.Enabled = true;
            button4.Enabled = true;
        }

        private void btnAdjustTeam_Click(object sender, EventArgs e)
        {
            ModTeamsAdjMems aMems = new ModTeamsAdjMems(OrgName, cbxTeams.SelectedItem.ToString());
            aMems.Show();
        }

        private void btnSelTitles_Click(object sender, EventArgs e)
        {
            ModTeamsTitles aTitles = new ModTeamsTitles(cbxTeams.SelectedItem.ToString(), OrgName);
            aTitles.Show();
        }

        private void cbxTeams_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditTeam.Enabled = true;
            btnDelTeam.Enabled = true;

            TeamsEntity team = storeHelper.TeamsList.FirstOrDefault(t => t.TeamName == cbxTeams.SelectedItem.ToString());

            tbNewName.Text = team.TeamName;
            cbxAsscBrand.SelectedItem = team.BrandName;
            tbWins.Text = team.Wins.ToString();
            tbLosses.Text = team.Losses.ToString();
            tbDraws.Text = team.Draws.ToString();
        }

        private void btnDelTeam_Click(object sender, EventArgs e)
        {
            string selBrand = cbxTeams.SelectedItem.ToString();

            for (int i = cbxTeams.Items.Count - 1; i >= 0; --i)
            {
                if (cbxTeams.Items[i].ToString().Contains(selBrand))
                {
                    cbxTeams.Items.RemoveAt(i);
                }
            }

            TeamsEntity team = storeHelper.TeamsList.FirstOrDefault(t => t.TeamName == cbxTeams.SelectedItem.ToString());

            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Teams\\" + team.TeamID + ".dat");

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            cbxTeams.Refresh();
        }
    }
}
