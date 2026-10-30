using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(20, 2)]
public sealed class Task20_Generics : ITask
{
    public string Title => "Обобщения: Swap<T>, Max<T>";
    public string Description => "Написать обобщенные методы.";
    public string[] Requirements => new[] { "Swap<T>(ref T a, ref T b)", "Max<T>(T a, T b) where T : IComparable<T>", "Продемонстрировать на int, string, double" };

    public void Run()
    {
        int a = 5, b = 10;
        Console.WriteLine($"До Swap: a={a}, b={b}");
        Swap(ref a, ref b);
        Console.WriteLine($"После Swap: a={a}, b={b}");
        Console.WriteLine($"Max({a}, {b}) = {Max(a, b)}");

        string s1 = "apple", s2 = "banana";
        Console.WriteLine($"\nДо Swap: s1={s1}, s2={s2}");
        Swap(ref s1, ref s2);
        Console.WriteLine($"После Swap: s1={s1}, s2={s2}");
        Console.WriteLine($"Max(\"{s1}\", \"{s2}\") = {Max(s1, s2)}");

        double d1 = 3.14, d2 = 2.71;
        Console.WriteLine($"\nДо Swap: d1={d1}, d2={d2}");
        Swap(ref d1, ref d2);
        Console.WriteLine($"После Swap: d1={d1}, d2={d2}");
        Console.WriteLine($"Max({d1}, {d2}) = {Max(d1, d2)}");
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        (x, y) = (y, x);
    }

    private static T Max<T>(T x, T y) where T : IComparable<T>
    {
        return x.CompareTo(y) > 0 ? x : y;
    }
}