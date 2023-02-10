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

namespace Proekt
{
    public partial class proekt2 : Form
    {
        MySql sql;
        MySqlConnection conn;// открыл подключение
        class MySql
        {
            string h = "chuc.caseum.ru";// задал данным для подключения переменные 
            string p = "33333";
            string u = "uchebka";
            string bd = "uchebka";
            string P = "uchebka";
            public string connStr;
            public string con() // метод возвращающий переменные 
            {
                return connStr = $"server={h};port" +
                     $"={p};user={u};database={bd};password={P};";
            }
        }
        
        public proekt2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                sql = new MySql();
                sql.con();
                conn = new MySqlConnection(sql.connStr);
                conn.Open();
                conn.Close();
                MessageBox.Show("Все чики пуки");
            }
            catch
            {
                MessageBox.Show("Все плохо");
            }
        }
    }
}
