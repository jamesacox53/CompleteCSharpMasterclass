using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_15___Linq
{
    internal class University
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void Print() 
        {
            Console.WriteLine($"University {Name} with Id {Id}");
        }

    }
}
