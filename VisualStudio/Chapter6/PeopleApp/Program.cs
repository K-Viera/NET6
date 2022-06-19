using Packt.Shared;
using static System.Console;

//Person harry = new() { Name = "Harry" };
//Person mary = new() { Name = "Mary" };
//Person jill = new() { Name = "Jill" };

//// call static method
//Person baby2 = Person.Procreate(harry, jill);
//// call an operator
//Person baby3 = harry * mary;

//harry.Shout += Harry_Shout;
//harry.Poke();
//harry.Poke();
//harry.Poke();
//harry.Poke();

//static void Harry_Shout(object? sender, EventArgs e)
//{
//    if (sender is null) return;
//    Person p = (Person)sender;
//    WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
//}

//// non-generic lookup collection
//System.Collections.Hashtable lookupObject = new();
//lookupObject.Add(key: 1, value: "Alpha");
//lookupObject.Add(key: 2, value: "Beta");
//lookupObject.Add(key: 3, value: "Gamma");
//lookupObject.Add(key: harry, value: "Delta");

//int key = 2; // lookup the value that has 2 as its key
//WriteLine(format: "Key {0} has value: {1}",
//  arg0: key,
//  arg1: lookupObject[key]);

//// lookup the value that has harry as its key
//WriteLine(format: "Key {0} has value: {1}",
//  arg0: harry,
//  arg1: lookupObject[harry]);

//// generic lookup collection
//Dictionary<int, string> lookupIntString = new();
//lookupIntString.Add(key: 1, value: "Alpha");
//lookupIntString.Add(key: 2, value: "Beta");
//lookupIntString.Add(key: 3, value: "Gamma");
//lookupIntString.Add(key: 4, value: "Delta");

//////interfaces
//Person[] people =
//{
//  new() { Name = "Simon" },
//  new() { Name = "Jenny" },
//  new() { Name = "Adam" },
//  new() { Name = "Richard" },
//};
//WriteLine("Initial list of people:");
//foreach (Person p in people)
//{
//    WriteLine($"  {p.Name}");
//}
////WriteLine("Use Person's IComparable implementation to sort:");
////Array.Sort(people);

//WriteLine("Use PersonComparer's IComparer implementation to sort:");
//Array.Sort(people, new PersonComparer());
//foreach (Person p in people)
//{
//    WriteLine($"  {p.Name}");
//}

//////Struc Types
//DisplacementVector dv1 = new(3, 5);
//DisplacementVector dv2 = new(-2, 7);
//DisplacementVector dv3 = dv1 + dv2;
//WriteLine($"({dv1.X}, {dv1.Y}) + ({dv2.X}, {dv2.Y}) = ({dv3.X}, {dv3.Y})");

//// Inherence
Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year: 1990, month: 7, day: 28)
};
john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yy}");
WriteLine(john.ToString());

////polymorphism
Employee aliceInEmployee = new()
{ Name = "Alice", EmployeeCode = "AA123" };
Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1950, 12, 25));
}
catch (PersonException ex)
{
    WriteLine(ex.Message);
}

string email1 = "pamela@test.com";
string email2 = "ian&test.com";
WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: StringExtensions.IsValidEmail(email1));
WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: StringExtensions.IsValidEmail(email2));

WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email1,
  arg1: email1.IsValidEmail());
WriteLine("{0} is a valid e-mail address: {1}",
  arg0: email2,
  arg1: email2.IsValidEmail());