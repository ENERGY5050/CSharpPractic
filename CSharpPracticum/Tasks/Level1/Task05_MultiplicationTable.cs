using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(5, 1)]
public sealed class Task05_MultiplicationTable : ITask
{
    public string Title => "Таблица умножения 10×10";

    public string Description =>
        "Вывести таблицу умножения 10×10 с выравниванием столбцов.";

    public string[] Requirements => new[]
    {
        "Использовать вложенные циклы for",
        "Выровнять столбцы",
        "Заголовки строк/столбцов — приветствуются",
    };

    public void Run()
    {
        // Заголовок столбцов
        Console.Write("    ");
        for (int j = 1; j <= 10; j++)
            Console.Write($"{j,4}");
        Console.WriteLine();

        for (int i = 1; i <= 10; i++)
        {
            Console.Write($"{i,3} ");
            for (int j = 1; j <= 10; j++)
                Console.Write($"{i * j,4}");
            Console.WriteLine();
        }
    }
}