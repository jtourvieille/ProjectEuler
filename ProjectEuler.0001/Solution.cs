using System.Linq;

namespace ProjectEuler._0001
{
    public class Solution
    {
        private readonly MultipleComputer _multipleComputer;

        public Solution(MultipleComputer multipleComputer)
        {
            _multipleComputer = multipleComputer;
        }

        public int FindSumOfMultiple(int upperBound, int multiple1, int multiple2)
        {
            return _multipleComputer.GetMultiples(upperBound, multiple1, multiple2).Sum();
        }
    }
}
