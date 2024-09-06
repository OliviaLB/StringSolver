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

            int total = 0;

            foreach (var item in numbers.Split(delimiters))
            {
                // Try parsing the value into an integer
                if (int.TryParse(item, out int number))
                {
                    total += number;
                }
                else
                {
                    throw new ArgumentException($"Invalid value: {item}");
                }
            }

            return total;
        }
    }
}
