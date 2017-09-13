using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace ProjectEuler._0001.Tests.Scenarios
{
    [Binding]
    public class MultiplesOf3And5Steps
    {
        private const string Multiple1Key = "Multiple1";
        private const string Multiple2Key = "Multiple2";
        private const string UpperBoundKey = "UpperBound";
        private const string SumOfMultiplesKey = "SumOfMultiples";
        private const string MultiplesKey = "Multiples";

        [Given(@"the multiples (.*) and (.*)")]
        public void GivenTheMultiples(int multiple1, int multiple2)
        {
            ScenarioContext.Current[Multiple1Key] = multiple1;
            ScenarioContext.Current[Multiple2Key] = multiple2;
        }
        
        [Given(@"an upper bound of (.*)")]
        public void GivenAnUpperBoundOf(int upperBound)
        {
            ScenarioContext.Current[UpperBoundKey] = upperBound;
        }
        
        [When(@"I compute the sum of all the multiples")]
        public void WhenIComputeTheSumOfAllTheMultiples()
        {
            var multiple1 = (int) ScenarioContext.Current[Multiple1Key];
            var multiple2 = (int) ScenarioContext.Current[Multiple2Key];
            var upperBound = (int) ScenarioContext.Current[UpperBoundKey];

            var solution = new Solution(new MultipleComputer());
            var sumOfMultiple = solution.FindSumOfMultiple(upperBound, multiple1, multiple2);

            ScenarioContext.Current[SumOfMultiplesKey] = sumOfMultiple;
        }

        [When(@"I list the multiples")]
        public void WhenIListTheMultiples()
        {
            var multiple1 = (int)ScenarioContext.Current[Multiple1Key];
            var multiple2 = (int)ScenarioContext.Current[Multiple2Key];
            var upperBound = (int)ScenarioContext.Current[UpperBoundKey];

            var computer = new MultipleComputer();

            var multiples = computer.GetMultiples(upperBound, multiple1, multiple2);

            ScenarioContext.Current[MultiplesKey] = multiples;
        }

        [Then(@"the sum is (.*)")]
        public void ThenTheSumIs(int expectedSumOfMultiple)
        {
            var actualSumOfMultiple = (int) ScenarioContext.Current[SumOfMultiplesKey];

            Assert.AreEqual(expectedSumOfMultiple, actualSumOfMultiple);
        }

        [Then(@"the multiples are (.*)")]
        public void ThenTheMultiplesAre(string expectedComputedMultiples)
        {
            var expectedMultiples = expectedComputedMultiples.Split(';').Select(int.Parse);
            
            var actualMultiples = (IEnumerable<int>) ScenarioContext.Current[MultiplesKey];

            CollectionAssert.AreEquivalent(expectedMultiples, actualMultiples);
        }
    }
}
