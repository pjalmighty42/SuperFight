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

namespace Super_Fight.Edit.Wrestlers
{
    public partial class AddWrestlers : Form
    {
        WrestlerHelper wHelper = new WrestlerHelper();
        TitleHelper tHelper = new TitleHelper();
        PromotionHelper pHelper = new PromotionHelper();

        StoreEntitiesHelper shHelper = new StoreEntitiesHelper();

        private bool isEdit;
        public AddWrestlers()
        {
            InitializeComponent();

            shHelper.WrestlersList = wHelper.PopulateWrestlersList();
            shHelper.PromotionsList = pHelper.PopulatePromotionsList();

            isEdit = false;

            foreach (WrestlersEntity w in shHelper.WrestlersList)
            {
                lbWrestlerList.Items.Add(w.Name);
            }

            foreach (PromotionsEntity p in shHelper.PromotionsList)
            {
                cbxAsscCo.Items.Add(p.Name);
            }
            
            btnCreateWrest.Enabled = true;
            btnDelete.Enabled = false;
            btnEditWrestler.Enabled = false;
            tbNewName.Enabled = false;
            cbxWeight.Enabled = false;
            tbWins.Enabled = false;
            tbLosses.Enabled = false;
            tbDraws.Enabled = false;
            button4.Enabled = false;
        }

        private void rbIsCo_CheckedChanged(object sender, EventArgs e)
        {
            cbxAsscCo.Enabled = true;
        }
        

        private void button6_Click(object sender, EventArgs e)
        {
            EditMain main = new EditMain();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isEdit)
            {
                WrestlersEntity wrest = shHelper.WrestlersList.FirstOrDefault(w => w.Name == lbWrestlerList.SelectedItem.ToString());

                foreach (WrestlersEntity w in shHelper.WrestlersList)
                {
                    if (w.WrestlerID == wrest.WrestlerID)
                    {
                        if (tbNewName.Text == "" || cbxWeight.SelectedItem == null)
                        {
                            tbNewName.BackColor = Color.MistyRose;
                            cbxWeight.BackColor = Color.MistyRose;
                        }
                        else
                        {
                            int wins = 0;
                            int losses = 0;
                            int draws = 0;

                            int tempWins = 0;
                            int tempLoss = 0;
                            int tempDraws = 0;

                            if (tbWins.Text == "" ||
                                tbLosses.Text == "" ||
                                tbDraws.Text == "")
                            {
                                wins = 0;
                                losses = 0;
                                draws = 0;
                            }
                            else if (int.TryParse(tbWins.Text, out tempWins) &&
                                int.TryParse(tbLosses.Text, out tempLoss) &&
                                int.TryParse(tbDraws.Text, out tempDraws))
                            {
                                wins = tempWins;
                                losses = tempLoss;
                                draws = tempDraws;

                                IDSetterHelper idHelper = new IDSetterHelper();

                                string assocCo = "";

                                if (cbxAsscCo.SelectedItem != null)
                                {
                                    assocCo = cbxAsscCo.SelectedItem.ToString();
                                }
                                else
                                {
                                    assocCo = "";
                                }

                                wrest.Name = tbNewName.Text;
                                wrest.WeightClass = cbxWeight.SelectedItem.ToString();
                                wrest.CurrentCompanyName = assocCo;
                                wrest.Wins = wins;
                                wrest.Losses = losses;
                                wrest.Draws = draws;

                                wHelper.SaveWrestlersList(wrest);

                                EditMain main = new EditMain();
                                main.Show();
                                this.Hide();
                            }
                        }
                    }
                }
            }
            else
            {
                if (tbNewName.Text == "" || cbxWeight.SelectedItem == null)
                {
                    tbNewName.BackColor = Color.MistyRose;
                    cbxWeight.BackColor = Color.MistyRose;
                }
                else
                {
                    int wins = 0;
                    int losses = 0;
                    int draws = 0;

                    int tempWins = 0;
                    int tempLoss = 0;
                    int tempDraws = 0;

                    if (tbWins.Text == "" ||
                        tbLosses.Text == "" ||
                        tbDraws.Text == "")
                    {
                        wins = 0;
                        losses = 0;
                        draws = 0;
                    }
                    else if (int.TryParse(tbWins.Text, out tempWins) &&
                        int.TryParse(tbLosses.Text, out tempLoss) &&
                        int.TryParse(tbDraws.Text, out tempDraws))
                    {
                        wins = tempWins;
                        losses = tempLoss;
                        draws = tempDraws;

                        IDSetterHelper idHelper = new IDSetterHelper();

                        string assocCo = "";
                        string brandName = "";

                        if (cbxAsscCo.SelectedItem != null)
                        {
                            assocCo = cbxAsscCo.SelectedItem.ToString();
                        }
                        else
                        {
                            assocCo = "";
                        }

                        WrestlersEntity wrest = new WrestlersEntity()
                        {
                            WrestlerID = idHelper.CurrentID(false, false, false, false, false, false, true),
                            Name = tbNewName.Text,
                            WeightClass = cbxWeight.SelectedItem.ToString(),
                            CurrentCompanyName = assocCo,

                            Wins = Convert.ToInt32(tbWins.Text),
                            Losses = Convert.ToInt32(tbLosses.Text),
                            Draws = Convert.ToInt32(tbDraws.Text),

                            BrandName = brandName,

                            TeamName = ""
                        };

                        wHelper.SaveWrestlersList(wrest);

                        EditMain main = new EditMain();
                        main.Show();
                        this.Hide();
                    }
                }
            }
        }
        
        private void btnCreateWrest_Click(object sender, EventArgs e)
        {
            isEdit = false;

            tbWins.Text = "0";
            tbLosses.Text = "0";
            tbDraws.Text = "0";

            btnCreateWrest.Enabled = false;
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            
            button4.Enabled = true;
        }

        private void btnEditWrestler_Click(object sender, EventArgs e)
        {
            isEdit = true;

            btnCreateWrest.Enabled = false;
            tbNewName.Enabled = true;
            cbxWeight.Enabled = true;
            tbWins.Enabled = true;
            tbLosses.Enabled = true;
            tbDraws.Enabled = true;
            cbxAsscCo.Enabled = true;
            btnEditWrestler.Enabled = false;
            lbWrestlerList.Enabled = false;
            
            button4.Enabled = true;
        }
        
        private void lbWrestlerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditWrestler.Enabled = true;
            btnDelete.Enabled = true;

            WrestlersEntity wrest = shHelper.WrestlersList.FirstOrDefault(w => w.Name == lbWrestlerList.SelectedItem.ToString());

            tbNewName.Text = wrest.Name;
            tbWins.Text = wrest.Wins.ToString();
            tbLosses.Text = wrest.Losses.ToString();
            tbDraws.Text = wrest.Draws.ToString();
            cbxWeight.SelectedItem = wrest.WeightClass;
            cbxAsscCo.SelectedItem = wrest.CurrentCompanyName;
           
            button4.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string wrestToBeDELETED = lbWrestlerList.SelectedItem.ToString();

            WrestlersEntity wrest = shHelper.WrestlersList.FirstOrDefault(w => w.Name == wrestToBeDELETED);

            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Wrestlers\\" + wrest.WrestlerID + ".dat");

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
