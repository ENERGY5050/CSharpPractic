using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(4, 1)]
public sealed class Task04_EvenOdd : ITask
{
    public string Title => "Чётность числа (два способа)";

    public string Description =>
        "Определить, чётное ли введённое число, двумя способами.";

    public string[] Requirements => new[]
    {
        "Способ 1: через n % 2 == 0",
        "Способ 2: через тернарный оператор ? :",
        "Оба способа реализовать отдельными методами",
        "Вывести результат обоих способов",
    };

    public void Run()
    {
        int n = ConsoleHelper.ReadInt("Введите целое число: ");

        bool byModulo = IsEvenByModulo(n);
        bool byTernary = IsEvenByTernary(n);

        Console.WriteLine($"Способ 1 (% 2 == 0):   {n} — {(byModulo ? "чётное" : "нечётное")}");
        Console.WriteLine($"Способ 2 (тернарный): {n} — {(byTernary ? "чётное" : "нечётное")}");
        Console.WriteLine($"Способы согласованы:   {byModulo == byTernary}");
    }

    /// <summary>Способ 1: остаток от деления.</summary>
    public static bool IsEvenByModulo(int n) => n % 2 == 0;

    /// <summary>Способ 2: тернарный оператор.</summary>
    public static bool IsEvenByTernary(int n) => n % 2 == 0 ? true : false;
}