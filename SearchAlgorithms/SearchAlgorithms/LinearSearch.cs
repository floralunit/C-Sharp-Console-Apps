using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class LinearSearch
{
    public static void Run()
    {
        Console.Write("Введите слова через пробел: ");
        string text = Console.ReadLine();
        Console.Write("Введите искомое слово: ");
        string searchWord = Console.ReadLine();

        string[] words = text.Split(' ');

        for (int i = 0; i < words.Length; i++)
        {
            if (words[i] == searchWord)
            {
                Console.WriteLine("Слово '{0}' найдено на позиции {1}", searchWord, i + 1);
                return;
            }
        }

        Console.WriteLine("Слово '{0}' не найдено в тексте.", searchWord);
    }
}
