using System;
using System.Diagnostics;

namespace 1
{
    class First
    {
        public void ArgsToDebag(params object[] args)
        {
            Debug.WriteLine("Arguments: ");
            foreach (var argums in args)
            {
                Debug.WriteLine(argums);
            }
        }
    }
    class Second : First
    {
        public new void ArgsToDebag(params object[] args)
        {
            Debug.WriteLine("Arguments & Types: ");

            //я не нашел как красить дебаг

            foreach (var argums in args)
            {
                Debug.WriteLine($"{argums.GetType()}: {argums}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Second second = new Second();
            second.ArgsToDebag
            (
                12,
                4.5m,
                99.99f,
                12.5d,
                'c',
                "Hello world",
                DateTime.Now,
                new object()
                              );

            First first = (First)second;
            first.ArgsToDebag
            (
                12,
                4.5m,
                99.99f,
                12.5d,
                'c',
                "Hello world",
                DateTime.Now,
                new object()
                              );
            Console.ReadLine();
        }
    }
}