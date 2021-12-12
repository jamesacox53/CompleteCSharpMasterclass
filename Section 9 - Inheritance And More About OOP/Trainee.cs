using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section9Namespace
{
    internal class Trainee : Employee
    {
        protected double WorkingHours { get; }
        protected double SchoolHours { get; }

        public Trainee(string name, string firstName, int salary, double workingHours, double schoolHours) : base(name, firstName, salary)
        {
            this.WorkingHours = workingHours;
            this.SchoolHours = schoolHours;
        }

        public override void Work()
        {
            Console.WriteLine($"My working hours are {WorkingHours}.");
        }

        public void Learn()
        {
            Console.WriteLine("I am a Trainee and I am learning.");
        }
    }
}
