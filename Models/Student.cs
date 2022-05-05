using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_48__2_.Models
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
