using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Continue.Game.Play;
using Super_Fight.Entities;
using Super_Fight.Helpers;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Continue.Game.Finalize
{
    public partial class FinalizeCard : Form
    {
        CardHelper cHelper = new CardHelper();
        MatchHelper mHelper = new MatchHelper();
        TitleHelper tHelper = new TitleHelper();
        WrestlerHelper wHelper = new WrestlerHelper();

        IDSetterHelper idHelper = new IDSetterHelper();
        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        private CardsEntity thisCard;

        private int currMatchCount;

        public FinalizeCard(int cardID)
        {
            InitializeComponent();
            
            currMatchCount = 0;

            thisCard = cHelper.PopulateCardsList().FirstOrDefault(c => c.CardID == cardID);

            storeHelper.WrestlersList = wHelper.PopulateWrestlersList().Where(w => w.CurrentCompanyName == thisCard.ConnOrgName).ToList();
            storeHelper.MatchesList = mHelper.PopulateMatchesList().Where(m => m.AttachedCardName == thisCard.CardName).ToList();
            

            if (storeHelper.MatchesList.Count == 1 ||
                storeHelper.MatchesList.Count < 1
            )
            {
                btnFwd.Enabled = false;
                btnBckwd.Enabled = false;
            }
            else
            {
                btnFwd.Enabled = true;
                btnBckwd.Enabled = true;
            }

            PopulateNextMatch(storeHelper.MatchesList[0]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thisCard.CardID = idHelper.CurrentID(false, true, false, false, false, false, false);
            thisCard.NumOfMatches = storeHelper.MatchesList.Count;

            SaveCurrentMatch(storeHelper.MatchesList[0]);

            cHelper.SaveCardsList(thisCard);

            FinalizeOutput output = new FinalizeOutput(thisCard.CardID);
            output.Show();
            this.Hide();
        }
        
        private void btnBckwd_Click(object sender, EventArgs e)
        {
            SaveCurrentMatch(storeHelper.MatchesList[currMatchCount]);

            currMatchCount = currMatchCount - 1;

            if (currMatchCount < 0)
            {
                currMatchCount = storeHelper.MatchesList.Count() - 1;
            }

            PopulateNextMatch(storeHelper.MatchesList[currMatchCount]);
        }

        private void btnFwd_Click(object sender, EventArgs e)
        {
            SaveCurrentMatch(storeHelper.MatchesList[currMatchCount]);

            currMatchCount = currMatchCount + 1;

            if (currMatchCount >= storeHelper.MatchesList.Count())
            {
                currMatchCount = 0;
            }

            PopulateNextMatch(storeHelper.MatchesList[currMatchCount]);
        }

        private void SaveCurrentMatch(MatchesEntity match)
        {
            if (match.MatchRules != "SWA Match" ||
                match.MatchRules != "Gruesome Match")
            {
                match.FinalFallCount = Convert.ToInt32(udFallNum.Value);
                match.FinalMatchMins = Convert.ToInt32(udMatchMins.Value);
                match.FinalMatchSecs = Convert.ToInt32(udMatchSecs.Value);
                match.MatchRating = Convert.ToInt32(udMatchRating.Value);
                
                if (match.MatchType == "Singles Match" ||
                    match.MatchType == "Tag Team Match" ||
                    match.MatchType == "6-Man Tag Match" ||
                    match.MatchType == "8-Man Tag Match")
                {
                    if (cbRed1.Checked)
                    {
                        match.RedSideResult = "Won";
                        match.BlueSideResult = "Loss";

                        if (match.MatchType == "Singles Match")
                        {
                            match.MatchWinners = tbPart1.Text;
                        }
                        else if (match.MatchType == "Tag Team Match")
                        {
                            match.MatchWinners = tbPart1.Text + " & " + tbPart3.Text;
                        }
                        else if (match.MatchType == "6-Man Tag Match")
                        {
                            match.MatchWinners = tbPart1.Text + " & " + tbPart3.Text + " & " + tbPart5.Text;
                        }
                        else if (match.MatchType == "8-Man Tag Match")
                        {
                            match.MatchWinners = tbPart1.Text + " & " + tbPart3.Text + " & " + tbPart5.Text + " & " + tbPart7.Text;
                        }
                    }
                    else if (cbBlue1.Checked)
                    {
                        match.RedSideResult = "Loss";
                        match.BlueSideResult = "Won";

                        if (match.MatchType == "Singles Match")
                        {
                            match.MatchWinners = tbPart2.Text;
                        }
                        else if (match.MatchType == "Tag Team Match")
                        {
                            match.MatchWinners = tbPart2.Text + " & " + tbPart4.Text;
                        }
                        else if (match.MatchType == "6-Man Tag Match")
                        {
                            match.MatchWinners = tbPart2.Text + " & " + tbPart4.Text + " & " + tbPart6.Text;
                        }
                        else if (match.MatchType == "8-Man Tag Match")
                        {
                            match.MatchWinners = tbPart2.Text + " & " + tbPart4.Text + " & " + tbPart6.Text + " & " + tbPart8.Text;
                        }
                    }
                    else
                    {
                        match.RedSideResult = "Draw";
                        match.BlueSideResult = "Draw";

                        match.MatchWinners = "Match Draw";
                    }
                }
                else if (match.MatchType == "Battle Royal")
                {
                    if (cbRed1.Checked)
                    {
                        match.RedSideResult = "Won";
                        match.BlueSideResult = "Loss";

                        match.MatchWinners = tbPart1.Text;
                    }
                    else if (cbRed2.Checked)
                    {
                        match.RedSideResult = "Won";
                        match.BlueSideResult = "Loss";

                        match.MatchWinners = tbPart3.Text;
                    }
                    else if (cbRed3.Checked)
                    {
                        match.RedSideResult = "Won";
                        match.BlueSideResult = "Loss";

                        match.MatchWinners = tbPart5.Text;
                    }
                    else if (cbRed4.Checked)
                    {
                        match.RedSideResult = "Won";
                        match.BlueSideResult = "Loss";

                        match.MatchWinners = tbPart7.Text;
                    }
                    else if (cbBlue1.Checked)
                    {
                        match.RedSideResult = "Loss";
                        match.BlueSideResult = "Won";

                        match.MatchWinners = tbPart2.Text;
                    }
                    else if (cbBlue2.Checked)
                    {
                        match.RedSideResult = "Loss";
                        match.BlueSideResult = "Won";

                        match.MatchWinners = tbPart4.Text;
                    }
                    else if (cbBlue3.Checked)
                    {
                        match.RedSideResult = "Loss";
                        match.BlueSideResult = "Won";

                        match.MatchWinners = tbPart6.Text;
                    }
                    else if (cbBlue4.Checked)
                    {
                        match.RedSideResult = "Loss";
                        match.BlueSideResult = "Won";

                        match.MatchWinners = tbPart8.Text;
                    }
                    else
                    {
                        match.RedSideResult = "Draw";
                        match.BlueSideResult = "Draw";

                        match.MatchWinners = "Match Draw";
                    }
                }

                mHelper.SaveMatchesList(match);
            }
            else
            {
                match.FinalNumOfRounds = Convert.ToInt32(udRndNum.Value);
                match.FinalMatchMins = Convert.ToInt32(udMatchMins.Value);
                match.FinalMatchSecs = Convert.ToInt32(udMatchSecs.Value);
                match.MatchRating = Convert.ToInt32(udMatchRating.Value);

                if (cbRed1.Checked)
                {
                    match.RedSideResult = "Won";
                    match.BlueSideResult = "Loss";

                    match.MatchWinners = tbPart1.Text;
                }
                else if (cbBlue1.Checked)
                {
                    match.RedSideResult = "Loss";
                    match.BlueSideResult = "Won";

                    match.MatchWinners = tbPart2.Text;
                }
                else
                {
                    match.RedSideResult = "Draw";
                    match.BlueSideResult = "Draw";

                    match.MatchWinners = "Match Draw";
                }

                mHelper.SaveMatchesList(match);
            }
        }
        
        private void PopulateNextMatch(MatchesEntity match)
        {
            lblMatchNum.Text = match.CardMatchNumber.ToString();
            lblMatchTitle.Text = match.MatchTitle;
            lblMatchRules.Text = match.MatchRules;
            lblChamp.Text = match.Title;

            tbPart1.Text = match.Participant1;
            tbPart2.Text = match.Participant2;
            tbPart3.Text = match.Participant3;
            tbPart4.Text = match.Participant4;
            tbPart5.Text = match.Participant5;
            tbPart6.Text = match.Participant6;
            tbPart7.Text = match.Participant7;
            tbPart8.Text = match.Participant8;

            if (match.MatchRules != "SWA Match" ||
                match.MatchRules != "Gruesome Match")
            {
                udRndNum.Enabled = false;
                udRndMins.Enabled = false;
                udRndSecs.Enabled = false;

                udFallNum.Enabled = true;
                udMatchMins.Enabled = true;
                udMatchSecs.Enabled = true;

                udFallNum.Value = match.FinalFallCount;
                udMatchMins.Value = match.FinalMatchMins;
                udMatchSecs.Value = match.FinalMatchSecs;
                udMatchRating.Value = match.MatchRating;

                if (match.MatchType == "Singles Match")
                {
                    cbBlue1.Enabled = true;
                    cbRed1.Enabled = true;

                    cbBlue2.Enabled = false;
                    cbBlue3.Enabled = false;
                    cbBlue4.Enabled = false;
                    cbRed2.Enabled = false;
                    cbRed3.Enabled = false;
                    cbRed4.Enabled = false;
                }
                else if (match.MatchType == "Tag Team Match")
                {
                    cbBlue1.Enabled = true;
                    cbRed1.Enabled = true;

                    cbBlue2.Enabled = false;
                    cbBlue3.Enabled = false;
                    cbBlue4.Enabled = false;
                    cbRed2.Enabled = false;
                    cbRed3.Enabled = false;
                    cbRed4.Enabled = false;
                }
                else if (match.MatchType == "6-Man Tag Match")
                {
                    cbBlue1.Enabled = true;
                    cbRed1.Enabled = true;

                    cbBlue2.Enabled = false;
                    cbBlue3.Enabled = false;
                    cbBlue4.Enabled = false;
                    cbRed2.Enabled = false;
                    cbRed3.Enabled = false;
                    cbRed4.Enabled = false;
                }
                else if (match.MatchType == "8-Man Tag Match")
                {
                    cbBlue1.Enabled = true;
                    cbRed1.Enabled = true;

                    cbBlue2.Enabled = false;
                    cbBlue3.Enabled = false;
                    cbBlue4.Enabled = false;
                    cbRed2.Enabled = false;
                    cbRed3.Enabled = false;
                    cbRed4.Enabled = false;
                }
                else if (match.MatchType == "Battle Royal")
                {
                    cbBlue1.Enabled = true;
                    cbBlue2.Enabled = true;
                    cbBlue3.Enabled = true;
                    cbBlue4.Enabled = true;

                    cbRed1.Enabled = true;
                    cbRed2.Enabled = true;
                    cbRed3.Enabled = true;
                    cbRed4.Enabled = true;
                }
            }
            else
            {
                udFallNum.Enabled = false;
                udMatchMins.Enabled = false;
                udMatchSecs.Enabled = false;

                udRndNum.Enabled = true;
                udRndMins.Enabled = true;
                udRndSecs.Enabled = true;
                
                udRndNum.Value = match.FinalNumOfRounds;
                udMatchMins.Value = match.FinalMatchMins;
                udMatchSecs.Value = match.FinalMatchSecs;
                udMatchRating.Value = match.MatchRating;

                cbBlue1.Enabled = true;
                cbRed1.Enabled = true;

                cbBlue2.Enabled = false;
                cbBlue3.Enabled = false;
                cbBlue4.Enabled = false;
                cbRed2.Enabled = false;
                cbRed3.Enabled = false;
                cbRed4.Enabled = false;
            }
        }

        private void lblOrgName_Click(object sender, EventArgs e)
        {

        }

        private void lblBrandName_Click(object sender, EventArgs e)
        {

        }
    }
}
