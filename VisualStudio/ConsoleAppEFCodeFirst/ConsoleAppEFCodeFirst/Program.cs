
using ConsoleAppEFCodeFirst.Data;
using ConsoleAppEFCodeFirst.Models;

//addStudent("chris");
listStudents();

static void addStudent(string name)
{
    using (SchoolContext db = new())
    {
        Student newStudent = new()
        {
            Name = name
        };
        db.Add(newStudent);
        db.SaveChanges();
    };
}

static void listStudents() 
{
    using (SchoolContext db = new())
    {
        List<Student> listStudents = db.students.Where(x=>x.Name=="Andres").ToList();
        foreach (Student s in listStudents)
        {
            Console.WriteLine($"Student name: {s.Name}");
        }
    }
}

