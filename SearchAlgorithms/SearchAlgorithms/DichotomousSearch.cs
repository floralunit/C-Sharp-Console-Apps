using System;

public class DichotomousSearch
{
    public static void Run()
    {
        // Ввод массива и искомого значения
        Console.Write("Введите числа через пробел: ");
        string inputStr = Console.ReadLine();
        string[] input = inputStr.Split(' ');
        int[] array = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            array[i] = int.Parse(input[i]);
        }
        BubbleSort(ref array);
        Console.WriteLine("Массив после сортировки: ");
        foreach (int num in array)
        {
            Console.Write(num + " ");
        }
        Console.Write("\nВведите искомое число: ");
        int value = int.Parse(Console.ReadLine());
        // Вызов функции бинарного поиска
        int index = BinarySearch(array, value);

        // Вывод результата поиска
        if (index == -1)
        {
            Console.WriteLine("Элемент не найден");
        }
        else
        {
            Console.WriteLine($"Искомый элемент {value} находится на позиции {index + 1}");
        }
    }
     
    // 4 + p*3 + (1-p)*((n+1)*(4) + n*(3 + 3 + 1/c * 1 + 1 + p*1 +  (1-p1-p2)*1)

    // 4 + p*3 + (1-p)*((n+1)*(4) + n*(3 + 3 + 1/c * 1) + (n - 1)(1 + p1*1 +  (1-p1-1/c)*1) + 1)
    static int BinarySearch(int[] array, int value)
    {
        int left = 0;
        int right = array.Length - 1;
        int num = -1;

        if (value == array[array.Length - 1])
        {
            num = array.Length - 1;
            return num;
        }
        else {
            while (num == -1 || left <= right - 1)
            {
                int k = (left + right) / 2;
                if (array[k] == value)
                {
                    num = k;
                    break;
                }
                else if (value > k)
                {
                    left = k;
                }
                else
                {
                    right = k;
                }
            }
            return num; // Элемент не найден
        }
    }


    static void BubbleSort(ref int[] A)
    {
        for (int i = 0; i < A.Length; i++)
        {
            for (int j = 0; j < A.Length - 1; j++)
            {
                if (A[j] > A[j + 1])
                {
                    int z = A[j];
                    A[j] = A[j + 1];
                    A[j + 1] = z;
                }
            }
        }
    }
}