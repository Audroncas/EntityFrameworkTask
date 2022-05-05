using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_48__2_.Models
{
    internal class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
