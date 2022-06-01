using CalculatorLib;
using static System.Console;

WriteLine("in main");
Alpha();

static void Alpha()
{
  WriteLine("In Alpha");
  Beta();
}
static void Beta()
{
  WriteLine("In Beta");
  try
  {
    Calculator.Gamma();
  }
  catch (Exception ex)
  {
    WriteLine($"Caught this: {ex.Message}");
    //throw ex delete usefull information about callstack
    throw;
  }
}