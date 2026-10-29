using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(13, 1)]
public sealed class Task13_WordCount : ITask
{
    public string Title => "Счётчик вхождений слов (Dictionary)";

    public string Description =>
        "Посчитать, сколько раз каждое слово встречается в тексте.";

    public string[] Requirements => new[]
    {
        "Использовать Dictionary<string, int>",
        "Разбить текст по пробелам и знакам пунктуации",
        "Привести слова к нижнему регистру",
        "Вывести пары «слово → количество», отсортированные по убыванию",
    };

    public void Run()
    {
        const string demoText =
            "Привет мир. Мир прекрасен! Привет, как дела? Дела хорошо; хорошо, что спросил.";

        Console.WriteLine("Демонстрационный текст:");
        Console.WriteLine($"  «{demoText}»");
        Console.WriteLine();

        var counts = CountWords(demoText);

        Console.WriteLine("Частоты слов (по убыванию):");
        foreach (var kv in counts)
            Console.WriteLine($"  {kv.Key} → {kv.Value}");
    }

    /// <summary>Считает вхождения слов и возвращает список, отсортированный по убыванию частоты.</summary>
    public static List<KeyValuePair<string, int>> CountWords(string text)
    {
        char[] separators =
        {
            ' ', '\t', '\n', '\r',
            '.', ',', '!', '?', ';', ':', '-', '—',
            '"', '\'', '(', ')', '«', '»',
        };

        var words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        var dict = new Dictionary<string, int>();
        foreach (var word in words)
        {
            string key = word.ToLowerInvariant();
            dict[key] = dict.TryGetValue(key, out int c) ? c + 1 : 1;
        }

        var list = new List<KeyValuePair<string, int>>(dict);
        list.Sort((a, b) => b.Value.CompareTo(a.Value));
        return list;
    }
}