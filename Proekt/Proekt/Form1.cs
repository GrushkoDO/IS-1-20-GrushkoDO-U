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
    public partial class Form1 : Form
    {
        Harddrive hdd;
         abstract class accessories
         {
            public int price;
            public int realize;
            public accessories(int a, int b)
            {
                price = a;
                realize = b;
            }
            public void Display()
            {

            }
         }
        class Harddrive : accessories
        {
            public int turnovers;
            public string inter;
            public int volume;
            public Harddrive(int a, int b, int c , string v, int g ):base (a ,b)
            {
                turnovers = c;
                inter = v;
                volume = g;
            }
            public new string Display()
            {
                return $"Обороты {turnovers}, Интерфейс {inter}, Объем{volume}";
            }
            class GPU : accessories
            {
                public int frequency;
                public string manufactur;
                public int memorycapacity;
                public GPU(int a, int b , int c, string v, int s):base(a,b)
                {
                    frequency = c;
                    manufactur = v;
                    memorycapacity = s;
                }
                public new string Display()
                {
                    return $"Частота{frequency}, Производитель{manufactur},Объем памяти{memorycapacity}";
                }
            }

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hdd = new Harddrive(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text));
            listBox1.Items.Add(hdd.Display());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
