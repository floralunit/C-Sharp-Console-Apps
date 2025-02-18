using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

class Program
{
    static void Main()
    {
        string token1 = "13e2db34034a3f91498a3ff5c3e12543";
        string token2 = "91fe007f7b6fc1f33cfaa0e7276c7e54";
        string id1 = "0003"; // ID для рабочего токена
        string id2 = "0004"; // ID для тестового токена

        Console.WriteLine("Выберите токен:");
        Console.WriteLine("1 - Продуктовый токен");
        Console.WriteLine("2 - Тестовый токен");

        string choice = Console.ReadLine();
        string selectedToken = null;
        string selectedID = null;

        if (choice == "1")
        {
            selectedToken = token1;
            selectedID = id1;
        }
        else if (choice == "2")
        {
            selectedToken = token2;
            selectedID = id2;
        }
        else
        {
            Console.WriteLine("Неверный выбор. Завершение программы.");
            return;
        }

        string currentDate = DateTime.UtcNow.ToString("yyyyMMdd");

        string tokenWithDate = selectedToken + currentDate;

        string md5Hash = ComputeMD5Hash(tokenWithDate);

        var appInfo = new
        {
            AppInfo = new
            {
                ID = selectedID,
                Token = md5Hash
            }
        };

        string jsonOutput = JsonSerializer.Serialize(appInfo, new JsonSerializerOptions { WriteIndented = true });

        Console.WriteLine(jsonOutput);
    }

    static string ComputeMD5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
