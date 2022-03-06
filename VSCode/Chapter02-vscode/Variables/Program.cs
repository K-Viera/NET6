object height = 1.88;// storing a double in an object
object name = "Amir"; // storing a string in an object
Console.WriteLine($"{name} is {height} metres tall.");
//int length1 = name.Length; // gives compile error!
int length2 = ((string)name).Length;
Console.WriteLine($"{name} has {length2} characters.");
dynamic something = "Ahmed";
Console.WriteLine($"Length is {something.Length}");