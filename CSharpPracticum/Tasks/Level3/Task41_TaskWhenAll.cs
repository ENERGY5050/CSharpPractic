using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(41, 3)]
public sealed class Task41_TaskWhenAll : ITask
{
    public string Title => "Task.WhenAll — параллельно 10 задач";
    public string Description => "Сравнить последовательное и параллельное выполнение.";
    public string[] Requirements => new[] { "Task WorkAsync", "Последовательно в цикле", "Task.WhenAll", "Замерить Stopwatch" };

    public void Run()
    {
        Task.Run(async () =>
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 10; i++) await WorkAsync(i);
            sw.Stop();
            Console.WriteLine($"Последовательно: {sw.ElapsedMilliseconds} мс");

            sw.Restart();
            var tasks = Enumerable.Range(0, 10).Select(WorkAsync);
            await Task.WhenAll(tasks);
            sw.Stop();
            Console.WriteLine($"Параллельно:     {sw.ElapsedMilliseconds} мс");
        }).GetAwaiter().GetResult();
    }

    private async Task<int> WorkAsync(int id)
    {
        await Task.Delay(500);
        return id;
    }
}