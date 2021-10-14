using System;

namespace TaskC
{
    class Program
    {
        public struct Manufacturer
        {
            public Manufacturer(string name, string country)
            {
               Name = name;
               Country = country;
            }
            public string Name { get; }
            public string Country { get; }

            /*public void DisplayInformationManufacturer()
            {
                Console.WriteLine($"Название производителя: {Name}");
                Console.WriteLine($"Страна производителя: {Country}");
            }*/
        }

        public struct Souvenir
        {
            public Manufacturer manufacturer;
            public Souvenir(string souvenirName, string manufacturerRequisites, DateTime releaseDate, decimal price, Manufacturer someManufacturer) 
            {
                SouvenirName = souvenirName;
                ManufacturerRequisites = manufacturerRequisites;
                ReleaseDate = releaseDate;
                Price = price;
                manufacturer = someManufacturer;
            }
            public string SouvenirName { get;}
            public string ManufacturerRequisites { get; }
            public DateTime ReleaseDate { get; }
            public decimal Price { get; }
            public void DisplayInformationSouvenir()
            {
                Console.WriteLine($"Название сувенира: {SouvenirName}");
                Console.WriteLine($"Реквизиты производителя: {ManufacturerRequisites}");
                Console.WriteLine($"Дата выпуска: {ReleaseDate.ToShortDateString()}");
                Console.WriteLine($"Цена: {Price}");
                Console.WriteLine("--------------------------"); 
            }

            public void DisplayInformationManufacturer()
            {
                Console.WriteLine($"Название производителя: {manufacturer.Name}");
                Console.WriteLine($"Страна производителя: {manufacturer.Country}");
            }

        }
        public static Souvenir EnterInformation()
        {
            string souvenirName;
            string manufacturerRequisites;
            DateTime releaseDate;
            decimal price;
            string name;
            string country;
            //DateTime dtOut;

            Console.Write("Введите название сувенира: ");
            souvenirName = Console.ReadLine();
            Console.Write("Введите реквизиты производителя: ");
            manufacturerRequisites = Console.ReadLine();

            Console.Write("Введите дату выпуска: ");
            while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
            {
                Console.Write("Введите дату в формате: {0:d} ", new DateTime(2008, 1, 7));
            }
            Console.Write("Введите цену: ");
            price = decimal.Parse(Console.ReadLine());

            Console.Write("Введите название производителя: ");
            name = Console.ReadLine();
            Console.Write("Введите страну производителя: ");
            country = Console.ReadLine();
            Console.WriteLine("--------------------------");
            Manufacturer manufacturer = new Manufacturer(name, country);
             Souvenir  souvenir = new Souvenir(souvenirName, manufacturerRequisites, releaseDate, price, manufacturer);
            return souvenir;
        }
        /*class Manufacturer
         {
             public Manufacturer(string name, string country)
             {
                 Name = name;
                 Country = country;
             }
             public  string Name { get; }
             public  string Country { get; }
         }
         class Souvenir
         {
              Manufacturer manufacturer1;
             public Souvenir(string souvenirName, string manufacturerRequisites, DateTime releaseDate, decimal price, Manufacturer someManufacturer)
             {
                 SouvenirName = souvenirName;
                 ManufacturerRequisites = manufacturerRequisites;
                 ReleaseDate = releaseDate;
                 Price = price;
                 manufacturer1 = someManufacturer;
             }
             public string SouvenirName { get; }
             public string ManufacturerRequisites { get; }
             public DateTime ReleaseDate { get; }
             public decimal Price { get; }


         }*/
        public static Souvenir[] AddingItem()
        {
            Console.Write("Введите сколько записей о сувенирах вы хотите создать: ");
            int number = int.Parse(Console.ReadLine());
            
            Souvenir[] arraySouvenir = new Souvenir[number];
            for(int i = 0; i < number; i++)
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
            for(int i = 0; i< arraySouvenir.Length; i++)
            {
                if(arraySouvenir[i].manufacturer.Name == name)
                {
                    arraySouvenir[i].DisplayInformationSouvenir();
                }
            }
        }
        public static void DisplayInformationByCountry(Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название страны: ");
            string country = Console.ReadLine();
            for (int i = 0; i < arraySouvenir.Length; i++)
            {
                if (arraySouvenir[i].manufacturer.Country == country)
                {
                    arraySouvenir[i].DisplayInformationSouvenir();
                }
            }
        }

        public static void DisplayInformationByPrice(Souvenir[] arraySouvenir)
        {
            Console.Write("Введите цену: ");
            decimal price = decimal.Parse(Console.ReadLine());
            for (int i = 0; i < arraySouvenir.Length; i++)
            {
                if (arraySouvenir[i].Price < price)
                {
                    arraySouvenir[i].DisplayInformationManufacturer();
                }
            }
        }
        public static void DisplayInformationByDate(Souvenir[] arraySouvenir)
        {
            DateTime releaseDate;
            Console.Write("Введите дату выпуска: ");
            while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
            {
                Console.Write("Введите дату в формате: {0:d} ", new DateTime(2008, 1, 7));
            }
            for (int i = 0; i < arraySouvenir.Length; i++)
            {
                if (arraySouvenir[i].ReleaseDate == releaseDate)
                {
                    arraySouvenir[i].DisplayInformationManufacturer();
                }
            }
        }
        public static void DeleteItemByManufacturer(ref Souvenir[] arraySouvenir)
        {
            Console.Write("Введите название производителя: ");
            string name = Console.ReadLine();
            int count = 0;
            for (int i = 0; i < arraySouvenir.Length; i++)
            {
                if (arraySouvenir[i].manufacturer.Name == name)
                {
                    count++;
                    for (int j = i; j < arraySouvenir.Length-count; j++)
                    {
                        arraySouvenir[j] = arraySouvenir[j + 1];
                    }
                }
                
            }
        Array.Resize(ref arraySouvenir, arraySouvenir.Length - count);
        }
        static void Main(string[] args)
        {
            Souvenir[] arraySouvenir = AddingItem();
            DeleteItemByManufacturer(ref arraySouvenir);

            for (int i = 0; i < arraySouvenir.Length; i++)
            {

                arraySouvenir[i].DisplayInformationSouvenir();
                arraySouvenir[i].DisplayInformationManufacturer();
            }
            

        }
    }
}
