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
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Edit.Organizations
{
    public partial class AddOrg : Form
    {
        List<Promotions> promos = new List<Promotions>();
        List<WrestlersMain> wrest = new List<WrestlersMain>();
        List<TitlesMain> titles = new List<TitlesMain>();

        PromotionHelper pHelper = new PromotionHelper();
        WrestlerHelper wHelper = new WrestlerHelper();
        TitleHelper tHelper = new TitleHelper();

        public AddOrg()
        {
            InitializeComponent();
            
            promos = pHelper.PopulatePromotionsList();
            wrest = wHelper.PopulateWrestlersList();
            titles = tHelper.PopulateTitlesList();

            if (promos.Count > 0)
            {
                foreach (Promotions p in promos)
                {
                    lbOrgList.Items.Add(p.Name);
                }
            }
            else
            {
                lbOrgList.Enabled = false;
            }
        }

        private void btnCreateOrg_Click(object sender, EventArgs e)
        {
            btnEditOrg.Enabled = false;
            tbNewName.Text = "";
            tbNewName.Enabled = true;
            tbInitals.Text = "";
            tbInitals.Enabled = true;
            cbxLoc.Enabled = true;

            if (wrest.Count > 0)
            {
                btnAddWrest.Enabled = true;
            }
            else
            {
                btnAddWrest.Enabled = false;
            }

            if (titles.Count > 0)
            {
                btnAddTitle.Enabled = true;
            }
            else
            {
                btnAddTitle.Enabled = false;
            }
        }

        private void btnEditOrg_Click(object sender, EventArgs e)
        {
            tbNewName.Enabled = true;
            tbInitals.Enabled = true;
            cbxLoc.Enabled = true;

            if (wrest.Count > 0)
            {
                btnAddWrest.Enabled = true;
            }
            else
            {
                btnAddWrest.Enabled = false;
            }

            if (titles.Count > 0)
            {
                btnAddTitle.Enabled = true;
            }
            else
            {
                btnAddTitle.Enabled = false;
            }
        }

        private void btnAddWrest_Click(object sender, EventArgs e)
        {
            AddOrgAddWrest wrest = new AddOrgAddWrest();
            wrest.Show();
        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            AddOrgAddTitles title = new AddOrgAddTitles();
            title.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tbNewName.Text == null || tbInitals.Text == null || cbxLoc.SelectedItem == null)
            {
                tbNewName.BackColor = Color.MistyRose;
                tbInitals.BackColor = Color.MistyRose;
                cbxLoc.BackColor = Color.MistyRose;
            }
            else
            {
                Promotions newPromo = new Promotions()
                {
                    Name = tbNewName.Text,
                    Initals = tbInitals.Text,
                    Location = cbxLoc.SelectedItem.ToString()
                };

                pHelper.SavePromotionsList(newPromo);

                EditMain main = new EditMain();
                main.Show();
                this.Hide();
            }
        }

        private void lbOrgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbOrgList.SelectedItems.Count == 1)
            {
                Promotions promo =  promos.FirstOrDefault(p => p.Name == lbOrgList.SelectedItem.ToString());

                tbNewName.Text = promo.Name;
                tbInitals.Text = promo.Initals;
                cbxLoc.SelectedItem = promo.Location;
                btnEditOrg.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (lbOrgList.SelectedItems.Count == 1)
            {
                Promotions promo = promos.FirstOrDefault(p => p.Name == lbOrgList.SelectedItem.ToString());

                pHelper.DeletePromotion(promo);

                EditMain main = new EditMain();
                main.Show();
                this.Hide();
            }
        }
    }
}
