using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level3;

[TaskInfo(43, 3)]
public sealed class Task43_Exceptions : ITask
{
    public string Title => "Порядок catch блоков";
    public string Description => "Продемонстрировать порядок обработки исключений.";
    public string[] Requirements => new[] { "FormatException, DivideByZeroException, CustomException", "Правильный порядок catch", "finally" };

    public class CustomException : Exception { public CustomException(string msg) : base(msg) { } }

    public void Run()
    {
        TestException(1);
        TestException(2);
        TestException(3);
    }

    private void TestException(int scenario)
    {
        try
        {
            if (scenario == 1) throw new FormatException("Неверный формат!");
            if (scenario == 2) throw new DivideByZeroException("Деление на ноль!");
            if (scenario == 3) throw new CustomException("Мое кастомное исключение!");
        }
        // ВАЖНО: сначала ловим самые специфичные, потом общие (Exception)
        catch (CustomException ex) { Console.WriteLine($"Поймано Custom: {ex.Message}"); }
        catch (FormatException ex) { Console.WriteLine($"Поймано Format: {ex.Message}"); }
        catch (DivideByZeroException ex) { Console.WriteLine($"Поймано DivideByZero: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Поймано Exception: {ex.Message}"); }
        finally { Console.WriteLine("Блок finally выполнен.\n"); }
    }
}