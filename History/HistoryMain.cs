using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Continue;
using Super_Fight.History.Cards;
using Super_Fight.History.Matches;
using Super_Fight.History.Rankings;

namespace Super_Fight.History
{
    public partial class HistoryMain : Form
    {
        public HistoryMain()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MatchRankings mRank = new MatchRankings();
            mRank.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ContinueMain main = new ContinueMain();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MatchRankings matchR = new MatchRankings();
            matchR.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CardRankings cardR = new CardRankings();
            cardR.Show();
            this.Hide();
        }
    }
}
