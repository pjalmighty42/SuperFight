using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Edit.Organizations;
using Super_Fight.Edit.Teams;
using Super_Fight.Edit.Titles;
using Super_Fight.Edit.Wrestlers;
using Super_Fight.Entities;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Edit
{
    public partial class EditMain : Form
    {
        List<WrestlersEntity> wrests = new List<WrestlersEntity>();
        List<PromotionsEntity> promos = new List<PromotionsEntity>();
        
        WrestlerHelper wHelper = new WrestlerHelper();
        PromotionHelper plHelper = new PromotionHelper();

        public EditMain()
        {
            InitializeComponent();
            
            wrests = wHelper.PopulateWrestlersList();
            promos = plHelper.PopulatePromotionsList();
            
            button5.Enabled = true;
            button2.Enabled = true;
            
            if (promos.Count == 0)
            {
                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }

            if (wrests.Count >= 2)
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MainMenu main = new MainMenu();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            AddWrestlers aWrest = new AddWrestlers();
            aWrest.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddOrg aOrg = new AddOrg();
            aOrg.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTeam aTeam = new AddTeam();
            aTeam.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddTitles aTitles = new AddTitles();
            aTitles.Show();
            this.Hide();
        }
    }
}
