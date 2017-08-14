using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Fight.Continue.Create.Teams
{
    public partial class Teams : Form
    {
        public Teams()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CreateMain main = new CreateMain();
            main.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CreateMain main = new CreateMain();
            main.Show();
            this.Hide();
        }
    }
}
