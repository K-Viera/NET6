using static System.Console;
namespace Packt.Shared;
public class Person : object
{
    // fields
    public string? Name;    // ? allows null
    public DateTime DateOfBirth;
    public List<Person> Children = new(); // C# 9 or later
                                          // methods
    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    // static method to "multiply"
    public static Person Procreate(Person p1, Person p2)
    {
        Person baby = new()
        {
            Name = $"Baby of {p1.Name} and {p2.Name}"
        };
        p1.Children.Add(baby);
        p2.Children.Add(baby);
        return baby;
    }
    // operator to "multiply"
    public static Person operator *(Person p1, Person p2)
    {
        return Person.Procreate(p1, p2);
    }
    // instance method to "multiply"
    public Person ProcreateWith(Person partner)
    {
        return Procreate(this, partner);
    }

    // delegate field
    public event EventHandler? Shout;
    // data field
    public int AngerLevel;
    // method
    public void Poke()
    {
        AngerLevel++;
        if (AngerLevel >= 3)
        {
            // if something is listening...
            //if (Shout != null)
            //{
            //    // ...then call the delegate
            //    Shout(this, EventArgs.Empty);
            //}
            Shout?.Invoke(this, EventArgs.Empty);
        }
    }

}