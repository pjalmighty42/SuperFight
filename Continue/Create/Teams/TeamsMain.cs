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

namespace Super_Fight.Continue.Create.Teams
{
    public partial class TeamsMain : Form
    {
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        WrestlerHelper wHelper = new WrestlerHelper();
        TeamHelper tHelper = new TeamHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public TeamsMain(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);

            storeHelper.BrandsList = bHelper.PopulateBrandsList().Where(b => b.ConnOrgName == promo.Name).ToList();
            storeHelper.WrestlersList = wHelper.PopulateWrestlersList().Where(w => w.CurrentCompanyName == promo.Name).ToList();

            if (storeHelper.BrandsList.Count == 0)
            {
                cbxAsscBrand.Enabled = false;
            }
            else
            {
                cbxAsscBrand.Enabled = true;

                cbxAsscBrand.Items.Add("");
                foreach (BrandsEntity b in storeHelper.BrandsList)
                {
                    cbxAsscBrand.Items.Add(b.Name);
                }
            }


            //Limit the radio buttons dependent on if we have enough wrestlers for the team
            if (storeHelper.WrestlersList.Count < 2)
            {
                rbTagTeam.Enabled = false;
                rb6ManTagTeam.Enabled = false;
                rb8ManTagTeam.Enabled = false;
            }
            else if (storeHelper.WrestlersList.Count >= 2 && storeHelper.WrestlersList.Count <= 3)
            {
                rbTagTeam.Enabled = true;
                rb6ManTagTeam.Enabled = true;
                rb8ManTagTeam.Enabled = false;
            }
            else if (storeHelper.WrestlersList.Count > 3)
            {
                rbTagTeam.Enabled = true;
                rb6ManTagTeam.Enabled = true;
                rb8ManTagTeam.Enabled = true;
            }

            foreach (WrestlersEntity w in storeHelper.WrestlersList)
            {
                lbRoster.Items.Add(w.Name);
            }
            
            lbRoster.Enabled = false;
            lbSelected.Enabled = false;
            btnSave.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateMain main = new CreateMain(OrgName);
            main.Show();
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbRoster.SelectedItem != null)
            {
                if (rbTagTeam.Checked)
                {
                    if (lbSelected.Items.Count < 2)
                    {
                        AddWrestler();
                    }
                }
                else if (rb6ManTagTeam.Checked)
                {
                    if (lbSelected.Items.Count < 3)
                    {
                        AddWrestler();
                    }
                }
                else if (rb8ManTagTeam.Checked)
                {
                    if (lbSelected.Items.Count < 4)
                    {
                        AddWrestler();
                    }
                }
            }
        }

        private void btnRem_Click(object sender, EventArgs e)
        {
            if (lbSelected.SelectedItem != null)
            {
                RemoveWrestler();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TeamsEntity newTeam = new TeamsEntity();
            List<WrestlersEntity> wrestUpdate = new List<WrestlersEntity>();

            for (int i = 0; i < lbSelected.Items.Count; i++)
            {
                switch (lbSelected.Items.Count)
                {
                    case 2:
                        newTeam = new TeamsEntity()
                        {
                            TeamName = tbTeamName.Text,
                            OrgName = OrgName,
                            BrandName = cbxAsscBrand.SelectedItem.ToString(),
                            Wins = 0,
                            Losses = 0,
                            Draws = 0,

                            MemberName1 = lbSelected.Items[0].ToString(),
                            MemberName2 = lbSelected.Items[1].ToString()
                        };

                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[0].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[1].ToString()));
                        break;
                    case 3:
                        newTeam = new TeamsEntity()
                        {
                            TeamName = tbTeamName.Text,
                            OrgName = OrgName,
                            BrandName = cbxAsscBrand.SelectedItem.ToString(),
                            Wins = 0,
                            Losses = 0,
                            Draws = 0,

                            MemberName1 = lbSelected.Items[0].ToString(),
                            MemberName2 = lbSelected.Items[1].ToString(),
                            MemberName3 = lbSelected.Items[2].ToString()
                        };

                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[0].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[1].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[2].ToString()));
                        break;
                    case 4:
                        newTeam = new TeamsEntity()
                        {
                            TeamName = tbTeamName.Text,
                            OrgName = OrgName,
                            BrandName = cbxAsscBrand.SelectedItem.ToString(),
                            Wins = 0,
                            Losses = 0,
                            Draws = 0,

                            MemberName1 = lbSelected.Items[0].ToString(),
                            MemberName2 = lbSelected.Items[1].ToString(),
                            MemberName3 = lbSelected.Items[2].ToString(),
                            MemberName4 = lbSelected.Items[3].ToString()
                        };

                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[0].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[1].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[2].ToString()));
                        wrestUpdate.Add(storeHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelected.Items[3].ToString()));
                        break;
                    default:
                        lbSelected.BackColor = Color.MistyRose;
                        break;
                }
            }

            foreach (WrestlersEntity w in wrestUpdate)
            {
                w.BrandName = cbxAsscBrand.SelectedItem.ToString();
                w.TeamName = tbTeamName.Text;

                wHelper.SaveWrestlersList(w);
            }
            
            tHelper.SaveTeamsList(newTeam);

            CreateMain main = new CreateMain(OrgName);
            main.Show();
            this.Hide();
        }

        private void lbRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnRem.Enabled = false;
        }

        private void lbSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnRem.Enabled = true;
        }

        private void rbTagTeam_CheckedChanged(object sender, EventArgs e)
        {
            lbRoster.Enabled = true;
            lbSelected.Enabled = true;
            btnSave.Enabled = true;
        }

        private void rb6ManTagTeam_CheckedChanged(object sender, EventArgs e)
        {
            lbRoster.Enabled = true;
            lbSelected.Enabled = true;
            btnSave.Enabled = true;
        }

        private void rb8ManTagTeam_CheckedChanged(object sender, EventArgs e)
        {
            lbRoster.Enabled = true;
            lbSelected.Enabled = true;
            btnSave.Enabled = true;
        }

        private void AddWrestler()
        {
            string selItem = lbRoster.SelectedItem.ToString();

            for (int i = lbRoster.Items.Count - 1; i >= 0; --i)
            {
                if (lbRoster.Items[i].ToString().Contains(selItem))
                {
                    lbRoster.Items.RemoveAt(i);
                }
            }

            lbSelected.Items.Add(selItem);
            lbSelected.Refresh();
        }

        private void RemoveWrestler()
        {
            string selItem = lbSelected.SelectedItem.ToString();

            for (int i = lbSelected.Items.Count - 1; i >= 0; --i)
            {
                if (lbSelected.Items[i].ToString().Contains(selItem))
                {
                    lbSelected.Items.RemoveAt(i);
                }
            }

            lbRoster.Items.Add(selItem);
            lbRoster.Refresh();
        }

        private void cbxAsscBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selBrand = cbxAsscBrand.SelectedItem.ToString();

            if (selBrand != "")
            {
                List<WrestlersEntity> wrests = storeHelper.WrestlersList.Where(w => w.BrandName == selBrand).Distinct().ToList();

                lbRoster.Items.Clear();
                foreach (WrestlersEntity w in wrests)
                {
                    lbRoster.Items.Add(w.Name);
                }
            }
            else
            {
                lbRoster.Items.Clear();
                foreach (WrestlersEntity w in storeHelper.WrestlersList)
                {
                    lbRoster.Items.Add(w.Name);
                }
            }
        }

    }
}
