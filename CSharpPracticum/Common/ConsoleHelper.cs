using System.Globalization;

namespace CSharpPracticum.Common;

/// <summary>
/// Вспомогательные методы для консольного ввода/вывода.
/// </summary>
public static class ConsoleHelper
{
    /// <summary>Читает целое число с повтором при некорректном вводе.</summary>
    public static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out var value))
                return value;
            Console.WriteLine("Некорректное целое число, повторите ввод.");
        }
    }

    /// <summary>Читает длинное целое число.</summary>
    public static long ReadLong(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (long.TryParse(Console.ReadLine(), out var value))
                return value;
            Console.WriteLine("Некорректное целое число, повторите ввод.");
        }
    }

    /// <summary>Читает вещественное число (поддерживает '.' и ',').</summary>
    public static double ReadDouble(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
                return value;
            if (double.TryParse(input, out value))
                return value;
            Console.WriteLine("Некорректное число, повторите ввод.");
        }
    }

    /// <summary>Читает строку (никогда не возвращает null).</summary>
    public static string ReadString(string prompt)
    {
        Console.Write(prompt);
        return Console.ReadLine() ?? string.Empty;
    }

    /// <summary>Безопасная очистка консоли (не падает при перенаправлении вывода).</summary>
    public static void SafeClear()
    {
        try
        {
            Console.Clear();
        }
        catch (IOException)
        {
            // В некоторых средах консоль нельзя очистить — игнорируем.
        }
    }
}
