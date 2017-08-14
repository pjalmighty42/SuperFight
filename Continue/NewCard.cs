using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Continue.Game.Finalize;

namespace Super_Fight.Continue.Game.Play
{
    public partial class NewCard : Form
    {
        public string OrgName { get; set; }

        public NewCard()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContinueMain cont = new ContinueMain();
            cont.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalizeCard finalize = new FinalizeCard();
            finalize.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMatch add = new AddMatch();
            add.Show();
        }
    }
}
