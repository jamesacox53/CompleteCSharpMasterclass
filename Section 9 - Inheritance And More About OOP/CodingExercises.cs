using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section9Namespace
{
    public class CodingExercise11
    {
        public void CodingExercise11Method(string[] args)
        {
            // new instance 
            Gun pist = new Gun();

            // test for methods
            pist.Label();
            pist.Shoot();

            // verifying the interface and the parent class
            if (pist is IShootable && pist is Weapon)
                System.Console.WriteLine("Yes, it is my parents.");
        }
    }

    interface IShootable
    {
        public void Shoot();
    }
    
    class Weapon
    {
        private string name;

        public Weapon(string name)
        {
            this.name = name;
        }

        public void Label()
        {
            Console.WriteLine($"This is {name}!");
        }
    }

    class Gun : Weapon, IShootable
    {
        public Gun() : base("Gun")
        {
        }
        
        public void Shoot()
        {
            Console.WriteLine("Bang!");
        }
    }

    public class CodingExercise12
    {
        public void CodingExercise12Method(string[] args)
        {
            PhoneBook MyPhoneBook = new PhoneBook();

            foreach (Contact contact in MyPhoneBook)
            {
                contact.Call();
            }
        }
    }

    class PhoneBook: IEnumerable<Contact>
    {
        public List<Contact> contacts;

        public PhoneBook()
        {
            contacts = new List<Contact>{
                new Contact("Andre", "435797087"),
                new Contact("Lisa", "435677087"),
                new Contact("Dine", "3457697087"),
                new Contact("Sofi", "4367697087")
            };
        }

        public IEnumerator<Contact> GetEnumerator()
        {
            return contacts.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return contacts.GetEnumerator();
        }
    }

    class Contact
    {
        private string name;
        private string number;
        
        public Contact(string name, string number)
        {
            this.name = name;
            this.number = number;
        }

        public void Call()
        {
            Console.WriteLine($"Calling to {name}. Phone number is {number}");
        }
    }
}
