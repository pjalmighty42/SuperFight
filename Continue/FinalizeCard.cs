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

namespace Super_Fight.Continue.Game.Finalize
{
    public partial class FinalizeCard : Form
    {
        public FinalizeCard()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewCard card = new NewCard();
            card.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FinalizeOutput output = new FinalizeOutput();
            output.Show();
            this.Hide();
        }
        
        private void inputPanel_Paint(object sender, PaintEventArgs e)
        {
            Label lblMatchNo = new Label();
            Label lblMatchTitle = new Label();

            RadioButton rbPart1 = new RadioButton();
            RadioButton rbPart2 = new RadioButton();
            RadioButton rbPart3 = new RadioButton();
            RadioButton rbPart4 = new RadioButton();
            Label lblVS = new Label();
            RadioButton rbPart5 = new RadioButton();
            RadioButton rbPart6 = new RadioButton();
            RadioButton rbPart7 = new RadioButton();
            RadioButton rbPart8 = new RadioButton();

            List<RadioButton> participants = new List<RadioButton>() {
                rbPart1,
                rbPart2,
                rbPart3,
                rbPart4,
                rbPart5,
                rbPart6,
                rbPart7,
                rbPart8
            };

            Label lblMatchResults = new Label();

            Label lblMatchMins = new Label();
            TextBox tbMatchMins = new TextBox();
            Label lblMatchSecs = new Label();
            TextBox tbMatchSecs = new TextBox();

            Label lblRoundsRound = new Label();
            TextBox tbRound = new TextBox();
            Label lblRoundsMins = new Label();
            TextBox tbRoundMins = new TextBox();
            Label lblRoundsSecs = new Label();
            TextBox tbRoundSecs = new TextBox();

            Label lblRating = new Label();
            TextBox tbRating = new TextBox();


            int panelW = inputPanel.Width;
            int panelH = inputPanel.Height;

            //This is just to get things initally set up, TODO: Use a list of matches to dynamically create a list of matches
            lblMatchNo.Font = new Font("Microsoft YaHei UI", 14.25f, FontStyle.Bold);
            lblMatchNo.Text = "Match 1";
            lblMatchNo.Visible = true;

            lblMatchTitle.Font = new Font("Microsoft YaHei UI", 14.25f, FontStyle.Bold);
            lblMatchTitle.Text = "Random Stuffs";
            lblMatchTitle.Visible = true;

            inputPanel.Controls.Add(lblMatchNo);
            inputPanel.Controls.Add(lblMatchTitle);
        }
    }
}
