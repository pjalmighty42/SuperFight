﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.Continue.Modify.Brands
{
    public partial class ModBrands : Form
    {
        public ModBrands()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ModifyMain mMain = new ModifyMain();
            mMain.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ModifyMain mMain = new ModifyMain();
            mMain.Show();
            this.Hide();
        }
    }
}
