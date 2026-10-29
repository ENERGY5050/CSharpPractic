namespace CSharpPracticum.Common;

/// <summary>
/// Метаданные задания: номер и уровень.
/// </summary>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
public sealed class TaskInfoAttribute : Attribute
{
    /// <summary>Номер задания в практикуме.</summary>
    public int Number { get; }

    /// <summary>Уровень (1–3).</summary>
    public int Level { get; }

    /// <summary>Инициализирует атрибут.</summary>
    public TaskInfoAttribute(int number, int level)
    {
        Number = number;
        Level = level;
    }
}