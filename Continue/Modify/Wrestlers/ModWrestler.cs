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

namespace Super_Fight.Continue.Modify.Wrestlers
{
    public partial class ModWrestler : Form
    {
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        WrestlerHelper wHelper = new WrestlerHelper();
        TitleHelper tHelper = new TitleHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public ModWrestler(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);

            storeHelper.BrandsList = bHelper.PopulateBrandsList().Where(b => b.ConnOrgName == promo.Name).ToList();
            storeHelper.WrestlersList = wHelper.PopulateWrestlersList().Where(w => w.CurrentCompanyName == promo.Name).ToList();
            storeHelper.TitlesList = tHelper.PopulateTitlesList().Where(t => t.OwnerOrgName == promo.Name).ToList();

            foreach (WrestlersEntity w in storeHelper.WrestlersList)
            {
                cbxWrestlers.Items.Add(w.Name);
            }

            foreach (BrandsEntity b in storeHelper.BrandsList)
            {
                cbxAsscBrand.Items.Add(b.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            cbxAsscBrand.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            
            if (storeHelper.TitlesList.Count > 0)
            {
                btnSelTitles.Enabled = true;
            }
            else
            {
                btnSelTitles.Enabled = false;
            }

            button4.Enabled = true;
        }

        private void rbIsBrand_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscBrand.Enabled = true;
        }

        private void rbIsTitle_CheckedChanged(object sender, EventArgs e)
        {
            btnSelTitles.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WrestlersEntity wrest = storeHelper.WrestlersList.FirstOrDefault(w => w.Name == cbxWrestlers.SelectedItem.ToString());

            wrest.Name = tbNewName.Text;
            wrest.WeightClass = cbxWeight.SelectedItem.ToString();
            wrest.BrandName = cbxAsscBrand.SelectedItem.ToString();
            wrest.Wins = Convert.ToInt32(tbWins.Text);
            wrest.Losses = Convert.ToInt32(tbLosses.Text);
            wrest.Draws = Convert.ToInt32(tbDraws.Text);

            wHelper.SaveWrestlersList(wrest);
            
            ModifyMain main = new ModifyMain(OrgName);
            main.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain(OrgName);
            main.Show();
            this.Hide();
        }

        private void btnSelTitles_Click(object sender, EventArgs e)
        {
            WrestlersEntity wrest = storeHelper.WrestlersList.FirstOrDefault(w => w.Name == cbxWrestlers.SelectedItem.ToString());

            ModWrestlerTitles title = new ModWrestlerTitles(wrest.Name, OrgName);
            title.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WrestlersEntity wrest = storeHelper.WrestlersList.FirstOrDefault(w => w.Name == cbxWrestlers.SelectedItem.ToString());

            wrest.CurrentCompanyName = "";
            wrest.BrandName = "";

            cbxWrestlers.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string selBrand = cbxWrestlers.SelectedItem.ToString();

            for (int i = cbxWrestlers.Items.Count - 1; i >= 0; --i)
            {
                if (cbxWrestlers.Items[i].ToString().Contains(selBrand))
                {
                    cbxWrestlers.Items.RemoveAt(i);
                }
            }

            WrestlersEntity wrest = storeHelper.WrestlersList.FirstOrDefault(w => w.Name == cbxWrestlers.SelectedItem.ToString());

            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Wrestlers\\" + wrest.WrestlerID + ".dat");

            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        private void cbxWrestlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;

            WrestlersEntity wrest = storeHelper.WrestlersList.FirstOrDefault(w => w.Name == cbxWrestlers.SelectedItem.ToString());

            tbNewName.Text = wrest.Name;
            cbxWeight.SelectedItem = wrest.WeightClass;
            cbxAsscBrand.SelectedItem = wrest.BrandName;
            tbWins.Text = wrest.Wins.ToString();
            tbLosses.Text = wrest.Losses.ToString();
            tbDraws.Text = wrest.Draws.ToString();
        }
    }
}
