using Shouldly;
using Technical;

namespace StringSolverTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void Add_WhiteSpaceString_ShouldReturn0()
        {
            // Arrange
            string values = " ";
            int sum = 0;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_Receive1_ShouldReturn1()
        {
            // Arrange
            string values = "1";
            int sum = 1;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_NullString_ShouldReturn0()
        {
            // Arrange
            string values = null;
            int sum = 0;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_CommaSeparated1And2_ShouldReturnSum()
        {
            // Arrange
            string values = "1,2";
            int sum = 3;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_CommaSeparated1And2And3_ShouldReturnSum()
        {
            // Arrange
            string values = "1,2,3";
            int sum = 6;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_StringWithNewLineAndComma_ShouldReturnSum()
        {
            // Arrange
            string values = "1\n2,3";
            int sum = 6;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_GivenStringWithInvalidTrailingDelimiter_ShouldThrowException()
        {
            // Arrange
            string values = "1,\n";

            // Act & Assert
            var exception = Should.Throw<ArgumentException>(() => StringCalculator.Add(values));
            exception.Message.ShouldBe("Value required between delimiters.");
        }

        [Fact]
        public void Add_GivenMultipleDelimitersAddValue_ShouldReturnSum()
        {
            // Arrange
            string values = "//;\n1;2";
            int sum = 3;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_GivenUppercaseLetterWithLowercaseDelimiter_ShouldReturnSum()
        {
            // Arrange
            string values = "//Z\n1z2";
            int sum = 3;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_GivenLowercaseLetterWithUppercaseDelimiter_ShouldReturnSum()
        {
            // Arrange
            string values = "//z\n1Z2";
            int sum = 3;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_GivenNoLineBreakWithDelimterAssignment_ShouldThrowException()
        {
            // Arrange
            string values = "//abc1a2";

            // Act & Assert
            var exception = Should.Throw<ArgumentException>(() => StringCalculator.Add(values));
            exception.Message.ShouldBe("Please end delimter assignment with \\n.");
        }

        [Fact]
        public void Add_GivenInvalidString_ShouldThrowException()
        {
            // Arrange
            string values = "abc";

            // Act & Assert
            var exception = Should.Throw<ArgumentException>(() => StringCalculator.Add(values));
            exception.Message.ShouldBe("Invalid value: abc");
        }

        [Fact]
        public void Add_GivenStringWithNegatives_ShouldThrowException()
        {
            // Arrange
            string values = "-2,5,-3";

            // Act & Assert
            var exception = Should.Throw<ArgumentException>(() => StringCalculator.Add(values));
            exception.Message.ShouldBe("Negatives not allowed: -2, -3");
        }

        [Fact]
        public void Add_IgnoreValueOver1000_ShouldReturnSum()
        {
            // Arrange
            string values = "2, 1001, 13";
            int sum = 15;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

        [Fact]
        public void Add_GivenMultipleDelimiters_ShouldReturnSum()
        {
            // Arrange
            string values = "//*%\n1*2%3";
            int sum = 6;

            // Act
            var result = StringCalculator.Add(values);

            // Assert
            result.ShouldBe(sum);
        }

    }
}