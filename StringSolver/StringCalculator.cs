using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Technical
{
    public class StringCalculator
    {
        /// <summary>
        /// Adds together all the numbers in a given string. The string can contain numbers
        /// separated delimiters. If the input is empty or null,the method returns 0.
        /// </summary>
        /// <param name="numbers">A string containing numbers separated by delimiters.</param>
        /// <returns>The sum of all numbers in the string. Returns 0 if the input is empty or null.</returns>
        public static int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;

            // Potential delimiters
            char[] delimiters = { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                delimiters = ProcessDelimiters(ref numbers);
            }

            int total = 0;
            List<int> negatives = [];


            foreach (var item in numbers.Split(delimiters))
            {
                // Check if the value is null or empty
                if (string.IsNullOrEmpty(item))
                {
                    throw new ArgumentException("Value required between delimiters.");
                }

                // Try parsing the value into an integer.
                if (int.TryParse(item, out int number))
                {
                    // Check for negative numbers
                    if (number < 0)
                    {
                        negatives.Add(number);
                    }
                    // Filter out numbers >= 1000
                    else if (number < 1000)
                    {
                        // Add valid numbers to total
                        total += number;
                    }
                }
                else
                {
                    throw new ArgumentException($"Invalid value: {item}");
                }
            }

            // If any negative numbers were found, throw an exception
            if (negatives.Count > 0)
            {
                throw new ArgumentException($"Negatives not allowed: {string.Join(", ", negatives)}");
            }

            return total;
        }

        private static char[] ProcessDelimiters(ref string numbers)
        {
            // Remove "//" from start of string.
            numbers = numbers.Substring(2);
            var i = 0;
            List<char> newDelimiters = [];

            // Loop through until \n or the end of the string is encountered.
            while (i < numbers.Length && numbers[i] != '\n')
            {
                char character = char.ToLower(numbers[i]);
                newDelimiters.Add(character);
                i++;
            }

            // If no newline was encountered, throw an exception
            if (i == numbers.Length)
            {
                throw new ArgumentException("Please end delimter assignment with \\n.");
            }

            numbers = numbers.Substring(i + 1).ToLower();

            return newDelimiters.ToArray();
        }
    }
}
