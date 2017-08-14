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

namespace Super_Fight.Edit.Titles
{
    public partial class AddTitles : Form
    {
        TitleHelper tHelper = new TitleHelper();
        PromotionHelper pHelper = new PromotionHelper();
        WrestlerHelper wHelper = new WrestlerHelper();

        IDSetterHelper idHelper = new IDSetterHelper();
        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        private bool isEdit;

        public AddTitles()
        {
            InitializeComponent();

            storeHelper.TitlesList = tHelper.PopulateTitlesList();
            storeHelper.PromotionsList = pHelper.PopulatePromotionsList();
            storeHelper.WrestlersList = wHelper.PopulateWrestlersList();

            btnCreateChamp.Enabled = true;
            tbNewName.Enabled = false;
            cbxWeight.Enabled = false;
            cbxAsscOrg.Enabled = false;
            cbxSpec.Enabled = false;
            cbxGenre.Enabled = false;
            button4.Enabled = false;

            isEdit = false;

            foreach (TitlesEntity t in storeHelper.TitlesList)
            {
                lbChampList.Items.Add(t.Name);
            }

            foreach (PromotionsEntity p in storeHelper.PromotionsList)
            {
                cbxAsscOrg.Items.Add(p.Name);
            }
        }

        private void btnCreateChamp_Click(object sender, EventArgs e)
        {
            isEdit = false;

            btnCreateChamp.Enabled = false;
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            cbxAsscOrg.Enabled = true;
            cbxSpec.Enabled = true;
            cbxGenre.Enabled = true;
            
            btnEditChamp.Enabled = false;
            button4.Enabled = true;
        }

        private void btnEditChamp_Click(object sender, EventArgs e)
        {
            isEdit = true;

            btnCreateChamp.Enabled = false;
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            cbxAsscOrg.Enabled = true;
            cbxSpec.Enabled = true;
            cbxGenre.Enabled = true;
            btnEditChamp.Enabled = false;

            lbChampList.Enabled = false;
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                if (tbNewName.Text == "" ||
               cbxWeight.SelectedItem == null ||
               cbxSpec.SelectedItem == null ||
               cbxAsscOrg.SelectedItem == null ||
               cbxGenre.SelectedItem == null
               )
                {
                    tbNewName.BackColor = Color.MistyRose;
                    cbxWeight.BackColor = Color.MistyRose;
                    cbxSpec.BackColor = Color.MistyRose;
                    cbxAsscOrg.BackColor = Color.MistyRose;
                    cbxGenre.BackColor = Color.MistyRose;
                }
                else
                {
                    TitlesEntity title = tHelper.PopulateTitlesList().FirstOrDefault(ti => ti.Name == lbChampList.SelectedItem.ToString());

                    foreach (TitlesEntity t in storeHelper.TitlesList)
                    {
                        if (t.TitleID == title.TitleID)
                        {
                            title.Name = tbNewName.Text;
                            title.WeightClass = cbxWeight.SelectedItem.ToString();
                            title.OwnerOrgName = cbxAsscOrg.SelectedItem.ToString();
                            title.Specialization = cbxSpec.SelectedItem.ToString();
                            title.GenereType = cbxGenre.SelectedItem.ToString();

                            tHelper.SaveTitlesList(title);

                            EditMain main = new EditMain();
                            main.Show();
                            this.Hide();
                        }
                    }
                }
            }
            else
            {
                if (tbNewName.Text == "" ||
              cbxWeight.SelectedItem == null ||
              cbxSpec.SelectedItem == null ||
              cbxAsscOrg.SelectedItem == null ||
              cbxGenre.SelectedItem == null
              )
                {
                    tbNewName.BackColor = Color.MistyRose;
                    cbxWeight.BackColor = Color.MistyRose;
                    cbxSpec.BackColor = Color.MistyRose;
                    cbxAsscOrg.BackColor = Color.MistyRose;
                    cbxGenre.BackColor = Color.MistyRose;
                }
                else
                {
                    TitlesEntity title = new TitlesEntity()
                    {
                        TitleID = idHelper.CurrentID(false,false,false,false,false,true,false),
                        Name = tbNewName.Text,
                        WeightClass = cbxWeight.SelectedItem.ToString(),
                        OwnerOrgName = cbxAsscOrg.SelectedItem.ToString(),
                        Specialization = cbxSpec.SelectedItem.ToString(),
                        GenereType = cbxGenre.SelectedItem.ToString()
                    };

                    tHelper.SaveTitlesList(title);

                    EditMain main = new EditMain();
                    main.Show();
                    this.Hide();
                }
            }
        }
        
        private void lbChampList_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNewName.Text = "";
            cbxAsscOrg.SelectedItem = null;
            cbxGenre.SelectedItem = null;
            cbxSpec.SelectedItem = null;
            cbxWeight.SelectedItem = null;
            
            string selectedTitle = lbChampList.SelectedItem.ToString();

            TitlesEntity title = storeHelper.TitlesList.FirstOrDefault(t => t.Name == selectedTitle);

            tbNewName.Text = title.Name;
            cbxAsscOrg.SelectedItem = title.OwnerOrgName;
            cbxGenre.SelectedItem = title.GenereType;
            cbxSpec.SelectedItem = title.Specialization;
            cbxWeight.SelectedItem = title.WeightClass;

            btnEditChamp.Enabled = true;
            button4.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string teamToBeDELETED = lbChampList.SelectedItem.ToString();

            TitlesEntity title = tHelper.PopulateTitlesList().FirstOrDefault(t => t.Name == teamToBeDELETED);
            
            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Titles\\" + title.TitleID + ".dat");

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
