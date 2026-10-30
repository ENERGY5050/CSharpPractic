using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(16, 2)]
public sealed class Task16_StringExtensions : ITask
{
    public string Title => "Методы расширения для string";
    public string Description => "Написать extension-методы для string.";
    public string[] Requirements => new[] { "Статический класс StringExtensions", "Методы: IsPalindrome, WordCount, ReverseString", "Вызов как \"abc\".ReverseString()" };

    public void Run()
    {
        string test = "А роза упала на лапу Азора";
        Console.WriteLine($"Строка: \"{test}\"");
        Console.WriteLine($"Реверс: \"{test.ReverseString()}\"");
        Console.WriteLine($"Слов: {test.WordCount()}");
        Console.WriteLine($"Палиндром? {test.IsPalindrome()}");

        string test2 = "Hello world";
        Console.WriteLine($"\nСтрока: \"{test2}\"");
        Console.WriteLine($"Реверс: \"{test2.ReverseString()}\"");
        Console.WriteLine($"Слов: {test2.WordCount()}");
        Console.WriteLine($"Палиндром? {test2.IsPalindrome()}");
    }
}

public static class StringExtensions
{
    public static string ReverseString(this string str)
    {
        if (string.IsNullOrEmpty(str)) return str;
        char[] charArray = str.ToCharArray();
        int left = 0, right = charArray.Length - 1;
        while (left < right)
        {
            (charArray[left], charArray[right]) = (charArray[right], charArray[left]);
            left++;
            right--;
        }
        return new string(charArray);
    }

    public static int WordCount(this string str)
    {
        if (string.IsNullOrWhiteSpace(str)) return 0;
        return str.Split(new[] { ' ', '.', ',', '!', '?', ';', ':', '-', '—' }, StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public static bool IsPalindrome(this string str)
    {
        if (string.IsNullOrEmpty(str)) return true;
        int left = 0, right = str.Length - 1;
        while (left < right)
        {
            while (left < right && !char.IsLetterOrDigit(str[left])) left++;
            while (left < right && !char.IsLetterOrDigit(str[right])) right--;
            if (char.ToLowerInvariant(str[left]) != char.ToLowerInvariant(str[right])) return false;
            left++;
            right--;
        }
        return true;
    }
}