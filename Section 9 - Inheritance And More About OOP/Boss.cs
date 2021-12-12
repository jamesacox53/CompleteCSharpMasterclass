using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section9Namespace
{
    internal class Boss : Employee
    {
        protected string CompanyCar { get; }

        public Boss(string name, string firstName, int salary, string companyCar) : base(name, firstName, salary)
        { 
            this.CompanyCar = companyCar;
        }

        public void Lead()
        {
            Console.WriteLine("I am a Boss and I am leading.");
        }




    }
}
