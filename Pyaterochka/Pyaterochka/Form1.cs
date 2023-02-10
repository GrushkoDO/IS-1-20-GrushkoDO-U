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
            int c = 0;
            try
            {
                conn.Open();
                string bd = $"SELECT MAX(ID) FROM Name;";
                MySqlCommand cammandd = new MySqlCommand(bd, conn);
                MySqlDataReader readerr = cammandd.ExecuteReader();
                while (readerr.Read())
                {
                    c = Convert.ToInt32(readerr[0]);
                }
            }
            catch
            {}
            c++;
            conn.Close();
            conn.Open();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
