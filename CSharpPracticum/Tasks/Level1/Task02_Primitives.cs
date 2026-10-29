using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(2, 1)]
public sealed class Task02_Primitives : ITask
{
    public string Title => "Переменные примитивных типов";

    public string Description =>
        "Объявить переменные всех примитивных типов и вывести их значения и типы.";

    public string[] Requirements => new[]
    {
        "Объявить минимум: int, long, double, float, decimal, bool, char, string",
        "Для каждой переменной вывести значение и GetType().Name",
        "decimal — с суффиксом m, float — с суффиксом f",
    };

    public void Run()
    {
        int intValue = 42;
        long longValue = 9_000_000_000L;
        double doubleValue = 3.1415;
        float floatValue = 2.5f;
        decimal decimalValue = 19.99m;
        bool boolValue = true;
        char charValue = 'A';
        string stringValue = "Привет, C#";

        Print(nameof(intValue), intValue);
        Print(nameof(longValue), longValue);
        Print(nameof(doubleValue), doubleValue);
        Print(nameof(floatValue), floatValue);
        Print(nameof(decimalValue), decimalValue);
        Print(nameof(boolValue), boolValue);
        Print(nameof(charValue), charValue);
        Print(nameof(stringValue), stringValue);
    }

    private static void Print(string name, object value)
    {
        Console.WriteLine($"{name} = {value} ({value.GetType().Name})");
    }
}