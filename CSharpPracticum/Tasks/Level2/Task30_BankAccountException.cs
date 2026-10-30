using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(30, 2)]
public sealed class Task30_BankAccountException : ITask
{
    public string Title => "BankAccount + свой Exception";
    public string Description => "Реализовать банковский счёт с собственным исключением.";
    public string[] Requirements => new[] { "BankAccount с приватным балансом", "Deposit, Withdraw", "InsufficientFundsException", "Снять больше баланса с try/catch" };

    public void Run()
    {
        var account = new BankAccount(1000);

        account.Deposit(500);
        Console.WriteLine($"Текущий баланс: {account.Balance}");

        account.Withdraw(200);
        Console.WriteLine($"После снятия 200: {account.Balance}");

        try
        {
            account.Withdraw(5000);
        }
        catch (InsufficientFundsException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            Console.WriteLine($"Не хватает: {ex.Shortfall}");
        }

        Console.WriteLine($"Итоговый баланс: {account.Balance}");
    }
}

public class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount(decimal initialBalance)
    {
        Balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Сумма должна быть положительной");
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0) throw new ArgumentException("Сумма должна быть положительной");

        if (amount > Balance)
        {
            throw new InsufficientFundsException("Недостаточно средств на счете.", amount - Balance);
        }

        Balance -= amount;
    }
}

public class InsufficientFundsException : Exception
{
    public decimal Shortfall { get; }

    public InsufficientFundsException(string message, decimal shortfall) : base(message)
    {
        Shortfall = shortfall;
    }
}