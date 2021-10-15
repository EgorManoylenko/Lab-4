using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3
{
    class Employee : Person
    {
        private string _placeOfWork;
        private string _position;

        public Employee()
        {
            _placeOfWork = "Microsoft";
            _position = "Director of c#";
        }

        public override void GetInfo()
        {
            Debug.WriteLine($"\tAs a employee");
            base.GetInfo();
            Debug.WriteLine($"Place of work: {_placeOfWork}");
            Debug.WriteLine($"Position: {_position}");
        }
    }

    class Person
    {
        private string _name;
        private string _surname;
        private int _age;

        public Person()
        {
            _name = "Denys";
            _surname = "Zaidun";
            _age = 18;
        }

        public virtual void GetInfo()
        {
            Debug.WriteLine($"Name: {_name}");
            Debug.WriteLine($"Surname: {_surname}");
            Debug.WriteLine($"Age: {_age}");
        }
    }

    class Sportsmen : Person
    {
        private string _nameOfSport;
        private int _yearInSport;

        public Sportsmen()
        {
            _nameOfSport = "golf";
            _yearInSport = 17;
        }

        public override void GetInfo()
        {
            Debug.WriteLine("\tAs a sportsman");
            base.GetInfo();
            Debug.WriteLine($"Sport: {_nameOfSport}");
            Debug.WriteLine($"Year in sport: {_yearInSport}");
        }
    }

    class Student : Person
    {
        private string _universityName;
        private string _faculty;
        private int _yearOfStudy;
        private int _group;

        public Student()
        {
            _universityName = "KNUTE";
            _faculty = "FIT";
            _yearOfStudy = 2;
            _group = 3;
        }

        public override void GetInfo()
        {
            Debug.WriteLine("\tAs a student");
            base.GetInfo();
            Debug.WriteLine($"University Name: {_universityName}");
            Debug.WriteLine($"Faculty: {_faculty}");
            Debug.WriteLine($"Year of study: {_yearOfStudy}");
            Debug.WriteLine($"Group: {_group}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new[]
            {
                new Person(),
                new Student(),
                new Employee(),
                new Sportsmen()
            };

            foreach (var classes in persons)
            {
                classes.GetInfo();
                Debug.WriteLine("");
            }

            Console.ReadLine();
        }
    }
}
