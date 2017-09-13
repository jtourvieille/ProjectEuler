Feature: Multiples of 3 and 5
	In order to find the sum of all the multiples of 3 or 5 below 1000
    As a math problem solver
    I want to be told of the sum

Scenario Outline: Multiple below an upper bound
	Given the multiples <multiple1> and <multiple2>
	And an upper bound of <upperBound>
	When I list the multiples
	Then the multiples are <computedMultiples>

	Examples:
	| multiple1 | multiple2 | upperBound | computedMultiples |
	| 3         | 5         | 10         | 3;5;6;9           |

Scenario Outline: Global rule
	Given the multiples <multiple1> and <multiple2>
	And an upper bound of <upperBound>
	When I compute the sum of all the multiples
	Then the sum is <multiplesSum>

	Examples:
	| multiple1 | multiple2 | upperBound | multiplesSum |
	| 3         | 5         | 10         | 23           |
	| 3         | 5         | 1000       | 233168       |