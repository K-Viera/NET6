using Packt.Shared;
using static System.Console;

Person harry = new() { Name = "Harry" };
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

// non-generic lookup collection
System.Collections.Hashtable lookupObject = new();
lookupObject.Add(key: 1, value: "Alpha");
lookupObject.Add(key: 2, value: "Beta");
lookupObject.Add(key: 3, value: "Gamma");
lookupObject.Add(key: harry, value: "Delta");

int key = 2; // lookup the value that has 2 as its key
WriteLine(format: "Key {0} has value: {1}",
  arg0: key,
  arg1: lookupObject[key]);

// lookup the value that has harry as its key
WriteLine(format: "Key {0} has value: {1}",
  arg0: harry,
  arg1: lookupObject[harry]);

// generic lookup collection
Dictionary<int, string> lookupIntString = new();
lookupIntString.Add(key: 1, value: "Alpha");
lookupIntString.Add(key: 2, value: "Beta");
lookupIntString.Add(key: 3, value: "Gamma");
lookupIntString.Add(key: 4, value: "Delta");