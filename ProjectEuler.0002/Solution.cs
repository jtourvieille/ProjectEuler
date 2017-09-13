using System.Linq;

namespace ProjectEuler._0002
{
    public class Solution
    {
        private readonly FibonacciComputer _fibonacciComputer;

        public Solution(FibonacciComputer fibonacciComputer)
        {
            _fibonacciComputer = fibonacciComputer;
        }

        public int FindSumOfFibonacciSequence(int maxItemValue, bool onlySumEvenNumbers)
        {
            return _fibonacciComputer.GetSequence(null, maxItemValue)
                .Sum(s => onlySumEvenNumbers ? s%2 == 0 ? s : 0 : s);
        }
    }
}
