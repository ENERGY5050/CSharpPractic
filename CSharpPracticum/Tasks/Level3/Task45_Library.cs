using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(45, 3)]
public sealed class Task45_Library : ITask
{
    public string Title => "Мини-проект «Библиотека» + тесты";
    public string Description => "Логика библиотеки и xUnit тесты.";
    public string[] Requirements => new[] { "Классы Book, Reader, Library", "Лимит 3 книги", "Тесты проходят" };

    public void Run()
    {
        Console.WriteLine("Логика библиотеки покрыта тестами в проекте CSharpPracticum.Tests.");
        Console.WriteLine("Запустите тесты через меню Тест -> Запустить все тесты (Ctrl+R, A).");
    }
}

public class Book
{
    public string Title { get; set; } = "";
    public bool IsAvailable { get; set; } = true;
}

public class Reader
{
    public string Name { get; set; } = "";
    public List<Book> BorrowedBooks { get; } = new();
}

public class Library
{
    private readonly List<Book> _books = new();

    public void AddBook(Book book) => _books.Add(book);

    public void IssueBook(Book book, Reader reader)
    {
        if (!book.IsAvailable) throw new InvalidOperationException("Книга уже выдана.");
        if (reader.BorrowedBooks.Count >= 3) throw new InvalidOperationException("Лимит 3 книги.");

        book.IsAvailable = false;
        reader.BorrowedBooks.Add(book);
    }

    public void ReturnBook(Book book, Reader reader)
    {
        book.IsAvailable = true;
        reader.BorrowedBooks.Remove(book);
    }
}