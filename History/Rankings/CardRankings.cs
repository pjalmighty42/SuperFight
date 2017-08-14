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

namespace Super_Fight.History.Rankings
{
    public partial class CardRankings : Form
    {
        PromotionHelper pHelper = new PromotionHelper();
        CardHelper cHelper = new CardHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        bool isBrandSorted = false;
        private bool cards = false;
        private bool matches = false;

        public CardRankings(bool bHasCard = false, bool bHasMatches = false)
        {
            InitializeComponent();

            cards = bHasCard;
            matches = bHasMatches;

            storeHelper.PromotionsList = pHelper.PopulatePromotionsList();
            storeHelper.CardsList = cHelper.PopulateCardsList();

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
            List<CardsEntity> sortedCard = storeHelper.CardsList.OrderByDescending(c => c.FinalCardRating).ToList();

            List<CardsEntity> Top10 = new List<CardsEntity>();
            
            for (int i = 0; i < 10; i++)
            {
                Top10.Add(sortedCard[i]);
            }

            SetButonsOutput(Top10);

        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            HistoryMain histMain = new HistoryMain();
            histMain.Show();
            this.Hide();
        }

        private void cbxPromos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxPromos.SelectedItem.ToString() == "All Promotions")
            {
                List<CardsEntity> sortedCard = storeHelper.CardsList.OrderByDescending(c => c.FinalCardRating).ToList();

                isBrandSorted = false;

                SetButonsOutput(sortedCard);
            }
            else
            {
                string selItem = cbxPromos.SelectedItem.ToString();

                PromotionsEntity promo = storeHelper.PromotionsList.FirstOrDefault(p => p.Name == selItem);

                List<CardsEntity> promoCards = storeHelper.CardsList.Where(c => c.ConnOrgName == promo.Name).ToList();

                List<CardsEntity> sortedCard = promoCards.OrderByDescending(c => c.FinalCardRating).ToList();

                isBrandSorted = true;

                SetButonsOutput(sortedCard);
            }
        }

        private void SetButonsOutput(List<CardsEntity> sortedMatches)
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

        private string ButtonOutput(CardsEntity card)
        {
            string output = "";

            output = card.ConnOrgName + " - " + card.CardName + " : " + card.FinalCardRating;
 
            return output;
        }

        private void btn1st_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 0);
        }

        private void btn2nd_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 1);
        }

        private void btn3rd_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 2);
        }

        private void btn4th_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 3);
        }

        private void btn5th_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 4);
        }

        private void btn6th_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 5);
        }

        private void btn7th_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 6);
        }

        private void btn8th_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 7);
        }

        private void btn9th_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 8);
        }

        private void btn10th_Click(object sender, EventArgs e)
        {
            ShowPastCardMain(SortedCardOutput(), 9);
        }

        private List<CardsEntity> SortedCardOutput()
        {
            List<CardsEntity> sortedCard = new List<CardsEntity>();

            if (!isBrandSorted)
            {
                sortedCard  = storeHelper.CardsList.OrderByDescending(c => c.FinalCardRating).ToList();
            }
            else
            {
                string selItem = cbxPromos.SelectedItem.ToString();

                PromotionsEntity promo = storeHelper.PromotionsList.FirstOrDefault(p => p.Name == selItem);

                List<CardsEntity> promoCards = storeHelper.CardsList.Where(c => c.ConnOrgName == promo.Name).ToList();

                sortedCard = promoCards.OrderByDescending(c => c.FinalCardRating).ToList();
            }

            return sortedCard;
        }

        private void ShowPastCardMain(List<CardsEntity> cardList, int index)
        {
            PastCardsMain past = new PastCardsMain(cardList[index]);
            past.Show();
            this.Hide();
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
