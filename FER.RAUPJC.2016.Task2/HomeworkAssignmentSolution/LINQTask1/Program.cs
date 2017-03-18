using System;
using System.Linq;

namespace LINQTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] integers = new[] { 1, 2, 2, 2, 3, 3, 4, 5 };

            string[] strings = integers.GroupBy(i => i)
                                       .Select(group => $"Broj { group.Key} se ponavlja {group.Count()} puta")
                                       .ToArray();

            strings.ToList().ForEach(s => Console.WriteLine(s));

            Console.ReadKey();
        }
    }
}
