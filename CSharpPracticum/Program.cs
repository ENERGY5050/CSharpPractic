using CSharpPracticum.Menu;

namespace CSharpPracticum;

/// <summary>
/// Точка входа приложения. Запускает главное меню.
/// </summary>
public static class Program
{
    public static void Main()
    {
        var runner = new MenuRunner();
        runner.Run();
    }
}