using System;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncFactorial
{
    public class AsyncFactorialProgram
    {
        static void Main(string[] args)
        {
            int number = int.TryParse(Console.ReadLine(), out number) ? number : 1;
            var t = Task.Run(() => FactorialDigitSum(number));
            Console.WriteLine($"{number} has a factorial digit sum of {t.Result}");
            Console.ReadKey();
        }

        public static async Task<int> FactorialDigitSum(int number)
        {
            int factorial = await Task.Run(() => Factorial(number));
            return await Task.Run(() => DigitSum(factorial));
        }

        private static int Factorial(int number)
        {
            int factorial = 1;
            for (int i=2; i<=number; i++)
            {
                factorial *= i;
            }
            return factorial;
        }

        private static int DigitSum(int number)
        {
            return number.ToString().Select(digit => digit - '0').Sum();
        }
    }
}
