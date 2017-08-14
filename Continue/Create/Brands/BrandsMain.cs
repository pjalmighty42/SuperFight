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

namespace Super_Fight.Continue.Create.Brands
{
    public partial class BrandsMain : Form
    {
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        WrestlerHelper wHelper = new WrestlerHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public BrandsMain(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);

            storeHelper.WrestlersList = wHelper.PopulateWrestlersList().Where(w => w.CurrentCompanyName == promo.Name).ToList();

            foreach (var w in storeHelper.WrestlersList)
            {
                lbAllRoster.Items.Add(w.Name);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateMain main = new CreateMain(OrgName);
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbBrandName.Text) ||
                lbSelectedWresters.Items.Count > 0
                )
            {
                foreach (var i in lbSelectedWresters.Items)
                {
                    WrestlersEntity updateW = storeHelper.WrestlersList.FirstOrDefault(w => w.Name == i.ToString());

                    updateW.BrandName = tbBrandName.Text;

                    wHelper.SaveWrestlersList(updateW);
                }

                foreach (var x in lbAllRoster.Items)
                {
                    WrestlersEntity updateW = storeHelper.WrestlersList.FirstOrDefault(w => w.Name == x.ToString());

                    updateW.BrandName = "";

                    wHelper.SaveWrestlersList(updateW);
                }

                IDSetterHelper idHelper = new IDSetterHelper();

                BrandsEntity newBrand = new BrandsEntity()
                {
                    BrandID = idHelper.CurrentID(true, false, false, false,false,false,false),
                    ConnOrgName = OrgName,
                    Name = tbBrandName.Text
                };

                bHelper.SaveBrandsList(newBrand);

                CreateMain main = new CreateMain(OrgName);
                main.Show();
                this.Hide();
            }
            else
            {
                tbBrandName.BackColor = Color.MistyRose;
                lbSelectedWresters.BackColor = Color.MistyRose;
            }
        }

        private void lbAllRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnBck.Enabled = false;

            lbSelectedWresters.Enabled = true;
        }

        private void lbSelectedWresters_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnBck.Enabled = true;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string selItem = lbAllRoster.SelectedItem.ToString();

            for (int i = lbAllRoster.Items.Count - 1; i >= 0; --i)
            {
                if (lbAllRoster.Items[i].ToString().Contains(selItem))
                {
                    lbAllRoster.Items.RemoveAt(i);
                }
            }

            lbSelectedWresters.Items.Add(selItem);
            lbSelectedWresters.Refresh();
        }

        private void btnBck_Click(object sender, EventArgs e)
        {
            string selItem = lbSelectedWresters.SelectedItem.ToString();

            for (int i = lbSelectedWresters.Items.Count - 1; i >= 0; --i)
            {
                if (lbSelectedWresters.Items[i].ToString().Contains(selItem))
                {
                    lbSelectedWresters.Items.RemoveAt(i);
                }
            }

            lbAllRoster.Items.Add(selItem);
            lbAllRoster.Refresh();
        }
    }
}
