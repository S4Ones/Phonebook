namespace Phonebook
{
    internal class Phonebook
    {
        #region Константы

        private const string FilePath = "phonebook.txt";

        #endregion

        private List<Abonent> abonents;

        /// <summary>
        /// Подгрузка телефонного списка.
        /// </summary>
        public Phonebook()
        {
            abonents = new List<Abonent>();
            LoadData();
        }

        private static Phonebook instance;

        /// <summary>
        /// Реализация синглтона.
        /// </summary>
        public static Phonebook Instance
        {
            get
            {
                if (instance == null)
                    instance = new Phonebook();
                return instance;
            }
        }

        /// <summary>
        /// Добавление абонента в телефонный список.
        /// </summary>
        /// <param name="name">Имя абонента</param>
        /// <param name="phone">Номер телефона абонента.</param>
        public void AddPhonebook(string name, string phone)
        {
            if (abonents.Any(ab => ab.Name == name || ab.Phone == phone))
            {
                Console.WriteLine("Абонент уже существует.");
                return;
            }

            Abonent newAbonent = new Abonent()
            {
                Name = name,
                Phone = phone
            };
            abonents.Add(newAbonent);
            SaveData();
            Console.WriteLine("Абонент успешно добавлен.");
        }

        /// <summary>
        /// Получение имени абонента при помощи его номера телефона.
        /// </summary>
        /// <param name="phone">Номер телефона абонента.</param>
        public void GetAbonentByPhone(string phone)
        {
            var name = abonents.SingleOrDefault(ab => ab.Phone == phone);
            Console.Write("Имя абонента: ");
            Console.WriteLine(name != null ? name.Name : null);
        }

        /// <summary>
        /// Получене номера телефона абонента при помощи его имени.
        /// </summary>
        /// <param name="name">Имя абонента.</param>
        public void GetAbonentByName(string name)
        {
            var abonent = abonents.SingleOrDefault(ab => ab.Name == name);
            Console.Write("Телефон абонента: ");
            Console.WriteLine(abonent != null ? abonent.Phone : null);
        }

        /// <summary>
        /// Удаление абонента из телефонного списка.
        /// </summary>
        /// <param name="phone">Номер телефона абонента.</param>
        public void RemoveContact(string phone)
        {
            Abonent abonentToRemove = abonents.SingleOrDefault(a => a.Phone == phone);
            if (abonentToRemove != null)
            {
                abonents.Remove(abonentToRemove);
                SaveData();
                Console.WriteLine("Абонент успешно удален.");
            }
            else
            {
                Console.WriteLine("Абонент с таким номером телефона не найден.");
            }
        }

        /// <summary>
        /// Сохранение телефонного списака в файле.
        /// </summary>
        private void SaveData()
        {
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                foreach (var abonent in abonents)
                {
                    writer.WriteLine($"{abonent.Phone},{abonent.Name}");
                }
            }
        }

        /// <summary>
        /// Загрузка телефонного списака из файла.
        /// </summary>
        private void LoadData()
        {
            if (File.Exists(FilePath))
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            Abonent abonent = new Abonent
                            {
                                Name = parts[0],
                                Phone = parts[1]
                            };
                            abonents.Add(abonent);
                        }
                    }
                }
            }
        }
    }
}
