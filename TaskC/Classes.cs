using System;
using System.Collections.Generic;
using System.Text;


namespace TaskC
{
    class Classes
    {
        //Класс производителя сувениров
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

        //Класс сувенира
        public class Souvenir
        {
            //Создание экземляра класса производителя сувениров для примера агрегации
            Manufacturer _manufacturer;

            //Инициализирующий конструктор
            public Souvenir(string souvenirName, string manufacturerRequisites, int releaseDate, decimal price, Manufacturer someManufacturer)
            {
                SouvenirName = souvenirName;
                ManufacturerRequisites = manufacturerRequisites;
                ReleaseDate = releaseDate;
                Price = price;
                _manufacturer = someManufacturer;
            }
            //Конструктор по умолчанию
            public Souvenir()
            { }

            public string Country { get; set; }
            public string SouvenirName { get; set; }
            public string ManufacturerRequisites { get; set; }
            public int ReleaseDate { get; set; }
            public decimal Price { get; set; }
            public string ManufacturerName
            {
                get { return _manufacturer.ManufacturerName; }
            }
            public string ManufacturerCountry
            {
                get { return _manufacturer.ManufacturerCountry; }
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
                Console.WriteLine($"Название производителя: {_manufacturer.ManufacturerName}");
                Console.WriteLine($"Страна производителя: {_manufacturer.ManufacturerCountry}");
                Console.WriteLine("--------------------------\n");
            }
        }
        
    }
}
