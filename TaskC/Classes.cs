using System;
using System.Collections.Generic;
using System.Text;


namespace TaskC
{
    class Classes
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
    }
}
