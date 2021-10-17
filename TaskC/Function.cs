using System;
using System.Collections.Generic;
using System.Text;


namespace TaskC
{
    class Function
    {
        //Метод ввода информации о сувенире
        public static Classes.Souvenir EnterInformation()
        {
            Console.Write("Введите название сувенира: ");
            string souvenirName = Console.ReadLine();
            Console.Write("Введите реквизиты производителя(адрес): ");
            string manufacturerRequisites = Console.ReadLine();

            Console.Write("Введите год выпуска: ");
            int releaseDate;
            while (!int.TryParse(Console.ReadLine(), out releaseDate) || releaseDate > 2021)
            {
                Console.Write("Введите год в формате 2021: ");
            }
            Console.Write("Введите цену: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Введите цену в формате 105,62 or 105: ");
            }
            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            Console.Write("Введите страну производителя: ");
            string country = Console.ReadLine();
            Console.WriteLine("--------------------------");
       
            Classes.Manufacturer manufacturer = new Classes.Manufacturer(name, country);
            Classes.Souvenir souvenir = new Classes.Souvenir(souvenirName, manufacturerRequisites, releaseDate, price, manufacturer);
            return souvenir;
        }

        //Метод для добавления экземпляров класса в массив
        public static Classes.Souvenir[] AddingItem()
        {
            Console.Write("Введите сколько записей о сувенирах вы хотите создать: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Введите целое число! ");
            }
            //Создание массива экземпляров класса
            Classes.Souvenir[] arraySouvenir = new Classes.Souvenir[number];
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"\t{i + 1}-элемент");
                //Ввод информации о каждом сувенире
                arraySouvenir[i] = EnterInformation();
            }
            return arraySouvenir;
        }
       
        //Метод для вывода информации о сувенирах по названию производителя
        public static void DisplayInformationByManufacturer(Classes.Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("Информация о сувенирах заданного производителя: ");

            //Механизм обработки исключительных ситуаций(если нет производителя с таким названием)
            try
            {
                for (int i = 0; i < arraySouvenir.Length; i++)
                {
                    if (arraySouvenir[i].ManufacturerName == name)
                    {
                        arraySouvenir[i].DisplayInformationSouvenir();
                        flag = true;
                    }

                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Названия производителя {name} нет в базе!");
            }
        }

        //Метод для вывода информации о сувенирах по названию страны производителя
        public static void DisplayInformationByCountry(Classes.Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название страны: ");
            string country = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("Информация o сувенирах, произведенных в заданной стране: ");
            //Механизм обработки исключительных ситуаций(если нет страны с таким названием)
            try
            {
                for (int i = 0; i < arraySouvenir.Length; i++)
                {
                    if (arraySouvenir[i].ManufacturerCountry == country)
                    {
                        arraySouvenir[i].DisplayInformationSouvenir();
                        flag = true;
                    }
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Названия страны {country} нет в базе!");
            }

        }

        //Метод для вывода информации о производителях, чьи цены на сувениры меньше заданной
        public static void DisplayInformationByPrice(Classes.Souvenir[] arraySouvenir)
        {
            Console.Write("Введите цену: ");
            decimal price;
            while (!decimal.TryParse(Console.ReadLine(), out price))
            {
                Console.Write("Введите цену в формате: 105,62 or 105 ");
            }
            bool flag = false;
            Console.WriteLine("Информация o производителях, чьи цены на сувениры меньше заданной: ");
            //Механизм обработки исключительных ситуаций(если нет цены на сувениры меньше заданной)
            try
            {
                for (int i = 0; i < arraySouvenir.Length; i++)
                {
                    if (arraySouvenir[i].Price < price)
                    {
                        arraySouvenir[i].DisplayInformationManufacturer();
                        flag = true;
                    }
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Сувенира с ценой, меньше чем {price} нет в базе!");
            }
        }

        //Метод для вывода информации о производителях заданного сувенира, произведенного в заданном году
        public static void DisplayInformationByDate(Classes.Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название сувенира: ");
            string souvenirName = Console.ReadLine();
            Console.Write("Введите дату выпуска: ");
            int releaseDate;
            while (!int.TryParse(Console.ReadLine(), out releaseDate) || releaseDate > 2021)
            {
                Console.Write("Введите год в формате: 2021 ");
            }
            bool flag = false;
            Console.WriteLine("Информация о производителях заданного сувенира, произведенного в заданном году: ");
            //Механизм обработки исключительных ситуаций(если нет сувенира с заданным названием и датой)
            try
            {
                for (int i = 0; i < arraySouvenir.Length; i++)
                {
                    if (arraySouvenir[i].ReleaseDate == releaseDate && arraySouvenir[i].SouvenirName == souvenirName)
                    {
                        arraySouvenir[i].DisplayInformationManufacturer();
                        flag = true;
                    }
                }
                if (!flag)
                    throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Сувенира с названием {souvenirName} и датой выпуска {releaseDate} нет в базе!");
            }
        }

        //Метод для удаления элементов массива по заданному названию производителя
        public static void DeleteItemByManufacturer(ref Classes.Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            int count = 0;
            //Механизм обработки исключительных ситуаций(если нет сувенира с заданным названием производителя)
            try
            {
                for (int i = 0; i < arraySouvenir.Length - count; i++)
                {
                    //Если задданое название совпадает с названием в массиве
                    if (arraySouvenir[i].ManufacturerName == name)
                    {
                        //Добавление количества элементов, которые нужно удалить
                        count++;
                        //Перемещение элементов в конец
                        for (int j = i; j < arraySouvenir.Length - count; j++)
                        {
                            arraySouvenir[j] = arraySouvenir[j + 1];
                        }
                        i--;
                    }
                }
                if (count > 0)
                {
                    //Изменение размера массива по количеству совпадений - удаление элементов
                    Array.Resize(ref arraySouvenir, arraySouvenir.Length - count);
                    Console.WriteLine("Удаление прошло успешно!");
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                Console.WriteLine($"Производителя с названием {name} нет в базе!");
            }

        }
    }
}
