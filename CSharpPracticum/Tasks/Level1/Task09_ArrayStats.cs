using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(9, 1)]
public sealed class Task09_ArrayStats : ITask
{
    public string Title => "Массивы: min/max/sum/avg";

    public string Description =>
        "Для массива чисел найти минимум, максимум, сумму и среднее без LINQ.";

    public string[] Requirements => new[]
    {
        "Заполнить массив случайными числами 1–100, размер 20",
        "Реализовать без LINQ (Min/Max/Sum/Average запрещены)",
        "Оформить 4 отдельных метода",
        "Пустой массив — обработать (0, не падать)",
    };

    public void Run()
    {
        var rnd = new Random();
        var arr = new int[20];
        for (int i = 0; i < arr.Length; i++)
            arr[i] = rnd.Next(1, 101);

        Console.WriteLine("Массив: " + string.Join(", ", arr));
        Console.WriteLine();

        Console.WriteLine($"Min     = {Min(arr)}");
        Console.WriteLine($"Max     = {Max(arr)}");
        Console.WriteLine($"Sum     = {Sum(arr)}");
        Console.WriteLine($"Average = {Average(arr):F2}");

        Console.WriteLine();
        Console.WriteLine("Проверка пустого массива:");
        var empty = Array.Empty<int>();
        Console.WriteLine($"  Min(empty)     = {Min(empty)}");
        Console.WriteLine($"  Max(empty)     = {Max(empty)}");
        Console.WriteLine($"  Sum(empty)     = {Sum(empty)}");
        Console.WriteLine($"  Average(empty) = {Average(empty)}");
    }

    /// <summary>Минимум; для пустого массива возвращает 0.</summary>
    public static int Min(int[] arr)
    {
        if (arr.Length == 0) return 0;
        int min = arr[0];
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] < min) min = arr[i];
        return min;
    }

    /// <summary>Максимум; для пустого массива возвращает 0.</summary>
    public static int Max(int[] arr)
    {
        if (arr.Length == 0) return 0;
        int max = arr[0];
        for (int i = 1; i < arr.Length; i++)
            if (arr[i] > max) max = arr[i];
        return max;
    }

    /// <summary>Сумма; для пустого массива возвращает 0.</summary>
    public static int Sum(int[] arr)
    {
        int sum = 0;
        foreach (var x in arr) sum += x;
        return sum;
    }

    /// <summary>Среднее; для пустого массива возвращает 0.</summary>
    public static double Average(int[] arr)
    {
        if (arr.Length == 0) return 0;
        return (double)Sum(arr) / arr.Length;
    }
}