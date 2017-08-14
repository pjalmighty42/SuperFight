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

namespace Super_Fight.Continue.Game.Finalize
{
    public partial class FinalizeOutput : Form
    {
        CardHelper cHelper = new CardHelper();
        MatchHelper mHelper = new MatchHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        private CardsEntity thisCard;

        private int currMatchCount;


        public FinalizeOutput(int cardID)
        {
            InitializeComponent();
            
            currMatchCount = 0;

            thisCard = cHelper.PopulateCardsList().FirstOrDefault(c => c.CardID == cardID);

            storeHelper.MatchesList = mHelper.PopulateMatchesList().Where(m => m.AttachedCardName == thisCard.CardName).ToList();

            if (storeHelper.MatchesList.Count == 1)
            {
                btnFwd.Enabled = false;
                btnBck.Enabled = false;
            }
            else
            {
                btnFwd.Enabled = true;
                btnBck.Enabled = true;
            }

            PopulateFields(thisCard, storeHelper.MatchesList[currMatchCount]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalRating final = new FinalRating(thisCard.CardID);
            final.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FinalizeCard finalize = new FinalizeCard(thisCard.CardID);
            finalize.Show();
            this.Hide();
        }

        private void PopulateFields(CardsEntity card, MatchesEntity match)
        {
            MatchesEntity currMatch = match;

            lblCardTitle.Text = card.CardName;
            lblCardSubTitle.Text = card.SubTitle;

            lblMatchNum.Text = currMatch.CardMatchNumber.ToString();
            lblMatchTitle.Text = currMatch.MatchTitle;
            lblMatchRules.Text = currMatch.MatchType + "/" + currMatch.MatchRules;
            lblChamp.Text = currMatch.Title;

            lblPart1.Text = currMatch.Participant1;
            lblPart2.Text = currMatch.Participant2;
            lblPart3.Text = currMatch.Participant3;
            lblPart4.Text = currMatch.Participant4;
            lblPart5.Text = currMatch.Participant5;
            lblPart6.Text = currMatch.Participant6;
            lblPart7.Text = currMatch.Participant7;
            lblPart8.Text = currMatch.Participant8;


            lblMatchRating.Text = currMatch.MatchRating.ToString();

            lblMatchRating.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            currMatchCount = currMatchCount + 1;

            if (currMatchCount >= storeHelper.MatchesList.Count())
            {
                currMatchCount = 0;
            }

            PopulateFields(thisCard, storeHelper.MatchesList[currMatchCount]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currMatchCount = currMatchCount - 1;

            if (currMatchCount < 0)
            {
                currMatchCount = storeHelper.MatchesList.Count();
            }

            PopulateFields(thisCard, storeHelper.MatchesList[currMatchCount]);
        }
    }
}
