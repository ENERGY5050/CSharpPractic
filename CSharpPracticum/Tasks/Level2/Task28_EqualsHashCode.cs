using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(28, 2)]
public sealed class Task28_EqualsHashCode : ITask
{
    public string Title => "Equals / GetHashCode для Point";
    public string Description => "Переопределить Equals и GetHashCode для класса Point(x, y).";
    public string[] Requirements => new[] { "Переопределить Equals(object) и GetHashCode()", "Реализовать IEquatable<Point>", "Проверить HashSet<Point>" };

    public void Run()
    {
        var p1 = new Point(10, 20);
        var p2 = new Point(10, 20);
        var p3 = new Point(30, 40);

        Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)}");
        Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)}");
        Console.WriteLine($"p1 == p2: {p1 == p2}");
        Console.WriteLine($"Hash-коды: p1={p1.GetHashCode()}, p2={p2.GetHashCode()}");

        var set = new HashSet<Point> { p1, p2, p3 };
        Console.WriteLine($"\nКоличество элементов в HashSet: {set.Count} (должно быть 2)");
    }
}

public class Point : IEquatable<Point>
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public bool Equals(Point? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj) => Equals(obj as Point);

    public override int GetHashCode() => HashCode.Combine(X, Y);

    public static bool operator ==(Point? left, Point? right) => Equals(left, right);
    public static bool operator !=(Point? left, Point? right) => !Equals(left, right);
}