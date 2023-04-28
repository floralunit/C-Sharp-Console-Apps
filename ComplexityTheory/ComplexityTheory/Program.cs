var startTime = DateTime.Now;
Console.WriteLine($"Начальное время {startTime}");
oneDim();
var endTime =DateTime.Now;
Console.WriteLine($"Конечное время {endTime}");
Console.WriteLine($"Разница {endTime - startTime}");
Console.ReadKey();

void matr()
{
    Random rand = new Random();
    int n = rand.Next(5000, 10001);
    int[,] mas = new int[n, n];
    Console.WriteLine($"n = {n}");

    long sum = 0;

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            mas[i, j] = rand.Next(1, 10);
            //Console.Write(mas[i, j]);
            if (i < j)
                sum += mas[i, j];
        }
        //Console.WriteLine();
    }


    Console.WriteLine($"sum = {sum}");
}

void oneDim()
{
    Random rand = new Random();
    int n = rand.Next(5000, 10001);
    int[] nums = new int[n * n];
    Console.WriteLine($"n = {n}");

    long sum = 0;
    int iterator = -1;
    for (long i = 0; i < n * n; i++)
    {
        nums[i] = rand.Next(1, 10);
        if (i % n == 0)
        {
            iterator++;
            //Console.WriteLine();
        }

        if (i % n > iterator)
            sum += nums[i];
        // Console.Write($"{nums[i]} ");
    }


    Console.WriteLine($"sum = {sum}");
}

