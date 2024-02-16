using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entidades
{
    public class FiltroLogs
    {
        public int ID { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public DateTime Date { get; set; }     
    }
}
