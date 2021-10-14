using System;

namespace TaskC
{
    class Program
    {
        public class Manufacturer
        {
            public Manufacturer(string manufacturerName, string manufacturerCountry)
            {
                ManufacturerName = manufacturerName;
                ManufacturerCountry = manufacturerCountry;
            }
             public string ManufacturerName { get; }
            public string ManufacturerCountry { get; }
        }
        public class Souvenir
        {
            Manufacturer manufacturer;
            
            public Souvenir(string souvenirName, string manufacturerRequisites, int releaseDate, decimal price, Manufacturer someManufacturer)
            {
                SouvenirName = souvenirName;
                ManufacturerRequisites = manufacturerRequisites;
                ReleaseDate = releaseDate;
                Price = price;
                manufacturer = someManufacturer;
            }
            
            public string Country { get; }
            public string SouvenirName { get; }
            public string ManufacturerRequisites { get; }
            public int ReleaseDate { get; }
            public decimal Price { get; }
            public string ManufacturerName
            {
                get { return manufacturer.ManufacturerName; }
            }
            public string ManufacturerCountry
            {
                get { return manufacturer.ManufacturerCountry; }
            }
            public void DisplayInformationSouvenir()
            {
                Console.WriteLine($"Название сувенира: {SouvenirName}");
                Console.WriteLine($"Реквизиты производителя(адрес): {ManufacturerRequisites}");
                Console.WriteLine($"Год выпуска: {ReleaseDate}");
                Console.WriteLine($"Цена: {Price}");
                Console.WriteLine("--------------------------");
            }

            public void DisplayInformationManufacturer()
            {
                Console.WriteLine($"Название производителя: {manufacturer.ManufacturerName}");
                Console.WriteLine($"Страна производителя: {manufacturer.ManufacturerCountry}");
                Console.WriteLine("--------------------------\n");
            }
        }
        public static Souvenir EnterInformation()
        {         
            Console.Write("Введите название сувенира: ");
            string souvenirName = Console.ReadLine();
            Console.Write("Введите реквизиты производителя(адрес): ");
            string manufacturerRequisites = Console.ReadLine();

            Console.Write("Введите год выпуска: ");
            int releaseDate;
            while (!int.TryParse(Console.ReadLine(), out releaseDate)|| releaseDate>2021)
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
            Manufacturer manufacturer = new Manufacturer(name, country);
            Souvenir souvenir = new Souvenir(souvenirName, manufacturerRequisites, releaseDate, price, manufacturer);
            return souvenir;
        }
        public static Souvenir[] AddingItem()
        {
            Console.Write("Введите сколько записей о сувенирах вы хотите создать: ");
            int number; 
            while(!int.TryParse(Console.ReadLine(), out number))
            {
                Console.Write("Введите целое число! ");
            }

            Souvenir[] arraySouvenir = new Souvenir[number];
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine($"\t{i + 1}-элемент");
                arraySouvenir[i] = EnterInformation();
            }
            return arraySouvenir;

        }
        public static void DisplayInformationByManufacturer(Souvenir[] arraySouvenir)
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
            catch(Exception)
            {
                Console.WriteLine($"Названия производителя {name} нет в базе!");
            }
        }
        public static void DisplayInformationByCountry(Souvenir[] arraySouvenir)
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

        public static void DisplayInformationByPrice(Souvenir[] arraySouvenir)
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
        public static void DisplayInformationByDate(Souvenir[] arraySouvenir)
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
        public static void DeleteItemByManufacturer(ref Souvenir[] arraySouvenir)
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
      
        static void Main(string[] args)
        {  
            Souvenir[] arraySouvenir = AddingItem();
            int number;
            do {  Console.WriteLine("\n--Выберите, какое действие хотите совершить--");
            Console.WriteLine("1 - Вывести информацию о сувенирах заданного производителя " +
                " \n2 - Вывести информацию о сувенирах, произведенных в заданной стране " +
                " \n3 - Вывести информацию о производителях, чьи цены на сувениры меньше заданной " +
                "\n4 - Вывести информацию о производителях заданного сувенира, произведенного в заданном году " +
                "\n5 - Удалить заданного производителя и его сувениры \n6 - Вывести информацию о сувенирах " +
                "\n7 - выйти\n");
                number = int.Parse(Console.ReadLine());
           
            switch (number)
            {
                case 1:
                    DisplayInformationByManufacturer(arraySouvenir);
                    break;
                case 2:
                    DisplayInformationByCountry(arraySouvenir);
                    break;
                case 3:
                    DisplayInformationByPrice(arraySouvenir);
                    break;
                case 4:
                    DisplayInformationByDate(arraySouvenir);
                    break;
                case 5:
                    DeleteItemByManufacturer(ref arraySouvenir);
                    break;
                case 6:
                        if (arraySouvenir.Length > 0)
                        {
                            for (int i = 0; i < arraySouvenir.Length; i++)
                            {

                                arraySouvenir[i].DisplayInformationSouvenir();
                                arraySouvenir[i].DisplayInformationManufacturer();
                            }
                        }
                        else Console.WriteLine("Нет информации о сувенирах!");
                    break;
                default: break;
            }
        } while (number != 7); 

        }
    }
}
