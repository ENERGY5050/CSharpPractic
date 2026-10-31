using System.Text.Json;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(44, 3)]
public sealed class Task44_TodoList : ITask
{
    public string Title => "Мини-проект «Todo List»";
    public string Description => "Список задач с сохранением в JSON.";
    public string[] Requirements => new[] { "Классы TaskItem, TaskRepository, TaskService", "CRUD", "Сохранение/загрузка JSON" };

    public void Run()
    {
        var service = new TaskService("tasks.json");
        service.AddTask("Выучить C#");
        service.AddTask("Сдать практикум");
        service.MarkAsDone(1);

        Console.WriteLine("Текущие задачи:");
        foreach (var t in service.GetAll())
            Console.WriteLine($"  [{t.Id}] {t.Title} - {(t.IsDone ? "Сделано" : "В работе")}");
    }
}

public class TaskItem { public int Id { get; set; } public string Title { get; set; } = ""; public bool IsDone { get; set; } }

public class TaskRepository
{
    private readonly string _path;
    public TaskRepository(string path) => _path = path;
    public List<TaskItem> Load() => File.Exists(_path) ? JsonSerializer.Deserialize<List<TaskItem>>(File.ReadAllText(_path)) ?? new() : new();
    public void Save(List<TaskItem> tasks) => File.WriteAllText(_path, JsonSerializer.Serialize(tasks));
}

public class TaskService
{
    private readonly TaskRepository _repo;
    private List<TaskItem> _tasks;
    public TaskService(string path) { _repo = new TaskRepository(path); _tasks = _repo.Load(); }
    public void AddTask(string title) { _tasks.Add(new TaskItem { Id = _tasks.Count + 1, Title = title }); _repo.Save(_tasks); }
    public void MarkAsDone(int id) { var t = _tasks.FirstOrDefault(x => x.Id == id); if (t != null) { t.IsDone = true; _repo.Save(_tasks); } }
    public List<TaskItem> GetAll() => _tasks;
}