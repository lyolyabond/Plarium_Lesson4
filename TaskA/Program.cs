using System;
using System.Text;

namespace TaskA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--Введите строку--");
            string str = Console.ReadLine();
            //Вызов метода выделения слов в строке
            string[] arrayStr = Function.HighlightWords(str);
            //Вызов метода удаления глаголов из строки
            Function.RemoveVerbs(arrayStr);
            //Вызов метода поиска одинаковых оснований
            Function.BaseWords(arrayStr);
        }
    }
}
