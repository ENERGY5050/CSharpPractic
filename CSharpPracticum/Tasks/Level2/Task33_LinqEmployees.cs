using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(33, 2)]
public sealed class Task33_LinqEmployees : ITask
{
    public string Title => "LINQ: сотрудники";
    public string Description => "LINQ-запросы по списку сотрудников.";
    public string[] Requirements => new[] { "Класс Employee", "Список из 10+ сотрудников", "Топ-3 по зарплате", "Средняя по отделу", "Старше 30" };

    public void Run()
    {
        var employees = new List<Employee>
        {
            new("Иван", 28, 50000, "IT"),
            new("Мария", 35, 70000, "HR"),
            new("Алексей", 42, 90000, "IT"),
            new("Елена", 31, 60000, "Finance"),
            new("Дмитрий", 25, 45000, "IT"),
            new("Ольга", 38, 75000, "HR"),
            new("Сергей", 45, 110000, "IT"),
            new("Анна", 29, 55000, "Finance"),
            new("Павел", 33, 65000, "IT"),
            new("Наталья", 27, 48000, "HR")
        };

        Console.WriteLine("--- Топ-3 по зарплате ---");
        var top3 = employees.OrderByDescending(e => e.Salary).Take(3);
        foreach (var e in top3) Console.WriteLine($"  {e.Name}: {e.Salary}");

        Console.WriteLine("\n--- Средняя зарплата по отделам ---");
        var avgByDept = employees.GroupBy(e => e.Department)
                                 .Select(g => new { Dept = g.Key, Avg = g.Average(e => e.Salary) });
        foreach (var item in avgByDept) Console.WriteLine($"  {item.Dept}: {item.Avg:F2}");

        Console.WriteLine("\n--- Сотрудники старше 30 ---");
        var over30 = employees.Where(e => e.Age > 30);
        foreach (var e in over30) Console.WriteLine($"  {e.Name} ({e.Age} лет)");
    }
}

public record Employee(string Name, int Age, decimal Salary, string Department);