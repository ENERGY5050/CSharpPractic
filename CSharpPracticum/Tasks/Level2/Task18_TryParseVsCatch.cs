using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(18, 2)]
public sealed class Task18_TryParseVsCatch : ITask
{
    public string Title => "TryParse vs try/catch";
    public string Description => "Сравнить два способа обработки некорректного ввода числа.";
    public string[] Requirements => new[] { "Способ 1: int.TryParse", "Способ 2: int.Parse внутри try/catch", "Продемонстрировать на корректном и некорректном вводе" };

    public void Run()
    {
        string[] inputs = { "123", "abc", "  45  ", "999999999999999999" };

        foreach (var input in inputs)
        {
            Console.WriteLine($"Ввод: \"{input}\"");
            Console.WriteLine($"  TryParse:  {ParseWithTryParse(input, out int r1)} (Результат: {r1})");
            Console.WriteLine($"  TryCatch:  {ParseWithTryCatch(input, out int r2)} (Результат: {r2})");
            Console.WriteLine();
        }
    }

    private static bool ParseWithTryParse(string input, out int result)
    {
        return int.TryParse(input, out result);
    }

    private static bool ParseWithTryCatch(string input, out int result)
    {
        try
        {
            result = int.Parse(input);
            return true;
        }
        catch (FormatException)
        {
            result = 0;
            return false;
        }
        catch (OverflowException)
        {
            result = 0;
            return false;
        }
    }
}