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

namespace Super_Fight.Continue.Create.Titles
{
    public partial class TitlesMain : Form
    {
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        TitleHelper tiHelper = new TitleHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public TitlesMain(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);

            storeHelper.BrandsList = bHelper.PopulateBrandsList().Where(b => b.ConnOrgName == promo.Name).ToList();

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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateMain main = new CreateMain(OrgName);
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbNewName.Text) ||
                cbxWeightClass.SelectedItem != null ||
                cbxSpec.SelectedItem != null ||
                cbxGenre.SelectedItem != null
                )
            {
                string assocCo = "";

                if (cbxAsscBrand.SelectedItem != null)
                {
                    assocCo = cbxAsscBrand.SelectedItem.ToString();
                }
                else
                {
                    assocCo = "";
                }

                TitlesEntity newTitle = new TitlesEntity()
                {
                    Name = tbNewName.Text,
                    OwnerOrgName = OrgName,
                    BrandName = assocCo,
                    WeightClass = cbxWeightClass.SelectedItem.ToString(),
                    Specialization = cbxSpec.SelectedItem.ToString(),
                    GenereType = cbxGenre.SelectedItem.ToString()
                };

                tiHelper.SaveTitlesList(newTitle);

                CreateMain main = new CreateMain(OrgName);
                main.Show();
                this.Hide();
            }
            else
            {
                tbNewName.BackColor = Color.MistyRose;
                cbxWeightClass.BackColor = Color.MistyRose;
                cbxSpec.BackColor = Color.MistyRose;
                cbxGenre.BackColor = Color.MistyRose;
            }
            
        }
    }
}
