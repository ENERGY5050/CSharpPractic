using CSharpPracticum.Common;
using CSharpPracticum.Tasks.Level1;
using CSharpPracticum.Tasks.Level2;
using CSharpPracticum.Tasks.Level3;

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
                    CreateLevel2Menu().Run();
                    break;
                case "3":
                    CreateLevel3Menu().Run();
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

    private static LevelMenu CreateLevel2Menu()
    {
        var tasks = new List<ITask>
        {
            new Task16_StringExtensions(),
            new Task17_StringBuilderBench(),
            new Task18_TryParseVsCatch(),
            new Task19_CustomStackQueue(),
            new Task20_Generics(),
            new Task21_DayOfWeekEnum(),
            new Task22_ParamsAndOverload(),
            new Task23_NullableTypes(),
            new Task24_OopAnimals(),
            new Task25_ShapesSorting(),
            new Task26_StrategyPattern(),
            new Task27_StudentComparable(),
            new Task28_EqualsHashCode(),
            new Task29_FactoryPattern(),
            new Task30_BankAccountException(),
            new Task31_DisposableFile(),
            new Task32_PropertiesValidation(),
            new Task33_LinqEmployees(),
            new Task34_LinqGrouping(),
            new Task35_GitAdvanced(),
        };
        return new LevelMenu("Уровень 2: Средний", tasks);
    }
    private static LevelMenu CreateLevel3Menu()
    {
        var tasks = new List<ITask>
        {
            new Task36_Duplicates(),
            new Task37_Fibonacci(),
            new Task38_ListVsLinkedList(),
            new Task39_YieldReturn(),
            new Task40_AsyncAwait(),
            new Task41_TaskWhenAll(),
            new Task42_CancellationToken(),
            new Task43_Exceptions(),
            new Task44_TodoList(),
            new Task45_Library(), 
        };
        return new LevelMenu("Уровень 3: Продвинутый", tasks);
    }
}