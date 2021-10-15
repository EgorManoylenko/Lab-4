using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    class A
    {
        public B[] Args; 

        public A(B one, B two) 
        {
            Args = new[] { one, two };
        }

        public A(B one, B two, B three)
        {
            Args = new[] { one, two, three };
        }

        public void PrintPropertiesToDebug()
        {
            Debug.WriteLine("Arguments properties:");

            foreach (var Argums in Args)
            {
                Argums.PropertiesInfo();
            }
        }
    }

    class B
    {
        public virtual void PropertiesInfo()
        {
            Debug.WriteLine("Class B:");
            Debug.WriteLine("It`s base class for D, C, E");
        }
    }

    class C : B
    {
        private string _text = "Hello)";

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public override void PropertiesInfo()
        {
            Debug.WriteLine("Class C:");
            Debug.WriteLine($"Some text: {_text}");
        }
    }

    class D : B
    {
        public DateTime Time;

        public D()
        {
            Time = DateTime.Now;
        }

        public override void PropertiesInfo()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Class D:");
            Debug.WriteLine($"Data time: {Time}");
        }
    }

    class E : B
    {
        public override void PropertiesInfo()
        {
            Debug.WriteLine("");
            Debug.WriteLine("Class E:");
            Debug.WriteLine("Some prop E");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            A mainAAA = new A(new C() { Text = "Lalalal" }, new D(), new E());

            mainAAA.PrintPropertiesToDebug();

            Console.ReadLine();
        }
    }
}
