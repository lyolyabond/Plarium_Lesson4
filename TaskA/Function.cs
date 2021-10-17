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

            //Установка значения позиции курсора в консоле
            int topPositionForKey = Console.CursorTop;
            int topPositionForStr = 1;
            int indexOfWord;
            //Получение значения длины строки консоли
            int buffW = Console.BufferWidth;
            int entryException = 0;
            StringBuilder temp = new StringBuilder();

            for (int j = 0; j < arrayStr.Length; j++)
            {
                //Проверка, равно ли слово в массиве заданному(без учёта регистра)
                if (string.Equals(arrayStr[j], word, StringComparison.OrdinalIgnoreCase))
                {
                    //Ожидание нажатия клавиши
                    Console.ReadKey();
                    //Замена символа на пробел, и возврат в начало строки
                    Console.Write("\b \b");
                    indexOfWord = str.IndexOf(arrayStr[j], temp.Length);
                    try
                    {
                        //Проверка, было ли исключение
                        if(entryException > 0)
                        {
                            //Индекс для позиции в консоли меняется
                            indexOfWord -=  entryException * buffW;
                        }
                        SetPosition(indexOfWord, topPositionForStr, word);
                    }
                    //Обработка исключения
                    catch (ArgumentOutOfRangeException)
                    {
                        entryException++;
                        topPositionForStr++;
                        indexOfWord -= buffW;
                        SetPosition(indexOfWord, topPositionForStr, word);
                    }
                }
                temp.Append(arrayStr[j] + " ");
                //Установка позиции курсора в начальную точку
                Console.SetCursorPosition(0, topPositionForKey);
            }
            Console.WriteLine("\nНажмите произвольную клавишу для продолжения работы...");
            //Ожидание нажатия клавиши
            Console.ReadKey();
            Console.Write("\b  \b");
            //Возвращение массива слов
            return arrayStr;
        }

        //Метод для установки курсора в консоли в начале нужного слова
        static void SetPosition(int indexOfWord, int topPositionForStr, string word)
        {
            //Установка позиции курсора на начальный индекс нужного слова
            Console.SetCursorPosition(indexOfWord, topPositionForStr);
            Console.ForegroundColor = ConsoleColor.Green;
            //Выведение слова другим цветом на месте старого
            Console.Write(word);
            //Сброс цвета
            Console.ResetColor();
        }

        // Ищет в ней глаголы и возвращает в консоль строку без глаголов.
        //Для выполнения задания создать массив строк и проинициализировать его 
        //несколькими окончаниями, которые есть у глаголов, например, “ать”, “ять” и т.д.
        // Слово из входной строки соответствует глаголу, если оно содержит одно из этих окончаний.

        //Метод для реализации удаления глаголов из строки
        public static void RemoveVerbs(string[] str)
        {
            //Масиив окончаний глаголов
            string[] endingsVerbs = { "ешь", "ем", "еть", "ут", "ют", "ить", "ит", "ите", "ать", "ять", "аю", "ю" };
            StringBuilder stringBuilder = new StringBuilder();

            //Проход по словам в массиве строк
            foreach (var word in str)
            {
                //Флаг того, что слово, имеет или не имеет окончание глагола
                bool flag = false;
                //Проход по окончаниям в массиве окончаний
                foreach (var ending in endingsVerbs)
                {//Проверка, заканчивается ли слово как глагол
                    if (word.EndsWith(ending))
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {//Если слово - не главгол, добавляется в строку
                    stringBuilder.Append(word + " ");
                }
            }
            Console.Write($"\n--Строка без глаголов--\n{stringBuilder}");
        }
        //Найти во входной строке слова с одинаковым основанием(совпадающие части двух и более слов, 3 буквы и более) и разбить эти слова на 3 части
        //– префикс, то что стоит до основания слева,
        //– основа, то что совпадает с частью другого слова,
        //– окончание.

        //Метод для передачи слов на сравнение на одинаковые основания
        public static void BaseWords(string[] str)
        {
            StringBuilder stringBuilder = new StringBuilder("");
            StringBuilder empty = new StringBuilder("");

            //Передача слова с каждым последующим в метод определения одинаковых оснований
            for (int i = 0; i < str.Length - 1; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    //Добавление в строку оснований
                    stringBuilder.Append(BaseTwoWords(str[i], str[j]) ?? empty);
                }
            }
            if(stringBuilder.Length == 0)
            {
                Console.WriteLine("\nСлов с одинаковым основанием НЕТ!");
            }
        }

        //Метод для проверки 2 слов на одинаковые основания
        static StringBuilder BaseTwoWords(string firstWord, string secondWord)
        {
            //Переменная для подсчёта одинаковых букв
            int count = 0;
            //Переменная для проверки добавления основания равному 3 
            bool added = false;
            //Переменная для проверки, можно ли очищать строку оснований
            bool canBeCleaned = true;
            StringBuilder stringBuilder = new StringBuilder();
            StringBuilder baseWord = new StringBuilder();

            //Проход и сравнение букв в каждом слове
            for (int i = 0; i < firstWord.Length; i++)
            {
                for (int j = 0; j < secondWord.Length; j++)
                {
                    //Если не равны буквы
                    if (firstWord[i] != secondWord[j])
                    {
                        //Если ещё не добавлено основание больше или равно 3
                        if (!added)
                        {
                            //Очищение строки основания
                            baseWord = new StringBuilder("");
                        }
                        //Если добавлено основание больше или равно 3 
                        //Не может быть очищена строка оснований
                        else if (added && baseWord.Length > 2) canBeCleaned = false;
                        count = 0;
                        continue;
                    }
                    else
                    {
                        //Добавление количества одинаковых букв, расположенных подряд
                        count++;
                        //Если может быть очищено(то есть длина основания меньше 3)
                        if (canBeCleaned)
                        {
                            //Добавление общей буквы
                            baseWord.Append(secondWord[j]);
                        }
                        //Если количество одинаковых букв равно 3 
                        if (count == 3)
                        {
                            //Добавление слов в строку 
                            stringBuilder.Append(firstWord + " ").Append(secondWord); 
                            added = true;
                            //Вывод в консоль слов
                            Console.WriteLine("\n\n--Слова с одинаковым основанием:--");
                            Console.Write(stringBuilder);
                        }
                        //Если это не конец символов слов, то переходим к сравнению следующих символов
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
            //Если было добавлено основание 
            if (added)
            {
                //Разбиваем слова на префикс, основание, окончание
                ParseWord(stringBuilder, baseWord);
            }
            return stringBuilder;
        }

        //Метод разбиение слова на префикс, основание, окончание
        static void ParseWord(StringBuilder stringBuilder, StringBuilder baseWord)
        {
            Console.WriteLine($"\nПрефикс\t\tОснование\tОкончание");

            string str = stringBuilder.ToString();
            //Префикс1 - подстрока между 0-индексом и основанием
            string prefix1 = str.Substring(0, str.IndexOf(baseWord.ToString()));
            //Окончание1 - подстрока между префиксом+основанием и пробелом
            string end1 = str.Substring(prefix1.Length + baseWord.Length, str.IndexOf(" ") - prefix1.Length - baseWord.Length);

            Check(prefix1);
            Console.Write($"{baseWord}\t\t");
            Check(end1);

            Console.WriteLine();
            //Префикс2 - подстрока между индексом пробела +1 и последним вхождением основания
            string prefix2 = str.Substring(str.IndexOf(" ") + 1, str.LastIndexOf(baseWord.ToString()) - (str.IndexOf(" ") + 1));
            //Окончание2 - подстрока между последним вхождением основания и концом строки
            string end2 = str.Substring(str.LastIndexOf(baseWord.ToString()) + baseWord.Length);
            Check(prefix2);
            Console.Write($"{baseWord}\t\t");
            Check(end2);
        }

        //Метод проверки на пустоту строки и выведение частей слова
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
