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
using Super_Fight.History.Rankings;

namespace Super_Fight.History.Cards
{
    public partial class PastCardsMain : Form
    {
        private string CardName;
        private string OrgName;

        PromotionHelper pHelper = new PromotionHelper();
        CardHelper cHelper = new CardHelper();

        
        public PastCardsMain(CardsEntity card)
        {
            InitializeComponent();
            
            CardName = card.CardName;
            OrgName = card.ConnOrgName;

            PromotionsEntity promo = pHelper.PopulatePromotionsList().FirstOrDefault(p => p.Name == OrgName);

            CardsEntity c = cHelper.PopulateCardsList().FirstOrDefault(ca => ca.CardName == CardName && ca.ConnOrgName == promo.Name);

            lblPromoName.Text = promo.Name;
            lblCardLocation.Text = card.Location;

            lblCardTitle.Text = card.CardName;
            lblCardSubTitle.Text = card.SubTitle;

            lblTotalMatches.Text = card.NumOfMatches.ToString();
            lblFinalRating.Text = card.FinalCardRating.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CardRankings cRank = new CardRankings();
            cRank.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
