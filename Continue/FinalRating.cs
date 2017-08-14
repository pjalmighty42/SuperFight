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
    public partial class FinalRating : Form
    {
        public FinalRating()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContinueMain main = new ContinueMain();
            main.Show();
            this.Hide();
        }
    }
}
