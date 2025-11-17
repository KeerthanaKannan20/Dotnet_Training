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
}
