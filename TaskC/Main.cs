using System;



namespace TaskC
{
    class Program
    {
        //4. Сувениры.В сущностях(типах) хранится информация о сувенирах и их производителях.
        //Для сувениров необходимо хранить:
        //— название;
        //— реквизиты производителя;
        //— дату выпуска;
        //— цену.
        //Для производителей необходимо хранить:
        //— название;
        //— страну.
        //Вывести информацию о сувенирах заданного производителя.
        //Вывести информацию о сувенирах, произведенных в заданной стране.
        //Вывести информацию о производителях, чьи цены на сувениры меньше заданной.
        //Вывести информацию о производителях заданного сувенира, произведенного в заданном году.
        //Удалить заданного производителя и его сувениры.
        static void Menu(int choice, ref Classes.Souvenir[] arraySouvenir)
        {
            do
            {
                Console.WriteLine("\n--Выберите, какое действие хотите совершить--");
                Console.WriteLine("1 - Вывести информацию о сувенирах заданного производителя " +
                    " \n2 - Вывести информацию о сувенирах, произведенных в заданной стране " +
                    " \n3 - Вывести информацию о производителях, чьи цены на сувениры меньше заданной " +
                    "\n4 - Вывести информацию о производителях заданного сувенира, произведенного в заданном году " +
                    "\n5 - Удалить заданного производителя и его сувениры \n6 - Вывести информацию о сувенирах " +
                    "\n7 - выйти\n");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Function.DisplayInformationByManufacturer(arraySouvenir);
                        break;
                    case 2:
                        Function.DisplayInformationByCountry(arraySouvenir);
                        break;
                    case 3:
                        Function.DisplayInformationByPrice(arraySouvenir);
                        break;
                    case 4:
                        Function.DisplayInformationByDate(arraySouvenir);
                        break;
                    case 5:
                        Function.DeleteItemByManufacturer(ref arraySouvenir);
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
            } while (choice != 7);
        }

        static void Main(string[] args)
        {
            int choice;
            Console.WriteLine("--Выберите действие: --");
            Console.WriteLine("1 - Добавить сувениры и ввести информацию о них\n2 - Инициализировать по умолчанию");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: 
                    Classes.Souvenir[] arraySouvenir = Function.AddingItem();
                    Console.Clear();
                    Menu(choice, ref arraySouvenir);
                    break;

                case 2:
                    Classes.Souvenir[] arraySouvenirDefault = new Classes.Souvenir[3];
                    arraySouvenirDefault[0] = new Classes.Souvenir("монета", "г. Москва, ул. Пушкина, 3", 2006, 1006.26m,
                        new Classes.Manufacturer("Global", "Россия"));
                    arraySouvenirDefault[1] = new Classes.Souvenir("статуэтка", "г. Киев, ул. Шевченка, 99", 2020, 105m,
                        new Classes.Manufacturer("UKR", "Украина"));
                    arraySouvenirDefault[2] = new Classes.Souvenir("магнитик", "г. Харьков, ул. Сумская, 1", 2020, 12000m,
                        new Classes.Manufacturer("Global", "Украина"));
                    Console.Clear();
                    Menu(choice, ref arraySouvenirDefault);
                    break;

                default: break;
            }  
        }
    }
}
