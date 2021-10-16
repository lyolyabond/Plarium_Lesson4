using System;
using System.Text;

namespace TaskA
{
    class Program
    {
        //Метод нахождения 
        

        static void Main(string[] args)
        {
            Console.WriteLine("--Введите строку--");
            string str = Console.ReadLine();
            string[] arrayStr = Function.HighlightWords(str);
            Function.RemoveVerbs(arrayStr);
            Function.BaseWords(arrayStr);
        }
    }
}
