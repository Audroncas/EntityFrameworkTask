using Lesson_48__2_.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

/*using (var context = new SchoolContext())
{
    var student = new Student() { Name = "Tomas" };
    var department = new Department() { Name = "Economics", Students = new List<Student>() { student } };
    context.Departments.Add(department);
    context.SaveChanges();
}*/

SchoolRepository schoolRepository = new SchoolRepository();
//1
//schoolRepository.CreateDepartment(new Department() { Name = "Inžinerija" });

//2.1
/*var lectures = new List<Lecture>();
lectures.Add(new Lecture() { Name = "Matematika" });
lectures.Add(new Lecture() { Name = "Fizika" });
lectures.Add(new Lecture() { Name = "Chemija" });
schoolRepository.DepartmentAddListOf<Lecture>(3, lectures);*/

//2.2
/*var students = new List<Student>();
students.Add(new Student() { Name = "Marius Marijampolis" });
students.Add(new Student() { Name = "Ona Onaitė" });
students.Add(new Student() { Name = "Jurga Jurgaitytė" });
schoolRepository.DepartmentAddListOf<Student>(3, students);*/

//3
//schoolRepository.CreateLecture(new Lecture() { Name = "Anglų kalba" }, 4);

//4
//schoolRepository.CreateStudent(new Student() { Name = "Jonas Jonaitis" }, 3);

/*using (var context = new SchoolContext())
{
    var student = context.Students.Where(s => s.Id == 5).Include(s => s.Lectures).First();
    foreach (var item in student.Lectures)
    {
        Console.WriteLine(item.Name);
    }
}*/

//5
//schoolRepository.MoveStudentToAnotherDepartment(8, 4);

/*//6
Console.WriteLine("Departments students:");
foreach (var item in schoolRepository.GetDepartmentStudents(3))
{
    Console.WriteLine(item.Name);
}

//7
Console.WriteLine("Department lectures:");
foreach (var item in schoolRepository.GetDepartmentLectures(3))
{
    Console.WriteLine(item.Name);
}

//8
Console.WriteLine("Student lectures:");
foreach (var item in schoolRepository.GetStudentLectures(8))
{
    Console.WriteLine(item.Name);
}*/