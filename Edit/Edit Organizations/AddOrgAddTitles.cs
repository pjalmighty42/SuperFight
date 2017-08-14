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

namespace Super_Fight.Edit.Edit_Organizations
{
    public partial class AddOrgAddTitles : Form
    {
        List<TitlesEntity> allTitles = new List<TitlesEntity>();

        TitleHelper tHelper = new TitleHelper();

        StoreEntitiesHelper storeHelper = new StoreEntitiesHelper();

        private string CurrentOrgName;

        public AddOrgAddTitles(string currOrg)
        {
            InitializeComponent();

            CurrentOrgName = currOrg;

            storeHelper.TitlesList = tHelper.PopulateTitlesList();

            List<TitlesEntity> selTitles = storeHelper.TitlesList.Where(t => t.OwnerOrgName == CurrentOrgName).ToList();

            List<TitlesEntity> allTitles = storeHelper.TitlesList.Except(selTitles).ToList();

            foreach (TitlesEntity a in allTitles)
            {
                lbAllTitles.Items.Add(a.Name);
            }

            if (selTitles.Count < 32)
            {
                foreach (TitlesEntity s in selTitles)
                {
                    lbSelTitles.Items.Add(s.Name);
                }
            }
            else
            {
                lbAllTitles.Enabled = false;
                lbSelTitles.Enabled = false;
                btnAddTitles.Enabled = false;
                btnRemTitles.Enabled = false;
                button4.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<TitlesEntity> all = storeHelper.TitlesList;

            for (int i = 0; i < lbAllTitles.Items.Count; i++)
            {
                TitlesEntity title = all.FirstOrDefault(t => t.Name == lbAllTitles.Items[i].ToString());

                title.OwnerOrgName = "";
                tHelper.SaveTitlesList(title);
            }

            for (int i = 0; i < lbSelTitles.Items.Count; i++)
            {
                TitlesEntity title = all.FirstOrDefault(t => t.Name == lbSelTitles.Items[i].ToString());
                
                title.OwnerOrgName = CurrentOrgName;
                tHelper.SaveTitlesList(title);
            }

            this.Hide();
        }

        private void btnAddTitles_Click(object sender, EventArgs e)
        {
            if (lbAllTitles.SelectedItem != null)
            {
                string selItem = lbAllTitles.SelectedItem.ToString();

                for (int i = lbAllTitles.Items.Count - 1; i >= 0; --i)
                {
                    if (lbAllTitles.Items[i].ToString().Contains(selItem))
                    {
                        lbAllTitles.Items.RemoveAt(i);
                    }
                }

                lbSelTitles.Items.Add(selItem);
            }
        }

        private void btnRemTitles_Click(object sender, EventArgs e)
        {
            if (lbSelTitles.SelectedItem != null)
            {
                string selItem = lbSelTitles.SelectedItem.ToString();

                for (int i = lbSelTitles.Items.Count - 1; i >= 0; --i)
                {
                    if (lbSelTitles.Items[i].ToString().Contains(selItem))
                    {
                        lbSelTitles.Items.RemoveAt(i);
                    }
                }

                lbAllTitles.Items.Add(selItem);
            }
        }

        private void lbAllTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddTitles.Enabled = true;
            btnRemTitles.Enabled = false;
        }

        private void lbSelTitles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAddTitles.Enabled = false;
            btnRemTitles.Enabled = true;
        }
    }
}
