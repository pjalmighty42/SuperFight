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
using Super_Fight.Edit.Edit_Organizations;
using Super_Fight.Edit.Titles;
using Super_Fight.Entities;
using Super_Fight.Helpers;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Edit.Organizations
{
    public partial class AddOrg : Form
    {
        WrestlerHelper wHelper = new WrestlerHelper();
        TitleHelper tHelper = new TitleHelper();
        PromotionHelper pHelper = new PromotionHelper();

        StoreEntitiesHelper shHelper = new StoreEntitiesHelper();
        IDSetterHelper idHelper = new IDSetterHelper();

        private bool isEditOrg;

        public AddOrg()
        {
            InitializeComponent();

            shHelper.WrestlersList = wHelper.PopulateWrestlersList();
            shHelper.TitlesList = tHelper.PopulateTitlesList();
            shHelper.PromotionsList = pHelper.PopulatePromotionsList();

            isEditOrg = false;
            
            foreach (PromotionsEntity p in shHelper.PromotionsList)
            {
                lbOrgList.Items.Add(p.Name);
            }

            btnCreateOrg.Enabled = true;
            tbNewName.Enabled = false;
            tbInitals.Enabled = false;
            cbxLoc.Enabled = false;
            btnAddWrest.Enabled = false;
            btnAddTitle.Enabled = false;
            btnEditOrg.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnCreateOrg_Click(object sender, EventArgs e)
        {
            isEditOrg = false;

            btnCreateOrg.Enabled = false;
            btnEditOrg.Enabled = false;

            tbNewName.Text = "";
            tbInitals.Text = "";

            tbNewName.Enabled = true;
            tbInitals.Enabled = true;
            cbxLoc.Enabled = true;

            btnAddWrest.Enabled = false;
            btnAddTitle.Enabled = false;
            button4.Enabled = true;
        }

        private void btnEditOrg_Click(object sender, EventArgs e)
        {
            isEditOrg = true;

            btnCreateOrg.Enabled = false;
            btnEditOrg.Enabled = false;

            tbNewName.Enabled = true;
            tbInitals.Enabled = true;
            cbxLoc.Enabled = true;

            btnAddWrest.Enabled = true;
            btnAddTitle.Enabled = true;

            lbOrgList.Enabled = false;

            button4.Enabled = true;
        }

        private void btnAddWrest_Click(object sender, EventArgs e)
        {
            AddOrgAddWrest wrest = new AddOrgAddWrest(tbNewName.Text);
            wrest.Show();
        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            AddOrgAddTitles tAdd = new AddOrgAddTitles(tbNewName.Text);
            tAdd.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isEditOrg)
            {
                if (tbInitals.Text == "" || tbNewName.Text == "" || cbxLoc.SelectedItem == null)
                {
                    tbNewName.BackColor = Color.MistyRose;
                    tbInitals.BackColor = Color.MistyRose;
                    cbxLoc.BackColor = Color.MistyRose;
                }
                else
                {
                    PromotionsEntity promo = shHelper.PromotionsList.FirstOrDefault(p => p.Name == lbOrgList.SelectedItem.ToString());

                    foreach (PromotionsEntity p in shHelper.PromotionsList)
                    {
                        if (p.OrgID == promo.OrgID)
                        {
                            promo.Name = tbNewName.Text;
                            promo.Initals = tbInitals.Text;
                            promo.Location = cbxLoc.SelectedItem.ToString();

                            pHelper.SavePromotionsList(promo);
                        }
                    }
                    
                    EditMain main = new EditMain();
                    main.Show();
                    this.Hide();
                }
            }
            else
            {
                if (tbInitals.Text == "" || tbNewName.Text == "" || cbxLoc.SelectedItem == null)
                {
                    tbNewName.BackColor = Color.MistyRose;
                    tbInitals.BackColor = Color.MistyRose;
                    cbxLoc.BackColor = Color.MistyRose;
                }
                else
                {
                    PromotionsEntity promo = new PromotionsEntity()
                    {
                        OrgID = idHelper.CurrentID(false, false, false, true, false, false, false),
                        Name = tbNewName.Text,
                        Initals = tbInitals.Text,
                        Location = cbxLoc.SelectedItem.ToString()
                    };

                    pHelper.SavePromotionsList(promo);

                    EditMain main = new EditMain();
                    main.Show();
                    this.Hide();
                }
            }
        }

        private void lbOrgList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNewName.Text = "";
            tbInitals.Text = "";
            cbxLoc.SelectedItem = null;
            
            PromotionsEntity promo = shHelper.PromotionsList.FirstOrDefault(p => p.Name == lbOrgList.SelectedItem.ToString());

            tbNewName.Text = promo.Name;
            tbInitals.Text = promo.Initals;
            cbxLoc.SelectedItem = promo.Location;

            btnEditOrg.Enabled = true;
            btnCreateOrg.Enabled = false;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string orgToBeDELETED = lbOrgList.SelectedItem.ToString();
            
            List<WrestlersEntity> selW = shHelper.WrestlersList.Where(w => w.CurrentCompanyName == orgToBeDELETED).ToList();
            List<TitlesEntity> selT = shHelper.TitlesList.Where(t => t.OwnerOrgName == orgToBeDELETED).ToList();
            List<TeamsEntity> selTeams = shHelper.TeamsList.Where(te => te.OrgName == orgToBeDELETED).ToList();

            foreach (WrestlersEntity w in selW)
            {
                w.CurrentCompanyName = "";
                w.BrandName = "";
                
                w.TeamName = "";
                
                
                wHelper.SaveWrestlersList(w);
            }

            foreach (TitlesEntity t in selT)
            {
                t.OwnerOrgName = "";

                tHelper.SaveTitlesList(t);
            }

            //Delete Teams attached to Org (cannot have team w/o org it performs in)
            foreach (TeamsEntity t in selTeams)
            {
                string teamFile = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Teams\\" + t.TeamID + ".dat");

                if (File.Exists(teamFile))
                {
                    File.Delete(teamFile);
                }
            }

            PromotionsEntity promo = shHelper.PromotionsList.FirstOrDefault(p => p.Name == lbOrgList.SelectedItem.ToString());

            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Promotions\\" + promo.OrgID + ".dat");

            if (File.Exists(file))
            {
                File.Delete(file);
            }

            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }
    }
}
