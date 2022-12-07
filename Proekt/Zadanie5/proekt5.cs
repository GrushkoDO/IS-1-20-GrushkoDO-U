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
using bib4;


namespace Zadanie5
{
    public partial class proekt5 : Form
    {

        Class1 chop = new Class1();
        MySqlConnection conn;
        private BindingSource bind = new BindingSource();
        private MySqlDataAdapter data = new MySqlDataAdapter();
        DataTable table = new DataTable();

        void prop()
        {
            conn.Open();
            string com = "SELECT * FROM t_Uchebka_Grushko";// выбираем все поля в таблице
            table.Clear();
            table.Columns.Clear();
            data.SelectCommand = new MySqlCommand(com, conn);
            dataGridView1.DataSource = bind;
            bind.DataSource = table;
            data.Fill(table);

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;// растягивают колонки по дата гриду
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns[0].ReadOnly = true;// задают поля только для чтения
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
  
            conn.Close();
        }


        public proekt5()
        {
            InitializeComponent();
        }

        private void proekt5_Load(object sender, EventArgs e)
        {
            chop.con();
            conn = new MySqlConnection(chop.connStr);
            prop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string com = $"INSERT t_Uchebka_Grushko(fioStud,datetimeStud) VALUES ('{textBox2.Text}','{textBox1.Text}');";// запрос для добавления информации в таблицу
                MySqlCommand command = new MySqlCommand(com, conn);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Исключение: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
