using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(23, 2)]
public sealed class Task23_NullableTypes : ITask
{
    public string Title => "Nullable-типы, ??, ?.";
    public string Description => "Продемонстрировать работу с nullable.";
    public string[] Requirements => new[] { "int? FindValue(string key)", "Использовать ??", "Использовать ?.", "HasValue/Value с проверкой" };

    class UserProfile { public string? Name { get; set; } }

    public void Run()
    {
        var dict = new Dictionary<string, int> { { "age", 25 }, { "score", 100 } };

        Console.WriteLine("Ключ 'age':");
        int? val1 = FindValue("age", dict);
        Console.WriteLine($"  FindValue: {val1}");
        Console.WriteLine($"  Значение по умолчанию (??): {val1 ?? -1}");
        if (val1.HasValue) Console.WriteLine($"  HasValue: true, Value: {val1.Value}");

        Console.WriteLine("\nКлюч 'unknown':");
        int? val2 = FindValue("unknown", dict);
        Console.WriteLine($"  FindValue: {(val2.HasValue ? val2.ToString() : "null")}");
        Console.WriteLine($"  Значение по умолчанию (??): {val2 ?? -1}");

        UserProfile? profile = null;
        Console.WriteLine($"\nБезопасный доступ к null-объекту (?.): {profile?.Name ?? "Имя не задано"}");
        profile = new UserProfile { Name = "Иван" };
        Console.WriteLine($"Безопасный доступ к объекту (?.): {profile?.Name ?? "Имя не задано"}");
    }

    private int? FindValue(string key, Dictionary<string, int> dict)
    {
        return dict.TryGetValue(key, out int val) ? val : null;
    }
}