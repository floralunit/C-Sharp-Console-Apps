using System;
using System.IO;

public class VideoConverter
{
    public static void ConvertMp4ToMov(string folderPath)
    {
        try
        {
            string[] videoFiles = Directory.GetFiles(folderPath, "*.mp4");

            foreach (var videoFile in videoFiles)
            {
                string newFileName = Path.ChangeExtension(videoFile, ".mov");

                File.Move(videoFile, newFileName);
            }

            Console.WriteLine("Все видео файлы успешно сконвертированы в формат .mov.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при конвертации видео файлов: " + ex.Message);
        }
    }
    public static void ConvertAviToMp4(string folderPath)
    {
        try
        {
            string[] videoFiles = Directory.GetFiles(folderPath, "*.avi");

            foreach (var videoFile in videoFiles)
            {
                string newFileName = Path.ChangeExtension(videoFile, ".mp4");

                File.Move(videoFile, newFileName);
            }

            Console.WriteLine("Все видео файлы успешно сконвертированы в формат .mp4.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при конвертации видео файлов: " + ex.Message);
        }
    }

    public static void ConvertMovToMp4(string folderPath)
    {
        try
        {
            string[] videoFiles = Directory.GetFiles(folderPath, "*.mov");

            foreach (var videoFile in videoFiles)
            {
                string newFileName = Path.ChangeExtension(videoFile, ".mp4");

                File.Move(videoFile, newFileName);
            }

            Console.WriteLine("Все видео файлы успешно сконвертированы в формат .mp4.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка при конвертации видео файлов: " + ex.Message);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите тип конвертации: \n1 - avi на mp4 \n2 - mp4 на mov \n3 - mov на mp4");
        string pipa = Console.ReadLine();
        Console.WriteLine("Введите путь к папке, содержащей видео файлы:");
        string folderPath = Console.ReadLine();
        if (pipa == "1") VideoConverter.ConvertAviToMp4(folderPath);
        if (pipa == "2") VideoConverter.ConvertMp4ToMov(folderPath);
        if (pipa == "3") VideoConverter.ConvertMovToMp4(folderPath);

    }
}
