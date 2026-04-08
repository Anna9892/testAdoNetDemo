using System;
using ADO.NET.DAL;
using ADO.NET.DAL.Models;

namespace ADONetTest.Connected;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var connection = DbConnectionFactory.GetPostgreSqlConnection();
            var context = new ConnectedContext(connection);

            // ... (предыдущий закомментированный код остается без изменений)

            context.TransactionsDemoRawSql();

           
            
            Console.WriteLine("\n--- Поиск пользователей ---");
            Console.Write("Введите часть имени для поиска: ");
            string searchName = Console.ReadLine() ?? "";

            var filteredUsers = context.GetUsersByFilter(searchName);

            if (filteredUsers.Count > 0)
            {
                foreach (var user in filteredUsers)
                {
                    Console.WriteLine($"{user.Id} - {user.Name} - [{(user.IsDriver ? "Водитель" : "Пешеход")}]");
                }
            }
            else
            {
                Console.WriteLine("Пользователи не найдены.");
            }

            Console.WriteLine("---------------------------\n");
            
            Console.WriteLine("Нажмите Enter для выхода...");
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка: " + e.Message);
        }
    }
}