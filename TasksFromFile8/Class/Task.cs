using System;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
namespace TasksFromFile8.Class
{
    internal class Task
    {
        public Workers Customer { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public Workers Implementer { get; set; }
        public Report TaskReport { get; set; }
        public string Status { get; set; }

        public Task(Workers implementer, DateTime deadLine, string description)
        {
            Implementer = implementer;
            DeadLine = deadLine;
            Description = description;
            TaskReport = null;
            Status = "Назначена";

        }
        public void AcceptedForExecution()
        {
            Status = "В работе";
            Console.WriteLine(Description);
        }
        public void TheTaskIsCompleted(string reportDocument, DateTime reportDay)
        {
            if (TaskReport != null)
            {
                Console.WriteLine("Ошибка.На одну задачу необходим один отчёт");
                return;
            }
            TaskReport = new Report(reportDocument, reportDay, Implementer);
            Status = "Выполнена";
            TaskReport = new Report(reportDocument, reportDay, Implementer);
        }
        public void ApproveTheReport()
        {
            if (TaskReport != null)
            {
                Console.WriteLine("Отчет утвержден.");
            }
        }
        public void Vodification()
        {
            if (TaskReport != null)
            {
                Console.WriteLine("Возвращен на доработку.");
            }


        }
    }
}