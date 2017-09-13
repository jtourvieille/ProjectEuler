using System.Collections.Generic;

namespace ProjectEuler._0002
{
    public class FibonacciComputer
    {
        public IEnumerable<int> GetSequence(int? maxItemInSequence, int? maxItemValue)
        {
            var sequence = new List<int> { 1, 2 };

            while (
                (maxItemInSequence.HasValue && sequence.Count < maxItemInSequence.Value) || !maxItemInSequence.HasValue)
            {
                var nextVal = sequence[sequence.Count - 1] + sequence[sequence.Count - 2];

                if (maxItemValue.HasValue && nextVal >= maxItemValue.Value)
                {
                    break;
                }

                sequence.Add(nextVal);
            }

            return sequence;
        } 
    }
}
