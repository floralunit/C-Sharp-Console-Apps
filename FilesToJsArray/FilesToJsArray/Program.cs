using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FilesToJsArray
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = args[0]; // получаем путь к папке из аргументов командной строки

            Console.WriteLine("Enter files type: \n1 - images \n2 - songs");
            string num = Console.ReadLine();

            Console.WriteLine("Enter the folder path: ");
            string path = Console.ReadLine();
            string json = "";

            if (num == "1") {
                string[] extensions = { ".png", ".jpg", ".jpeg", ".gif", ".svg" , ".webp" }; // список расширений файлов, которые нужно добавить в массив

                List<string> files = new List<string>();
                foreach (string extension in extensions)
                {
                    files.AddRange(Directory.GetFiles(path, "*" + extension));
                }

                List<object> photos = new List<object>();
                foreach (string file in files)
                {
                    photos.Add(new { src = string.Format("require(" + "'./" + Path.GetFileName(file) + "'" + ")") });
                }
                var serializer = new JsonSerializer();
                var stringWriter = new StringWriter();
                using (var writer = new JsonTextWriter(stringWriter))
                {
                    writer.QuoteName = false;
                    serializer.Serialize(writer, photos);
                }
                json = stringWriter.ToString();
            }
            else if (num == "2") {
                string[] extensions = { ".mp3"}; // список расширений файлов, которые нужно добавить в массив

                List<string> files = new List<string>();
                foreach (string extension in extensions)
                {
                    files.AddRange(Directory.GetFiles(path, "*" + extension));
                }

                List<object> songs = new List<object>();
                int i = 0;
                foreach (string file in files)
                {
                    i++;
                    string[] subs = Path.GetFileName(file).Split(" - ");
                    songs.Add(new { id = i, genre = "'" + subs[0] + "'", artist = "'" + subs[1] + "'", name = "'" + subs[2].Replace(".mp3", "") + "'", url = string.Format("require(" + "'./" + Path.GetFileName(file) + "'" + ")")});
                }
                var serializer = new JsonSerializer();
                var stringWriter = new StringWriter();
                using (var writer = new JsonTextWriter(stringWriter))
                {
                    writer.QuoteName = false;
                    serializer.Serialize(writer, songs);
                }
                json = stringWriter.ToString();
            }
            

            string output = $"export const {Path.GetFileName(path).Replace("-", "_")} = " + json + ";"; // сериализуем массив в формат JSON и записываем его в строку

            string outputPath = Path.Combine(path, Path.GetFileName(path) + ".js"); // создаем путь для выходного файла
            File.WriteAllText(outputPath, output.Replace("\"", "")); // записываем данные в выходной файл
        }
    }
}