using System;

public class InterpolatingSearch
{
    static int InterpolationSearch(int[] array, int value)
    {
        int num = -1;
        int low = 0;
        int high = array.Length - 1;

        while (array[low] < value && array[high] > value)
        {
            int mid = low + (value - array[low]) * (high - low) / (array[high] - array[low]);
            if (array[mid] < value)
            {
                low = mid + 1;
            }
            else if (array[mid] > value)
            {
                high = mid - 1;
            }
            else
            {
                num = mid;
                break;
            }
        }

        if (array[low] == value)
        {
            num = low;
        }
        else if (array[high] == value)
        {
            num = high;
        }

        return num;
    }

    public static void Run()
    {
        // Ввод массива и искомого значения
        int[] arr = new int[10];
        Random rnd = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(0, 101);
        }
        BubbleSort(ref arr);
        Console.WriteLine("Массив: ");
        foreach (int num in arr)
        {
            Console.Write(num + " ");
        }

        Console.Write("\nВведите искомое число: ");
        int value = int.Parse(Console.ReadLine());

        // Вызов функции бинарного поиска
        int index = InterpolationSearch(arr, value);

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