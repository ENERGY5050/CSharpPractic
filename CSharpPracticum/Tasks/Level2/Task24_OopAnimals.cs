using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(24, 2)]
public sealed class Task24_OopAnimals : ITask
{
    public string Title => "ООП: Animal → Dog/Cat/Bird";
    public string Description => "Построить иерархию животных.";
    public string[] Requirements => new[] { "Абстрактный класс Animal", "Классы Dog, Cat, Bird", "Полиморфизм через List<Animal>" };

    public void Run()
    {
        var animals = new List<Animal>
        {
            new Dog("Бобик"),
            new Cat("Мурка"),
            new Bird("Кеша")
        };

        foreach (var animal in animals)
        {
            animal.MakeSound();
            Console.WriteLine(animal.ToString());
            if (animal is Bird bird)
            {
                bird.Fly();
            }
            Console.WriteLine();
        }
    }
}

public abstract class Animal
{
    public string Name { get; }
    protected Animal(string name) => Name = name;
    public abstract void MakeSound();
    public override string ToString() => $"Я {GetType().Name} по имени {Name}.";
}

public class Dog : Animal
{
    public Dog(string name) : base(name) { }
    public override void MakeSound() => Console.WriteLine($"{Name}: Гав-гав!");
}

public class Cat : Animal
{
    public Cat(string name) : base(name) { }
    public override void MakeSound() => Console.WriteLine($"{Name}: Мяу!");
}

public class Bird : Animal
{
    public Bird(string name) : base(name) { }
    public override void MakeSound() => Console.WriteLine($"{Name}: Чирик!");
    public void Fly() => Console.WriteLine($"{Name} летит!");
}