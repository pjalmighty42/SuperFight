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

namespace Super_Fight.Edit.Organizations
{
    public partial class AddOrgAddWrest : Form
    {
        WrestlerHelper wHelper = new WrestlerHelper();
        PromotionHelper pHelper = new PromotionHelper();

        StoreEntitiesHelper seHelper = new StoreEntitiesHelper();

        private string CurrentOrgName;

        public AddOrgAddWrest(string orgName)
        {
            InitializeComponent();

            CurrentOrgName = orgName;

            seHelper.WrestlersList = wHelper.PopulateWrestlersList();
            seHelper.PromotionsList = pHelper.PopulatePromotionsList();

            List<WrestlersEntity> selWrests = seHelper.WrestlersList.Where(w => w.CurrentCompanyName == CurrentOrgName).ToList();

            List<WrestlersEntity> allWrests = seHelper.WrestlersList.Except(selWrests).ToList();

            foreach (WrestlersEntity wAll in allWrests)
            {
                lbAllWrestlers.Items.Add(wAll.Name);
            }

            //If past 512 total wrestlers in one Org, add no more!
            if (selWrests.Count < 128)
            {
                foreach (WrestlersEntity wSel in selWrests)
                {
                    lbSelWrestlers.Items.Add(wSel.Name);
                }
            }
            else
            {
                lbAllWrestlers.Enabled = false;
                lbSelWrestlers.Enabled = false;
                btnAddWrest.Enabled = false;
                btnRemWrest.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbAllWrestlers.Items.Count; i++)
            {
                WrestlersEntity wrest = seHelper.WrestlersList.FirstOrDefault(w => w.Name == lbAllWrestlers.Items[i].ToString());

                wrest.CurrentCompanyName = "";
                wHelper.SaveWrestlersList(wrest);
            }

            for (int x = 0; x < lbSelWrestlers.Items.Count; x++)
            {
                WrestlersEntity wrest = seHelper.WrestlersList.FirstOrDefault(w => w.Name == lbSelWrestlers.Items[x].ToString());

                wrest.CurrentCompanyName = CurrentOrgName;
                wHelper.SaveWrestlersList(wrest);
            }

            this.Hide();
        }

        private void lbAllWrestlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddWrest.Enabled = true;
            btnRemWrest.Enabled = false;
        }

        private void lbSelWrestlers_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddWrest.Enabled = false;
            btnRemWrest.Enabled = true;
        }

        private void btnAddWrest_Click(object sender, EventArgs e)
        {
            if (lbAllWrestlers.SelectedItem != null)
            {
                string selItem = lbAllWrestlers.SelectedItem.ToString();

                for (int i = lbAllWrestlers.Items.Count - 1; i >= 0; --i)
                {
                    if (lbAllWrestlers.Items[i].ToString().Contains(selItem))
                    {
                        lbAllWrestlers.Items.RemoveAt(i);
                    }
                }

                lbSelWrestlers.Items.Add(selItem);
            }
        }

        private void btnRemWrest_Click(object sender, EventArgs e)
        {
            if (lbSelWrestlers.SelectedItem != null)
            {
                string selItem = lbSelWrestlers.SelectedItem.ToString();

                for (int i = lbSelWrestlers.Items.Count - 1; i >= 0; --i)
                {
                    if (lbSelWrestlers.Items[i].ToString().Contains(selItem))
                    {
                        lbSelWrestlers.Items.RemoveAt(i);
                    }
                }

                lbAllWrestlers.Items.Add(selItem);
            }
        }
    }
}
