using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFromFile8.Class
{
    internal class Report
    {
        public string TextOfReport { get; set; }
        public DateTime Date { get; set; }
        public Workers Implementer { get; set; }

        public Report(string textOfReport, DateTime date, Workers implementer)
        {
            TextOfReport = textOfReport;
            Date = date;
            Implementer = implementer;
        }
    }

}

