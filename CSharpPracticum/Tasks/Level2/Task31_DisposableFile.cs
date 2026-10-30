using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(31, 2)]
public sealed class Task31_DisposableFile : ITask
{
    public string Title => "IDisposable + using";
    public string Description => "Реализовать IDisposable для класса, работающего с файлом.";
    public string[] Requirements => new[] { "Класс FileWriter с StreamWriter", "Реализовать Dispose()", "Использовать через using", "Показать using var (C# 8+)" };

    public void Run()
    {
        string filePath = Path.Combine(Environment.CurrentDirectory, "task31_test.txt");

        // Способ 1: Традиционный блок using
        using (var writer1 = new MyFileWriter(filePath))
        {
            writer1.WriteLine("Строка 1 через блок using.");
        }
        Console.WriteLine("Блок using завершен, файл закрыт.");

        // Способ 2: using-декларация (C# 8+)
        using var writer2 = new MyFileWriter(filePath);
        writer2.WriteLine("Строка 2 через using var.");

        Console.WriteLine("Мы все еще в методе Run(). Файл закроется в конце метода.");

        // Читаем содержимое для проверки
        Console.WriteLine($"\nСодержимое файла {filePath}:");
        Console.WriteLine(File.ReadAllText(filePath));
    }
}

public class MyFileWriter : IDisposable
{
    private readonly StreamWriter _writer;

    public MyFileWriter(string path)
    {
        _writer = new StreamWriter(path, append: false);
    }

    public void WriteLine(string text)
    {
        _writer.WriteLine(text);
    }

    public void Dispose()
    {
        _writer?.Dispose();
    }
}