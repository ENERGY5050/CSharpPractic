using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(36, 3)]
public sealed class Task36_Duplicates : ITask
{
    public string Title => "Дубликаты в List (HashSet + GroupBy)";
    public string Description => "Найти дубликаты в списке чисел двумя способами.";
    public string[] Requirements => new[] { "Способ 1: HashSet", "Способ 2: LINQ GroupBy", "Оба метода отдельно" };

    public void Run()
    {
        var numbers = new List<int> { 1, 2, 3, 2, 4, 5, 5, 6, 1, 7 };
        Console.WriteLine("Список: " + string.Join(", ", numbers));
        Console.WriteLine("Дубликаты (HashSet): " + string.Join(", ", FindDuplicatesHashSet(numbers)));
        Console.WriteLine("Дубликаты (LINQ):    " + string.Join(", ", FindDuplicatesLinq(numbers)));
    }

    private static IEnumerable<int> FindDuplicatesHashSet(IEnumerable<int> list)
    {
        var seen = new HashSet<int>();
        var duplicates = new HashSet<int>();
        foreach (var item in list)
        {
            if (!seen.Add(item)) duplicates.Add(item);
        }
        return duplicates;
    }

    private static IEnumerable<int> FindDuplicatesLinq(IEnumerable<int> list)
    {
        return list.GroupBy(x => x).Where(g => g.Count() > 1).Select(g => g.Key);
    }
}