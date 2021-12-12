using System;

namespace Section9Namespace
{
    class Section9
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee("Tim O'Neal", "Tim", 20000);
            Trainee trainee = new Trainee("Jake Marston", "Jake", 15000, 12.0, 12.5);
            Boss boss = new Boss("Patrick Smith", "Patrick", 50000, "Mercedes");

            employee.Work();
            employee.Pause();

            trainee.Work();
            trainee.Pause();
            trainee.Learn();

            boss.Work();
            boss.Pause();
            boss.Lead();
        }
    }
}