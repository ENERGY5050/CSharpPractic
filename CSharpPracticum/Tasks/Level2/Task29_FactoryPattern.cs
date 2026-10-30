using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(29, 2)]
public sealed class Task29_FactoryPattern : ITask
{
    public string Title => "Паттерн «Фабрика» (уведомления)";
    public string Description => "Реализовать фабрику уведомлений.";
    public string[] Requirements => new[] { "INotification", "EmailNotification, SmsNotification, PushNotification", "NotificationFactory", "enum NotificationType" };

    public void Run()
    {
        var types = new[] { NotificationType.Email, NotificationType.Sms, NotificationType.Push };

        foreach (var type in types)
        {
            var notification = NotificationFactory.Create(type);
            notification.Send("Ваш заказ доставлен!");
        }
    }
}

public enum NotificationType { Email, Sms, Push }

public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[Email] {message}");
}

public class SmsNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[SMS] {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"[Push] {message}");
}

public static class NotificationFactory
{
    public static INotification Create(NotificationType type)
    {
        return type switch
        {
            NotificationType.Email => new EmailNotification(),
            NotificationType.Sms => new SmsNotification(),
            NotificationType.Push => new PushNotification(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), "Неизвестный тип уведомления")
        };
    }
}