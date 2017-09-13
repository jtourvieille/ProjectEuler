using System.Collections.Generic;

namespace ProjectEuler._0001
{
    public class MultipleComputer
    {
        public IEnumerable<int> GetMultiples(int upperBound, int multiple1, int multiple2)
        {
            var multiples = new HashSet<int>();

            for (int currentValue = 1; currentValue < upperBound; currentValue++)
            {
                if (currentValue%multiple1 == 0)
                {
                    multiples.Add(currentValue);
                }
                else
                {
                    if (currentValue%multiple2 == 0)
                    {
                        multiples.Add(currentValue);
                    }
                }
            }

            return multiples;
        }
    }
}
