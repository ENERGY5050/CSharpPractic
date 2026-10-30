using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(25, 2)]
public sealed class Task25_ShapesSorting : ITask
{
    public string Title => "Интерфейс IShape + сортировка фигур";
    public string Description => "Реализовать интерфейс фигур и отсортировать их.";
    public string[] Requirements => new[] { "IShape с Area и Perimeter", "Circle, Rectangle, Triangle", "List<IShape> из 5+ фигур", "Сортировка по площади" };

    public void Run()
    {
        var shapes = new List<IShape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Triangle(3, 4, 5),
            new Circle(2.5),
            new Rectangle(10, 2)
        };

        Console.WriteLine("До сортировки:");
        PrintShapes(shapes);

        shapes.Sort((a, b) => a.Area().CompareTo(b.Area()));
        Console.WriteLine("\nПосле сортировки (по возрастанию площади):");
        PrintShapes(shapes);
    }

    private static void PrintShapes(List<IShape> shapes)
    {
        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name,-10} | Площадь: {shape.Area(),6:F2} | Периметр: {shape.Perimeter(),6:F2}");
        }
    }
}

public interface IShape
{
    double Area();
    double Perimeter();
}

public class Circle : IShape
{
    public double Radius { get; }
    public Circle(double radius) => Radius = radius;
    public double Area() => Math.PI * Radius * Radius;
    public double Perimeter() => 2 * Math.PI * Radius;
}

public class Rectangle : IShape
{
    public double Width { get; }
    public double Height { get; }
    public Rectangle(double width, double height) { Width = width; Height = height; }
    public double Area() => Width * Height;
    public double Perimeter() => 2 * (Width + Height);
}

public class Triangle : IShape
{
    public double A { get; }
    public double B { get; }
    public double C { get; }
    public Triangle(double a, double b, double c) { A = a; B = b; C = c; }

    public double Area()
    {
        double p = Perimeter() / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public double Perimeter() => A + B + C;
}