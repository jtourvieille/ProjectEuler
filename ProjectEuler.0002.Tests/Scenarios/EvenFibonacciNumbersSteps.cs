using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Collections.Generic;

namespace ProjectEuler._0002.Tests.Scenarios
{
    [Binding]
    public class EvenFibonacciNumbersSteps
    {
        private const string UpperBoundKey = "UpperBound";
        private const string MaximumValueKey = "MaximumValue";
        private const string ListKey = "List";
        private const string SumKey = "Sum";

        [Given(@"a maximum number of terms of (.*)")]
        public void GivenAMaximumNumberOfTermsOf(int upperBound)
        {
            ScenarioContext.Current[UpperBoundKey] = upperBound;
        }

        [Given(@"a maximum value of (.*)")]
        public void GivenAMaximumValueOf(int maximumValue)
        {
            ScenarioContext.Current[MaximumValueKey] = maximumValue;
        }

        [When(@"I list the terms of Fibonacci sequence")]
        public void WhenIListTheTermsOfFibonacciSequence()
        {
            var upperBound = (int) ScenarioContext.Current[UpperBoundKey];

            var fibonacciComputer = new FibonacciComputer();

            var list = fibonacciComputer.GetSequence(upperBound, null);

            ScenarioContext.Current[ListKey] = list;
        }

        [When(@"I sum the terms of Fibonacci sequence")]
        public void WhenISumTheTermsOfFibonacciSequence()
        {
            var maximumValue = (int)ScenarioContext.Current[MaximumValueKey];

            var solution = new Solution(new FibonacciComputer());
            var sum = solution.FindSumOfFibonacciSequence(maximumValue, false);

            ScenarioContext.Current[SumKey] = sum;
        }

        [When(@"I sum the even terms of Fibonacci sequence")]
        public void WhenISumTheEvenTermsOfFibonacciSequence()
        {
            var maximumValue = (int)ScenarioContext.Current[MaximumValueKey];

            var solution = new Solution(new FibonacciComputer());
            var sum = solution.FindSumOfFibonacciSequence(maximumValue, true);

            ScenarioContext.Current[SumKey] = sum;
        }

        [Then(@"the list is (.*)")]
        public void ThenTheListIs(string expectedList)
        {
            var expectedListNumbers = expectedList.Split(';').Select(int.Parse);
            var actualList = (IEnumerable<int>) ScenarioContext.Current[ListKey];

            CollectionAssert.AreEquivalent(expectedListNumbers, actualList);
        }

        [Then(@"the sum is (.*)")]
        public void ThenTheSumIs(int expectedSum)
        {
            var actualSum = (int) ScenarioContext.Current[SumKey];

            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}
