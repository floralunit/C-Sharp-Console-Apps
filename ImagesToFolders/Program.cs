using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Проверяем, что путь к папке передан в качестве аргумента

        //if (args.Length == 0)
        //{
        //    Console.WriteLine("Пожалуйста, укажите путь к папке с изображениями.");
        //    return;
        //}

        string sourceFolder = "C:\\Users\\floralunit\\Downloads\\dataset\\images\\Train";

        // Проверяем, существует ли указанная папка
        if (!Directory.Exists(sourceFolder))
        {
            Console.WriteLine("Указанная папка не существует.");
            return;
        }

        // Получаем все файлы в указанной папке
        string[] files = Directory.GetFiles(sourceFolder);

        foreach (string file in files)
        {
            // Извлекаем имя файла без расширения
            string fileName = Path.GetFileNameWithoutExtension(file);
            // Извлекаем имя предмета (без номера)
            string itemName = fileName.Substring(0, fileName.LastIndexOf('(')).Trim();

            // Создаем папку для предмета, если она не существует
            string itemFolder = Path.Combine(sourceFolder, itemName);
            if (!Directory.Exists(itemFolder))
            {
                Directory.CreateDirectory(itemFolder);
            }

            // Перемещаем файл в соответствующую папку
            string destinationFile = Path.Combine(itemFolder, Path.GetFileName(file));
            File.Move(file, destinationFile);
        }

        Console.WriteLine("Перемещение файлов завершено.");
    }
}
