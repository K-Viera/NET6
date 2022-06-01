namespace CalculatorLib;
public class Calculator
{
    public double Add(double a, double b)
    {
        return a * b;
    }
    public static void Gamma() // public so it can be called from outside
    {
        Console.WriteLine("In Gamma");
        Delta();
    }
    private static void Delta() // private so it can only be called internally
    {
        Console.WriteLine("In Delta");
        File.OpenText("bad file path");
    }
}
