using System;
using System.IO;

public class VideoFileConverter
{
    public static void ConvertAviToMp4(string folderPath)
    {
        try
        {
            string[] videoFiles = Directory.GetFiles(folderPath, "*.mp4");

            foreach (var videoFile in videoFiles)
            {
                string newFileName = Path.ChangeExtension(videoFile, ".avi");

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
        Console.WriteLine("Введите путь к папке, содержащей видео файлы:");
        string folderPath = Console.ReadLine();

        VideoFileConverter.ConvertAviToMp4(folderPath);
    }
}