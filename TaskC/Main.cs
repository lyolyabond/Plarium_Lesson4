using System;



namespace TaskC
{
    class Program
    {

        static void Main(string[] args)
        {  
           Classes.Souvenir[] arraySouvenir = Function.AddingItem();
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
        } while (number != 7); 

        }
    }
}
