using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(35, 2)]
public sealed class Task35_GitAdvanced : ITask
{
    public string Title => "Git: .gitignore, PR, Conventional Commits, rebase";
    public string Description => "Пройти продвинутый git-сценарий.";
    public string[] Requirements => new[] { ".gitignore и .editorconfig", "Ветка feature/task-35", "Pull Request", "git rebase -i HEAD~3", "Сохранить вывод в git-notes.md" };

    public void Run()
    {
        Console.WriteLine("Это Git-задание. Его нужно выполнить в терминале.");
        Console.WriteLine("Проверьте, что в корне репозитория есть .gitignore и .editorconfig.");
        Console.WriteLine("В git-notes.md должен быть раздел 'Task 35' с результатами rebase.");

        var notesPath = Path.Combine(Environment.CurrentDirectory, "git-notes.md");
        Console.WriteLine($"\nФайл git-notes.md {(File.Exists(notesPath) ? "найден" : "НЕ найден")}.");
    }
}