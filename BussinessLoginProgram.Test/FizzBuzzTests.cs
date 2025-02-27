using AUTOMATION_TEST.Fundamentals;
using Xunit;

namespace BussinessLoginProgram.Test
{
    public class FizzBuzzTests
    {
        [Fact]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnsFizzBuzz()
        {
            var result = FizzBuzz.GetOutput(15);
            Assert.Equal("FizzBuzz", result);
        }

        [Fact]
        public void GetOutput_InputIsDivisibleBy3_ReturnsFizz()
        {
            var result = FizzBuzz.GetOutput(3);
            Assert.Equal("Fizz", result);
        }

        [Fact]
        public void GetOutput_InputIsDivisibleBy5_ReturnsBuzz()
        {
            var result = FizzBuzz.GetOutput(5);
            Assert.Equal("Buzz", result);
        }

        [Fact]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnsNumber()
        {
            var result = FizzBuzz.GetOutput(1);
            Assert.Equal("1", result);
        }
    }
}
