using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(42, 3)]
public sealed class Task42_CancellationToken : ITask
{
    public string Title => "CancellationToken — отмена через 2 сек";
    public string Description => "Долгая операция с поддержкой отмены.";
    public string[] Requirements => new[] { "LongOperationAsync", "CancelAfter(2000)", "OperationCanceledException" };

    public void Run()
    {
        Task.Run(async () =>
        {
            using var cts = new CancellationTokenSource();
            cts.CancelAfter(2000);

            try
            {
                Console.WriteLine("Запуск операции...");
                await LongOperationAsync(cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("\n[!] Операция отменена!");
            }
        }).GetAwaiter().GetResult();
    }

    private async Task LongOperationAsync(CancellationToken token)
    {
        for (int i = 0; i < 10; i++)
        {
            token.ThrowIfCancellationRequested();
            await Task.Delay(500, token);
            Console.WriteLine($"Шаг {i + 1} выполнен");
        }
    }
}