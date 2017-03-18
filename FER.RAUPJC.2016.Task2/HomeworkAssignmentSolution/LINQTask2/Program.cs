using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQTask2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Example1().ToString() + " " + Example2().ToString());
            Console.ReadKey();
        }

        static bool Example1()
        {
            var list = new List<Student>()
            {
            new Student (" Ivan ", jmbag :" 001234567 ")
            };
            var ivan = new Student(" Ivan ", jmbag: " 001234567 ");

            return list.Any(s => s == ivan);
        }

        static int Example2()
        {
            var list = new List<Student>()
            {
            new Student (" Ivan ", jmbag :" 001234567 ") ,
            new Student (" Ivan ", jmbag :" 001234567 ")
            };

            return list.Distinct().Count();
        }

    }
}
