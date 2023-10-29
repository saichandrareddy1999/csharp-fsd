using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace introduction
{
    public class Enum
    {
        static void Main()
        {
            Customer[] customer = new Customer[3];
            customer[0]=new Customer { Name="niti",Gender=1};
            customer[1] = new Customer { Name = "mine", Gender = 0 };
            customer[2] = new Customer { Name = "papa", Gender = 2 };
            foreach(Customer customer2 in customer)
            {
                Console.WriteLine(customer2.Name + GetGender(customer2.Gender));
            }

        }
        public static string GetGender(int gender)
        {
            switch(gender)
            {
                case 0: return "UNKNOWN";
                case 1: return "Male";
                case 3: return "Female";
                default: return "Invalid Input";
            }
        }
    }
    public class Customer
    {
        public string Name { get; set; }
        public int Gender { get; set; }

    }
}
