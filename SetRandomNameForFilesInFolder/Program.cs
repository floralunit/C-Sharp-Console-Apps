
using System;
using System.IO;
namespace SetRandomNameForFilesInFolder
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите путь к папке:");
            string folderPath = Console.ReadLine();

            if (Directory.Exists(folderPath))
            {
                Random random = new Random();
                string[] files = Directory.GetFiles(folderPath);

                foreach (string file in files)
                {
                    string extension = Path.GetExtension(file);
                    string randomName;
                    do
                    {
                        randomName = GenerateRandomName(random);
                    } while (File.Exists(Path.Combine(folderPath, randomName + extension)));

                    File.Move(file, Path.Combine(folderPath, randomName + extension));
                }

                Console.WriteLine("Имена файлов изменены.");
            }
            else
            {
                Console.WriteLine("Указанная папка не существует.");
            }
        }

        static string GenerateRandomName(Random random)
        {
            const string alphabet = "abcd";
            char[] name = new char[4];
            for (int i = 0; i < name.Length; i++)
            {
                name[i] = alphabet[random.Next(alphabet.Length)];
            }
            return new string(name);
        }
    }

}