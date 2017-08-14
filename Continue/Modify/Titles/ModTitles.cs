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

namespace Super_Fight.Continue.Modify.Titles
{
    public partial class ModTitles : Form
    {
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        TitleHelper tHelper = new TitleHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public ModTitles(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);

            storeHelper.BrandsList = bHelper.PopulateBrandsList().Where(b => b.ConnOrgName == promo.Name).Distinct().ToList();
            storeHelper.TitlesList = tHelper.PopulateTitlesList().Where(t => t.OwnerOrgName == promo.Name).Distinct().ToList();

            foreach (TitlesEntity t in storeHelper.TitlesList)
            {
                cbxTitles.Items.Add(t.Name);
            }

            if (storeHelper.BrandsList.Count > 0)
            {

                cbxAsscBrand.Items.Add("");
                foreach (BrandsEntity b in storeHelper.BrandsList)
                {
                    cbxAsscBrand.Items.Add(b.Name);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyMain main = new ModifyMain(OrgName);
            main.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TitlesEntity title = storeHelper.TitlesList.FirstOrDefault(t => t.Name == cbxTitles.SelectedItem.ToString());

            if (storeHelper.BrandsList.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(title.BrandName))
                {
                    cbxAsscBrand.SelectedIndex = cbxAsscBrand.Items.IndexOf(title.BrandName);
                    cbxAsscBrand.Refresh();
                }
                
                cbxAsscBrand.Enabled = true;
            }
            else
            {
                cbxAsscBrand.Enabled = false;
            }

            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            cbxSpec.Enabled = true;
            cbxGenre.Enabled = true;

            cbxTitles.Enabled = false;
        }

        private void rbIsBrand_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscBrand.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbNewName.Text))
            {
                tbNewName.BackColor = Color.MistyRose;
            }
            else
            {
                string tName = cbxTitles.SelectedItem.ToString();

                TitlesEntity selTitle = storeHelper.TitlesList.FirstOrDefault(t => t.Name == tName);

                selTitle.Name = tbNewName.Text;
                selTitle.WeightClass = cbxWeight.SelectedItem.ToString();

                if (cbxAsscBrand.SelectedItem.ToString() != "")
                {
                    selTitle.BrandName = cbxAsscBrand.SelectedItem.ToString();
                }

                selTitle.Specialization = cbxSpec.SelectedItem.ToString();
                selTitle.GenereType = cbxGenre.SelectedItem.ToString();
                
                tHelper.SaveTitlesList(selTitle);
                
                ModifyMain main = new ModifyMain(OrgName);
                main.Show();
                this.Hide();
            }
        }

        private void cbxTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            TitlesEntity title = storeHelper.TitlesList.FirstOrDefault(t => t.Name == cbxTitles.SelectedItem.ToString());

            tbNewName.Text = title.Name;
            cbxWeight.SelectedItem = title.WeightClass;

            if (storeHelper.BrandsList.Count > 0)
            {
                cbxAsscBrand.Items.Clear();

                cbxAsscBrand.Items.Add("");
                foreach (BrandsEntity b in storeHelper.BrandsList)
                {
                    cbxAsscBrand.Items.Add(b.Name);
                }

                if (!string.IsNullOrWhiteSpace(title.BrandName))
                {
                    cbxAsscBrand.SelectedIndex = cbxAsscBrand.Items.IndexOf(title.BrandName);
                    cbxAsscBrand.Refresh();
                }
            }
            
            cbxSpec.SelectedItem = title.Specialization;
            cbxGenre.SelectedItem = title.GenereType;
            
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            TitlesEntity title = storeHelper.TitlesList.FirstOrDefault(t => t.Name == cbxTitles.SelectedItem.ToString());

            string selBrand = cbxTitles.SelectedItem.ToString();

            for (int i = cbxTitles.Items.Count - 1; i >= 0; --i)
            {
                if (cbxTitles.Items[i].ToString().Contains(selBrand))
                {
                    cbxTitles.Items.RemoveAt(i);
                }
            }

            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Titles\\" + title.TitleID + ".dat");

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            ModifyMain main = new ModifyMain(OrgName);
            main.Show();
            this.Hide();
        }
    }
}
