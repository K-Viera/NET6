using Xunit;
using CalculatorLib;

namespace CalculatorLibUnitTests;

public class CalculteUnitTest
{
    [Fact]
    public void TestAdding2And2()
    {
      // arrange 
      double a = 2; 
      double b = 2;
      double expected = 4;
      Calculator calc = new();
      // act
      double actual = calc.Add(a, b);
      // assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestAdding2And3()
    {
      // arrange 
      double a = 2; 
      double b = 3;
      double expected = 6;
      Calculator calc = new();
      // act
      double actual = calc.Add(a, b);
      // assert
      Assert.Equal(expected, actual);
    }
    [Fact]
    public void TestAdding4()
    {
      // arrange 
      double a = 2; 
      double b = 3;
      double expected = 6;
      Calculator calc = new();
        // act
        double actual = calc.Add(a, b);
      // assert
      Assert.Equal(expected, actual);
    }
}