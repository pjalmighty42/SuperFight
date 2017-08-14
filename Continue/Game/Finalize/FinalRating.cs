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
    public partial class FinalRating : Form
    {
        CardHelper cHelper = new CardHelper();
        MatchHelper mHelper = new MatchHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        private CardsEntity thisCard;
        
        public FinalRating(int cardID)
        {
            InitializeComponent();
            
            thisCard = cHelper.PopulateCardsList().FirstOrDefault(c => c.CardID == cardID);

            storeHelper.MatchesList = mHelper.PopulateMatchesList().Where(m => m.AttachedCardName == thisCard.CardName).ToList();

            PopulateFields(thisCard, storeHelper.MatchesList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IDSetterHelper idHelper = new IDSetterHelper();

            CardsEntity newCard = new CardsEntity()
            {
                CardID = idHelper.CurrentID(false, true, false, false, false, false, false),
                CardName = lblCardTitle.Text,
                SubTitle = lblCardSubTitle.Text,
                ConnOrgName = lblOrgName.Text,
                BrandName = lblBrandName.Text,
                NumOfMatches = Convert.ToInt32(lblTotalMatches.Text),
                FinalCardRating = Convert.ToInt32(lblFinalRating.Text)
            };

            cHelper.SaveCardsList(newCard);

            ContinueMain main = new ContinueMain();
            main.Show();
            this.Hide();
        }

        private void PopulateFields(CardsEntity card, List<MatchesEntity> matches)
        {
            card.FinalCardRating = FinalCardRating(matches);

            lblOrgName.Text = card.ConnOrgName;
            lblBrandName.Text = card.BrandName;

            lblCardTitle.Text = card.CardName;
            lblCardSubTitle.Text = card.SubTitle;

            lblTotalMatches.Text = matches.Count().ToString();
            lblFinalRating.Text = card.FinalCardRating.ToString();
        }

        private int FinalCardRating(List<MatchesEntity> matchList)
        {
            int ratingTotals = 0;
            float finalRatingAverage = 0;

            foreach (MatchesEntity m in matchList)
            {
                ratingTotals = ratingTotals + m.MatchRating;
            }

            finalRatingAverage = ratingTotals / matchList.Count;

            return Convert.ToInt32(Math.Round(finalRatingAverage));
        }
    }
}
