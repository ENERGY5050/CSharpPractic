using System.Reflection;
using CSharpPracticum.Common;

namespace CSharpPracticum.Menu;

/// <summary>
/// Меню уровня: список заданий и запуск выбранного.
/// </summary>
public sealed class LevelMenu
{
    private readonly string _title;
    private readonly IReadOnlyList<ITask> _tasks;

    public LevelMenu(string title, IReadOnlyList<ITask> tasks)
    {
        _title = title;
        _tasks = tasks;
    }

    public void Run()
    {
        while (true)
        {
            ConsoleHelper.SafeClear();
            Console.WriteLine($"--- {_title} ---");
            for (int i = 0; i < _tasks.Count; i++)
                Console.WriteLine($"{i + 1}. {_tasks[i].Title}");
            Console.WriteLine($"{_tasks.Count + 1}. Назад");
            Console.WriteLine();
            Console.Write("Выберите задание: ");

            var input = Console.ReadLine()?.Trim();
            if (input is "0" or "q" or "Q") return;

            if (!int.TryParse(input, out int choice))
            {
                Console.WriteLine("Некорректный ввод. Нажмите Enter...");
                Console.ReadLine();
                continue;
            }

            if (choice == _tasks.Count + 1) return;
            if (choice < 1 || choice > _tasks.Count)
            {
                Console.WriteLine("Нет такого задания. Нажмите Enter...");
                Console.ReadLine();
                continue;
            }

            RunTask(_tasks[choice - 1]);
        }
    }

    private static void RunTask(ITask task)
    {
        ConsoleHelper.SafeClear();

        var info = task.GetType().GetCustomAttribute<TaskInfoAttribute>();
        var heading = info is null
            ? task.Title
            : $"Задание {info.Number}. {task.Title}";

        Console.WriteLine(new string('=', 50));
        Console.WriteLine(heading);
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("Описание:");
        Console.WriteLine($"  {task.Description}");
        Console.WriteLine();
        Console.WriteLine("Требования:");
        foreach (var req in task.Requirements)
            Console.WriteLine($"  - {req}");
        Console.WriteLine(new string('-', 50));
        Console.WriteLine("[запуск решения...]");
        Console.WriteLine();

        try
        {
            task.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.WriteLine($"Ошибка при выполнении задания: {ex.Message}");
        }

        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для возврата в меню...");
        Console.ReadLine();
    }
}