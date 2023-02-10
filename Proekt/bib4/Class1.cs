using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bib4
{
    public class Class1
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
