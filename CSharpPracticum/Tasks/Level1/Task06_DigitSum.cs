using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(6, 1)]
public sealed class Task06_DigitSum : ITask
{
    public string Title => "Сумма цифр числа (строка + арифметика)";

    public string Description =>
        "Найти сумму цифр введённого числа двумя способами.";

    public string[] Requirements => new[]
    {
        "Способ 1: число → ToString() → int.Parse каждой цифры",
        "Способ 2: while (n > 0) { sum += n % 10; n /= 10; }",
        "Оба способа — отдельными методами",
        "Отрицательные числа — брать модуль",
    };

    public void Run()
    {
        long n = ConsoleHelper.ReadLong("Введите целое число: ");

        int viaString = SumDigitsViaString(n);
        int viaArithmetic = SumDigitsViaArithmetic(n);

        Console.WriteLine($"Способ 1 (строка):     сумма цифр = {viaString}");
        Console.WriteLine($"Способ 2 (арифметика): сумма цифр = {viaArithmetic}");
        Console.WriteLine($"Результаты совпадают:  {viaString == viaArithmetic}");
    }

    /// <summary>Сумма цифр через строковое представление.</summary>
    public static int SumDigitsViaString(long n)
    {
        // Math.Abs(long.MinValue) теоретически переполняет long — на практике не встречается.
        string s = Math.Abs(n).ToString();
        int sum = 0;
        foreach (char c in s)
            sum += int.Parse(c.ToString());
        return sum;
    }

    /// <summary>Сумма цифр через арифметику (деление на 10).</summary>
    public static int SumDigitsViaArithmetic(long n)
    {
        long abs = Math.Abs(n);
        int sum = 0;
        while (abs > 0)
        {
            sum += (int)(abs % 10);
            abs /= 10;
        }
        return sum;
    }
}