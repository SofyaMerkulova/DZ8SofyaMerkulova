using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksFromFile8.Class;

namespace TasksFromFile8.Class
{
    internal class Program
    {
        static void TaskManager()
        {
            /*У команды из IT компании существует программа, где они контролируют свои текущие
          задачи – что-то типа Task Manager. Существует проекты по каждому проекту создаются
          задачи.
          Сущность Проект может быть в трех статусах: Проект, Исполнение, Закрыт.
          У проекта есть:
          ● описание проекта,
          ● сроки выполнения
          ● инициатор проекта(заказчик)
          ● человек, ответственный за проект(тимлид)
          ● задачи по проекту
          ● статус
          Задачи по проекту назначает только один человек(тимлид) Сущность Задача может быть в
          четырех статусах: Назначена, В работе, На проверке, Выполнена.
          У задачи есть:
         ● описание задачи,
         ● сроки задачи,
         ● инициатор задачи.
         ● исполнитель,
         ● статус задачи
         ● отчет(ы) по задаче
         Сущность Отчёт:
         ● текст отчета,
         ● дата выполнения,
         ● исполнитель.
          Описание процесса:
         Создается проект с определенными сроками. Далее ответственный за проект создает задачи
         по этому проекту.
         Задачи можно создавать только в статусе проекта «Проект». После того, как все проекты
         назначены необходимо перевести проект в статус «Исполнение».
         Задачи приходят исполнителям в статусе «Назначена». Исполнитель может взять задачу в
         работу, делегировать ее другому человеку или отклонить. Если человек берет задачу в
         работу, то задача переходит в статус «В работе», если он делегировал эту задачу, то меняется
         исполнитель, а статус становится «Назначена», при отклонении задачи, задача не имеет
         Исполнителя и Человек, назначивший задачу, может ее назначить кому-то другому или
         удалить эту задачу вообще. По каждой задаче создается отчет по выполненной работе.
         Отчет приходит инициатору на проверку.
         Отчет можно утвердить или вернуть на доработку. Проект считается закрытым, если по
         нему выполнены все задачи. Необходимо создать 10 человек команды, каждый человек
         должен получить минимум одну задачу.
         Проект минимум 1.*/
            Console.WriteLine("Упражнение: Task Manager ");
            Workers teamLeader = new Workers("Анастасия Алексеевна", "Тимлид");
            Workers customer = new Workers("Олег Николаевич", "Инициатор");
            Workers implementer1 = new Workers("Яна Виниаминовна", "Исполнитель");
            Workers implementer2 = new Workers("Елизавета Николаевна", "Исполнитель");
            Workers implementer3 = new Workers("Дмитрий Васильевич", "Исполнитель");
            Workers implementer4 = new Workers("Людмила Егоровна", "Исполнитель");
            Workers implementer5 = new Workers("Иван Иванович", "Исполнитель");
            Workers implementer6 = new Workers("Бахтияр Романович", "Исполнитель");
            Workers implementer7 = new Workers("Юрий Борисовчи", "Исполнитель");
            Workers implementer8 = new Workers("Ольга Васильевна", "Исполнитель");
            Project project = new Project("Выполнение плана в указанный срок", DateTime.Now.AddMonths(3), customer, teamLeader);
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(1), "Кибербезопасность"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Обслуживание оборудования и программного обеспечения"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Хранение и резервное копирование данных"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Разработка и доработка приложений"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Техподдержка и устранение неполадок"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Аварийное восстановление"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Управление лицензиями на программное обеспечение"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Внедрение и управление телефонными системами"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Облачные услуги и хостинг"));
            project.SetATask(new Task(customer, DateTime.Now.AddMonths(2), "Внедрение и управление телефонными (VoIP) системами"));
            project.SetANewStatus();
            project.Tasks[0].Implementer = implementer1;
            project.Tasks[1].Implementer = implementer2;
            project.Tasks[2].Implementer = implementer3;
            project.Tasks[3].Implementer = implementer4;
            project.Tasks[4].Implementer = implementer5;
            project.Tasks[5].Implementer = implementer6;
            project.Tasks[6].Implementer = implementer7;
            project.Tasks[7].Implementer = implementer8;
            foreach (Task task in project.Tasks)
            {
                task.AcceptedForExecution();
                task.TheTaskIsCompleted("Задача завершена", DateTime.Now);
                Console.WriteLine($"Задача: {task.Description}, статус задачи : {task.Status}");
                if (task.TaskReport != null)
                {
                    Console.WriteLine($"Дата: {task.TaskReport.Date.ToShortDateString()}, исполнитель: {task.TaskReport.Implementer.Name}");
                }

                task.ApproveTheReport();
            }
         project.EndOfWork();
         Console.WriteLine($"Статус проекта: {project.Status}");
        }
        static void Main(string[] args)
        {
          TaskManager();
        }
        
    }
}
