using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(37, 3)]
public sealed class Task37_Fibonacci : ITask
{
    public string Title => "Мемоизация Фибоначчи";
    public string Description => "Реализовать мемоизированную функцию Фибоначчи.";
    public string[] Requirements => new[] { "Обычная рекурсия", "Мемоизация с Dictionary", "Замерить время на N=30-35" };

    public void Run()
    {
        int n = 35;
        Console.WriteLine($"Вычисление Fibonacci({n})...");

        var sw = Stopwatch.StartNew();
        long normal = FibNormal(n);
        sw.Stop();
        Console.WriteLine($"Обычная рекурсия: {sw.ElapsedMilliseconds} мс, результат: {normal}");

        sw.Restart();
        var memo = new Dictionary<int, long>();
        long memoized = FibMemo(n, memo);
        sw.Stop();
        Console.WriteLine($"С мемоизацией:    {sw.ElapsedMilliseconds} мс, результат: {memoized}");
    }

    private static long FibNormal(int n)
    {
        if (n <= 1) return n;
        return FibNormal(n - 1) + FibNormal(n - 2);
    }

    private static long FibMemo(int n, Dictionary<int, long> memo)
    {
        if (n <= 1) return n;
        if (memo.TryGetValue(n, out long val)) return val;

        long result = FibMemo(n - 1, memo) + FibMemo(n - 2, memo);
        memo[n] = result;
        return result;
    }
}