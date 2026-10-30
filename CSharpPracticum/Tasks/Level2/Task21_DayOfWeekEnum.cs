using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(21, 2)]
public sealed class Task21_DayOfWeekEnum : ITask
{
    public string Title => "enum дни недели";
    public string Description => "Описать дни недели через enum.";
    public string[] Requirements => new[] { "enum DayOfWeek", "IsWeekend", "GetRussianName", "Продемонстрировать на всех днях" };

    public enum DayOfWeek { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

    public void Run()
    {
        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            Console.WriteLine($"{GetRussianName(day),-12} | Выходной: {IsWeekend(day)}");
        }
    }

    private static bool IsWeekend(DayOfWeek day)
    {
        return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
    }

    private static string GetRussianName(DayOfWeek day)
    {
        return day switch
        {
            DayOfWeek.Monday => "Понедельник",
            DayOfWeek.Tuesday => "Вторник",
            DayOfWeek.Wednesday => "Среда",
            DayOfWeek.Thursday => "Четверг",
            DayOfWeek.Friday => "Пятница",
            DayOfWeek.Saturday => "Суббота",
            DayOfWeek.Sunday => "Воскресенье",
            _ => "Неизвестно"
        };
    }
}