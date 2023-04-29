int exit = 0;

while (exit != 1)
{
    // Ввод массива и искомого значения
    int[] arr = new int[10];
    Random rnd = new Random();
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = rnd.Next(0, 101);
    }
    Console.WriteLine("Массив: ");
    foreach (int num in arr)
    {
        Console.Write(num + " ");
    }


    Console.WriteLine("\n\nВыберите алгоритм сортировки: \n1. Сортировка пузырьком \n2. Ускоренная сортировка пузырьком \n3. Алгоритм Шелла \n4. Сортировка выбором");
    int n;
    n = Convert.ToInt32(Console.ReadLine());

    var start = DateTime.Now;
    switch (n)
    {
        case 1:
            arr = BubbleSort(arr);
            break;
        case 2:
            arr = FastBubbleSort(arr);
            break;
        case 3:
            arr = ShellSort(arr);
            break;
        case 4:
            arr = ChoiseSort(arr);
            break;
        default:
            Console.WriteLine("Такого алгоритма нет!");
            break;
    }
    Console.WriteLine($"\nВремя выполнения алгоритма: {DateTime.Now - start}");
    Console.WriteLine("\nРезультат: ");
    foreach (int num in arr)
    {
        Console.Write(num + " ");
    }
    Console.WriteLine("\n\nВыйти? 1-Да 0-Нет");
    exit = Convert.ToInt32(Console.ReadLine());
}
Console.ReadLine();

//1 + 5n + n(1 + 5n + n(6 + p1 * (3 + 6 + 4)))
static int[] BubbleSort(int[] mas)
{
    int temp;
    for (int k = 1; k < mas.Length - 1; k++)
    {
        for (int i = 0; i < mas.Length - k; i++)
        {
            if (mas[i] > mas[i + 1])
            {
                temp = mas[i];
                mas[i] = mas[i + 1];
                mas[i + 1] = temp;
            }
            Console.WriteLine($"k = {k} i = {i}");
        }
    }
    return mas;
}

//(n+1) + n(1 + 1 + 5n + n(6 + p1 * (3 + 6 + 4 + 1) + 2))
static int[] FastBubbleSort(int[] mas)
{
    int temp;
    int k = 1;
    bool isMoved = true;
    while (isMoved)
    {
        isMoved = false;
        for (int i = 0; i < mas.Length - k; i++)
        {
            if (mas[i] > mas[i + 1])
            {
                temp = mas[i];
                mas[i] = mas[i + 1];
                mas[i + 1] = temp;
                isMoved = true;
            }
            Console.WriteLine($"k = {k} i = {i}");
        }
        k++;
    }
    return mas;
}

static int[] ChoiseSort(int[] mas)
{
    for (int k = 0; k < mas.Length; k++)
    {
        int j = k;
        for (int i = k + 1; i < mas.Length; i++)
        {
            if (mas[i] < mas[j])
            {
                j = i;
            }
        }
        if (k != j)
        {
            var temp = mas[j];
            mas[j] = mas[k];
            mas[k] = temp;
        }
    }
    return mas;
}

//(n+1) + n(1 + 1 + 5n + n(6 + p1 * (3 + 6 + 4 + 1) + 2))
static int[] ShellSort(int[] mas)
{
    var d = mas.Length / 2;
    while (d >= 1)
    {
        for (var i = d; i < mas.Length; i++)
        {
            var j = i;
            while ((j >= d) && (mas[j - d] > mas[j]))
            {
                var temp = mas[j];
                mas[j] = mas[j - d];
                mas[j - d] = temp;
                j = j - d;
            }
        }

        d = d / 2;
    }
    return mas;
}
