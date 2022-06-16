using System;
using Packt.Shared;
using static System.Console;

//BankAccount.InterestRate = 0.012M; // store a shared value
//BankAccount jonesAccount = new(); // C# 9.0 and later
//jonesAccount.AccountName = "Mrs. Jones";
//jonesAccount.Balance = 2400;
//WriteLine(format: "{0} earned {1:C} interest.",
//  arg0: jonesAccount.AccountName,
//  arg1: jonesAccount.Balance * BankAccount.InterestRate);
//BankAccount gerrierAccount = new();
//gerrierAccount.AccountName = "Ms. Gerrier";
//gerrierAccount.Balance = 98;
//WriteLine(format: "{0} earned {1:C} interest.",
//  arg0: gerrierAccount.AccountName,
//  arg1: gerrierAccount.Balance * BankAccount.InterestRate);

//Constructors
//Person blankPerson = new();
//WriteLine(format:
//  "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
//  arg0: blankPerson.Name,
//  arg1: blankPerson.HomePlanet,
//  arg2: blankPerson.Instantiated);

//Tuples
Person bob = new();
(string, int) fruit = bob.GetFruit();
WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

var fruitNamed = bob.GetNamedFruit();
WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}.");
//inferring tuple names
var thing1 = ("Neville", 4);
WriteLine($"{thing1.Item1} has {thing1.Item2} children.");
var thing2 = (bob.Name, bob.Children.Count);
WriteLine($"{thing2.Name} has {thing2.Count} children.");
//Deconstructing tuples
(string fruitName, int fruitNumber) = bob.GetFruit();
WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");