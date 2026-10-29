using CSharpPracticum.Common;
using CSharpPracticum.Tasks.Level1;

namespace CSharpPracticum.Menu;

/// <summary>
/// Главное меню практикума: выбор уровня.
/// </summary>
public sealed class MenuRunner
{
    public void Run()
    {
        while (true)
        {
            ConsoleHelper.SafeClear();
            Console.WriteLine("=== Практикум по C# ===");
            Console.WriteLine("1. Уровень 1 — Базовый (задания 1–15)");
            Console.WriteLine("2. Уровень 2 — Средний (задания 16–35)");
            Console.WriteLine("3. Уровень 3 — Продвинутый (задания 36–50)");
            Console.WriteLine("4. Выход");
            Console.WriteLine();
            Console.Write("Выберите уровень: ");

            var input = Console.ReadLine()?.Trim();
            switch (input)
            {
                case "1":
                    CreateLevel1Menu().Run();
                    break;
                case "2":
                case "3":
                    Console.WriteLine("Этот уровень пока не реализован. Нажмите Enter...");
                    Console.ReadLine();
                    break;
                case "0":
                case "4":
                case "q":
                case "Q":
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Нажмите Enter...");
                    Console.ReadLine();
                    break;
            }
        }
    }

    private static LevelMenu CreateLevel1Menu()
    {
        var tasks = new List<ITask>
        {
            new Task01_HelloWorld(),
            new Task02_Primitives(),
            new Task03_Calculator(),
            new Task04_EvenOdd(),
            new Task05_MultiplicationTable(),
            new Task06_DigitSum(),
            new Task07_ReverseString(),
            new Task08_FizzBuzz(),
            new Task09_ArrayStats(),
            new Task10_Sorting(),
            new Task11_MatrixDiagonal(),
            new Task12_Palindrome(),
            new Task13_WordCount(),
            new Task14_Age(),
            new Task15_GitBasics(),
        };
        return new LevelMenu("Уровень 1: Базовый", tasks);
    }
}