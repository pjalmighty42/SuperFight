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
using Super_Fight.History.Rankings;

namespace Super_Fight.History.Matches
{
    public partial class PastMatchMain : Form
    {
        private string MatchName;
        private string CardName;
        
        CardHelper cHelper = new CardHelper();
        MatchHelper mHelper = new MatchHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        public PastMatchMain(MatchesEntity match)
        {
            InitializeComponent();

            MatchName = match.Title;
            CardName = match.AttachedCardName;

            storeHelper.CardsList = cHelper.PopulateCardsList();
            storeHelper.MatchesList = mHelper.PopulateMatchesList();

            MatchesEntity ma = storeHelper.MatchesList.FirstOrDefault(m => m.Title == MatchName && m.AttachedCardName == CardName);
            CardsEntity card = storeHelper.CardsList.FirstOrDefault(c => c.CardName == CardName && c.CardName == match.AttachedCardName);

            lblCardPromo.Text = card.ConnOrgName;
            lblCardLoc.Text = card.Location;

            lblCardTitle.Text = card.CardName;
            lblSubTitle.Text = card.SubTitle;

            lblMatchTitle.Text = match.Title;

            lblRedRes.Text = match.RedSideResult;
            lblPart1.Text = match.Participant1;
            lblPart3.Text = match.Participant3;
            lblPart5.Text = match.Participant5;
            lblPart7.Text = match.Participant7;

            switch (match.RedSideResult)
            {
                case "Won":
                    lblRedRes.BackColor = Color.Green;
                    lblRedRes.ForeColor = Color.PaleGreen;
                    break;
                case "Draw":
                    lblRedRes.BackColor = Color.DarkGoldenrod;
                    lblRedRes.ForeColor = Color.NavajoWhite;
                    break;
                case "Loss":
                    lblRedRes.BackColor = Color.Crimson;
                    lblRedRes.ForeColor = Color.MistyRose;
                    break;
            }

            lblBlueRes.Text = match.BlueSideResult;
            lblPart2.Text = match.Participant2;
            lblPart4.Text = match.Participant4;
            lblPart6.Text = match.Participant6;
            lblPart8.Text = match.Participant8;

            switch (match.BlueSideResult)
            {
                case "Won":
                    lblBlueRes.BackColor = Color.Green;
                    lblBlueRes.ForeColor = Color.PaleGreen;
                    break;
                case "Draw":
                    lblBlueRes.BackColor = Color.DarkGoldenrod;
                    lblBlueRes.ForeColor = Color.NavajoWhite;
                    break;
                case "Loss":
                    lblBlueRes.BackColor = Color.Crimson;
                    lblBlueRes.ForeColor = Color.MistyRose;
                    break;
            }

            if (match.FinalFallCount > 0)
            {
                lblRndOrFalls.Text = "Fall #:";
                lblMatchRndFallNum.Text = match.FinalFallCount.ToString();
            }
            else if (match.FinalNumOfRounds > 0)
            {
                lblRndOrFalls.Text = "Round #:";
                lblMatchRndFallNum.Text = match.FinalNumOfRounds.ToString();
            }

            lblMatchRndFallMins.Text = match.FinalMatchMins.ToString();
            lblMatchRndFallSecs.Text = match.FinalMatchSecs.ToString();

            lblMatchFinalRating.Text = match.MatchRating.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MatchRankings mRank = new MatchRankings();
            mRank.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
