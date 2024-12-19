using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksFromFile8.Class
{
    internal class Project
    {
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Workers TeamLeader { get; set; }
        public Workers Customer { get; set; } 
        public List<Task> Tasks { get; set; } 
        public string Status { get; set; } 
        public Project(string description, DateTime deadline, Workers teamLeader, Workers customer) 
        {
            Description = description;
            Deadline = deadline;
            Customer = customer;
            TeamLeader = teamLeader;
            Tasks = new List<Task>();
            Status = "Проект";
            Tasks = new List<Task>();
        }

        public void SetATask(Task task)
        {
            if ( Status != "Проект")
            {
                Console.WriteLine("Нельзя осуществить данное действие");
            }
            else 
            { 
                Tasks.Add( task );
            }
        }
        public void SetANewStatus()
        {
            Status = "Исполнение";
        }
        public void EndOfWork()
        {
            bool allTasksCompleted = true;
            foreach (var task in Tasks)
            {
                if (task.Status != "Выполнена")
                {
                    allTasksCompleted = false;
                    break;
                }
            }
            if (allTasksCompleted)
            {
                Status = "Закрыт";
            }
        }

    }
}
