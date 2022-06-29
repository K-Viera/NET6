using System.Xml.Serialization; // XmlSerializer
using static System.Console;
using System;
using System.IO;
using WorkingWithSerialization;

List<Person> people = new()
{
    new(30_000M)
    {
        FirstName="Alice",
        LastName="Smith",
        DateOfBirth=new(1974,3,14)
    },
    new(40000M)
    {
        FirstName = "Bob",
        LastName = "Jones",
        DateOfBirth = new(1969, 11, 23)
    },
    new(20000M)
    {
        FirstName = "Charlie",
        LastName = "Cox",
        DateOfBirth = new(1984, 5, 4),
        Children = new()
        {
            new(0M){
                FirstName = "Sally",
                LastName = "Cox",
                DateOfBirth = new(2000, 7, 12)
            }
        }
    }
};

foreach (Person p in people)
{
    WriteLine("{0} has {1} children.",
        p.LastName, p.Children?.Count());
}

// create object that will format a List of Persons as XML
XmlSerializer serializer = new(people.GetType());
// Create a file to write
string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "people.xml");
WriteLine(path);
using (FileStream stream = File.Create(path))
{
    serializer.Serialize(stream, people);
}
WriteLine("Written {0:N0} bytes of XML to {1}",
  arg0: new FileInfo(path).Length,
  arg1: path);
WriteLine();
// Display the serialized object graph
WriteLine(File.ReadAllText(path));

using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
    // deserealize and cast the object graph into a List of Person
    List<Person>? loadedPeople = serializer.Deserialize(xmlLoad) as List<Person>;
    if (loadedPeople is not null) 
    {
        foreach (Person p in loadedPeople)
        {
            WriteLine("{0} has {1} children.",
                p.LastName, p.Children?.Count()??0);
        }
    }
}