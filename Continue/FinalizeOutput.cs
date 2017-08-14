using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.Continue.Game.Finalize
{
    public partial class FinalizeOutput : Form
    {
        public FinalizeOutput()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalRating final = new FinalRating();
            final.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FinalizeCard finalize = new FinalizeCard();
            finalize.Show();
            this.Hide();
        }
    }
}
