using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumofSquare
{
    public static class Extension
    {
        public static int SumOfSquares(this IEnumerable<int> numbers)
        {
            return numbers.Sum(n => n * n);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 2, 3, 4 };
            Console.WriteLine(list.SumOfSquares());
            Console.ReadLine();
        }
    }
}