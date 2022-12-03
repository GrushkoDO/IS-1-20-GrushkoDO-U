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
    public partial class proekt1 : Form
    {

        Harddrive<int> hdd;
        GPU<string> gpu;
        abstract class accessories<T>
        {
            public int price;
            public int realize;
            public T Articul { get; }

            public accessories(int a, int b, T articul)
            {
                price = a;
                realize = b;
                Articul = articul;
            }
            public void Display()
            {

            }
        }
        class Harddrive<T> : accessories<T>
        {
            public int turnovers { set; get; }
            public string inter { set; get; }
            public int volume { set; get; }
            public Harddrive(int a, int b, int c, string v, int g, T art) : base(a, b, art)
            {
                turnovers = c;
                inter = v;
                volume = g;
            }
            public new string Display()
            {
                return $"Обороты {turnovers}, Интерфейс {inter}, Объем{volume}";
            }

        }

        class GPU<T> : accessories<T>
        {
            public int frequency { set; get; }
            public string manufactur { set; get; }
            public int memorycapacity { set; get; }
            public GPU(int a, int b, int c, string v, int s, T art) : base(a, b, art)
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


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                hdd = new Harddrive<int>(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), textBox4.Text, Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox9.Text));
                listBox1.Items.Add(hdd.Display());
            }
            catch
            {
                MessageBox.Show($"Пустые поля");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gpu = new GPU<string>(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), textBox4.Text, Convert.ToInt32(textBox5.Text), textBox9.Text);
            listBox1.Items.Add(gpu.Display());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Run(new proekt1());

        }
        public proekt1()
        {
            InitializeComponent();
        }
    }
}
