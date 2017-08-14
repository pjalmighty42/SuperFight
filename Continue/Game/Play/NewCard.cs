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
using Super_Fight.Continue.Game.Finalize;
using Super_Fight.Entities;
using Super_Fight.Helpers;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Continue.Game.Play
{
    public partial class NewCard : Form
    {
        private string OrgName;
        private string CardName;
        private bool bIsNewCard;

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();
        IDSetterHelper idHelper = new IDSetterHelper();

        PromotionHelper pHelper = new PromotionHelper();
        BrandHelper bHelper = new BrandHelper();
        WrestlerHelper wHelper = new WrestlerHelper();
        TeamHelper tHelper = new TeamHelper();
        TitleHelper tiHelper = new TitleHelper();
        MatchHelper mHelper = new MatchHelper();
        CardHelper cHelper = new CardHelper();

        public NewCard(string orgName, bool isNewCard = true, string cardName = "", int currWrestNum = 0)
        {
            InitializeComponent();

            this.Invalidate();
            
            OrgName = orgName;
            CardName = cardName;
            bIsNewCard = isNewCard;

            if (bIsNewCard)
            {
                storeHelper.WrestlersList = wHelper.PopulateWrestlersList();
                storeHelper.TeamsList = tHelper.PopulateTeamsList();
                storeHelper.TitlesList = tiHelper.PopulateTitlesList();
                storeHelper.PromotionsList = pHelper.PopulatePromotionsList();
                storeHelper.BrandsList = bHelper.PopulateBrandsList();
                storeHelper.CardsList = cHelper.PopulateCardsList();
                
                //This gets the int id of the most recent card (aka- this one)
                int currCard = storeHelper.CardsList.Count();

                PromotionsEntity promo = storeHelper.PromotionsList.FirstOrDefault(p => p.Name == OrgName);
                CardsEntity thisCard = storeHelper.CardsList.FirstOrDefault(c => c.ConnOrgName == promo.Name && c.CardID == currCard);

                List<MatchesEntity> cardM = storeHelper.MatchesList.Where(m => m.AttachedCardName == thisCard.CardName).ToList();

                List<BrandsEntity> brands = storeHelper.BrandsList.Where(b => b.ConnOrgName == promo.Name).ToList();
                
                if (brands.Count == 0)
                {
                    cbxBrandName.Items.Add("");
                    cbxBrandName.SelectedIndex = 0;
                }
                else
                {
                    cbxBrandName.Items.Add("");
                    foreach (BrandsEntity b in brands)
                    {
                        cbxBrandName.Items.Add(b.Name);
                    }

                    cbxBrandName.SelectedIndex = 0;
                }
                
                button1.Enabled = false;
            }
            else
            {
                storeHelper.CardsList = cHelper.PopulateCardsList();

                //This gets the int id of the most recent card (aka- this one)
                int currCard = storeHelper.CardsList.Count();

                storeHelper.MatchesList = mHelper.PopulateMatchesList();
                storeHelper.PromotionsList = pHelper.PopulatePromotionsList();
                storeHelper.BrandsList = bHelper.PopulateBrandsList();
                
                PromotionsEntity promo = storeHelper.PromotionsList.FirstOrDefault(p => p.Name == OrgName);
                List<BrandsEntity> brands = storeHelper.BrandsList.Where(b => b.ConnOrgName == promo.Name).ToList();
                CardsEntity thisCard = storeHelper.CardsList.FirstOrDefault(c => c.ConnOrgName == promo.Name && c.CardID == currCard);

                List<MatchesEntity> cardM = storeHelper.MatchesList.Where(m => m.AttachedCardName == thisCard.CardName).ToList();

                if (brands.Count == 0)
                {
                    cbxBrandName.Items.Add("");
                    cbxBrandName.SelectedItem = "";
                }
                else
                {
                    cbxBrandName.Items.Add("");
                    foreach (BrandsEntity b in brands)
                    {
                        cbxBrandName.Items.Add(b.Name);
                    }
                }

                tbCardTitle.Text = thisCard.CardName;
                tbCardTitle.Enabled = false;
                cbxLocation.Text = thisCard.Location;
                cbxLocation.Enabled = false;
                cbxBrandName.Text = thisCard.BrandName;
                cbxBrandName.Enabled = false;

              
                switch (cardM.Count)
                {
                    case 1:
                        btnMatch1.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch1Clr.Enabled = true;

                        btnMatch2.Enabled = true;
                        break;
                    case 2:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        break;
                    case 3:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        break;
                    case 4:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        break;
                    case 5:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;
                        btnMatch6.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);
                        btnMatch5.Text = ButtonTextOutput(cardM, 4);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        btnMatch5Clr.Enabled = true;
                        break;
                    case 6:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;
                        btnMatch6.Enabled = true;
                        btnMatch7.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);
                        btnMatch5.Text = ButtonTextOutput(cardM, 4);
                        btnMatch6.Text = ButtonTextOutput(cardM, 5);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        btnMatch5Clr.Enabled = true;
                        btnMatch6Clr.Enabled = true;
                        break;
                    case 7:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;
                        btnMatch6.Enabled = true;
                        btnMatch7.Enabled = true;
                        btnMatch8.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);
                        btnMatch5.Text = ButtonTextOutput(cardM, 4);
                        btnMatch6.Text = ButtonTextOutput(cardM, 5);
                        btnMatch7.Text = ButtonTextOutput(cardM, 6);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        btnMatch5Clr.Enabled = true;
                        btnMatch6Clr.Enabled = true;
                        btnMatch7Clr.Enabled = true;
                        break;
                    case 8:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;
                        btnMatch6.Enabled = true;
                        btnMatch7.Enabled = true;
                        btnMatch8.Enabled = true;
                        btnMatch9.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);
                        btnMatch5.Text = ButtonTextOutput(cardM, 4);
                        btnMatch6.Text = ButtonTextOutput(cardM, 5);
                        btnMatch7.Text = ButtonTextOutput(cardM, 6);
                        btnMatch8.Text = ButtonTextOutput(cardM, 7);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        btnMatch5Clr.Enabled = true;
                        btnMatch6Clr.Enabled = true;
                        btnMatch7Clr.Enabled = true;
                        btnMatch8Clr.Enabled = true;
                        break;
                    case 9:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;
                        btnMatch6.Enabled = true;
                        btnMatch7.Enabled = true;
                        btnMatch8.Enabled = true;
                        btnMatch9.Enabled = true;
                        btnMatch10.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);
                        btnMatch5.Text = ButtonTextOutput(cardM, 4);
                        btnMatch6.Text = ButtonTextOutput(cardM, 5);
                        btnMatch7.Text = ButtonTextOutput(cardM, 6);
                        btnMatch8.Text = ButtonTextOutput(cardM, 7);
                        btnMatch9.Text = ButtonTextOutput(cardM, 8);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        btnMatch5Clr.Enabled = true;
                        btnMatch6Clr.Enabled = true;
                        btnMatch7Clr.Enabled = true;
                        btnMatch8Clr.Enabled = true;
                        btnMatch9Clr.Enabled = true;
                        break;
                    case 10:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;
                        btnMatch6.Enabled = true;
                        btnMatch7.Enabled = true;
                        btnMatch8.Enabled = true;
                        btnMatch9.Enabled = true;
                        btnMatch10.Enabled = true;
                        btnMatch11.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);
                        btnMatch5.Text = ButtonTextOutput(cardM, 4);
                        btnMatch6.Text = ButtonTextOutput(cardM, 5);
                        btnMatch7.Text = ButtonTextOutput(cardM, 6);
                        btnMatch8.Text = ButtonTextOutput(cardM, 7);
                        btnMatch9.Text = ButtonTextOutput(cardM, 8);
                        btnMatch10.Text = ButtonTextOutput(cardM, 9);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        btnMatch5Clr.Enabled = true;
                        btnMatch6Clr.Enabled = true;
                        btnMatch7Clr.Enabled = true;
                        btnMatch8Clr.Enabled = true;
                        btnMatch9Clr.Enabled = true;
                        btnMatch10Clr.Enabled = true;
                        break;
                    case 11:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;
                        btnMatch6.Enabled = true;
                        btnMatch7.Enabled = true;
                        btnMatch8.Enabled = true;
                        btnMatch9.Enabled = true;
                        btnMatch10.Enabled = true;
                        btnMatch11.Enabled = true;
                        btnMatch12.Enabled = true;
                        btnMatch12Clr.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);
                        btnMatch5.Text = ButtonTextOutput(cardM, 4);
                        btnMatch6.Text = ButtonTextOutput(cardM, 5);
                        btnMatch7.Text = ButtonTextOutput(cardM, 6);
                        btnMatch8.Text = ButtonTextOutput(cardM, 7);
                        btnMatch9.Text = ButtonTextOutput(cardM, 8);
                        btnMatch10.Text = ButtonTextOutput(cardM, 9);
                        btnMatch11.Text = ButtonTextOutput(cardM, 10);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        btnMatch5Clr.Enabled = true;
                        btnMatch6Clr.Enabled = true;
                        btnMatch7Clr.Enabled = true;
                        btnMatch8Clr.Enabled = true;
                        btnMatch9Clr.Enabled = true;
                        btnMatch10Clr.Enabled = true;
                        btnMatch11Clr.Enabled = true;
                        break;
                    case 12:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = true;
                        btnMatch3.Enabled = true;
                        btnMatch4.Enabled = true;
                        btnMatch5.Enabled = true;
                        btnMatch6.Enabled = true;
                        btnMatch7.Enabled = true;
                        btnMatch8.Enabled = true;
                        btnMatch9.Enabled = true;
                        btnMatch10.Enabled = true;
                        btnMatch11.Enabled = true;
                        btnMatch12.Enabled = true;

                        btnMatch1.Text = ButtonTextOutput(cardM, 0);
                        btnMatch2.Text = ButtonTextOutput(cardM, 1);
                        btnMatch3.Text = ButtonTextOutput(cardM, 2);
                        btnMatch4.Text = ButtonTextOutput(cardM, 3);
                        btnMatch5.Text = ButtonTextOutput(cardM, 4);
                        btnMatch6.Text = ButtonTextOutput(cardM, 5);
                        btnMatch7.Text = ButtonTextOutput(cardM, 6);
                        btnMatch8.Text = ButtonTextOutput(cardM, 7);
                        btnMatch9.Text = ButtonTextOutput(cardM, 8);
                        btnMatch10.Text = ButtonTextOutput(cardM, 9);
                        btnMatch11.Text = ButtonTextOutput(cardM, 10);
                        btnMatch12.Text = ButtonTextOutput(cardM, 11);

                        btnMatch1Clr.Enabled = true;
                        btnMatch2Clr.Enabled = true;
                        btnMatch3Clr.Enabled = true;
                        btnMatch4Clr.Enabled = true;
                        btnMatch5Clr.Enabled = true;
                        btnMatch6Clr.Enabled = true;
                        btnMatch7Clr.Enabled = true;
                        btnMatch8Clr.Enabled = true;
                        btnMatch9Clr.Enabled = true;
                        btnMatch10Clr.Enabled = true;
                        btnMatch11Clr.Enabled = true;
                        btnMatch12Clr.Enabled = true;
                        break;
                    default:
                        btnMatch1.Enabled = true;
                        btnMatch2.Enabled = false;
                        btnMatch3.Enabled = false;
                        btnMatch4.Enabled = false;
                        btnMatch5.Enabled = false;
                        btnMatch6.Enabled = false;
                        btnMatch7.Enabled = false;
                        btnMatch8.Enabled = false;
                        btnMatch9.Enabled = false;
                        btnMatch10.Enabled = false;
                        btnMatch11.Enabled = false;
                        btnMatch12.Enabled = false;

                        btnMatch1Clr.Enabled = false;
                        btnMatch2Clr.Enabled = false;
                        btnMatch3Clr.Enabled = false;
                        btnMatch4Clr.Enabled = false;
                        btnMatch5Clr.Enabled = false;
                        btnMatch6Clr.Enabled = false;
                        btnMatch7Clr.Enabled = false;
                        btnMatch8Clr.Enabled = false;
                        btnMatch9Clr.Enabled = false;
                        btnMatch10Clr.Enabled = false;
                        btnMatch11Clr.Enabled = false;
                        btnMatch12Clr.Enabled = false;
                        break;
                }
                
                button1.Enabled = true;
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContinueMain cont = new ContinueMain();
            cont.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardsEntity card = new CardsEntity()
            {
                CardName = tbCardTitle.Text,
                Location = cbxLocation.SelectedItem.ToString(),
                ConnOrgName = OrgName
            };

            CardHelper cHelper = new CardHelper();

            cHelper.SaveCardsList(card);

            FinalizeCard finalize = new FinalizeCard(card.CardID);
            finalize.Show();
            this.Hide();
        }

        private void btnMatch1_Click(object sender, EventArgs e)
        {
            NewMatchAddCard(1);
        }

        private void btnMatch2_Click(object sender, EventArgs e)
        {
            NewMatch(2);
        }

        private void btnMatch3_Click(object sender, EventArgs e)
        {
            NewMatch(3);
        }

        private void btnMatch4_Click(object sender, EventArgs e)
        {
            NewMatch(4);
        }

        private void btnMatch5_Click(object sender, EventArgs e)
        {
            NewMatch(5);
        }

        private void btnMatch6_Click(object sender, EventArgs e)
        {
            NewMatch(6);
        }

        private void btnMatch7_Click(object sender, EventArgs e)
        {
            NewMatch(7);
        }

        private void btnMatch8_Click(object sender, EventArgs e)
        {
            NewMatch(8);
        }

        private void btnMatch9_Click(object sender, EventArgs e)
        {
            NewMatch(9);
        }

        private void btnMatch10_Click(object sender, EventArgs e)
        {
            NewMatch(10);
        }


        private void btnMatch11_Click(object sender, EventArgs e)
        {
            NewMatch(11);
        }
        
        private void btnMatch12_Click(object sender, EventArgs e)
        {
            NewMatch(12);
        }


        //DELETE!! DELETE!! DELETE!!!
        private void btnMatch1Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(0);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);
                
            //thisForm.Invalidate();
            btnMatch1.Text = "Match 1";
        }

        private void btnMatch2Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(1);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch2.Text = "Match 2";
        }

        private void btnMatch3Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(2);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch3.Text = "Match 3";
        }

        private void btnMatch4Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(3);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch4.Text = "Match 4";
        }

        private void btnMatch5Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(4);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch5.Text = "Match 5";
        }

        private void btnMatch6Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(5);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch6.Text = "Match 6";
        }

        private void btnMatch7Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(6);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch7.Text = "Match 7";
        }

        private void btnMatch8Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(7);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch8.Text = "Match 8";
        }

        private void btnMatch9Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(8);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch9.Text = "Match 9";
        }

        private void btnMatch10Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(9);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch10.Text = "Match 10";
        }

        private void btnMatch11Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(10);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch11.Text = "Match 11";
        }

        private void btnMatch12Clr_Click(object sender, EventArgs e)
        {
            DELETEObsoleteMuleMatch(11);
            ResetAllMatches(storeHelper.MatchesList);

            NewCard thisForm = new NewCard(OrgName, false, CardName);

            thisForm.Invalidate();
            btnMatch12.Text = "Match 12";
        }

        
        private void NewMatchAddCard(int matchNum)
        {
            if (!string.IsNullOrWhiteSpace(tbCardTitle.Text) &&
                    cbxLocation.SelectedItem != null
            )
            {
                string brandName = cbxBrandName.SelectedItem.ToString();

                //Why are we saving this? FOR SCIENCE~! (And also because this will help us draw the correct matches for this card to populate the LV)
                CardsEntity thisCard = new CardsEntity()
                {
                    CardID = idHelper.CurrentID(false, true, false, false, false, false, false),
                    CardName = tbCardTitle.Text,
                    ConnOrgName = OrgName,
                    BrandName = brandName,
                    Location = cbxLocation.SelectedItem.ToString()
                };

                cHelper.SaveCardsList(thisCard);

                AddMatch add = new AddMatch(tbCardTitle.Text, OrgName, brandName, matchNum);
                add.Show();
                this.Hide();
            }
            else
            {
                tbCardTitle.BackColor = Color.MistyRose;
                cbxLocation.BackColor = Color.MistyRose;
            }
        }

        private void NewMatch(int matchNum)
        {
            if (!string.IsNullOrWhiteSpace(tbCardTitle.Text) &&
                    cbxLocation.SelectedItem != null
            )
            {
                string brandName = cbxBrandName.SelectedItem.ToString();
                
                AddMatch add = new AddMatch(tbCardTitle.Text, OrgName, brandName, matchNum);
                add.Show();
                this.Hide();
            }
            else
            {
                tbCardTitle.BackColor = Color.MistyRose;
                cbxLocation.BackColor = Color.MistyRose;
            }
        }

        private void DELETEObsoleteMuleMatch(int index)
        {
            //0-based n-1 == actual Index
            MatchesEntity matchToBeDELETED = storeHelper.MatchesList[index];

            string file = string.Concat(Directory.GetCurrentDirectory(), "\\Saves\\Main\\Matches\\" + matchToBeDELETED.MatchID + ".dat");

            if (File.Exists(file) == true)
            {
                File.Delete(file);
            }
        }

        private string ButtonTextOutput(List<MatchesEntity> cardM, int index)
        {
            string buttonText = "";
            
            if (cardM[index].MatchType == "Singles Match")
            {
                buttonText = "Match " + index + "- " + cardM[index].Participant1 + " vs " + cardM[index].Participant2;
            }
            else if (cardM[index].MatchType == "Tag Team Match")
            {
                buttonText = "Match " + index + "- " + cardM[index].Participant1 + " & " +
                            cardM[index].Participant3 + " vs " +
                            cardM[index].Participant2 + " & " +
                            cardM[index].Participant4;
            }
            else if (cardM[index].MatchType == "6-Man Tag Match")
            {
                buttonText = "Match - " + index + " " +
                            cardM[index].Participant1 + " & " +
                            cardM[index].Participant3 + " & " +
                            cardM[index].Participant5 + " vs " +
                            cardM[index].Participant2 + " & " +
                            cardM[index].Participant4 + " & " +
                            cardM[index].Participant6 + " & ";
            }
            else if (cardM[index].MatchType == "8-Man Tag Match")
            {
                buttonText = "Match - " + index + " " +
                            cardM[index].Participant1 + " & " +
                            cardM[index].Participant3 + " & " +
                            cardM[index].Participant5 + " & " +
                            cardM[index].Participant7 + " vs " +
                            cardM[index].Participant2 + " & " +
                            cardM[index].Participant4 + " & " +
                            cardM[index].Participant6 + " & " +
                            cardM[index].Participant8;
            }
            else if (cardM[index].MatchType == "Battle Royal")
            {
                buttonText = "Match - " + index + " " +
                            cardM[index].Participant1 + " vs " +
                            cardM[index].Participant2 + " vs " +
                            cardM[index].Participant3 + " vs " +
                            cardM[index].Participant4 + " vs " +
                            cardM[index].Participant5 + " vs " +
                            cardM[index].Participant6 + " vs " +
                            cardM[index].Participant7 + " vs " +
                            cardM[index].Participant8;
            }
            else
            {
                buttonText = "Match - " + index;
            }

            return buttonText;
        }

        private void ResetAllMatches(List<MatchesEntity> matchList)
        {
            if (matchList.Count > 0)
            {
                for (int i = 0; i < matchList.Count(); i++)
                {
                    //Temp save the match @ index i
                    MatchesEntity newMatch = new MatchesEntity()
                    {
                        MatchID = i,
                        CardMatchNumber = matchList[i].CardMatchNumber,
                        MatchTitle = matchList[i].MatchTitle,
                        AttachedCardName = matchList[i].AttachedCardName,
                        MatchType = matchList[i].MatchType,
                        MatchRules = matchList[i].MatchRules,

                        NumOfRounds = matchList[i].NumOfRounds,
                        MinsPerRound = matchList[i].MinsPerRound,

                        MatchMins = matchList[i].MatchMins,
                        NumOfFalls = matchList[i].NumOfFalls,

                        Title = matchList[i].Title,

                        Participant1 = matchList[i].Participant1,
                        Participant2 = matchList[i].Participant2,
                        Participant3 = matchList[i].Participant3,
                        Participant4 = matchList[i].Participant4,
                        Participant5 = matchList[i].Participant5,
                        Participant6 = matchList[i].Participant6,
                        Participant7 = matchList[i].Participant7,
                        Participant8 = matchList[i].Participant8
                    };
                    
                    //Save it with new index
                    mHelper.SaveMatchesList(newMatch);
                }
            }
        }
    }
}
