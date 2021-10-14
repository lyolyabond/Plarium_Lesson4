using System;
using System.Collections.Generic;
using System.Text;


namespace TaskC
{
    class Function
    {
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
        public static Classes.Souvenir[] AddingItem()
        {
            Console.Write("Введите сколько записей о сувенирах вы хотите создать: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Введите целое число! ");
            }

            Classes.Souvenir[] arraySouvenir = new Classes.Souvenir[number];
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"\t{i + 1}-элемент");
                arraySouvenir[i] = EnterInformation();
            }
            return arraySouvenir;

        }
       
        public static void DisplayInformationByManufacturer(Classes.Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("Информация о сувенирах заданного производителя: ");
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
        public static void DisplayInformationByCountry(Classes.Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название страны: ");
            string country = Console.ReadLine();
            bool flag = false;
            Console.WriteLine("Информация o сувенирах, произведенных в заданной стране: ");
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
                Console.WriteLine($"Сувенира с  названием {souvenirName} и датой выпуска {releaseDate} нет в базе!");
            }

        }
        public static void DeleteItemByManufacturer(ref Classes.Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            int count = 0;
            try
            {
                for (int i = 0; i < arraySouvenir.Length - count; i++)
                {
                    if (arraySouvenir[i].ManufacturerName == name)
                    {
                        count++;
                        for (int j = i; j < arraySouvenir.Length - count; j++)
                        {
                            arraySouvenir[j] = arraySouvenir[j + 1];
                        }
                        i--;
                    }
                }
                if (count > 0)
                {
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
