using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_15___Linq
{
    internal class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        // Foreign key
        public int UniversityId { get; set; }

        public void Print()
        {
            Console.WriteLine($"Student {Name} with: Id {Id}, Gender {Gender} " + 
                $"and Age {Age} goes to the University with Id {UniversityId}.");
        }



    }
}
