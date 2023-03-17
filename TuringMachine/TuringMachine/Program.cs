using TuringMachine;

int exit = 0;
Console.WriteLine("Машина Тьюринга\n");
while (exit != 1)
{
    Console.WriteLine("Задание 1. Преобразование ( x1, x2) → (x1, x2, x1).");
    Console.WriteLine("Задание 2. Модуль разности двух любых цифр.");
    Console.WriteLine("Задание 3. Вычисление предиката с четными, нечетными числами.");
    Console.Write("Выберете задание => ");
    int? task = Convert.ToInt32(Console.ReadLine());

    if (!(task >= 1 && task <= 3))
    { 
        Console.WriteLine("Такого задания не существует!\n");
        exit = 0;
    }

    switch (task)
    {
        case 1: {
                var sut = new TuringMachine.Machine(0, new TuringMachine.Head(new[] { '0', '0', '0', '1', '1', '0', '1', '1', '1', '0', '0', '0', '0', '0', '0' }, 2), TransitionTableGenerator.MovingArrays_Task1());
                sut.Run();
            } break;
        case 2:{
                var sut = new TuringMachine.Machine(0, new TuringMachine.Head(new[] { Head.Blank, '2', '-', '4', Head.Blank }, 4), TransitionTableGenerator.ModuleRaznost_Task2());
                sut.Run();
            } break;
        case 3: {
                var sut = new TuringMachine.Machine(0, new TuringMachine.Head(new[] { 'y', '1', '1', '1', 'y' }, 1), TransitionTableGenerator.Predicat_Task3());
                sut.Run();
            } break;
        default: break;
    }
    Console.Write("\nВыйти? (1-Да 0-Нет) => ");
    exit = Convert.ToInt32(Console.ReadLine());
}
