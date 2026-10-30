using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(34, 2)]
public sealed class Task34_LinqGrouping : ITask
{
    public string Title => "LINQ: группировка слов по первой букве";
    public string Description => "Сгруппировать слова по первой букве.";
    public string[] Requirements => new[] { "Список слов (10+)", "GroupBy(w => w[0])", "Сортировка групп по первой букве", "Внутри группы по алфавиту" };

    public void Run()
    {
        var words = new List<string>
        {
            "яблоко", "банан", "апельсин", "арбуз", "брусника",
            "вишня", "абрикос", "виноград", "ягода", "баклажан"
        };

        var grouped = words.GroupBy(w => char.ToUpper(w[0]))
                           .OrderBy(g => g.Key);

        foreach (var group in grouped)
        {
            var sortedWords = group.OrderBy(w => w);
            Console.WriteLine($"{group.Key}: {string.Join(", ", sortedWords)}");
        }
    }
}