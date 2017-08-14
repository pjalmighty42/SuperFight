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

namespace Super_Fight.Continue.Modify.Brands
{
    public partial class ModBrands : Form
    {
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        WrestlerHelper wHelper = new WrestlerHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public ModBrands(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);

            storeHelper.BrandsList = bHelper.PopulateBrandsList().Where(b => b.ConnOrgName == promo.Name).ToList();
            storeHelper.WrestlersList = wHelper.PopulateWrestlersList().Where(w => w.CurrentCompanyName == promo.Name).ToList();
            
            foreach (BrandsEntity bAll in storeHelper.BrandsList)
            {
                cbxOvrBrands.Items.Add(bAll.Name);
            }

            if (storeHelper.BrandsList.Count < 1)
            {
                lbBrand1.Enabled = false;
                lbBrand2.Enabled = false;

                cbxBrand1.Enabled = false;
                cbxBrand2.Enabled = false;
            }
            else
            {
                lbBrand1.Enabled = true;
                lbBrand2.Enabled = true;

                foreach (BrandsEntity b in storeHelper.BrandsList)
                {
                    cbxBrand1.Items.Add(b.Name);
                    cbxBrand2.Items.Add(b.Name);
                }

                cbxBrand1.Enabled = true;
                cbxBrand2.Enabled = true;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyMain mMain = new ModifyMain(OrgName);
            mMain.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (lbBrand1.Items.Count > 0)
            {
                foreach (var b1 in lbBrand1.Items)
                {
                    WrestlersEntity w1 = wHelper.PopulateWrestlersList().FirstOrDefault(w => w.Name == b1.ToString());

                    w1.BrandName = cbxBrand1.SelectedItem.ToString();

                    wHelper.SaveWrestlersList(w1);
                }
            }

            if (lbBrand2.Items.Count > 0)
            {
                foreach (var b2 in lbBrand2.Items)
                {
                    WrestlersEntity w2 = wHelper.PopulateWrestlersList().FirstOrDefault(w => w.Name == b2.ToString());

                    w2.BrandName = cbxBrand2.SelectedItem.ToString();

                    wHelper.SaveWrestlersList(w2);
                }
            }

            ModifyMain mMain = new ModifyMain(OrgName);
            mMain.Show();
            this.Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selBrand = cbxOvrBrands.SelectedItem.ToString();

            for (int i = cbxOvrBrands.Items.Count - 1; i >= 0; --i)
            {
                if (cbxOvrBrands.Items[i].ToString().Contains(selBrand))
                {
                    cbxOvrBrands.Items.RemoveAt(i);
                }
            }

            BrandsEntity brand = storeHelper.BrandsList.FirstOrDefault(b => b.Name == selBrand);

            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Brands\\" + brand.BrandID + ".dat");

            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        private void cbxBrand1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selBrand = cbxBrand1.SelectedItem.ToString();

            List<WrestlersEntity> b1Wrestlers = wHelper.PopulateWrestlersList().Where(w => w.BrandName == selBrand).ToList();

            for (int i = cbxBrand2.Items.Count - 1; i >= 0; --i)
            {
                if (cbxBrand2.Items[i].ToString().Contains(selBrand))
                {
                   cbxBrand2.Items.RemoveAt(i);
                }
            }

            lbBrand1.Items.Clear();

            foreach (WrestlersEntity w in b1Wrestlers)
            {
                lbBrand1.Items.Add(w.Name);
            }
        }

        private void cbxBrand2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selBrand = cbxBrand2.SelectedItem.ToString();

            List<WrestlersEntity> b1Wrestlers = wHelper.PopulateWrestlersList().Where(w => w.BrandName == selBrand).ToList();

            for (int i = cbxBrand1.Items.Count - 1; i >= 0; --i)
            {
                if (cbxBrand1.Items[i].ToString().Contains(selBrand))
                {
                    cbxBrand1.Items.RemoveAt(i);
                }
            }

            lbBrand2.Items.Clear();

            foreach (WrestlersEntity w in b1Wrestlers)
            {
                lbBrand2.Items.Add(w.Name);
            }
        }

        private void lbBrand1_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMoveRight.Enabled = true;
            btnMoveLeft.Enabled = false;
        }

        private void lbBrand2_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnMoveRight.Enabled = false;
            btnMoveLeft.Enabled = true;
        }

        private void btnMoveRight_Click(object sender, EventArgs e)
        {
            string selItem = lbBrand1.SelectedItem.ToString();

            for (int i = lbBrand1.Items.Count - 1; i >= 0; --i)
            {
                if (lbBrand1.Items[i].ToString().Contains(selItem))
                {
                    lbBrand1.Items.RemoveAt(i);
                }
            }

            lbBrand2.Items.Add(selItem);
        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            string selItem = lbBrand2.SelectedItem.ToString();

            for (int i = lbBrand2.Items.Count - 1; i >= 0; --i)
            {
                if (lbBrand2.Items[i].ToString().Contains(selItem))
                {
                    lbBrand2.Items.RemoveAt(i);
                }
            }

            lbBrand1.Items.Add(selItem);
        }
    }
}
