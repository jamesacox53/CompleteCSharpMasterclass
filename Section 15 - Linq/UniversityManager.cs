using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_15___Linq
{
    internal class UniversityManager
    {
        public List<University> universities;

        public List<Student> students;

        public UniversityManager() 
        {
            universities = new List<University>();

            students = new List<Student>();

            universities.Add(new University { Id = 1, Name = "Yale" });
            universities.Add(new University { Id = 2, Name = "Beijing Tech" });

            students.Add(new Student { Id = 1, Name = "Carla", Gender = "Female", Age = 17, UniversityId = 1 });
            students.Add(new Student { Id = 2, Name = "Toni", Gender = "Male", Age = 21, UniversityId = 1 });
            students.Add(new Student { Id = 3, Name = "Leyla", Gender = "Female", Age = 19, UniversityId = 2 });
            students.Add(new Student { Id = 4, Name = "James", Gender = "Trans-Gender", Age = 25, UniversityId = 2 });
            students.Add(new Student { Id = 5, Name = "Linda", Gender = "Female", Age = 22, UniversityId = 2 });
        }

        public void MaleStudents() 
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "Male" select student;

            Console.WriteLine("Male students:");
        
            foreach(Student student in maleStudents)
            {
                student.Print();
            }
        }

        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students where student.Gender == "Female" select student;

            Console.WriteLine("Female students:");

            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }
    }
}
