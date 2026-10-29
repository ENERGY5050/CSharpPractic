using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(12, 1)]
public sealed class Task12_Palindrome : ITask
{
    public string Title => "Палиндром (без регистра/пробелов)";

    public string Description =>
        "Проверить, является ли строка палиндромом, игнорируя регистр и пунктуацию.";

    public string[] Requirements => new[]
    {
        "Игнорировать регистр",
        "Игнорировать пробелы и знаки пунктуации",
        "Не использовать LINQ Reverse",
        "Пустая строка и строка из одного символа — палиндром",
    };

    public void Run()
    {
        Console.WriteLine("Автопроверка:");
        foreach (var sample in new[]
                 {
                     "А роза упала на лапу Азора",
                     "hello",
                     "Madam, I'm Adam",
                     "",
                     "a",
                 })
        {
            Console.WriteLine($"  «{sample}» → {IsPalindrome(sample)}");
        }
        Console.WriteLine();

        var input = ConsoleHelper.ReadString("Введите строку для проверки: ");
        Console.WriteLine($"Результат: {IsPalindrome(input)}");
    }

    /// <summary>Проверяет, является ли строка палиндромом (без учёта регистра и не-букв).</summary>
    public static bool IsPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s)) return true;

        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(s[left])) left++;
            while (left < right && !char.IsLetterOrDigit(s[right])) right--;

            if (char.ToLowerInvariant(s[left]) != char.ToLowerInvariant(s[right]))
                return false;

            left++;
            right--;
        }

        return true;
    }
}