using System.Diagnostics;
using System.Text;
using CSharpPracticum.Common;

namespace CSharpPracticum.Tasks.Level2;

[TaskInfo(17, 2)]
public sealed class Task17_StringBuilderBench : ITask
{
    public string Title => "StringBuilder vs конкатенация";
    public string Description => "Сравнить производительность конкатенации через + и StringBuilder.";
    public string[] Requirements => new[] { "10 000 или 100 000 итераций", "Замерить время через Stopwatch", "Вывести разницу", "Объяснить в комментарии" };

    public void Run()
    {
        const int n = 50_000; // 50 000 достаточно для наглядной разницы

        var sw = Stopwatch.StartNew();
        string resultConcat = "";
        for (int i = 0; i < n; i++)
        {
            resultConcat += i.ToString();
        }
        sw.Stop();
        var concatTime = sw.ElapsedMilliseconds;

        sw.Restart();
        var sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            sb.Append(i.ToString());
        }
        string resultSb = sb.ToString();
        sw.Stop();
        var sbTime = sw.ElapsedMilliseconds;

        Console.WriteLine($"Количество итераций: {n}");
        Console.WriteLine($"Обычная конкатенация (+): {concatTime} мс");
        Console.WriteLine($"StringBuilder:            {sbTime} мс");
        Console.WriteLine($"Разница:                  {concatTime - sbTime} мс");
        Console.WriteLine($"\nРезультаты равны: {resultConcat == resultSb}");

        /* 
         * ОБЪЯСНЕНИЕ:
         * Строки в C# неизменяемы (immutable). При каждой операции "+" создается 
         * НОВЫЙ объект строки в куче, а старый остается в памяти до сборки мусора.
         * Это создает огромную нагрузку на память (O(N^2)).
         * StringBuilder хранит внутри изменяемый массив символов (буфер), 
         * который расширяется при необходимости. Это работает за O(N).
         */
    }
}