using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(19, 2)]
public sealed class Task19_CustomStackQueue : ITask
{
    public string Title => "Свой стек/очередь на массиве";
    public string Description => "Реализовать MyStack<T> и MyQueue<T> на массиве.";
    public string[] Requirements => new[] { "Стек: Push, Pop, Peek, Count, IsEmpty", "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty", "Расширение массива при переполнении", "Бросать InvalidOperationException на пустой коллекции" };

    public void Run()
    {
        Console.WriteLine("--- Тест MyStack ---");
        var stack = new MyStack<int>();
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);
        Console.WriteLine($"Peek: {stack.Peek()}, Count: {stack.Count}");
        Console.WriteLine($"Pop: {stack.Pop()}, Pop: {stack.Pop()}");
        Console.WriteLine($"Count после Pop: {stack.Count}, IsEmpty: {stack.IsEmpty}");
        stack.Pop();
        try { stack.Pop(); } catch (InvalidOperationException) { Console.WriteLine("Пустой стек — исключение поймано."); }

        Console.WriteLine("\n--- Тест MyQueue ---");
        var queue = new MyQueue<string>();
        queue.Enqueue("A");
        queue.Enqueue("B");
        queue.Enqueue("C");
        Console.WriteLine($"Peek: {queue.Peek()}, Count: {queue.Count}");
        Console.WriteLine($"Dequeue: {queue.Dequeue()}, Dequeue: {queue.Dequeue()}");
        Console.WriteLine($"Count после Dequeue: {queue.Count}, IsEmpty: {queue.IsEmpty}");
        queue.Dequeue();
        try { queue.Dequeue(); } catch (InvalidOperationException) { Console.WriteLine("Пустая очередь — исключение поймано."); }
    }
}

public class MyStack<T>
{
    private T[] _items = new T[4];
    public int Count { get; private set; }
    public bool IsEmpty => Count == 0;

    public void Push(T item)
    {
        if (Count == _items.Length)
        {
            var newItems = new T[_items.Length * 2];
            Array.Copy(_items, newItems, _items.Length);
            _items = newItems;
        }
        _items[Count++] = item;
    }

    public T Pop()
    {
        if (IsEmpty) throw new InvalidOperationException("Стек пуст");
        T item = _items[--Count];
        _items[Count] = default!;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Стек пуст");
        return _items[Count - 1];
    }
}

public class MyQueue<T>
{
    private T[] _items = new T[4];
    private int _head = 0;
    private int _tail = 0;
    public int Count { get; private set; }
    public bool IsEmpty => Count == 0;

    public void Enqueue(T item)
    {
        if (Count == _items.Length)
        {
            var newItems = new T[_items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                newItems[i] = _items[(_head + i) % _items.Length];
            }
            _items = newItems;
            _head = 0;
            _tail = Count;
        }
        _items[_tail] = item;
        _tail = (_tail + 1) % _items.Length;
        Count++;
    }

    public T Dequeue()
    {
        if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
        T item = _items[_head];
        _items[_head] = default!;
        _head = (_head + 1) % _items.Length;
        Count--;
        return item;
    }

    public T Peek()
    {
        if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
        return _items[_head];
    }
}