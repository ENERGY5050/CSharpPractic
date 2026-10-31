using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(40, 3)]
public sealed class Task40_AsyncAwait : ITask
{
    public string Title => "async/await + исключения";
    public string Description => "Асинхронный метод с эмуляцией скачивания.";
    public string[] Requirements => new[] { "DownloadAsync", "Task.Delay", "ArgumentException при пустом url" };

    public void Run()
    {
        Task.Run(async () =>
        {
            try
            {
                Console.WriteLine("Скачивание 1 (успешно)...");
                string data = await DownloadAsync("http://example.com");
                Console.WriteLine(data);

                Console.WriteLine("\nСкачивание 2 (ошибка)...");
                string data2 = await DownloadAsync("");
                Console.WriteLine(data2);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Поймано исключение: {ex.Message}");
            }
        }).GetAwaiter().GetResult();
    }

    private async Task<string> DownloadAsync(string url)
    {
        if (string.IsNullOrEmpty(url)) throw new ArgumentException("URL не может быть пустым!");
        await Task.Delay(1000);
        return $"Данные с {url} успешно загружены.";
    }
}