using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Phonebook
{
    internal class Program
    {
        /// <summary>
        /// Главное меню.
        /// </summary>
        static void Main()
        {
            Phonebook phonebook = Phonebook.Instance;
            Phonebook contact = new Phonebook();

            while(true)
            {
                Console.WriteLine("Выберете действие.");
                Console.WriteLine("1. Добавить новый контакт.");
                Console.WriteLine("2. Получить абонента по номеру телефона.");
                Console.WriteLine("3. Получить номер телефона по имени абонента.");
                Console.WriteLine("4. Удалить контакт.");
                Console.WriteLine("5. Выйти.");

                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                        AddAbonent(contact);
                        break;
                    case "2":
                        GetAbonentByPhone(contact);
                        break;
                    case "3":
                        GetAbonentByName(contact);
                        break;
                    case "4":
                        RemoveContact(contact);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Ошибка: Недопустимый выбор.");
                        break;
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Заполнение данных абонента для добавления в список контактов.
        /// </summary>
        /// <param name="contact">Телефонный список.</param>
        static void AddAbonent(Phonebook contact)
        {
            Console.Write("Введите имя абонента: ");
            string name = Console.ReadLine();
            Console.Write("Введите номер абонента: ");
            string phone = Console.ReadLine();
            contact.AddPhonebook(name, phone);
        }


        /// <summary>
        /// Заполнение данных абонента для его поиска с помошью номера телефона.
        /// </summary>
        /// <param name="contact">Телефонный список.</param>
        static void GetAbonentByPhone(Phonebook contact)
        {
            Console.Write("Введите номер абонента: ");
            string phone = Console.ReadLine();

            contact.GetAbonentByPhone(phone);
        }

        /// <summary>
        /// Заполнение данных абонента для поиска его номера телефона с помошью имени.
        /// </summary>
        /// <param name="contact">Телефонный список.</param>
        static void GetAbonentByName(Phonebook contact)
        {
            Console.Write("Введите имя абонента:");
            string name = Console.ReadLine();

            contact.GetAbonentByName(name);
        }

        /// <summary>
        /// Заполнение данных абонента для его удаления из телефонной книги.
        /// </summary>
        /// <param name="contact">Телефонный список.</param>
        static void RemoveContact(Phonebook contact)
        {
            Console.Write("Введите номер абонента: ");
            string phone = Console.ReadLine();

            contact.RemoveContact(phone);
        }
    }
}