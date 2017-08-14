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
using Super_Fight.History.Cards;
using Super_Fight.History.Matches;

namespace Super_Fight.History.Rankings
{
    public partial class MatchRankings : Form
    {
        PromotionHelper pHelper = new PromotionHelper();
        CardHelper cHelper = new CardHelper();
        MatchHelper mHelper = new MatchHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        private bool isBrandSorted = false;

        public MatchRankings()
        {
            InitializeComponent();
            
            storeHelper.PromotionsList = pHelper.PopulatePromotionsList();
            storeHelper.CardsList = cHelper.PopulateCardsList();
            storeHelper.MatchesList = mHelper.PopulateMatchesList();

            cbxPromos.Items.Add("All Promotions");

            foreach (PromotionsEntity p in storeHelper.PromotionsList)
            {
                if (IsPromoValid(p.Name))
                {
                    cbxPromos.Items.Add(p.Name);
                }
            }

            cbxPromos.SelectedIndex = 0;
            
            //Because the drop down is auto-set at "All Promotions", then we set the buttons until otherwise inputted
            List<MatchesEntity> matches = new List<MatchesEntity>();

            foreach (CardsEntity c in storeHelper.CardsList)
            {
                MatchesEntity match = mHelper.PopulateMatchesList().FirstOrDefault(m => m.AttachedCardName == c.CardName);
                matches.Add(match);
            }

            List<MatchesEntity> sortedMatches = matches.OrderByDescending(m => m.MatchRating).ToList();

            List<MatchesEntity> Top10 = new List<MatchesEntity>();

            for (int i = 0; i < 10; i++)
            {
                Top10.Add(sortedMatches[i]);
            }

            SetButonsOutput(Top10);
        }

        private void cbxPromos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPromos.SelectedItem.ToString() == "All Promotions")
            {
                List<MatchesEntity> matches = new List<MatchesEntity>();

                foreach (CardsEntity c in storeHelper.CardsList)
                {
                    MatchesEntity match = mHelper.PopulateMatchesList().FirstOrDefault(m => m.AttachedCardName == c.CardName);
                    matches.Add(match);
                }

                List<MatchesEntity> sortedMatches = matches.OrderByDescending(m => m.MatchRating).ToList();

                isBrandSorted = false;

                List<MatchesEntity> Top10 = new List<MatchesEntity>();

                for (int i = 0; i < 10; i++)
                {
                    Top10.Add(sortedMatches[i]);
                }


                SetButonsOutput(Top10);
                
            }
            else
            {
                string selItem = cbxPromos.SelectedItem.ToString();

                PromotionsEntity promo = storeHelper.PromotionsList.FirstOrDefault(p => p.Name == selItem);

                List<CardsEntity> promoCards = storeHelper.CardsList.Where(c => c.ConnOrgName == promo.Name).ToList();

                List<MatchesEntity> matches = new List<MatchesEntity>();

                foreach (CardsEntity c in promoCards)
                {
                    MatchesEntity match = mHelper.PopulateMatchesList().FirstOrDefault(m => m.AttachedCardName == c.CardName);

                    matches.Add(match);
                }

                List<MatchesEntity> sortedMatches = matches.OrderByDescending(m => m.MatchRating).ToList();

                isBrandSorted = true;

                List<MatchesEntity> Top10 = new List<MatchesEntity>();

                for (int i = 0; i < 10; i++)
                {
                    Top10.Add(sortedMatches[i]);
                }


                SetButonsOutput(Top10);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HistoryMain hist = new HistoryMain();
            hist.Show();
            this.Hide();
        }

        private string ButtonOutput(MatchesEntity match)
        {
            /*
                Singles Match
                Tag Team Match
                6-Man Tag Match
                8-Man Tag Match
                Battle Royal
             */
            string output = "";

            switch (match.MatchType)
            {
                case "Singles Match":
                    output = match.Participant1 + " vs " + match.Participant2 + " : " + match.MatchRating;
                    break;
                case "Tag Team Match":
                    output = match.Participant1 + " & " + match.Participant3 + " vs " + match.Participant2 + " & " + match.Participant4 + " : " + match.MatchRating;
                    break;
                case "6-Man Tag Match":
                    output = match.Participant1 + " & " + match.Participant3 + " & " + match.Participant5 + " vs " + match.Participant2 + " & " + match.Participant4 + " & " + match.Participant6 + " : " + match.MatchRating;
                    break;
                case "8-Man Tag Match":
                    output = match.Participant1 + " & " + match.Participant3 + " & " + match.Participant5 + " & " + match.Participant7 + " vs " + match.Participant2 + " & " + match.Participant4 + " & " + match.Participant6 + " & " + match.Participant8 + " : " + match.MatchRating;
                    break;
                default:
                    output = "";
                    break;
            }

            return output;
        }

        private void SetButonsOutput(List<MatchesEntity> sortedMatches)
        {
            switch (sortedMatches.Count)
            {
                case 1:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);

                    btn2nd.Enabled = false;
                    btn3rd.Enabled = false;
                    btn4th.Enabled = false;
                    btn5th.Enabled = false;
                    btn6th.Enabled = false;
                    btn7th.Enabled = false;
                    btn8th.Enabled = false;
                    btn9th.Enabled = false;
                    btn10th.Enabled = false;
                    break;
                case 2:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn2nd.Enabled = true;

                    btn3rd.Enabled = false;
                    btn4th.Enabled = false;
                    btn5th.Enabled = false;
                    btn6th.Enabled = false;
                    btn7th.Enabled = false;
                    btn8th.Enabled = false;
                    btn9th.Enabled = false;
                    btn10th.Enabled = false;
                    break;
                case 3:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn3rd.Text = ButtonOutput(sortedMatches[2]);
                    btn2nd.Enabled = true;
                    btn3rd.Enabled = true;

                    btn4th.Enabled = false;
                    btn5th.Enabled = false;
                    btn6th.Enabled = false;
                    btn7th.Enabled = false;
                    btn8th.Enabled = false;
                    btn9th.Enabled = false;
                    btn10th.Enabled = false;
                    break;
                case 4:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn3rd.Text = ButtonOutput(sortedMatches[2]);
                    btn4th.Text = ButtonOutput(sortedMatches[3]);
                    btn2nd.Enabled = true;
                    btn3rd.Enabled = true;
                    btn4th.Enabled = true;

                    btn5th.Enabled = false;
                    btn6th.Enabled = false;
                    btn7th.Enabled = false;
                    btn8th.Enabled = false;
                    btn9th.Enabled = false;
                    btn10th.Enabled = false;
                    break;
                case 5:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn3rd.Text = ButtonOutput(sortedMatches[2]);
                    btn4th.Text = ButtonOutput(sortedMatches[3]);
                    btn5th.Text = ButtonOutput(sortedMatches[4]);
                    btn2nd.Enabled = true;
                    btn3rd.Enabled = true;
                    btn4th.Enabled = true;
                    btn5th.Enabled = true;

                    btn6th.Enabled = false;
                    btn7th.Enabled = false;
                    btn8th.Enabled = false;
                    btn9th.Enabled = false;
                    btn10th.Enabled = false;
                    break;
                case 6:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn3rd.Text = ButtonOutput(sortedMatches[2]);
                    btn4th.Text = ButtonOutput(sortedMatches[3]);
                    btn5th.Text = ButtonOutput(sortedMatches[4]);
                    btn6th.Text = ButtonOutput(sortedMatches[5]);
                    btn2nd.Enabled = true;
                    btn3rd.Enabled = true;
                    btn4th.Enabled = true;
                    btn5th.Enabled = true;
                    btn6th.Enabled = true;

                    btn7th.Enabled = false;
                    btn8th.Enabled = false;
                    btn9th.Enabled = false;
                    btn10th.Enabled = false;
                    break;
                case 7:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn3rd.Text = ButtonOutput(sortedMatches[2]);
                    btn4th.Text = ButtonOutput(sortedMatches[3]);
                    btn5th.Text = ButtonOutput(sortedMatches[4]);
                    btn6th.Text = ButtonOutput(sortedMatches[5]);
                    btn7th.Text = ButtonOutput(sortedMatches[6]);
                    btn2nd.Enabled = true;
                    btn3rd.Enabled = true;
                    btn4th.Enabled = true;
                    btn5th.Enabled = true;
                    btn6th.Enabled = true;
                    btn7th.Enabled = true;

                    btn8th.Enabled = false;
                    btn9th.Enabled = false;
                    btn10th.Enabled = false;
                    break;
                case 8:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn3rd.Text = ButtonOutput(sortedMatches[2]);
                    btn4th.Text = ButtonOutput(sortedMatches[3]);
                    btn5th.Text = ButtonOutput(sortedMatches[4]);
                    btn6th.Text = ButtonOutput(sortedMatches[5]);
                    btn7th.Text = ButtonOutput(sortedMatches[6]);
                    btn8th.Text = ButtonOutput(sortedMatches[7]);
                    btn2nd.Enabled = true;
                    btn3rd.Enabled = true;
                    btn4th.Enabled = true;
                    btn5th.Enabled = true;
                    btn6th.Enabled = true;
                    btn7th.Enabled = true;
                    btn8th.Enabled = true;

                    btn9th.Enabled = false;
                    btn10th.Enabled = false;
                    break;
                case 9:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn3rd.Text = ButtonOutput(sortedMatches[2]);
                    btn4th.Text = ButtonOutput(sortedMatches[3]);
                    btn5th.Text = ButtonOutput(sortedMatches[4]);
                    btn6th.Text = ButtonOutput(sortedMatches[5]);
                    btn7th.Text = ButtonOutput(sortedMatches[6]);
                    btn8th.Text = ButtonOutput(sortedMatches[7]);
                    btn9th.Text = ButtonOutput(sortedMatches[8]);
                    btn2nd.Enabled = true;
                    btn3rd.Enabled = true;
                    btn4th.Enabled = true;
                    btn5th.Enabled = true;
                    btn6th.Enabled = true;
                    btn7th.Enabled = true;
                    btn8th.Enabled = true;
                    btn9th.Enabled = true;

                    btn10th.Enabled = false;
                    break;
                case 10:
                    btn1st.Text = ButtonOutput(sortedMatches[0]);
                    btn2nd.Text = ButtonOutput(sortedMatches[1]);
                    btn3rd.Text = ButtonOutput(sortedMatches[2]);
                    btn4th.Text = ButtonOutput(sortedMatches[3]);
                    btn5th.Text = ButtonOutput(sortedMatches[4]);
                    btn6th.Text = ButtonOutput(sortedMatches[5]);
                    btn7th.Text = ButtonOutput(sortedMatches[6]);
                    btn8th.Text = ButtonOutput(sortedMatches[7]);
                    btn9th.Text = ButtonOutput(sortedMatches[8]);
                    btn10th.Text = ButtonOutput(sortedMatches[9]);

                    btn2nd.Enabled = true;
                    btn3rd.Enabled = true;
                    btn4th.Enabled = true;
                    btn5th.Enabled = true;
                    btn6th.Enabled = true;
                    btn7th.Enabled = true;
                    btn8th.Enabled = true;
                    btn9th.Enabled = true;
                    btn10th.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private List<MatchesEntity> SortedMatchOutput()
        {
            List<MatchesEntity> sortedMatches = new List<MatchesEntity>();

            if (!isBrandSorted)
            {
                sortedMatches = storeHelper.MatchesList.OrderByDescending(c => c.MatchRating).ToList();
            }
            else
            {
                string selItem = cbxPromos.SelectedItem.ToString();

                PromotionsEntity promo = storeHelper.PromotionsList.FirstOrDefault(p => p.Name == selItem);

                List<CardsEntity> promoCards = storeHelper.CardsList.Where(c => c.ConnOrgName == promo.Name).ToList();

                List<MatchesEntity> matches = new List<MatchesEntity>();

                foreach (CardsEntity c in promoCards)
                {
                    MatchesEntity match = mHelper.PopulateMatchesList().FirstOrDefault(m => m.AttachedCardName == c.CardName);

                    matches.Add(match);
                }

               sortedMatches = matches.OrderByDescending(m => m.MatchRating).ToList();
            }

            return sortedMatches;
        }

        private void ShowPastMatchMain(List<MatchesEntity> matchList, int index)
        {
            PastMatchMain past = new PastMatchMain(matchList[index]);
            past.Show();
            this.Hide();
        }

        private void btn1st_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 0);
        }

        private void btn2nd_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 1);
        }

        private void btn3rd_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 2);
        }

        private void btn4th_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 3);
        }

        private void btn5th_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 4);
        }

        private void btn6th_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 5);
        }

        private void btn7th_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 6);
        }

        private void btn8th_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 7);
        }

        private void btn9th_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 8);
        }

        private void btn10th_Click(object sender, EventArgs e)
        {
            ShowPastMatchMain(SortedMatchOutput(), 9);
        }

        private bool IsPromoValid(string promoName)
        {
            bool bPromoValid = false;

            List<CardsEntity> cardList = cHelper.PopulateCardsList().Where(c => c.ConnOrgName == promoName).ToList();
            
            if (cardList.Count > 0)
            {
                bPromoValid = true;
            }
            else
            {
                bPromoValid = false;
            }

            return bPromoValid;
        }
    }
}
