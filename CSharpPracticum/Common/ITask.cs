namespace CSharpPracticum.Common;

/// <summary>
/// Контракт задания практикума.
/// </summary>
public interface ITask
{
    /// <summary>Краткое название задания.</summary>
    string Title { get; }

    /// <summary>Описание того, что нужно было сделать.</summary>
    string Description { get; }

    /// <summary>Список требований к решению.</summary>
    string[] Requirements { get; }

    /// <summary>Запуск решения задания.</summary>
    void Run();
}