using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proekt
{
    public partial class Menu : Form
    {
            public Menu()
            {
            InitializeComponent();
            }

        private void button1_Click(object sender, EventArgs e)
        {
           proekt1  f2 = new proekt1();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            proekt2 f2 = new proekt2();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }
    }
}
