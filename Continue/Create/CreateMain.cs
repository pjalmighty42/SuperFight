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
        private string OrgName;

        public CreateMain(string orgName)
        {
            InitializeComponent();

            OrgName = orgName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ContinueMain main = new ContinueMain();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnChamps_Click(object sender, EventArgs e)
        {
            TitlesMain titles = new TitlesMain(OrgName);
            titles.Show();
            this.Hide();
        }

        private void btnBrands_Click(object sender, EventArgs e)
        {
            BrandsMain brands = new BrandsMain(OrgName);
            brands.Show();
            this.Hide();
        }

        private void btnTeams_Click(object sender, EventArgs e)
        {
            TeamsMain teams = new TeamsMain(OrgName);
            teams.Show();
            this.Hide();
        }
    }
}
