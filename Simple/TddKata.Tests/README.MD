### [String Calculator Kata](http://osherove.com/tdd-kata-1/ )
    Create a simple String calculator with a method int Add(string numbers)
        The method can take 0, 1, or 2 comma-separated numbers, and will return their sum (for an empty string it will return 0) for example “” or “1” or “1,2”
        Start with the simplest test case of an empty string and move to 1 and two numbers
        Remember to solve things as simply as possible so that you force yourself to write tests you did not think about
        Remember to refactor after each passing test
    Allow the Add method to handle an unknown amount of numbers
    Allow the Add method to handle new lines between numbers (instead of commas).
        the following input is ok:  “1\n2,3”  (will equal 6)
        the following input is NOT ok:  “1,\n” (not need to prove it - just clarifying)
        Support different delimiters
        to change a delimiter, the beginning of the string will contain a separate line that looks like this:   “//[delimiter]\n[numbers…]” for example “//;\n1;2” should return three where the default delimiter is ‘;’ .
        the first line is optional. all existing scenarios should still be supported
    Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.if there are multiple negatives, show all of them in the exception message stop here if you are a beginner. 
    
## [FizzBuzzKata](https://www.codewars.com/kata/fizz-buzz)

Return an array containing the numbers from 1 to N, where N is the parametered value. N will never be less than 1 (in C#, N might be less then 1).

C# ONLY: If N is smaller then or equal to 0, throw an ArgumentOutOfRangeException!
Replace certain values however if any of the following conditions are met:

If the value is a multiple of 3: use the value 'Fizz' instead
If the value is a multiple of 5: use the value 'Buzz' instead
If the value is a multiple of 3 & 5: use the value 'FizzBuzz' instead
