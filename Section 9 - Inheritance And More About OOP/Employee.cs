using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section9Namespace
{
    internal class Employee
    {
        protected string Name { get; }
        protected string FirstName { get; }
        protected int Salary { get; }

        public Employee(string name, string firstName, int salary)
        {
            this.Name = name;
            this.FirstName = firstName;
            this.Salary = salary;
        }

        public virtual void Work()
        {
            Console.WriteLine("I am an employee and I am working.");
        }

        public void Pause()
        {
            Console.WriteLine("I am an employee and I have stopped working.");
        }


    }
}
