using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(10, 1)]
public sealed class Task10_Sorting : ITask
{
    public string Title => "Сортировка пузырьком + вставками";

    public string Description =>
        "Отсортировать массив двумя алгоритмами и замерить время на 10 000 элементов.";

    public string[] Requirements => new[]
    {
        "Реализовать BubbleSort и InsertionSort отдельными методами",
        "Оба — без LINQ и Array.Sort",
        "Замерить время через Stopwatch на массиве 10 000 элементов",
        "Вывести оба времени",
    };

    public void Run()
    {
        const int size = 10_000;
        var rnd = new Random(42); // фиксированный seed для воспроизводимости
        var source = new int[size];
        for (int i = 0; i < size; i++)
            source[i] = rnd.Next(1, 100_000);

        var bubble = (int[])source.Clone();
        var insertion = (int[])source.Clone();

        var sw = Stopwatch.StartNew();
        BubbleSort(bubble);
        sw.Stop();
        var bubbleMs = sw.ElapsedMilliseconds;

        sw.Restart();
        InsertionSort(insertion);
        sw.Stop();
        var insertionMs = sw.ElapsedMilliseconds;

        Console.WriteLine($"Размер массива: {size}");
        Console.WriteLine($"BubbleSort:    {bubbleMs} мс");
        Console.WriteLine($"InsertionSort: {insertionMs} мс");
        Console.WriteLine($"Массивы отсортированы одинаково: {AreEqual(bubble, insertion)}");
    }

    /// <summary>Сортировка пузырьком с ранним выходом.</summary>
    public static void BubbleSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < arr.Length - 1 - i; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    swapped = true;
                }
            }
            if (!swapped) break;
        }
    }

    /// <summary>Сортировка вставками.</summary>
    public static void InsertionSort(int[] arr)
    {
        for (int i = 1; i < arr.Length; i++)
        {
            int key = arr[i];
            int j = i - 1;
            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j--;
            }
            arr[j + 1] = key;
        }
    }

    private static bool AreEqual(int[] a, int[] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i]) return false;
        return true;
    }
}