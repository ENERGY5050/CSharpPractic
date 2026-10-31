using CSharpPracticum.Tasks.Level3;
using Xunit;

namespace CSharpPracticum.Tests;

public class LibraryTests
{
    [Fact]
    public void IssueBook_ShouldMarkAsUnavailable()
    {
        var lib = new Library();
        var book = new Book { Title = "Война и мир" };
        var reader = new Reader { Name = "Иван" };
        lib.AddBook(book);

        lib.IssueBook(book, reader);

        Assert.False(book.IsAvailable);
        Assert.Contains(book, reader.BorrowedBooks);
    }

    [Fact]
    public void IssueBook_ShouldThrow_WhenAlreadyBorrowed()
    {
        var lib = new Library();
        var book = new Book { Title = "1984" };
        var reader = new Reader { Name = "Олег" };
        lib.AddBook(book);
        lib.IssueBook(book, reader);

        Assert.Throws<InvalidOperationException>(() => lib.IssueBook(book, new Reader()));
    }

    [Fact]
    public void IssueBook_ShouldThrow_WhenLimitExceeded()
    {
        var lib = new Library();
        var reader = new Reader { Name = "Анна" };
        for (int i = 0; i < 4; i++)
        {
            var b = new Book { Title = $"Книга {i}" };
            lib.AddBook(b);
            if (i < 3) lib.IssueBook(b, reader); 
            else Assert.Throws<InvalidOperationException>(() => lib.IssueBook(b, reader)); 
        }
    }

    [Fact]
    public void ReturnBook_ShouldMakeAvailableAgain()
    {
        var lib = new Library();
        var book = new Book { Title = "Гарри Поттер" };
        var reader = new Reader { Name = "Мария" };
        lib.AddBook(book);
        lib.IssueBook(book, reader);

        lib.ReturnBook(book, reader);

        Assert.True(book.IsAvailable);
        Assert.Empty(reader.BorrowedBooks);
    }
}