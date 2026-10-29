using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(11, 1)]
public sealed class Task11_MatrixDiagonal : ITask
{
    public string Title => "Диагональ матрицы N×N";

    public string Description =>
        "Найти сумму элементов главной диагонали матрицы N×N.";

    public string[] Requirements => new[]
    {
        "Размер N вводится пользователем (минимум 2)",
        "Матрица заполняется случайными числами",
        "Сумма без LINQ, в одном цикле for",
        "Вывести матрицу и сумму",
    };

    public void Run()
    {
        int n = ConsoleHelper.ReadInt("Введите размер матрицы N (минимум 2): ");
        if (n < 2)
        {
            Console.WriteLine("N должно быть не меньше 2.");
            return;
        }

        var rnd = new Random();
        var m = new int[n, n];
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                m[i, j] = rnd.Next(0, 100);

        Console.WriteLine("Матрица:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write($"{m[i, j],4}");
            Console.WriteLine();
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
            sum += m[i, i];

        Console.WriteLine();
        Console.WriteLine($"Сумма главной диагонали: {sum}");
    }
}