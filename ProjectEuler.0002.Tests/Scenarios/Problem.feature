Feature: Even Fibonacci numbers
	In order to find the sum of even-valued terms of Fibonacci sequence
    As a math problem solver
    I want to be told of the sum

Scenario: Fibonacci sequence
	Given a maximum number of terms of 10
	When I list the terms of Fibonacci sequence
	Then the list is 1;2;3;5;8;13;21;34;55;89

Scenario Outline: Fibonacci sequence with upper bound
	Given a maximum value of <maximumValue>
	When I sum the terms of Fibonacci sequence
	Then the sum is <sum>

	Examples:
	| maximumValue | sum |
	| 3            | 3   |
	| 4            | 6   |
	| 5            | 6   |
	| 6            | 11  |

Scenario: Sum of even Fibonacci sequence with upper bound
	Given a maximum value of 4000000
	When I sum the even terms of Fibonacci sequence
	Then the sum is 4613732