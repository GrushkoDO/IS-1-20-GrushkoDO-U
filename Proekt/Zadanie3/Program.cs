using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadanie3
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form());
        }


    }
    public class Connect
    {
        
        public string h = "chuc.caseum.ru";
        public string p = "33333";
        public string u = "st_1_20_9";
        public string d = "is_1_20_st9_KURS";
        public string P = "19134029";
        public string connStr;
        public string con()
        {
            return connStr = $"server={h};port={p};user={u};database={d};password={P};";
        }
    }
}