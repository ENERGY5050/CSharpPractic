using System.Globalization;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level1;

[TaskInfo(14, 1)]
public sealed class Task14_Age : ITask
{
    public string Title => "Возраст по дате рождения";

    public string Description =>
        "По дате рождения вычислить точный возраст в годах, месяцах и днях.";

    public string[] Requirements => new[]
    {
        "Ввод даты через DateTime.TryParse / TryParseExact",
        "Учесть, что день рождения в этом году мог ещё не наступить",
        "Вывести «X лет, Y месяцев, Z дней»",
        "Некорректная дата — сообщение об ошибке, не падать",
    };

    public void Run()
    {
        DateTime birth;
        while (true)
        {
            Console.Write("Введите дату рождения (дд.мм.гггг): ");
            var input = Console.ReadLine();

            if (DateTime.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out birth)
                || DateTime.TryParse(input, out birth))
            {
                break;
            }

            Console.WriteLine("Некорректная дата, попробуйте снова.");
        }

        var today = DateTime.Today;
        if (birth > today)
        {
            Console.WriteLine("Дата рождения находится в будущем.");
            return;
        }

        var (years, months, days) = CalculateAge(birth, today);
        Console.WriteLine($"Возраст: {years} лет, {months} месяцев, {days} дней.");
    }

    /// <summary>Вычисляет точный возраст между двумя датами.</summary>
    public static (int Years, int Months, int Days) CalculateAge(DateTime birth, DateTime today)
    {
        int years = 0;
        while (birth.AddYears(years + 1) <= today) years++;

        var afterYears = birth.AddYears(years);

        int months = 0;
        while (afterYears.AddMonths(months + 1) <= today) months++;

        var afterMonths = afterYears.AddMonths(months);
        int days = (today - afterMonths).Days;

        return (years, months, days);
    }
}