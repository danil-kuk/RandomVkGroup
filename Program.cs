using Newtonsoft.Json;
using System;
using System.IO;

namespace RandomVkGroupApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = "";
            try
            {
                config = File.ReadAllText("config.json");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка! Не найден файл config.json");
            }
            var settings = JsonConvert.DeserializeObject<ConfigSettings>(config);
            var generator = new Generator(settings);
            Console.WriteLine("Spacebar - сгенереровать новую группу, Esc - закрыть приложение");
            while (!Console.KeyAvailable)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Spacebar)
                    generator.Generate();
                else if (Console.ReadKey(true).Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}
