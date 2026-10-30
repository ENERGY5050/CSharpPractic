using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(26, 2)]
public sealed class Task26_StrategyPattern : ITask
{
    public string Title => "Паттерн «Стратегия» (скидки)";
    public string Description => "Реализовать калькулятор скидок через паттерн «Стратегия».";
    public string[] Requirements => new[] { "IDiscountStrategy", "NoDiscount, VipDiscount (10%), PromoDiscount (20%)", "PriceCalculator" };

    public void Run()
    {
        decimal price = 1000m;

        var noDiscount = new PriceCalculator(new NoDiscount());
        var vipDiscount = new PriceCalculator(new VipDiscount());
        var promoDiscount = new PriceCalculator(new PromoDiscount());

        Console.WriteLine($"Базовая цена: {price} руб.");
        Console.WriteLine($"Без скидки: {noDiscount.Calculate(price)} руб.");
        Console.WriteLine($"VIP скидка (10%): {vipDiscount.Calculate(price)} руб.");
        Console.WriteLine($"Промо скидка (20%): {promoDiscount.Calculate(price)} руб.");
    }
}

public interface IDiscountStrategy
{
    decimal Apply(decimal price);
}

public class NoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price;
}

public class VipDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * 0.9m;
}

public class PromoDiscount : IDiscountStrategy
{
    public decimal Apply(decimal price) => price * 0.8m;
}

public class PriceCalculator
{
    private readonly IDiscountStrategy _strategy;
    public PriceCalculator(IDiscountStrategy strategy) => _strategy = strategy;
    public decimal Calculate(decimal price) => _strategy.Apply(price);
}