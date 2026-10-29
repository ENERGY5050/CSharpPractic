using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(3, 1)]
public sealed class Task03_Calculator : ITask
{
    public string Title => "Калькулятор с делением на ноль";

    public string Description =>
        "Принимает два числа и оператор (+, -, *, /), выводит результат. Обработать деление на ноль.";

    public string[] Requirements => new[]
    {
        "Оператор обрабатывать через switch",
        "При делении на ноль — сообщение об ошибке, не падать",
        "Некорректный оператор — «Неизвестная операция»",
        "Ввод чисел — через double.TryParse",
    };

    public void Run()
    {
        double a = ConsoleHelper.ReadDouble("Введите первое число: ");
        double b = ConsoleHelper.ReadDouble("Введите второе число: ");

        Console.Write("Введите оператор (+, -, *, /): ");
        var opInput = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(opInput))
        {
            Console.WriteLine("Оператор не введён.");
            return;
        }

        switch (opInput[0])
        {
            case '+':
                Console.WriteLine($"{a} + {b} = {a + b}");
                break;
            case '-':
                Console.WriteLine($"{a} - {b} = {a - b}");
                break;
            case '*':
                Console.WriteLine($"{a} * {b} = {a * b}");
                break;
            case '/':
                if (b == 0)
                    Console.WriteLine("Ошибка: деление на ноль.");
                else
                    Console.WriteLine($"{a} / {b} = {a / b}");
                break;
            default:
                Console.WriteLine("Неизвестная операция.");
                break;
        }
    }
}