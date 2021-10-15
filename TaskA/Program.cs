using System;
using System.Text;

namespace TaskA
{
    class Program
    {
        static string[] HighlightWords(string str)
        {
            Console.Write("Введите слово: ");
            string word = Console.ReadLine();
            string[] arrayStr = str.Replace(",", "").Replace(".", "").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Нажимайте произвольную клавишу для поочерёдного выведения слов и выделения указанного слова");
            for (int j = 0; j < arrayStr.Length; j++)
            {
                Console.ReadKey();
                Console.Write("\b");

                if (arrayStr[j] == word)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else { Console.ResetColor(); }
                Console.Write(arrayStr[j] + " ");

            }
            Console.ResetColor();
            return arrayStr;
        }
        static void RemoveVerbs(string[] str)
        {
            string[] endingsVerbs = { "ешь", "ет", "ем", "еть", "ут", "ют", "ить", "ит", "ите", "ать", "ять", "аю" };
            StringBuilder stringBuilder = new StringBuilder();
           
            foreach(var word in str)
            {
                bool flag = false;
                foreach(var ending in endingsVerbs)
                {
                    if (word.EndsWith(ending))
                    {
                        flag = true;
                        break;
                    }
                    //else stringBuilder.Append(" ");
                }
                if(!flag)
                { 
                stringBuilder.Append(word + " ");
                }
            }
            
            Console.WriteLine();
            Console.WriteLine(stringBuilder);
        }
        static void BaseWords(string[] str)
        {
            StringBuilder stringBuilder = new StringBuilder("");
            StringBuilder empty = new StringBuilder("");
            
            
            for (int i = 0; i < str.Length-1; i++)
            {
                for (int j = i+1; j < str.Length; j++)
                {
                    stringBuilder.Append(BaseTwoWords(str[i], str[j]) ?? empty);

                }
            }
           

        }
        static StringBuilder BaseTwoWords(string firstWord, string secondWord)
        {
            int count = 0;
            bool flag = false;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder baseWord = new StringBuilder();
            for (int i = 0; i < firstWord.Length; i++)
            {
                for (int j = 0; j < secondWord.Length; j++)
                {
                    if (firstWord[i] == secondWord[j])
                    {
                        count++;
                        baseWord.Append(secondWord[j]);
                        if (count == 3)
                        {
                            stringBuilder.Append(firstWord + " ").Append(secondWord + "\n");
                            flag = true;
                            Console.WriteLine("\n\n--Однокоренные слова:--");
                            Console.Write(stringBuilder);
                            
                        }

                        if (i < firstWord.Length - 1 && j < secondWord.Length)
                        {
                            i++;
                            continue;
                        }
                    }
                    else
                    {
                        count = 0;
                        if(!flag)
                        baseWord = new StringBuilder("");
                    }

                    if (count < 1 && (i == firstWord.Length - 2 || j == secondWord.Length - 2))
                    {
                        break;
                    }
                }
            }
            if(baseWord.Length !=0)
            { 
            Console.Write($"Основание: {baseWord}");
            }
            return stringBuilder;
        }
       

        static void Main(string[] args)
        {
            Console.WriteLine("--Введите строку--");
            string str = Console.ReadLine();
            string[] arrayStr = HighlightWords(str);
            // RemoveVerbs(arrayStr);
            // BaseWord(arrayStr);
            // BaseTwoWords("лес", "лесок");
            // StringBuilder stringBuilder = new StringBuilder(str);
            BaseWords(arrayStr);
        }
    }
}
