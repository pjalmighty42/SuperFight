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
using Super_Fight.Helpers;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Continue.Modify.Teams
{
    public partial class ModTeamsAdjMems : Form
    {
        private string OrgName;
        private string TeamName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        WrestlerHelper wHelper = new WrestlerHelper();
        TeamHelper tHelper = new TeamHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public ModTeamsAdjMems(string orgName, string teamName)
        {
            InitializeComponent();

            OrgName = orgName;
            TeamName = teamName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);
            TeamsEntity team = tHelper.PopulateTeamsList().FirstOrDefault(t => t.TeamName == TeamName);

            storeHelper.BrandsList = bHelper.PopulateBrandsList().Where(b => b.ConnOrgName == promo.Name).ToList();
            storeHelper.WrestlersList = wHelper.PopulateWrestlersList().Where(w => w.CurrentCompanyName == promo.Name).ToList();
            
            List<WrestlersEntity> teamW = storeHelper.WrestlersList.Where(w => w.TeamName != "").ToList();
            List<WrestlersEntity> roster = storeHelper.WrestlersList.Except(teamW).ToList();

            foreach (WrestlersEntity w in roster)
            {
                lbRoster.Items.Add(w.Name);
            }
                

            foreach (WrestlersEntity w in teamW)
            {
                if (w.TeamName == TeamName)
                {
                    lbSelWrestlers.Items.Add(w.Name);
                }
            }
                
            lbRoster.Enabled = false;
            lbSelWrestlers.Enabled = false;
            btnSave.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TeamsEntity newTeam = new TeamsEntity();
            List<WrestlersEntity> wrestUpdate = new List<WrestlersEntity>();

            for (int i = 0; i < lbSelWrestlers.Items.Count; i++)
            {
                switch (lbSelWrestlers.Items.Count)
                {
                    case 2:
                        newTeam = new TeamsEntity()
                        {
                            TeamName = TeamName,
                            OrgName = OrgName,
                            Wins = 0,
                            Losses = 0,
                            Draws = 0,

                            MemberName1 = lbSelWrestlers.Items[0].ToString(),
                            MemberName2 = lbSelWrestlers.Items[1].ToString()
                        };

                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[0].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[1].ToString()));
                        break;
                    case 3:
                        newTeam = new TeamsEntity()
                        {
                            TeamName = TeamName,
                            OrgName = OrgName,
                            Wins = 0,
                            Losses = 0,
                            Draws = 0,

                            MemberName1 = lbSelWrestlers.Items[0].ToString(),
                            MemberName2 = lbSelWrestlers.Items[1].ToString(),
                            MemberName3 = lbSelWrestlers.Items[2].ToString()
                        };

                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[0].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[1].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[2].ToString()));
                        break;
                    case 4:
                        newTeam = new TeamsEntity()
                        {
                            TeamName = TeamName,
                            OrgName = OrgName,
                            Wins = 0,
                            Losses = 0,
                            Draws = 0,

                            MemberName1 = lbSelWrestlers.Items[0].ToString(),
                            MemberName2 = lbSelWrestlers.Items[1].ToString(),
                            MemberName3 = lbSelWrestlers.Items[2].ToString(),
                            MemberName4 = lbSelWrestlers.Items[3].ToString()
                        };

                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[0].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[1].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[2].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[3].ToString()));
                        break;
                    default:
                        lbSelWrestlers.BackColor = Color.MistyRose;
                        break;
                }
            }

            foreach (WrestlersEntity w in wrestUpdate)
            {
                w.TeamName = TeamName;

                wHelper.SaveWrestlersList(w);
            }

            tHelper.SaveTeamsList(newTeam);

            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lbRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnRem.Enabled = false;
        }

        private void lbSelWrestlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnRem.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (rbTagTeam.Checked)
            {
                if (lbSelWrestlers.Items.Count < 2)
                {
                    string selItem = lbRoster.SelectedItem.ToString();

                    for (int i = lbRoster.Items.Count - 1; i >= 0; --i)
                    {
                        if (lbRoster.Items[i].ToString().Contains(selItem))
                        {
                            lbRoster.Items.RemoveAt(i);
                        }
                    }

                    lbSelWrestlers.Items.Add(selItem);
                }
            }
            else if (rb6ManTagTeam.Checked)
            {
                if (lbSelWrestlers.Items.Count < 3)
                {
                    string selItem = lbRoster.SelectedItem.ToString();

                    for (int i = lbRoster.Items.Count - 1; i >= 0; --i)
                    {
                        if (lbRoster.Items[i].ToString().Contains(selItem))
                        {
                            lbRoster.Items.RemoveAt(i);
                        }
                    }

                    lbSelWrestlers.Items.Add(selItem);
                }
            }
            else if (rb8ManTagTeam.Checked)
            {
                if (lbSelWrestlers.Items.Count < 4)
                {
                    string selItem = lbRoster.SelectedItem.ToString();

                    for (int i = lbRoster.Items.Count - 1; i >= 0; --i)
                    {
                        if (lbRoster.Items[i].ToString().Contains(selItem))
                        {
                            lbRoster.Items.RemoveAt(i);
                        }
                    }

                    lbSelWrestlers.Items.Add(selItem);
                }
            }

            lbSelWrestlers.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            string selItem = lbSelWrestlers.SelectedItem.ToString();

            for (int i = lbSelWrestlers.Items.Count - 1; i >= 0; --i)
            {
                if (lbSelWrestlers.Items[i].ToString().Contains(selItem))
                {
                    lbSelWrestlers.Items.RemoveAt(i);
                }
            }

            lbRoster.Items.Add(selItem);
        }

        private void rbTagTeam_CheckedChanged(object sender, EventArgs e)
        {
            lbRoster.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void rb6ManTagTeam_CheckedChanged(object sender, EventArgs e)
        {
            lbRoster.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void rb8ManTagTeam_CheckedChanged(object sender, EventArgs e)
        {
            lbRoster.Enabled = true;
            btnAdd.Enabled = true;
        }
    }
}
