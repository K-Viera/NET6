using Packt.Shared;
using static System.Console;

Person harry = new() { Name = "Harry" };
Person mary = new() { Name = "Mary" };
Person jill = new() { Name = "Jill" };

// call static method
Person baby2 = Person.Procreate(harry, jill);
// call an operator
Person baby3 = harry * mary;