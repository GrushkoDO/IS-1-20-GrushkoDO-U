using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pyaterochka
{
    public partial class Form1 : Form
    {
        MySqlConnection conn;

        private BindingSource bind = new BindingSource();

        private MySqlDataAdapter data = new MySqlDataAdapter();

        DataTable table = new DataTable();
        public void con()
        {
            string connStr = "server=chuc.caseum.ru;port=33333;user=st_1_20_9;database=is_1_20_st9_KURS;password=19134029;";
            conn = new MySqlConnection(connStr);
            if (conn == null)
            {
                string connStr1 = "server=10.90.12.110;port=33333;user=st_1_20_9;database=is_1_20_st9_KURS;password=19134029;";
                conn = new MySqlConnection(connStr1);
            }

        }

       
        public Form1()
        {
            InitializeComponent();

        }
        
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            con();

            conn.Open();

            table.Clear();
            table.Columns.Clear();
            string com = "SELECT * FROM Pyaterochka";
            data.SelectCommand = new MySqlCommand(com, conn);
            dataGridView1.DataSource = bind;
            bind.DataSource = table;
            data.Fill(table);
            conn.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = 0;
            int b = 0;
            try
            {
                a = Convert.ToInt32(textBox5.Text);
                b = Convert.ToInt32(textBox4.Text);
            }
            catch { }
            if (b > 0 && a > 0)
            {
                a++;
                for(int c=b; a<c;c++)
                {
                    conn.Open();
                    string del = $"SELECT * FROM Name WHERE ID = {c}";
                    MySqlCommand command = new MySqlCommand(del, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            else if(b>0)
            {
                conn.Open();
                string del = $"SELECT * FROM Name WHERE ID = {b}";
                MySqlCommand command = new MySqlCommand(del, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show("Диапазон не найден");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int b = 0;
            try
            {
                conn.Open();
                string po = $"Select MAX(ID) FROM Name";
                MySqlCommand com1 = new MySqlCommand(po,conn);
                MySqlDataReader read1 = com1.ExecuteReader();
                while (read1.Read())
                {
                    b = Convert.ToInt32(read1[0]);
                }
            }
            catch { }
            b++;
            conn.Close();
            conn.Open();
            DateTime dt = DateTime.Now;
            dt = Convert.ToDateTime(dateTimePicker1.Value);
            string update = $"INSERT Pyaterochka VALUES {textBox1.Text},{Convert.ToInt32(textBox2.Text)},\"{dt.ToString("yyyy-MM-dd")}\")";
            MySqlCommand command = new MySqlCommand(update,conn);
            command.ExecuteNonQuery();
            conn.Close();
        }
    }
}
