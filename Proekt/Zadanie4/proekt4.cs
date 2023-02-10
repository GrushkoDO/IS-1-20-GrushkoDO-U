using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bib4;
using MySql.Data.MySqlClient;
using Zadanie4;

namespace Zadanie4
{
    public partial class proekt4 : Form
    {
        Class1 chop = new Class1();
        MySqlConnection conn;
        private BindingSource bind = new BindingSource();
        private MySqlDataAdapter data = new MySqlDataAdapter();
        DataTable table = new DataTable();
        public proekt4()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chop.con();
            conn = new MySqlConnection(chop.connStr);

            conn.Open();
            table.Clear();
            table.Columns.Clear();
            string com = "SELECT * FROM t_datatime;";// выбираю все данные из таблицы
            data.SelectCommand = new MySqlCommand(com, conn);
            dataGridView1.DataSource = bind;
            bind.DataSource = table;
            data.Fill(table);

            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            
            dataGridView1.Columns[1].ReadOnly = true; // делаю столбцы только для чтения
            dataGridView1.Columns[2].ReadOnly = true;

            dataGridView1.Columns[0].Visible = false;// убираю ненужны столбцы как id и ссылка на нашку картинку
            dataGridView1.Columns[3].Visible = false;



            conn.Close();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try// эта конструкция нужна чтобы при попытке сломать программу она крепко держалась 
            {
                conn.Open();
                int rowIndex = e.RowIndex;
                int conIndex = e.ColumnIndex;
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                if (conIndex == 1)
                {
                    string com = $"SELECT photoUrl FROM t_datatime WHERE id = {row.Cells[conIndex - 1].Value.ToString()} ;";// вытаскиваю ссылку на картинку
                    MySqlCommand command = new MySqlCommand(com, conn);
                    MySqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())// цикл для повторного открытия или открытия картинок из других строк 
                    {
                        pictureBox1.ImageLocation = reader[0].ToString();// вытаскиваем картинку
                    }
                    conn.Close();
                }
            }
            catch { }
            finally { }
        }
    }
}
