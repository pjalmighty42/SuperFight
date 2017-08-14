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

namespace Super_Fight.Continue.Game.Play
{
    public partial class AddMatch : Form
    {
        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();
        WrestlerHelper wHelper = new WrestlerHelper();
        TeamHelper tHelper = new TeamHelper();
        TitleHelper tiHelper = new TitleHelper();
        MatchHelper mHelper = new MatchHelper();
        CardHelper cHelper = new CardHelper();

        CardsEntity thisCard = new CardsEntity();

        private string CardName;
        private string BrandName;
        private string OrgName;
        private int MatchNum;

        public AddMatch(string cardName, string orgName, string brandName, int matchNum)
        {
            InitializeComponent();

            CardName = cardName;
            BrandName = brandName;
            OrgName = orgName;
            MatchNum = matchNum;

            storeHelper.WrestlersList = wHelper.PopulateWrestlersList().Where(w => w.CurrentCompanyName == OrgName).ToList();
            storeHelper.TeamsList = tHelper.PopulateTeamsList().Where(t => t.OrgName == OrgName).ToList();
            storeHelper.TitlesList = tiHelper.PopulateTitlesList().Where(ti => ti.OwnerOrgName == OrgName).ToList();

            thisCard = cHelper.PopulateCardsList().FirstOrDefault(c => c.CardName == CardName);
            storeHelper.MatchesList = mHelper.PopulateMatchesList().Where(m => m.AttachedCardName == thisCard.CardName).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewCard newCard = new NewCard(OrgName, false, CardName);
            newCard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDSetterHelper idHelper = new IDSetterHelper();

            int rnds, rndsMins, mMins, mFalls;

            if (cbxRoundsCount.SelectedItem == null)
            {
                rnds = 0;
            }
            else
            {
                rnds = Convert.ToInt32(cbxRoundsCount.SelectedItem.ToString());
            }

            if (cbxRndsMinPerRnds.SelectedItem == null)
            {
                rndsMins = 0;
            }
            else
            {
                rndsMins = Convert.ToInt32(cbxRndsMinPerRnds.SelectedItem.ToString().ToString());
            }

            if (cbxFallsCount.SelectedItem == null)
            {
                mFalls = 0;
            }
            else
            {
                mFalls = Convert.ToInt32(cbxFallsCount.SelectedItem.ToString().ToString());
            }

            if (cbxMatchMins.SelectedItem == null)
            {
                mMins = 0;
            }
            else
            {
                mMins = Convert.ToInt32(cbxMatchMins.SelectedItem.ToString().ToString());
            }

            string title;

            if (cbxTitles.SelectedItem == null)
            {
                title = "";
            }
            else
            {
                title = cbxTitles.SelectedItem.ToString();
            }

            string part1 = "";
            string part2 = "";
            string part3 = "";
            string part4 = "";
            string part5 = "";
            string part6 = "";
            string part7 = "";
            string part8 = "";

            /*
                Singles Match
                Tag Team Match
                6-Man Tag Match
                8-Man Tag Match
                Battle Royal
             */

            if (cbxMatchType.SelectedItem.ToString() == "Singles Match")
            {
                if (cbxPart1.SelectedItem == null)
                {
                    cbxPart1.BackColor = Color.MistyRose;
                }
                else
                {
                    part1 = cbxPart1.SelectedItem.ToString();
                }

                if (cbxPart2.SelectedItem == null)
                {
                    cbxPart2.BackColor = Color.MistyRose;
                }
                else
                {
                    part2 = cbxPart2.SelectedItem.ToString();
                }

                part3 = "";
                part4 = "";
                part5 = "";
                part6 = "";
                part7 = "";
                part8 = "";
            }
            else if (cbxMatchType.SelectedItem.ToString() == "Tag Team Match")
            {
                if (cbxPart1.SelectedItem == null)
                {
                    cbxPart1.BackColor = Color.MistyRose;
                }
                else
                {
                    part1 = cbxPart1.SelectedItem.ToString();
                }

                if (cbxPart3.SelectedItem == null)
                {
                    cbxPart3.BackColor = Color.MistyRose;
                }
                else
                {
                    part3 = cbxPart3.SelectedItem.ToString();
                }

                if (cbxPart2.SelectedItem == null)
                {
                    cbxPart2.BackColor = Color.MistyRose;
                }
                else
                {
                    part2 = cbxPart2.SelectedItem.ToString();
                }

                if (cbxPart4.SelectedItem == null)
                {
                    cbxPart4.BackColor = Color.MistyRose;
                }
                else
                {
                    part4 = cbxPart4.SelectedItem.ToString();
                }
                
                part5 = "";
                part6 = "";
                part7 = "";
                part8 = "";
            }
            else if (cbxMatchType.SelectedItem.ToString() == "6-Man Tag Match")
            {
                if (cbxPart1.SelectedItem == null)
                {
                    cbxPart1.BackColor = Color.MistyRose;
                }
                else
                {
                    part1 = cbxPart1.SelectedItem.ToString();
                }

                if (cbxPart3.SelectedItem == null)
                {
                    cbxPart3.BackColor = Color.MistyRose;
                }
                else
                {
                    part3 = cbxPart3.SelectedItem.ToString();
                }

                if (cbxPart5.SelectedItem == null)
                {
                    cbxPart5.BackColor = Color.MistyRose;
                }
                else
                {
                    part5 = cbxPart5.SelectedItem.ToString();
                }

                if (cbxPart2.SelectedItem == null)
                {
                    cbxPart2.BackColor = Color.MistyRose;
                }
                else
                {
                    part2 = cbxPart2.SelectedItem.ToString();
                }
                
                if (cbxPart4.SelectedItem == null)
                {
                    cbxPart4.BackColor = Color.MistyRose;
                }
                else
                {
                    part4 = cbxPart4.SelectedItem.ToString();
                }

                if (cbxPart6.SelectedItem == null)
                {
                    cbxPart6.BackColor = Color.MistyRose;
                }
                else
                {
                    part6 = cbxPart6.SelectedItem.ToString();
                }
                
                part7 = "";
                part8 = "";
            }
            else if (cbxMatchType.SelectedItem.ToString() == "8-Man Tag Match" ||
                cbxMatchType.SelectedItem.ToString() == "Battle Royal")
            {
                if (cbxPart1.SelectedItem == null)
                {
                    cbxPart1.BackColor = Color.MistyRose;
                }
                else
                {
                    part1 = cbxPart1.SelectedItem.ToString();
                }

                if (cbxPart3.SelectedItem == null)
                {
                    cbxPart3.BackColor = Color.MistyRose;
                }
                else
                {
                    part3 = cbxPart3.SelectedItem.ToString();
                }

                if (cbxPart5.SelectedItem == null)
                {
                    cbxPart5.BackColor = Color.MistyRose;
                }
                else
                {
                    part5 = cbxPart5.SelectedItem.ToString();
                }

                if (cbxPart7.SelectedItem == null)
                {
                    cbxPart7.BackColor = Color.MistyRose;
                }
                else
                {
                    part7 = cbxPart7.SelectedItem.ToString();
                }


                if (cbxPart2.SelectedItem == null)
                {
                    cbxPart2.BackColor = Color.MistyRose;
                }
                else
                {
                    part2 = cbxPart2.SelectedItem.ToString();
                }

                if (cbxPart4.SelectedItem == null)
                {
                    cbxPart4.BackColor = Color.MistyRose;
                }
                else
                {
                    part4 = cbxPart4.SelectedItem.ToString();
                }

                if (cbxPart6.SelectedItem == null)
                {
                    cbxPart6.BackColor = Color.MistyRose;
                }
                else
                {
                    part6 = cbxPart6.SelectedItem.ToString();
                }

                if (cbxPart8.SelectedItem == null)
                {
                    cbxPart8.BackColor = Color.MistyRose;
                }
                else
                {
                    part8 = cbxPart8.SelectedItem.ToString();
                }
            }

            MatchesEntity newMatch = new MatchesEntity()
            {
                MatchID = idHelper.CurrentID(false, false, true, false, false, false, false),
                CardMatchNumber = storeHelper.MatchesList.Count() + 1,
                MatchTitle = tbMatchTitle.Text,
                AttachedCardName = CardName,
                MatchType = cbxMatchType.SelectedItem.ToString(),
                MatchRules = cbxMatchRules.SelectedItem.ToString(),

                NumOfRounds = rnds,
                MinsPerRound = rndsMins,

                MatchMins = mMins,
                NumOfFalls = mFalls,

                Title = title,

                Participant1 = part1,
                Participant2 = part2,
                Participant3 = part3,
                Participant4 = part4,
                Participant5 = part5,
                Participant6 = part6,
                Participant7 = part7,
                Participant8 = part8
            };

            mHelper.SaveMatchesList(newMatch);

            NewCard n = new NewCard(OrgName, false, thisCard.CardName);
            n.Show();
            this.Hide();
        }

        private void cbxMatchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // SWA & Gruesome matches are 1v1, if anything else than 1v1, remove SWA/Gruesome match rules
            if (cbxMatchType.SelectedItem.ToString() != "Singles Match")
            {
                for (int i = 0; i < cbxMatchRules.Items.Count; i++)
                {
                    if (cbxMatchRules.Items[i].ToString() == "SWA Match" ||
                        cbxMatchRules.Items[i].ToString() == "Gruesome Match")
                    {
                        cbxMatchRules.Items.RemoveAt(i);
                    }
                }

                //Since no SWA/Gruesome, then no need for rounds
                cbxRndsMinPerRnds.Enabled = false;
                cbxRoundsCount.Enabled = false;
                cbxMatchMins.Enabled = true;
                cbxFallsCount.Enabled = true;
            }

            //Set the Participants & Titles that could be fought over
            List<ComboBox> cbxs = new List<ComboBox>();

            cbxs.Add(cbxPart1);
            cbxs.Add(cbxPart2);
            cbxs.Add(cbxPart3);
            cbxs.Add(cbxPart4);
            cbxs.Add(cbxPart5);
            cbxs.Add(cbxPart6);
            cbxs.Add(cbxPart7);
            cbxs.Add(cbxPart8);

            switch (cbxMatchType.SelectedItem.ToString())
            {
                case "Singles Match":
                    List<TitlesEntity> singlesTitles = storeHelper.TitlesList.Where(t => t.Specialization == "Singles Match").ToList();

                    cbxPart1.Enabled = true;
                    cbxPart2.Enabled = true;

                    cbxPart1.Items.Clear();
                    cbxPart2.Items.Clear();

                    cbxPart3.Enabled = false;
                    cbxPart4.Enabled = false;
                    cbxPart5.Enabled = false;
                    cbxPart6.Enabled = false;
                    cbxPart7.Enabled = false;
                    cbxPart8.Enabled = false;

                    foreach (WrestlersEntity w in storeHelper.WrestlersList)
                    {
                        if (String.IsNullOrWhiteSpace(BrandName))
                        {
                            //No Brands, add as normal
                            cbxPart1.Items.Add(w.Name);
                            cbxPart2.Items.Add(w.Name);
                        }
                        else
                        {
                            //Has a brand, catagorize by Brand
                            if (w.BrandName == BrandName)
                            {
                                cbxPart1.Items.Add(w.Name);
                                cbxPart2.Items.Add(w.Name);
                            }
                        }
                    }

                    if (singlesTitles.Count > 0)
                    {
                        foreach (var s in singlesTitles)
                        {
                            cbxTitles.Items.Add(s.Name);
                        }

                        cbxTitles.Enabled = true;
                    }
                    else
                    {
                        cbxTitles.Enabled = false;
                    }

                    break;
                case "Tag Team Match":
                    List<TitlesEntity> tagTitles = storeHelper.TitlesList.Where(t => t.Specialization == "Tag Team Match").ToList();

                    if (tagTitles.Count > 0)
                    {
                        foreach (var t in tagTitles)
                        {
                            cbxTitles.Items.Add(t.Name);
                        }

                        cbxTitles.Enabled = true;
                    }
                    else
                    {
                        cbxTitles.Enabled = false;
                    }
                    
                    cbxPart1.Enabled = true;
                    cbxPart3.Enabled = true;

                    cbxPart2.Enabled = true;
                    cbxPart4.Enabled = true;

                    cbxPart1.Items.Clear();
                    cbxPart2.Items.Clear();
                    cbxPart3.Items.Clear();
                    cbxPart4.Items.Clear();

                    cbxPart5.Enabled = false;
                    cbxPart6.Enabled = false;
                    cbxPart7.Enabled = false;
                    cbxPart8.Enabled = false;

                    foreach (WrestlersEntity w in storeHelper.WrestlersList)
                    {
                        if (String.IsNullOrWhiteSpace(BrandName))
                        {
                            //No Brands, add as normal
                            cbxPart1.Items.Add(w.Name);
                            cbxPart2.Items.Add(w.Name);
                            cbxPart3.Items.Add(w.Name);
                            cbxPart4.Items.Add(w.Name);
                        }
                        else
                        {
                            //Has a brand, catagorize by Brand
                            if (w.BrandName == BrandName)
                            {
                                cbxPart1.Items.Add(w.Name);
                                cbxPart2.Items.Add(w.Name);
                                cbxPart3.Items.Add(w.Name);
                                cbxPart4.Items.Add(w.Name);
                            }
                        }
                    }
                    break;
                case "6-Man Tag Match":
                    List<TitlesEntity> sixTitles = storeHelper.TitlesList.Where(t => t.Specialization == "6-Man Tag Match").ToList();

                    foreach (var s in sixTitles)
                    {
                        cbxTitles.Items.Add(s.Name);
                    }

                    cbxPart1.Enabled = true;
                    cbxPart3.Enabled = true;
                    cbxPart5.Enabled = true;

                    cbxPart2.Enabled = true;
                    cbxPart4.Enabled = true;
                    cbxPart6.Enabled = true;

                    cbxPart1.Items.Clear();
                    cbxPart2.Items.Clear();
                    cbxPart3.Items.Clear();
                    cbxPart4.Items.Clear();
                    cbxPart5.Items.Clear();
                    cbxPart6.Items.Clear();


                    cbxPart7.Enabled = false;
                    cbxPart8.Enabled = false;

                    foreach (WrestlersEntity w in storeHelper.WrestlersList)
                    {
                        if (String.IsNullOrWhiteSpace(BrandName))
                        {
                            //No Brands, add as normal
                            cbxPart1.Items.Add(w.Name);
                            cbxPart2.Items.Add(w.Name);
                            cbxPart3.Items.Add(w.Name);
                            cbxPart4.Items.Add(w.Name);
                            cbxPart5.Items.Add(w.Name);
                            cbxPart6.Items.Add(w.Name);
                        }
                        else
                        {
                            //Has a brand, catagorize by Brand
                            if (w.BrandName == BrandName)
                            {
                                cbxPart1.Items.Add(w.Name);
                                cbxPart2.Items.Add(w.Name);
                                cbxPart3.Items.Add(w.Name);
                                cbxPart4.Items.Add(w.Name);
                                cbxPart5.Items.Add(w.Name);
                                cbxPart6.Items.Add(w.Name);
                            }
                        }
                    }

                    cbxTitles.Enabled = true;

                    break;
                case "8-Man Tag Match":
                    List<TitlesEntity> eightTitles = storeHelper.TitlesList.Where(t => t.Specialization == "8-Man Tag Match").ToList();

                    if (eightTitles.Count > 0)
                    {
                        foreach (var et in eightTitles)
                        {
                            cbxTitles.Items.Add(et.Name);
                        }

                        cbxTitles.Enabled = true;
                    }
                    else
                    {
                        cbxTitles.Enabled = false;
                    }
                    
                    cbxPart1.Enabled = true;
                    cbxPart3.Enabled = true;
                    cbxPart5.Enabled = true;
                    cbxPart7.Enabled = true;

                    cbxPart2.Enabled = true;
                    cbxPart4.Enabled = true;
                    cbxPart6.Enabled = true;
                    cbxPart8.Enabled = true;

                    cbxPart1.Items.Clear();
                    cbxPart2.Items.Clear();
                    cbxPart3.Items.Clear();
                    cbxPart4.Items.Clear();
                    cbxPart5.Items.Clear();
                    cbxPart6.Items.Clear();
                    cbxPart7.Items.Clear();
                    cbxPart8.Items.Clear();

                    foreach (WrestlersEntity w in storeHelper.WrestlersList)
                    {
                        if (String.IsNullOrWhiteSpace(BrandName))
                        {
                            //No Brands, add as normal
                            cbxPart1.Items.Add(w.Name);
                            cbxPart2.Items.Add(w.Name);
                            cbxPart3.Items.Add(w.Name);
                            cbxPart4.Items.Add(w.Name);
                            cbxPart5.Items.Add(w.Name);
                            cbxPart6.Items.Add(w.Name);
                            cbxPart7.Items.Add(w.Name);
                            cbxPart8.Items.Add(w.Name);
                        }
                        else
                        {
                            //Has a brand, catagorize by Brand
                            if (w.BrandName == BrandName)
                            {
                                cbxPart1.Items.Add(w.Name);
                                cbxPart2.Items.Add(w.Name);
                                cbxPart3.Items.Add(w.Name);
                                cbxPart4.Items.Add(w.Name);
                                cbxPart5.Items.Add(w.Name);
                                cbxPart6.Items.Add(w.Name);
                                cbxPart7.Items.Add(w.Name);
                                cbxPart8.Items.Add(w.Name);
                            }
                        }
                    }
                    break;
                case "Battle Royal":
                    List<TitlesEntity> brTitles = storeHelper.TitlesList.Where(t => t.Specialization == "Battle Royal").ToList();

                    if (brTitles.Count > 0)
                    {
                        foreach (var br in brTitles)
                        {
                            cbxTitles.Items.Add(br.Name);
                        }
                        cbxTitles.Enabled = true;
                    }
                    else
                    {
                        cbxTitles.Enabled = false;
                    }

                    cbxPart1.Enabled = true;
                    cbxPart2.Enabled = true;
                    cbxPart3.Enabled = true;
                    cbxPart4.Enabled = true;
                    cbxPart5.Enabled = true;
                    cbxPart6.Enabled = true;
                    cbxPart7.Enabled = true;
                    cbxPart8.Enabled = true;

                    cbxPart1.Items.Clear();
                    cbxPart2.Items.Clear();
                    cbxPart3.Items.Clear();
                    cbxPart4.Items.Clear();
                    cbxPart5.Items.Clear();
                    cbxPart6.Items.Clear();
                    cbxPart7.Items.Clear();
                    cbxPart8.Items.Clear();


                    foreach (WrestlersEntity w in storeHelper.WrestlersList)
                    {
                        if (String.IsNullOrWhiteSpace(BrandName))
                        {
                            //No Brands, add as normal
                            cbxPart1.Items.Add(w.Name);
                            cbxPart2.Items.Add(w.Name);
                            cbxPart3.Items.Add(w.Name);
                            cbxPart4.Items.Add(w.Name);
                            cbxPart5.Items.Add(w.Name);
                            cbxPart6.Items.Add(w.Name);
                            cbxPart7.Items.Add(w.Name);
                            cbxPart8.Items.Add(w.Name);
                        }
                        else
                        {
                            //Has a brand, catagorize by Brand
                            if (w.BrandName == BrandName)
                            {
                                cbxPart1.Items.Add(w.Name);
                                cbxPart2.Items.Add(w.Name);
                                cbxPart3.Items.Add(w.Name);
                                cbxPart4.Items.Add(w.Name);
                                cbxPart5.Items.Add(w.Name);
                                cbxPart6.Items.Add(w.Name);
                                cbxPart7.Items.Add(w.Name);
                                cbxPart8.Items.Add(w.Name);
                            }
                        }
                    }
                    break;
            }

        }

        private void cbxMatchRules_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            Standard Match
            Standard Match - No DQ/Count-Out
            Standard Match - Pinfall Only
            Standard Match - Submission Only
            Cage Deathmatch
            Barbedwire Deathmatch
            Landmine Deathmatch
            SWA Match
            Gruesome Match
             */

            if (cbxMatchRules.SelectedItem.ToString() == "SWA Match" || cbxMatchRules.SelectedItem.ToString() == "Gruesome Match")
            {
                cbxRoundsCount.Enabled = true;
                cbxRndsMinPerRnds.Enabled = true;

                cbxFallsCount.Enabled = false;
                cbxMatchMins.Enabled = false;
            }
            else
            {
                cbxRoundsCount.Enabled = false;
                cbxRndsMinPerRnds.Enabled = false;

                cbxFallsCount.Enabled = true;
                cbxMatchMins.Enabled = true;
            }
        }

        private void cbxPart1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpponentSelection(cbxPart1.SelectedItem.ToString(), 1);
        }

        private void cbxPart2_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpponentSelection(cbxPart2.SelectedItem.ToString(), 2);
        }

        private void cbxPart3_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpponentSelection(cbxPart3.SelectedItem.ToString(), 3);
        }

        private void cbxPart4_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpponentSelection(cbxPart4.SelectedItem.ToString(), 4);
        }

        private void cbxPart5_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpponentSelection(cbxPart5.SelectedItem.ToString(), 5);
        }

        private void cbxPart6_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpponentSelection(cbxPart6.SelectedItem.ToString(), 6);
        }

        private void cbxPart7_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpponentSelection(cbxPart7.SelectedItem.ToString(), 7);
        }

        private void cbxPart8_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpponentSelection(cbxPart8.SelectedItem.ToString(), 8);
        }

        private void OpponentSelection(string selWrest, int cbxNum)
        {
            switch (cbxNum)
            {
                case 1:
                    cbxPart2.Items.Remove(selWrest);
                    cbxPart3.Items.Remove(selWrest);
                    cbxPart4.Items.Remove(selWrest);
                    cbxPart5.Items.Remove(selWrest);
                    cbxPart6.Items.Remove(selWrest);
                    cbxPart7.Items.Remove(selWrest);
                    cbxPart8.Items.Remove(selWrest);
                    break;
                case 2:
                    cbxPart1.Items.Remove(selWrest);
                    cbxPart3.Items.Remove(selWrest);
                    cbxPart4.Items.Remove(selWrest);
                    cbxPart5.Items.Remove(selWrest);
                    cbxPart6.Items.Remove(selWrest);
                    cbxPart7.Items.Remove(selWrest);
                    cbxPart8.Items.Remove(selWrest);
                    break;
                case 3:
                    cbxPart1.Items.Remove(selWrest);
                    cbxPart2.Items.Remove(selWrest);
                    cbxPart4.Items.Remove(selWrest);
                    cbxPart5.Items.Remove(selWrest);
                    cbxPart6.Items.Remove(selWrest);
                    cbxPart7.Items.Remove(selWrest);
                    cbxPart8.Items.Remove(selWrest);
                    break;
                case 4:
                    cbxPart1.Items.Remove(selWrest);
                    cbxPart2.Items.Remove(selWrest);
                    cbxPart3.Items.Remove(selWrest);
                    cbxPart5.Items.Remove(selWrest);
                    cbxPart6.Items.Remove(selWrest);
                    cbxPart7.Items.Remove(selWrest);
                    cbxPart8.Items.Remove(selWrest);
                    break;
                case 5:
                    cbxPart1.Items.Remove(selWrest);
                    cbxPart2.Items.Remove(selWrest);
                    cbxPart3.Items.Remove(selWrest);
                    cbxPart4.Items.Remove(selWrest);
                    cbxPart6.Items.Remove(selWrest);
                    cbxPart7.Items.Remove(selWrest);
                    cbxPart8.Items.Remove(selWrest);
                    break;
                case 6:
                    cbxPart1.Items.Remove(selWrest);
                    cbxPart2.Items.Remove(selWrest);
                    cbxPart3.Items.Remove(selWrest);
                    cbxPart4.Items.Remove(selWrest);
                    cbxPart5.Items.Remove(selWrest);
                    cbxPart7.Items.Remove(selWrest);
                    cbxPart8.Items.Remove(selWrest);
                    break;
                case 7:
                    cbxPart1.Items.Remove(selWrest);
                    cbxPart2.Items.Remove(selWrest);
                    cbxPart3.Items.Remove(selWrest);
                    cbxPart4.Items.Remove(selWrest);
                    cbxPart5.Items.Remove(selWrest);
                    cbxPart6.Items.Remove(selWrest);
                    cbxPart8.Items.Remove(selWrest);
                    break;
                case 8:
                    cbxPart1.Items.Remove(selWrest);
                    cbxPart2.Items.Remove(selWrest);
                    cbxPart3.Items.Remove(selWrest);
                    cbxPart4.Items.Remove(selWrest);
                    cbxPart5.Items.Remove(selWrest);
                    cbxPart6.Items.Remove(selWrest);
                    cbxPart7.Items.Remove(selWrest);
                    break;
            }
        }
    }
}
