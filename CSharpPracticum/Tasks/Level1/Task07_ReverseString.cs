using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(7, 1)]
public sealed class Task07_ReverseString : ITask
{
    public string Title => "Реверс строки без LINQ";

    public string Description =>
        "Перевернуть строку без Array.Reverse и LINQ.";

    public string[] Requirements => new[]
    {
        "Не использовать Array.Reverse и LINQ",
        "Реализовать через цикл for от конца к началу",
        "Пустая строка и строка из одного символа — корректно",
    };

    public void Run()
    {
        Console.WriteLine("Автопроверка:");
        foreach (var sample in new[] { "abc", "a", "" })
            Console.WriteLine($"  «{sample}» → «{Reverse(sample)}»");
        Console.WriteLine();

        var input = ConsoleHelper.ReadString("Введите строку для реверса: ");
        Console.WriteLine($"Результат: «{Reverse(input)}»");
    }

    /// <summary>Переворачивает строку без LINQ.</summary>
    public static string Reverse(string s)
    {
        if (string.IsNullOrEmpty(s))
            return s;

        char[] chars = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
            chars[i] = s[s.Length - 1 - i];
        return new string(chars);
    }
}