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

namespace Super_Fight.Continue.Ranking
{
    public partial class CurrentRankings : Form
    {

        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        WrestlerHelper wHelper = new WrestlerHelper();
        TeamHelper tHelper = new TeamHelper();
        TitleHelper tiHelper = new TitleHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public CurrentRankings(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);
            storeHelper.BrandsList = bHelper.PopulateBrandsList().Where(b => b.ConnOrgName == promo.Name).ToList();
            storeHelper.TitlesList = tiHelper.PopulateTitlesList().Where(ti => ti.OwnerOrgName == promo.Name).ToList();

            storeHelper.WrestlersList = wHelper.PopulateWrestlersList().Where(w => w.CurrentCompanyName == promo.Name).Distinct().ToList();
            storeHelper.TeamsList = tHelper.PopulateTeamsList().Where(t => t.OrgName == promo.Name).Distinct().ToList();

            lblCompanyName.Text = promo.Name;

            cbxBrands.Items.Add("");
            foreach (BrandsEntity b in storeHelper.BrandsList)
            {
                cbxBrands.Items.Add(b.Name);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContinueMain cont = new ContinueMain();
            cont.Show();
            this.Close();
        }

        private void cbxSpec_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvRankings.Rows.Clear();
            dgvRankings.Refresh();

            if (cbxSpec.SelectedItem == null)
            {
                UpdateDVGRankings(null, cbxBrands.SelectedItem.ToString());
            }
            else if (cbxBrands.SelectedItem == null)
            {
                UpdateDVGRankings(cbxSpec.SelectedItem.ToString(), null);
            }
            else
            {
                UpdateDVGRankings(cbxSpec.SelectedItem.ToString(), cbxBrands.SelectedItem.ToString());
            }
            
        }

        private void cbxBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvRankings.Rows.Clear();
            dgvRankings.Refresh();

            if (cbxSpec.SelectedItem == null || cbxSpec.SelectedItem.ToString() == "")
            {
                UpdateDVGRankings(null, cbxBrands.SelectedItem.ToString());
            }
            else if (cbxBrands.SelectedItem == null || cbxBrands.SelectedItem.ToString() == "")
            {
                UpdateDVGRankings(cbxSpec.SelectedItem.ToString(), null);
            }
            else
            {
                UpdateDVGRankings(cbxSpec.SelectedItem.ToString(), cbxBrands.SelectedItem.ToString());
            }
        }

        private void FillOutTableSpecOnly(string specVal)
        {
            List<WrestlersEntity> newWrestList = new List<WrestlersEntity>();
            List<TeamsEntity> newTeamList = new List<TeamsEntity>();
            List<TitlesEntity> newTitleList = new List<TitlesEntity>();
            
            switch (specVal)
            {
                case "Singles":

                    newWrestList = storeHelper.WrestlersList.OrderByDescending(w => w.Wins).Distinct().ToList();

                    for (int i = 0; i < newWrestList.Count; i++)
                    {
                        dgvRankings.Rows.Add(i + 1, newWrestList[i].Name, "", newWrestList[i].Wins, newWrestList[i].Losses, newWrestList[i].Draws);
                    }

                    break;
                case "Tag Team":

                    newTeamList = storeHelper.TeamsList.Where(t => t.MemberName3 == null).OrderByDescending(t => t.Wins).Distinct().ToList();

                    for (int i = 0; i < newTeamList.Count; i++)
                    {
                        dgvRankings.Rows.Add(i, newTeamList[i].TeamName, "", newTeamList[i].Wins, newTeamList[i].Losses, newTeamList[i].Draws);
                    }

                    break;
                case "6-Man Tag Team":

                    newTeamList = storeHelper.TeamsList.Where(t => t.MemberName3 != null).OrderByDescending(t => t.Wins).Distinct().ToList();

                    for (int i = 0; i < newTeamList.Count; i++)
                    {
                        dgvRankings.Rows.Add(i, newTeamList[i].TeamName, "", newTeamList[i].Wins, newTeamList[i].Losses, newTeamList[i].Draws);
                    }

                    break;
                case "8-Man Tag Team":

                    newTeamList = storeHelper.TeamsList.Where(t => t.MemberName4 != null).OrderByDescending(t => t.Wins).Distinct().ToList();

                    for (int i = 0; i < newTeamList.Count; i++)
                    {
                        dgvRankings.Rows.Add(i, newTeamList[i].TeamName, "", newTeamList[i].Wins, newTeamList[i].Losses, newTeamList[i].Draws);
                    }

                    break;
            }
        }

        private void FillOutTableBrandOnly(string brandVal)
        {
            List<WrestlersEntity> newWrestList = new List<WrestlersEntity>();
            List<TeamsEntity> newTeamList = new List<TeamsEntity>();
            List<TitlesEntity> newTitleList = new List<TitlesEntity>();

            //Because no Spec selection, default to singles 
            newWrestList = storeHelper.WrestlersList.Where(w => w.BrandName == brandVal).OrderByDescending(w => w.Wins).Distinct().ToList();

            for (int i = 0; i < newWrestList.Count; i++)
            {
                dgvRankings.Rows.Add(i + 1, newWrestList[i].Name, "", newWrestList[i].Wins, newWrestList[i].Losses, newWrestList[i].Draws);
            }
                    
        }

        private void FillOutTableAll(string specVal, string brandVal)
        {
            List<WrestlersEntity> newWrestList = new List<WrestlersEntity>();
            List<TeamsEntity> newTeamList = new List<TeamsEntity>();
            List<TitlesEntity> newTitleList = new List<TitlesEntity>();

            switch (specVal)
            {
                case "Singles":

                    newWrestList = storeHelper.WrestlersList.Where(w => w.BrandName == brandVal).OrderByDescending(w => w.Wins).Distinct().ToList();

                    for (int i = 0; i < newWrestList.Count; i++)
                    {
                        dgvRankings.Rows.Add(i + 1, newWrestList[i].Name, "", newWrestList[i].Wins, newWrestList[i].Losses, newWrestList[i].Draws);
                    }

                    break;
                case "Tag Team":

                    newTeamList = storeHelper.TeamsList.Where(t => t.BrandName == brandVal && t.MemberName3 == null).OrderByDescending(t => t.Wins).Distinct().ToList();

                    for (int i = 0; i < newTeamList.Count; i++)
                    {
                        dgvRankings.Rows.Add(i, newTeamList[i].TeamName, "", newTeamList[i].Wins, newTeamList[i].Losses, newTeamList[i].Draws);
                    }

                    break;
                case "6-Man Tag Team":

                    newTeamList = storeHelper.TeamsList.Where(t => t.BrandName == brandVal && t.MemberName3 != null).OrderByDescending(t => t.Wins).Distinct().ToList();

                    for (int i = 0; i < newTeamList.Count; i++)
                    {
                        dgvRankings.Rows.Add(i, newTeamList[i].TeamName, "", newTeamList[i].Wins, newTeamList[i].Losses, newTeamList[i].Draws);
                    }

                    break;
                case "8-Man Tag Team":

                    newTeamList = storeHelper.TeamsList.Where(t => t.BrandName == brandVal && t.MemberName4 != null).OrderByDescending(t => t.Wins).Distinct().ToList();

                    for (int i = 0; i < newTeamList.Count; i++)
                    {
                        dgvRankings.Rows.Add(i, newTeamList[i].TeamName, "", newTeamList[i].Wins, newTeamList[i].Losses, newTeamList[i].Draws);
                    }

                    break;
            }
        }

        private void UpdateDVGRankings(string specVal, string brandVal)
        {
            if (specVal == null || specVal == "")
            {
                FillOutTableBrandOnly(brandVal);
            }
            else if (brandVal == null || brandVal == "")
            {
                FillOutTableSpecOnly(specVal);
            }
            else
            {
                FillOutTableAll(specVal, brandVal);
            }
        }
    }
}

