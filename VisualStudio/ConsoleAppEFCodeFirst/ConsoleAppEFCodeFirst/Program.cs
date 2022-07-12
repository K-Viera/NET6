
using ConsoleAppEFCodeFirst.Data;
using ConsoleAppEFCodeFirst.Models;

addStudent("Kevin");
addCurseToStudent("Spanish", "Kevin");
listStudents();
static void addCurseToStudent(string course,string name)
{
    using (SchoolContext db = new())
    {
        Student student = db.students.FirstOrDefault(x=>x.Name.Contains(name));
        Course newCourse = new() { CourseName= course };
        student.Courses.Add(newCourse);
        db.SaveChanges();
    };
}
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

