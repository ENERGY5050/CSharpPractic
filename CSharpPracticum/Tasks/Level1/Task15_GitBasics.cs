using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(15, 1)]
public sealed class Task15_GitBasics : ITask
{
    public string Title => "Git: репозиторий → ветка → merge → конфликт";

    public string Description =>
        "Базовый git-сценарий: init, коммиты, ветка, merge, разрешение конфликта.";

    public string[] Requirements => new[]
    {
        "git init — создать локальный репозиторий",
        "Сделать 2–3 коммита с осмысленными сообщениями",
        "Ветка feature/git-basics + изменение + коммит",
        "git merge feature/git-basics в main",
        "Смоделировать конфликт в README.md и разрешить вручную",
        "Сохранить вывод git log --graph --oneline --all в git-notes.md",
    };

    public void Run()
    {
        Console.WriteLine("Это Git-задание: оно выполняется в терминале Git,");
        Console.WriteLine("а не в коде приложения. Ниже — сценарий и критерии.");
        Console.WriteLine();

        var steps = new[]
        {
            "git init — создать локальный репозиторий",
            "Сделать 2–3 коммита с осмысленными сообщениями",
            "git checkout -b feature/git-basics; правка; git commit",
            "git checkout main; git merge feature/git-basics",
            "Смоделировать конфликт: изменить одну строку README.md в двух ветках, слить, разрешить вручную",
            "git log --graph --oneline --all — вывод сохранить в git-notes.md",
        };

        for (int i = 0; i < steps.Length; i++)
            Console.WriteLine($"  {i + 1}. {steps[i]}");

        Console.WriteLine();
        Console.WriteLine("Критерии готовности:");
        Console.WriteLine("  - в истории виден merge-коммит;");
        Console.WriteLine("  - в README.md нет маркеров <<<<<<<, =======, >>>>>>>;");
        Console.WriteLine("  - git-notes.md содержит раздел «Task 15 — Basic git».");

        Console.WriteLine();
        Console.WriteLine($"Текущий каталог: {Environment.CurrentDirectory}");
        var notesPath = Path.Combine(Environment.CurrentDirectory, "git-notes.md");
        Console.WriteLine(File.Exists(notesPath)
            ? "Файл git-notes.md найден в текущем каталоге."
            : "Файл git-notes.md в текущем каталоге не найден — не забудьте его заполнить.");
    }
}