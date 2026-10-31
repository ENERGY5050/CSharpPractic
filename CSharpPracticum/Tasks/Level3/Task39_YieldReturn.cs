using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(39, 3)]
public sealed class Task39_YieldReturn : ITask
{
    public string Title => "yield return — генератор";
    public string Description => "Генератор чётных чисел с ленивым выполнением.";
    public string[] Requirements => new[] { "IEnumerable<int> GetEvenNumbers", "yield return", "Показать ленивость" };

    public void Run()
    {
        Console.WriteLine("Запускаем foreach...");
        foreach (var num in GetEvenNumbers(10))
        {
            Console.WriteLine($"Получено число: {num}");
        }
    }

    private static IEnumerable<int> GetEvenNumbers(int max)
    {
        for (int i = 0; i <= max; i += 2)
        {
            Console.WriteLine($"[Генератор] Отдаю число {i}...");
            yield return i;
        }
    }
}