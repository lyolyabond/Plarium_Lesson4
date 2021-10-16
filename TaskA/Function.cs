using System;
using System.Collections.Generic;
using System.Text;

namespace TaskA
{
    class Function
    {
        //Программа принимает строку.
        //По нажатию произвольной клавиши поочередно выделяет
        //в тексте заданное слово(заданное слово вводится с клавиатуры);

        //Метод для реализации выделения заданного слова
        public static string[] HighlightWords(string str)
        {
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            //Разбиение строки на слова и помещение в массив строк
            string[] arrayStr = str.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Нажимайте произвольную клавишу для выделения указанного слова...");

            //int topPositionForHighlight = Console.CursorTop;
            //Установка значения позиции курсора в консоле
            int topPositionForKey = Console.CursorTop;
            StringBuilder temp = new StringBuilder();
            for (int j = 0; j < arrayStr.Length; j++)
            {
                //Проверка, равно ли слово в массиве заданному(без учёта регистра)
                if (string.Equals(arrayStr[j], word, StringComparison.OrdinalIgnoreCase))
                {  //Введение символа
                    Console.ReadKey();
                    //Замена символа на пробел, и возврат в начало строки
                    Console.Write("\b  \b");
                   //Установка позиции курсора на начальный индекс нужного слова
                    Console.SetCursorPosition(str.IndexOf(arrayStr[j], temp.Length), 1);
                    //Изменение цвета тескта
                    Console.ForegroundColor = ConsoleColor.Green;
                    //Выведение слова другим цветом на месте старого
                    Console.Write(arrayStr[j]);
                    //Сброс цвета
                    Console.ResetColor();
                }
                temp.Append(arrayStr[j] + " ");
                //Установка позиции курсора в начальную точку
                Console.SetCursorPosition(0, topPositionForKey);
            }
            Console.WriteLine("\nНажмите произвольную клавишу для продолжения работы...");
            Console.ReadKey();
            Console.Write("\b  \b");

            return arrayStr;
        }
        public static void RemoveVerbs(string[] str)
        {
            string[] endingsVerbs = { "ешь", "ет", "ем", "еть", "ут", "ют", "ить", "ит", "ите", "ать", "ять", "аю", "ю" };
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var word in str)
            {
                bool flag = false;
                foreach (var ending in endingsVerbs)
                {
                    if (word.EndsWith(ending))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    stringBuilder.Append(word + " ");
                }
            }

            Console.Write($"\n--Строка без глаголов--\n{stringBuilder}");
        }
        public static void BaseWords(string[] str)
        {
            StringBuilder stringBuilder = new StringBuilder("");
            StringBuilder empty = new StringBuilder("");


            for (int i = 0; i < str.Length - 1; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    stringBuilder.Append(BaseTwoWords(str[i], str[j]) ?? empty);

                }
            }
        }
        static StringBuilder BaseTwoWords(string firstWord, string secondWord)
        {
            int count = 0;
            bool flag = false;
            bool b = true;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder baseWord = new StringBuilder();
            for (int i = 0; i < firstWord.Length; i++)
            {
                for (int j = 0; j < secondWord.Length; j++)
                {
                    if (firstWord[i] != secondWord[j])
                    {
                        if (!flag)
                        {
                            baseWord = new StringBuilder("");
                        }
                        else if (flag && baseWord.Length > 2) b = false;
                        count = 0;
                        continue;
                    }
                    else
                    {
                        count++;
                        if (b)
                        {
                            baseWord.Append(secondWord[j]);
                        }
                        if (count == 3)
                        {
                            stringBuilder.Append(firstWord + " ").Append(secondWord);
                            flag = true;
                            Console.WriteLine("\n\n--Слова с одинаковым основанием:--\n");
                            Console.Write(stringBuilder);
                        }
                        if (i < firstWord.Length - 1 && j < secondWord.Length)
                        {
                            i++;
                            continue;
                        }
                    }

                    if (count < 1 && (i == firstWord.Length - 2 || j == secondWord.Length - 2))
                    {
                        break;
                    }
                }

            }
            if (baseWord.Length > 2)
            {
                ParseWord(stringBuilder, baseWord);
            }

            return stringBuilder;
        }

        static void ParseWord(StringBuilder stringBuilder, StringBuilder baseWord)
        {
            Console.WriteLine($"\nПрефикс\t\tОснование\tОкончание");

            string str = stringBuilder.ToString();
            string prefix1 = str.Substring(0, str.IndexOf(baseWord.ToString()));
            string end1 = str.Substring(prefix1.Length + baseWord.Length, str.IndexOf(" ") - prefix1.Length - baseWord.Length);

            Check(prefix1);
            Console.Write($"{baseWord}\t\t");
            Check(end1);

            Console.WriteLine();

            string prefix2 = str.Substring(str.IndexOf(" ") + 1, str.LastIndexOf(baseWord.ToString()) - (str.IndexOf(" ") + 1));
            string end2 = str.Substring(str.LastIndexOf(baseWord.ToString()) + baseWord.Length);
            Check(prefix2);
            Console.Write($"{baseWord}\t\t");
            Check(end2);
        }
        static void Check(string part)
        {
            if (string.IsNullOrEmpty(part))
            {
                Console.Write("-\t\t");
            }
            else Console.Write($"{part}\t\t");

        }
    }
}
