using System.Diagnostics;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(38, 3)]
public sealed class Task38_ListVsLinkedList : ITask
{
    public string Title => "List<T> vs LinkedList<T>";
    public string Description => "Сравнить вставку в середину.";
    public string[] Requirements => new[] { "100 000 элементов", "Вставить 1000 в середину", "Замерить Stopwatch" };

    public void Run()
    {
        int count = 100_000;
        int insertCount = 1000;
        var list = new List<int>(Enumerable.Range(1, count));
        var linkedList = new LinkedList<int>(Enumerable.Range(1, count));

        var sw = Stopwatch.StartNew();
        for (int i = 0; i < insertCount; i++) list.Insert(list.Count / 2, i);
        sw.Stop();
        Console.WriteLine($"List<T> вставка:       {sw.ElapsedMilliseconds} мс");

        sw.Restart();
        var middleNode = GetMiddleNode(linkedList);
        for (int i = 0; i < insertCount; i++) linkedList.AddAfter(middleNode, i);
        sw.Stop();
        Console.WriteLine($"LinkedList<T> вставка: {sw.ElapsedMilliseconds} мс");

        // LinkedList быстрее, так как не сдвигает память, а просто переставляет ссылки.
    }

    private static LinkedListNode<int> GetMiddleNode(LinkedList<int> list)
    {
        var node = list.First;
        for (int i = 0; i < list.Count / 2; i++) node = node!.Next;
        return node!;
    }
}