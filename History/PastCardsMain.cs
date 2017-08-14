using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.History.Cards
{
    public partial class PastCardsMain : Form
    {
        public PastCardsMain()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HistoryMain main = new HistoryMain();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
