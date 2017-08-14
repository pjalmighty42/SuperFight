using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.History.Titles
{
    public partial class PastTitlesMain : Form
    {
        public PastTitlesMain()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HistoryMain main = new HistoryMain();
            main.Show();
            this.Hide();
        }
    }
}
