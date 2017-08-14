using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Super_Fight.Entities;
using Super_Fight.Helpers;
using Super_Fight.Helpers.Enitities;

namespace Super_Fight.Edit.Teams
{
    public partial class TeamAddWrestlers : Form
    {
        TeamHelper tHelper = new TeamHelper();
        WrestlerHelper wHelper = new WrestlerHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        private string TeamName;
        private string CoName;

        public TeamAddWrestlers(string teamName, string coName)
        {
            InitializeComponent();

            TeamName = teamName;
            CoName = coName;

            storeHelper.WrestlersList = wHelper.PopulateWrestlersList();
            storeHelper.TeamsList = tHelper.PopulateTeamsList();

            TeamsEntity currTeam = storeHelper.TeamsList.FirstOrDefault(t => t.TeamName == TeamName);

            List<string> teamMemsList = new List<string>();

            teamMemsList.Add(currTeam.MemberName1);
            teamMemsList.Add(currTeam.MemberName2);
            teamMemsList.Add(currTeam.MemberName3);
            teamMemsList.Add(currTeam.MemberName4);
            
            List<WrestlersEntity> promoWrest = storeHelper.WrestlersList.Where(w => w.CurrentCompanyName == coName).ToList();

            List<string> allNames = new List<string>();

            foreach (WrestlersEntity all in promoWrest)
            {
                allNames.Add(all.Name);
            }

            List<string> withoutMems = allNames.Except(teamMemsList).ToList();

            foreach (string a in withoutMems)
            {
                lbRoster.Items.Add(a);
            }

            foreach (string team in teamMemsList)
            {
                if (string.IsNullOrWhiteSpace(team))
                {

                }
                else
                {
                    lbSelected.Items.Add(team);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lbRoster.Items.Count > 1)
            {
                foreach (var unSel in lbRoster.Items)
                {
                    foreach (WrestlersEntity w in storeHelper.WrestlersList)
                    {
                        if (unSel.ToString() == w.Name && w.TeamName == TeamName)
                        {
                            w.TeamName = "";
                            wHelper.SaveWrestlersList(w);
                        }
                    }
                }
            }

            if (lbSelected.Items.Count >= 2)
            {
                List<WrestlersEntity> all = wHelper.PopulateWrestlersList();
                TeamsEntity t = storeHelper.TeamsList.FirstOrDefault(tw => tw.TeamName == TeamName);

                WrestlersEntity w1 = new WrestlersEntity();
                WrestlersEntity w2 = new WrestlersEntity();
                WrestlersEntity w3 = new WrestlersEntity();
                WrestlersEntity w4 = new WrestlersEntity();

                if (lbSelected.Items.Count == 2)
                {
                    w1 = all.FirstOrDefault(s => s.Name == lbSelected.Items[0].ToString());
                    w2 = all.FirstOrDefault(s => s.Name == lbSelected.Items[1].ToString());

                    w1.TeamName = TeamName;
                    w2.TeamName = TeamName;

                    t.MemberName1 = w1.Name;
                    t.MemberName2 = w2.Name;

                    wHelper.SaveWrestlersList(w1);
                    wHelper.SaveWrestlersList(w2);

                    tHelper.SaveTeamsList(t);
                    this.Hide();
                }
                else if (lbSelected.Items.Count == 3)
                {
                    w1 = all.FirstOrDefault(s => s.Name == lbSelected.Items[0].ToString());
                    w2 = all.FirstOrDefault(s => s.Name == lbSelected.Items[1].ToString());
                    w3 = all.FirstOrDefault(s => s.Name == lbSelected.Items[2].ToString());

                    w1.TeamName = TeamName;
                    w2.TeamName = TeamName;
                    w3.TeamName = TeamName;

                    t.MemberName1 = w1.Name;
                    t.MemberName2 = w2.Name;
                    t.MemberName3 = w3.Name;

                    wHelper.SaveWrestlersList(w1);
                    wHelper.SaveWrestlersList(w2);
                    wHelper.SaveWrestlersList(w3);

                    tHelper.SaveTeamsList(t);
                    this.Hide();
                }
                else if (lbSelected.Items.Count == 4)
                {
                    w1 = all.FirstOrDefault(s => s.Name == lbSelected.Items[0].ToString());
                    w2 = all.FirstOrDefault(s => s.Name == lbSelected.Items[1].ToString());
                    w3 = all.FirstOrDefault(s => s.Name == lbSelected.Items[2].ToString());
                    w4 = all.FirstOrDefault(s => s.Name == lbSelected.Items[3].ToString());

                    w1.TeamName = TeamName;
                    w2.TeamName = TeamName;
                    w3.TeamName = TeamName;
                    w4.TeamName = TeamName;

                    t.MemberName1 = w1.Name;
                    t.MemberName2 = w2.Name;
                    t.MemberName3 = w3.Name;
                    t.MemberName4 = w4.Name;

                    wHelper.SaveWrestlersList(w1);
                    wHelper.SaveWrestlersList(w2);
                    wHelper.SaveWrestlersList(w3);
                    wHelper.SaveWrestlersList(w4);

                    tHelper.SaveTeamsList(t);
                    this.Hide();
                }
            }
        }

        private void lbRoster_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnRemove.Enabled = true;
            button4.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbRoster.SelectedItem != null)
            {
                if (lbSelected.Items.Count < 4)
                {
                    string selItem = lbRoster.SelectedItem.ToString();

                    for (int i = lbRoster.Items.Count - 1; i >= 0; --i)
                    {
                        if (lbRoster.Items[i].ToString().Contains(selItem))
                        {
                            lbRoster.Items.RemoveAt(i);
                        }
                    }

                    lbSelected.Items.Add(selItem);
                    lbSelected.Refresh();
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbSelected.SelectedItem != null)
            {
                string selItem = lbSelected.SelectedItem.ToString();

                for (int i = lbSelected.Items.Count - 1; i >= 0; --i)
                {
                    if (lbSelected.Items[i].ToString().Contains(selItem))
                    {
                        lbSelected.Items.RemoveAt(i);
                    }
                }

                lbRoster.Items.Add(selItem);
            }
        }

        private void lbSelected_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnRemove.Enabled = true;
            button4.Enabled = true;
        }
    }
}
