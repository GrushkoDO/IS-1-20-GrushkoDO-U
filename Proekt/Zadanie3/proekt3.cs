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
using Zadanie3;
namespace Proekt
{
    public partial class proekt3 : Form
    {
        MySqlConnection conn;
        Connect f2 = new Connect();
        private BindingSource bSource = new BindingSource();

        private MySqlDataAdapter MyDA = new MySqlDataAdapter();

        DataTable table = new DataTable();
        public proekt3()
        {
            InitializeComponent();
        }

        private void proekt3_Load(object sender, EventArgs e)
        {

            
            f2.con();
            conn = new MySqlConnection(f2.connStr);
            conn.Open();

            table.Clear();
            table.Columns.Clear();
            string com = "SELECT Purchase_gasoline.purchase_gasoline_id,Purchase_gasoline.provider,Purchase_gasoline.purchase_price,Purchase_gasoline.purchase_volume,Purchase_gasoline.type_gasoline FROM Purchase_gasoline INNER JOIN Provider ON Purchase_gasoline.provider = Provider.provider_id ORDER BY Provider.provider_id";

            MyDA.SelectCommand = new MySqlCommand(com, conn);
            dataGridView1.DataSource = bSource;
            bSource.DataSource = table;
            MyDA.Fill(table);

            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.ColumnHeadersVisible = true;

            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            conn.Open();

            int rowIndex = e.RowIndex;
            int conIndex = e.ColumnIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];
            if (conIndex == 0)
            {

                string con = $"SELECT * FROM Purchase_gasoline WHERE purchase_gasoline_id = {row.Cells[conIndex].Value.ToString()};";
                MySqlCommand command = new MySqlCommand(con, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    MessageBox.Show($"id  {reader[0].ToString()} Провайдер {reader[1].ToString()} Цена {reader[2].ToString()} Объем {reader[3].ToString()} Тип бензина{reader[4].ToString()} Работник {reader[5].ToString()}");

                }
                
            }

            else if (conIndex == 1)
            {
                MessageBox.Show($"id Провайдер {row.Cells[conIndex].Value.ToString()}");
            }
            else if (conIndex == 2)
            {
                MessageBox.Show($" цена {row.Cells[conIndex].Value.ToString()}");
            }
            else if (conIndex == 3)
            {
                MessageBox.Show($" Объем {row.Cells[conIndex].Value.ToString()}");
            }
            else if (conIndex == 4)
            {
                MessageBox.Show($"id Тип бензина {row.Cells[conIndex].Value.ToString()}");
            }

            conn.Close();
        }
    }
}

