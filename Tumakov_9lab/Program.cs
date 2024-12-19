using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_9lab.Classes
{
    internal class Program
    {
        static void TaskFirst()
        {
            /*Упражнение 9.1 В классе банковский счет, созданном в предыдущих упражнениях, удалить
            методы заполнения полей. Вместо этих методов создать конструкторы. Переопределить
            конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
            для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
            банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
            счета.*/
            Console.WriteLine("Упражнение 9.1");
            BankAccount yourAccount= new BankAccount(578908725538, BankAccount.AccountType.Текущий);
            BankAccount savingsAccount = new BankAccount(98000, BankAccount.AccountType.Сберегательный);
            Console.WriteLine("Информация о вашем счёте в банке: ");
            yourAccount.InfoAccount();
            yourAccount.AccountReplenishment(10000000); 
            yourAccount.WithdrawalFromTheAccount(600000);
            yourAccount.TransferFromOneAccountToAnother(yourAccount, savingsAccount, 4673168);
            Console.WriteLine(" ");
        }
        static void TaskSecond()
        {
           /*Упражнение 9.2 Создать новый класс BankTransaction, который будет хранить информацию
           о всех банковских операциях. При изменении баланса счета создается новый объект класса
           BankTransaction, который содержит текущую дату и время, добавленную или снятую со
           счета сумму. Поля класса должны быть только для чтения (readonly). Конструктору класса
           передается один параметр – сумма. В классе банковский счет добавить закрытое поле типа
           System.Collections.Queue, которое будет хранить объекты класса BankTransaction для
           данного банковского счета; изменить методы снятия со счета и добавления на счет так,
           чтобы в них создавался объект класса BankTransaction и каждый объект добавлялся в
           переменную типа System.Collections.Queue.*/
            Console.WriteLine("Упражнение 9.2");
            Console.WriteLine("Упражнение 9.1");
            BankAccount yourAccount = new BankAccount(578908725538, BankAccount.AccountType.Текущий);
            BankAccount savingsAccount = new BankAccount(98000, BankAccount.AccountType.Сберегательный);
            Console.WriteLine("Информация о вашем счёте в банке: ");
            yourAccount.InfoAccount();
            yourAccount.AccountReplenishment(10000000);
            yourAccount.WithdrawalFromTheAccount(600000);
            yourAccount.TransferFromOneAccountToAnother(yourAccount, savingsAccount, 4673168);
            Console.WriteLine("\nИстория транзакций: ");
            yourAccount.GetTransactionStorage();
            savingsAccount.GetTransactionStorage();
        }
        static void TaskThird()
        {
            /*Упражнение 9.3 В классе банковский счет создать метод Dispose, который данные о
            проводках из очереди запишет в файл. Не забудьте внутри метода Dispose вызвать метод
            GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
            завершения для указанного объекта.*/
            Console.WriteLine("\nУпражнение 9.3");
            using (BankAccount yourAccount = new BankAccount(6757565446576))
            {
                yourAccount.InfoAccount();
                yourAccount.AccountReplenishment(998899);
                yourAccount.WithdrawalFromTheAccount(344577);
                yourAccount.AccountReplenishment(67657);
            }
            Console.WriteLine("Операция успешно завершена");
        }
        static void FourthTask()
        {
            /*Домашнее задание 9.1 В класс Song (из домашнего задания 8.2) добавить следующие
             конструкторы:
            1) параметры конструктора – название и автор песни, указатель на предыдущую песню
            инициализировать null.
            2) параметры конструктора – название, автор песни, предыдущая песня. В методе Main
            создать объект mySong. Возникнет ли ошибка при инициализации объекта mySong
            следующим образом: Song mySong = new Song(); ?
            Исправьте ошибку, создав необходимый конструктор.*/
            Console.WriteLine("\nДомашнее задание 9.1");
            Song mySong = new Song();
            Console.WriteLine($"Название: {mySong.Name}, Исполнитель: {mySong.Author}");
            Song song1 = new Song("Almost Idyllic", "Sleeping At Last");
            Console.WriteLine(song1.Title());
            Song song2 = new Song("Once Upon a Time", "Austin Farwell");
            Song song3 = new Song("Beving:Ala", "New Artist", song2);
            Console.WriteLine(song3.Title());
            Console.WriteLine($"Предыдущая песня; {song3.Early.Title()}");
            List<Song> songList = new List<Song> { song1, song2, song3 };
            Console.WriteLine("\nРезультат сравнения между собой двух объектов-песен:");
            if (song1.Equals(song2)) 
            {
                Console.WriteLine("Песни 1 и 2 одинаковые");
            }
            else
            {
                Console.WriteLine("Песни 1 и 2 разные");
            }
        }
        static void Main(string[] args)
        {
            TaskFirst();
            TaskSecond();
            TaskThird();
            FourthTask();
        }
    }
}
