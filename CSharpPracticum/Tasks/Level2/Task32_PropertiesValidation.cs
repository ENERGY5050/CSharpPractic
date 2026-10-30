using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(32, 2)]
public sealed class Task32_PropertiesValidation : ITask
{
    public string Title => "Свойства с валидацией (Temperature)";
    public string Description => "Класс Temperature с валидацией в set.";
    public string[] Requirements => new[] { "Свойство Celsius с проверкой в set", "ArgumentOutOfRangeException", "Вычисляемое свойство Fahrenheit (только get)", "Продемонстрировать" };

    public void Run()
    {
        var temp = new Temperature();

        Console.WriteLine("Установка корректной температуры: 25 °C");
        temp.Celsius = 25;
        Console.WriteLine($"Celsius: {temp.Celsius} °C");
        Console.WriteLine($"Fahrenheit: {temp.Fahrenheit} °F");

        Console.WriteLine("\nПопытка установить -300 °C:");
        try
        {
            temp.Celsius = -300;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}

public class Temperature
{
    private double _celsius;

    public double Celsius
    {
        get => _celsius;
        set
        {
            if (value < -273.15)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Температура не может быть ниже абсолютного нуля (-273.15 °C).");
            }
            _celsius = value;
        }
    }

    public double Fahrenheit
    {
        get => Celsius * 9 / 5 + 32;
    }
}