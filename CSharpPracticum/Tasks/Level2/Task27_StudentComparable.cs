using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(27, 2)]
public sealed class Task27_StudentComparable : ITask
{
    public string Title => "IComparable / IComparer<T> для Student";
    public string Description => "Научить Student сортироваться.";
    public string[] Requirements => new[] { "Student: Name, AverageGrade", "IComparable<Student> - по убыванию балла", "IComparer<Student> ByNameComparer", "Продемонстрировать обе сортировки" };

    public void Run()
    {
        var students = new List<Student>
        {
            new("Алексей", 4.5),
            new("Мария", 5.0),
            new("Дмитрий", 3.8),
            new("Елена", 4.5)
        };

        Console.WriteLine("Сортировка по среднему баллу (по убыванию):");
        students.Sort();
        foreach (var s in students) Console.WriteLine($"  {s.Name}: {s.AverageGrade}");

        Console.WriteLine("\nСортировка по имени (A-Z):");
        students.Sort(new ByNameComparer());
        foreach (var s in students) Console.WriteLine($"  {s.Name}: {s.AverageGrade}");
    }
}

public class Student : IComparable<Student>
{
    public string Name { get; }
    public double AverageGrade { get; }

    public Student(string name, double averageGrade)
    {
        Name = name;
        AverageGrade = averageGrade;
    }

    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        // По убыванию балла (5.0 идет первым)
        return other.AverageGrade.CompareTo(this.AverageGrade);
    }
}

public class ByNameComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null && y == null) return 0;
        if (x == null) return -1;
        if (y == null) return 1;
        return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
    }
}