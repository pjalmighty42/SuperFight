using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Continue.Create.Brands;
using Super_Fight.Continue.Create.Teams;
using Super_Fight.Continue.Create.Titles;

namespace Super_Fight.Continue.Create
{
    public partial class CreateMain : Form
    {
        public CreateMain()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContinueMain main = new ContinueMain();
            main.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BrandsMain brands = new BrandsMain();
            brands.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TitlesMain title = new TitlesMain();
            title.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TeamsMain teams = new TeamsMain();
            teams.Show();
            this.Hide();
        }
    }
}
