using Pallets.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Введите, сколько палетов сгенерировать: ");
        while(!int.TryParse(Console.ReadLine(), out var count))
        {
            Console.WriteLine("Некорректное значение.");
        }
        Console.WriteLine("Генерация палетов...");
        Console.WriteLine("");
    }
}