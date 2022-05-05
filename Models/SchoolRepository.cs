using Microsoft.EntityFrameworkCore;

namespace Lesson_48__2_.Models
{
    internal class SchoolRepository
    {
        //1
        public void CreateDepartment(Department Department)
        {
            if (Department == null)
            {
                throw new NullReferenceException();
            }
            using (var schoolContext = new SchoolContext())
            {
                var lectures = schoolContext.Lectures;
                Department.Lectures.AddRange(lectures);
                schoolContext.Departments.Add(Department);
                schoolContext.SaveChanges();
            }
        }

        //2
        public void DepartmentAddListOf<T>(int DepartmentId, List<T> ListToAdd)
        {
            using (var schoolContext = new SchoolContext())
            {
                var department = schoolContext.Departments.Where(d => d.Id == DepartmentId).FirstOrDefault();
                if (department == null)
                {
                    throw new Exception($"Department with Id {DepartmentId} does not exists");
                }

                if (typeof(T) == typeof(Student))
                {
                    department.Students.AddRange(ListToAdd.Cast<Student>().ToList());
                }
                else if (typeof(T) == typeof(Lecture))
                {
                    department.Lectures.AddRange(ListToAdd.Cast<Lecture>().ToList());
                }
                else
                {
                    throw new Exception($"Provided list is not correct type. You should use Student or Lecture type.");
                }
                schoolContext.SaveChanges();
            }
        }

        //3
        public void CreateLecture(Lecture Lecture, int DepartmentId)
        {
            using (var schoolContext = new SchoolContext())
            {
                var department = schoolContext.Departments.Where(d => d.Id == DepartmentId).Include(d => d.Lectures).FirstOrDefault();
            
                if (department == null)
                {
                    throw new Exception($"Department with Id {DepartmentId} does not exists");
                }

                department.Lectures.Add(Lecture);
                schoolContext.SaveChanges();
            }
                
        }

        //4
        public void CreateStudent(Student Student, int DepartmentId)
        {
            using (var schoolContext = new SchoolContext())
            {
                var department = schoolContext.Departments.Where(d => d.Id == DepartmentId).Include(d => d.Students).Include(d => d.Lectures).FirstOrDefault();

                if (department == null)
                {
                    throw new Exception($"Department with Id {DepartmentId} does not exists");
                }

                Student.Lectures.AddRange(department.Lectures);
                department.Students.Add(Student);
                schoolContext.SaveChanges();
            }
        }

        //5
        public void MoveStudentToAnotherDepartment(int StudentId, int DepartmentId)
        {
            using (var schoolContext = new SchoolContext())
            {
                var student = schoolContext.Students.Where(s => s.Id == StudentId).Include(s => s.Lectures).FirstOrDefault();
                var department = schoolContext.Departments.Where(d => d.Id == DepartmentId).Include(d => d.Lectures).FirstOrDefault();

                if (student == null)
                {
                    throw new Exception($"Student with Id {StudentId} does not exists");
                }
                if (department == null)
                {
                    throw new Exception($"Department with Id {DepartmentId} does not exists");
                }

                if (student.Lectures.Count() > 0)
                {
                    //prieš priskiriant naujas paskaitas reikia ištrinti senas, nes jos automatiškai nepasišalina iš LectureStudent lentelės
                    student.Lectures.RemoveRange(0, student.Lectures.Count - 1); 
                }
                student.Lectures = department.Lectures;
                student.DepartmentId = DepartmentId;
                //schoolContext.Students.Update(student);
                schoolContext.SaveChanges();
            }
        }

        //6
        public List<Student> GetDepartmentStudents(int DepartmentId)
        {
            Department department;
            using (var schoolContext = new SchoolContext())
            {
                department = schoolContext.Departments.Where(d => d.Id == DepartmentId).Include(d => d.Students).FirstOrDefault();
            }

                if (department == null)
                {
                    throw new Exception($"Department with Id {DepartmentId} does not exists");
                }

                return department.Students;
        }

        //7
        public List<Lecture> GetDepartmentLectures(int DepartmentId)
        {
            Department department;
            using (var schoolContext = new SchoolContext())
            {
                department = schoolContext.Departments.Where(d => d.Id == DepartmentId).Include(d => d.Lectures).FirstOrDefault();
            }

            if (department == null)
            {
                throw new Exception($"Department with Id {DepartmentId} does not exists");
            }

            return department.Lectures;
        }

        //8
        public List<Lecture> GetStudentLectures(int StudentId)
        {
            Student student;
            using (var schoolContext = new SchoolContext())
            {
                student = schoolContext.Students.Where(s => s.Id == StudentId).Include(s => s.Lectures).FirstOrDefault();
            }

            if (student == null)
            {
                throw new Exception($"Student with Id {StudentId} does not exists");
            }

            return student.Lectures;
        }
    }
}
