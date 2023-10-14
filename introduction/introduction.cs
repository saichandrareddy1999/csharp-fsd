using System;

namespace introduction
{
    //public class introduction
    //{
    //    static void Main()
    //    {
    //        Console.WriteLine("Hello Sai !!!");
    //        Console.ReadLine();

    //    }
    //}
    public delegate void PrintDelegate(string message); // type safe pointer to a method
    public class MyClass
    {
        public static void Print(string message)
        {
            Console.WriteLine(message);
        }
        public static void Main()
        {
            PrintDelegate p = new PrintDelegate(Print);
            p("hello");            
            Print("hi");
            Console.ReadLine();
        }
    }
}
