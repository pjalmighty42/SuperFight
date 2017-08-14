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

namespace Super_Fight.Edit.Teams
{
    public partial class AddTeam : Form
    {
        TeamHelper tHelper = new TeamHelper();
        WrestlerHelper wHelper = new WrestlerHelper();
        TitleHelper tlHelper = new TitleHelper();
        PromotionHelper pHelper = new PromotionHelper();
        
        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();
        IDSetterHelper idHelper = new IDSetterHelper();

        private bool isEdit;

        public AddTeam()
        {
            InitializeComponent();

            storeHelper.TeamsList = tHelper.PopulateTeamsList();
            storeHelper.PromotionsList = pHelper.PopulatePromotionsList();
            storeHelper.TitlesList = tlHelper.PopulateTitlesList();
            storeHelper.WrestlersList = wHelper.PopulateWrestlersList();

            isEdit = false;

            foreach (TeamsEntity t in storeHelper.TeamsList)
            {
                lbTeamList.Items.Add(t.TeamName);
            }

            foreach (PromotionsEntity p in storeHelper.PromotionsList)
            {
                cbxAsscCo.Items.Add(p.Name);
            }
        }

        private void btnCreateWrest_Click(object sender, EventArgs e)
        {
            isEdit = false; 

            btnSelMembers.Enabled = true;
            btnCreateWrest.Enabled = false;
            tbNewName.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            cbxAsscCo.Enabled = true;
            button4.Enabled = true;
            btnSelMembers.Enabled = false;
        }

        private void btnEditTeam_Click(object sender, EventArgs e)
        {
            isEdit = true;

            btnCreateWrest.Enabled = false;
            tbNewName.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            btnSelMembers.Enabled = true;
            btnEditTeam.Enabled = false;
            btnDelete.Enabled = false;
            cbxAsscCo.Enabled = true;
            lbTeamList.Enabled = false;

            button4.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (isEdit)
            {
                TeamsEntity team = storeHelper.TeamsList.FirstOrDefault(t => t.TeamName == lbTeamList.SelectedItem.ToString());

                foreach (TeamsEntity t in storeHelper.TeamsList)
                {
                    if (team.TeamID == t.TeamID)
                    {
                        if (tbNewName.Text == "")
                        {
                            tbNewName.BackColor = Color.MistyRose;
                        }
                        else
                        {
                            int wins = 0;
                            int losses = 0;
                            int draws = 0;
                            string asscCo;

                            int tempWins = 0;
                            int tempLoss = 0;
                            int tempDraws = 0;

                            if (tbWins.Text == "" ||
                                tbLosses.Text == "" ||
                                tbDraws.Text == "")
                            {
                                wins = 0;
                                losses = 0;
                                draws = 0;
                            }
                            else if (int.TryParse(tbWins.Text, out tempWins) &&
                                int.TryParse(tbLosses.Text, out tempLoss) &&
                                int.TryParse(tbDraws.Text, out tempDraws))
                            {
                                wins = tempWins;
                                losses = tempLoss;
                                draws = tempDraws;
                                
                                if (string.IsNullOrWhiteSpace(cbxAsscCo.SelectedItem.ToString()))
                                {
                                    asscCo = "";
                                }
                                else
                                {
                                    asscCo = cbxAsscCo.SelectedItem.ToString();
                                }

                                team.TeamName = tbNewName.Text;
                                team.OrgName = asscCo;
                                team.Wins = wins;
                                team.Losses = losses;
                                team.Draws = draws;

                                tHelper.SaveTeamsList(team);

                                EditMain main = new EditMain();
                                main.Show();
                                this.Hide();
                            }
                            else
                            {
                                tbWins.BackColor = Color.MistyRose;
                                tbLosses.BackColor = Color.MistyRose;
                                tbDraws.BackColor = Color.MistyRose;
                            }
                        }
                    }
                }
            }
            else
            {
                if (tbNewName.Text == "")
                {
                    tbNewName.BackColor = Color.MistyRose;
                }
                else
                {
                    int wins = 0;
                    int losses = 0;
                    int draws = 0;
                    string asscCo;

                    int tempWins = 0;
                    int tempLoss = 0;
                    int tempDraws = 0;

                    if (tbWins.Text == "" ||
                        tbLosses.Text == "" ||
                        tbDraws.Text == "")
                    {
                        wins = 0;
                        losses = 0;
                        draws = 0;
                    }
                    else if (int.TryParse(tbWins.Text, out tempWins) &&
                        int.TryParse(tbLosses.Text, out tempLoss) &&
                        int.TryParse(tbDraws.Text, out tempDraws))
                    {
                        wins = tempWins;
                        losses = tempLoss;
                        draws = tempDraws;
                        
                        TeamsEntity team = storeHelper.TeamsList.FirstOrDefault(t => t.TeamName == lbTeamList.SelectedItem.ToString());

                        if (string.IsNullOrWhiteSpace(cbxAsscCo.SelectedItem.ToString()))
                        {
                            asscCo = "";
                        }
                        else
                        {
                            asscCo = cbxAsscCo.SelectedItem.ToString();
                        }


                        TeamsEntity newTeam = new TeamsEntity()
                        {
                            TeamID = idHelper.CurrentID(false, false, false, false, true, false, false),
                            TeamName = tbNewName.Text,
                            OrgName = asscCo,
                            Wins = wins,
                            Losses = losses,
                            Draws = draws
                        };

                        tHelper.SaveTeamsList(newTeam);

                        EditMain main = new EditMain();
                        main.Show();
                        this.Hide();
                    }
                    else
                    {
                        tbWins.BackColor = Color.MistyRose;
                        tbLosses.BackColor = Color.MistyRose;
                        tbDraws.BackColor = Color.MistyRose;
                    }
                }
            }
            
        }

        private void btnSelMembers_Click(object sender, EventArgs e)
        {
            string asscCo;

            TeamsEntity team = storeHelper.TeamsList.FirstOrDefault(t => t.TeamName == lbTeamList.SelectedItem.ToString());

            asscCo = team.OrgName;

            TeamAddWrestlers wrest = new TeamAddWrestlers(team.TeamName, asscCo);
            wrest.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string teamToBeDELETED = lbTeamList.SelectedItem.ToString();

            TeamsEntity selT = storeHelper.TeamsList.FirstOrDefault(w => w.TeamName == teamToBeDELETED);
            List<WrestlersEntity> wrests = storeHelper.WrestlersList.Where(w => w.TeamName == teamToBeDELETED).ToList();

            foreach (WrestlersEntity w in wrests)
            {
                w.TeamName = "";

                wHelper.SaveWrestlersList(w);
            }

            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Teams\\" + selT.TeamID + ".dat");

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void lbTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TeamsEntity team = storeHelper.TeamsList.FirstOrDefault(t => t.TeamName == lbTeamList.SelectedItem.ToString());
            
            tbNewName.Text = team.TeamName;
            tbWins.Text = team.Wins.ToString();
            tbLosses.Text = team.Losses.ToString();
            tbDraws.Text = team.Draws.ToString();
            cbxAsscCo.SelectedItem = team.OrgName;

            btnDelete.Enabled = true;
            btnEditTeam.Enabled = true;
        }
    }
}
