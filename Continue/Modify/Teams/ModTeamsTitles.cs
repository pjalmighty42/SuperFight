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
    public partial class ModTeamsTitles : Form
    {
        private string TeamName;
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        TitleHelper tHelper = new TitleHelper();
        TeamHelper teHelper = new TeamHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public ModTeamsTitles(string teamName, string orgName)
        {
            InitializeComponent();

            TeamName = teamName;
            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);
            TeamsEntity team = teHelper.PopulateTeamsList().FirstOrDefault(t => t.TeamName == TeamName);
            BrandsEntity brand = bHelper.PopulateBrandsList().FirstOrDefault(b => b.ConnOrgName == promo.Name && b.Name == team.BrandName);

            storeHelper.TitlesList = tHelper.PopulateTitlesList().Where(t => t.OwnerOrgName == promo.Name).ToList();

            if (brand == null)
            {
                List<TitlesEntity> titles = storeHelper.TitlesList.Where(t => t.Specialization != "Singles Championship").ToList();
                List<TitlesEntity> ownedTitles = storeHelper.TitlesList.Where(t => t.Specialization != "Singles Championship" && 
                    !String.IsNullOrWhiteSpace(t.HolderName1) &&
                    !String.IsNullOrWhiteSpace(t.HolderName2) ||
                    !String.IsNullOrWhiteSpace(t.HolderName3) ||
                    !String.IsNullOrWhiteSpace(t.HolderName4)).ToList();

                foreach (TitlesEntity t in titles)
                {
                    lbAllTeamTitles.Items.Add(t.Name);
                }

                foreach (TitlesEntity ot in ownedTitles)
                {
                    if (lbSelTeamTitles.Items.Count < 7)
                    {
                        lbSelTeamTitles.Items.Add(ot.Name);
                    }
                }
            }
            else
            {
                List<TitlesEntity> titles = storeHelper.TitlesList.Where(t => t.Specialization != "Singles Championship" && t.BrandName == brand.Name).ToList();
                List<TitlesEntity> ownedTitles = storeHelper.TitlesList.Where(t => t.Specialization != "Singles Championship" && 
                    t.BrandName == brand.Name &&
                    !String.IsNullOrWhiteSpace(t.HolderName1) &&
                    !String.IsNullOrWhiteSpace(t.HolderName2) ||
                    !String.IsNullOrWhiteSpace(t.HolderName3) ||
                    !String.IsNullOrWhiteSpace(t.HolderName4)).ToList();

                foreach (TitlesEntity t in titles)
                {
                    lbAllTeamTitles.Items.Add(t.Name);
                }

                foreach (TitlesEntity ot in ownedTitles)
                {
                    lbSelTeamTitles.Items.Add(ot.Name);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var t in lbSelTeamTitles.Items)
            {
                TitlesEntity title = tHelper.PopulateTitlesList().FirstOrDefault(ti => ti.Name == t.ToString());
                TeamsEntity team = teHelper.PopulateTeamsList().FirstOrDefault(te => te.TeamName == TeamName);
                
                title.HolderName1 = team.MemberName1;
                title.HolderName2 = team.MemberName2;
                title.HolderName3 = team.MemberName3;
                title.HolderName4 = team.MemberName4;

                tHelper.SaveTitlesList(title);
            };

            this.Hide();
        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            string selItem = lbAllTeamTitles.SelectedItem.ToString();

            for (int i = lbAllTeamTitles.Items.Count - 1; i >= 0; --i)
            {
                if (lbAllTeamTitles.Items[i].ToString().Contains(selItem))
                {
                    lbAllTeamTitles.Items.RemoveAt(i);
                }
            }

            if (lbSelTeamTitles.Items.Count < 7)
            {
                lbSelTeamTitles.Items.Add(selItem);
            }
        }

        private void btnRemTitles_Click(object sender, EventArgs e)
        {
            string selItem = lbSelTeamTitles.SelectedItem.ToString();

            for (int i = lbSelTeamTitles.Items.Count - 1; i >= 0; --i)
            {
                if (lbSelTeamTitles.Items[i].ToString().Contains(selItem))
                {
                    lbSelTeamTitles.Items.RemoveAt(i);
                }
            }

            lbAllTeamTitles.Items.Add(selItem);
        }

        private void lbAllTeamTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddTitle.Enabled = true;
            btnRemTitles.Enabled = false;
        }

        private void lbSelTeamTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddTitle.Enabled = false;
            btnRemTitles.Enabled = true;
        }
    }
}
