using System.Collections.Generic;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(22, 2)]
public sealed class Task22_ParamsAndOverload : ITask
{
    public string Title => "params-метод + перегрузка";
    public string Description => "Написать метод суммы с params и его перегрузку.";
    public string[] Requirements => new[] { "Sum(params int[])", "Sum(List<int>)", "Продемонстрировать Sum(1,2,3), Sum(new List<int> {1,2,3}), Sum()", "Пустой вызов - вернуть 0" };

    public void Run()
    {
        Console.WriteLine($"Sum(1, 2, 3) = {Sum(1, 2, 3)}");
        Console.WriteLine($"Sum(new List<int> {{ 1, 2, 3 }}) = {Sum(new List<int> { 1, 2, 3 })}");
        Console.WriteLine($"Sum() = {Sum()}");

        var emptyArray = Array.Empty<int>();
        Console.WriteLine($"Sum(emptyArray) = {Sum(emptyArray)}");
    }

    private static int Sum(params int[] numbers)
    {
        int sum = 0;
        foreach (var num in numbers) sum += num;
        return sum;
    }

    private static int Sum(List<int> numbers)
    {
        int sum = 0;
        foreach (var num in numbers) sum += num;
        return sum;
    }
}