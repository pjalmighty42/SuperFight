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

namespace Super_Fight.Continue.Modify.Wrestlers
{
    public partial class ModWrestlerTitles : Form
    {
        private string WrestName;
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        TitleHelper tHelper = new TitleHelper();
        WrestlerHelper wHelper = new WrestlerHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public ModWrestlerTitles(string wrestName, string orgName)
        {
            InitializeComponent();

            WrestName = wrestName;
            OrgName = orgName;

            WrestlersEntity wrest = wHelper.PopulateWrestlersList().FirstOrDefault(w => w.Name == WrestName);
            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);
            BrandsEntity brand = bHelper.PopulateBrandsList().FirstOrDefault(b => b.ConnOrgName == promo.Name && b.Name == wrest.BrandName);

            storeHelper.TitlesList = tHelper.PopulateTitlesList().Where(t => t.OwnerOrgName == promo.Name).ToList();

            if (brand == null)
            {
                List<TitlesEntity> ownedTitles = storeHelper.TitlesList.Where(t => t.Specialization == "Singles Championship" &&
                                                t.WeightClass == wrest.WeightClass && 
                                                t.HolderName1 == wrest.Name).ToList();
                List<TitlesEntity> titles = storeHelper.TitlesList.Where(t => t.Specialization == "Singles Championship" && 
                                                t.WeightClass == wrest.WeightClass).Except(ownedTitles).ToList();
                
                foreach (TitlesEntity t in titles)
                {
                    lbAllTitles.Items.Add(t.Name);
                }
                
                foreach (TitlesEntity o in ownedTitles)
                {
                    lbSelTitles.Items.Add(o.Name);
                }
            }
            else
            {
                List<TitlesEntity> ownedTitles = storeHelper.TitlesList.Where(t => t.Specialization == "Singles Championship" &&
                                                t.WeightClass == wrest.WeightClass &&
                                                t.BrandName == brand.Name &&
                                                t.HolderName1 == wrest.Name).ToList();
                List<TitlesEntity> titles = storeHelper.TitlesList.Where(t => t.Specialization == "Singles Championship"
                                            && t.WeightClass == wrest.WeightClass
                                            && t.BrandName == brand.Name).Except(ownedTitles).ToList();

                foreach (TitlesEntity t in titles)
                {
                    lbAllTitles.Items.Add(t.Name);
                }

                foreach (TitlesEntity o in ownedTitles)
                {
                    lbSelTitles.Items.Add(o.Name);
                }
            }

            lbAllTitles.Enabled = true;
            lbSelTitles.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var t in lbSelTitles.Items)
            {
                TitlesEntity title = tHelper.PopulateTitlesList().FirstOrDefault(ti => ti.Name == t.ToString());

                title.HolderName1 = WrestName;

                tHelper.SaveTitlesList(title);
            };

            foreach (var n in lbAllTitles.Items)
            {
                TitlesEntity title = tHelper.PopulateTitlesList().FirstOrDefault(ti => ti.Name == n.ToString());

                title.HolderName1 = "";

                tHelper.SaveTitlesList(title);
            }

            this.Hide();
        }

        private void lbAllTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddTitle.Enabled = true;
            btnRemTitles.Enabled = false;
        }

        private void lbSelTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddTitle.Enabled = false;
            btnRemTitles.Enabled = true;
        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            string selItem = lbAllTitles.SelectedItem.ToString();

            for (int i = lbAllTitles.Items.Count - 1; i >= 0; --i)
            {
                if (lbAllTitles.Items[i].ToString().Contains(selItem))
                {
                    lbAllTitles.Items.RemoveAt(i);
                }
            }

            if (lbSelTitles.Items.Count < 7)
            {
                lbSelTitles.Items.Add(selItem);
                lbSelTitles.Refresh();
            }

            button4.Enabled = true;
        }

        private void btnRemTitles_Click(object sender, EventArgs e)
        {
            string selItem = lbSelTitles.SelectedItem.ToString();

            for (int i = lbSelTitles.Items.Count - 1; i >= 0; --i)
            {
                if (lbSelTitles.Items[i].ToString().Contains(selItem))
                {
                    lbSelTitles.Items.RemoveAt(i);
                }
            }

            lbAllTitles.Items.Add(selItem);
            lbAllTitles.Refresh();

            button4.Enabled = true;
        }
    }
}
