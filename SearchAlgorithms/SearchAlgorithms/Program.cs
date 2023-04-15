int exit = 0;

while (exit != 1)
{
    Console.WriteLine("Выберите алгоритм для запуска: \n1. Дихотомический поиск \n2. Интерполирующий поиск \n3. Линейный поиск");
    int n;
    n = Convert.ToInt32(Console.ReadLine());
    switch (n)
    {
        case 1: 
            DichotomousSearch.Run();
            break;
        case 2:
            InterpolatingSearch.Run();
            break;
        case 3:
            LinearSearch.Run();
            break;
        default: Console.WriteLine("Такого алгоритма нет!");
            break;
    }
    Console.WriteLine("Выйти? 1-Да 0-Нет");
    exit = Convert.ToInt32(Console.ReadLine());
}
Console.ReadLine();