using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Continue.Create;
using Super_Fight.Continue.Game.Play;
using Super_Fight.Continue.Modify;
using Super_Fight.Continue.Ranking;
using Super_Fight.Entities;
using Super_Fight.Helpers;
using Super_Fight.Helpers.Enitities;
using Super_Fight.History;

namespace Super_Fight.Continue
{
    public partial class ContinueMain : Form
    {
        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();
        PromotionHelper pHelper = new PromotionHelper();
        CardHelper cHelper = new CardHelper();
        MatchHelper mHelper = new MatchHelper();

        public ContinueMain()
        {
            InitializeComponent();

            storeHelper.PromotionsList = pHelper.PopulatePromotionsList();

            cbxPromos.Items.Add("");

            foreach (PromotionsEntity p in storeHelper.PromotionsList)
            {
                cbxPromos.Items.Add(p.Name);
            }

            cbxPromos.SelectedItem = cbxPromos.Items[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxPromos.SelectedItem.ToString()))
            {
                cbxPromos.BackColor = Color.MistyRose;
            }
            else
            {
                NewCard card = new NewCard(cbxPromos.SelectedItem.ToString(), true);
                card.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxPromos.SelectedItem.ToString()))
            {
                cbxPromos.BackColor = Color.MistyRose;
            }
            else
            {
                CurrentRankings rank = new CurrentRankings(cbxPromos.SelectedItem.ToString());
                rank.Show();
                this.Hide();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxPromos.SelectedItem.ToString()))
            {
                cbxPromos.BackColor = Color.MistyRose;
            }
            else
            {
                CreateMain create = new CreateMain(cbxPromos.SelectedItem.ToString());
                create.Show();
                this.Hide();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cbxPromos.SelectedItem.ToString()))
            {
                cbxPromos.BackColor = Color.MistyRose;
            }
            else
            {
                ModifyMain modify = new ModifyMain(cbxPromos.SelectedItem.ToString());
                modify.Show();
                this.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HistoryMain history = new HistoryMain();
            history.Show();
            this.Hide();
        }
        
    }
}
