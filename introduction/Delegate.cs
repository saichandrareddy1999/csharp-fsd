using System;
using System.Collections.Generic;

namespace introduction
{
    #region DelegateIntroduction   
    public class Delegate
    {
        public static void Main()
        {
            List<Employee> emplist = new List<Employee>();
            emplist.Add(new Employee() { ID = 1, Name = "sai", Salary = 5000, Experience = 5 });
            emplist.Add(new Employee() { ID = 1, Name = "chandra", Salary = 4000, Experience = 4 });
            emplist.Add(new Employee() { ID = 1, Name = "vamsi", Salary = 6000, Experience = 6 });
            emplist.Add(new Employee() { ID = 1, Name = "reddy", Salary = 3000, Experience = 3 });
            IsPromotable isPromotable = new IsPromotable(Promote);
            Employee.PromoteEmployee(emplist, isPromotable);
            //Employee.PromoteEmployee(emplist, emp => emp.Experience >= 5); lamda expression

        }
        public static bool Promote(Employee employee)
        {
            if (employee.Experience >= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public delegate bool IsPromotable(Employee empl);
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int Experience { get; set; }

        public static void PromoteEmployee(List<Employee> employeelist, IsPromotable IsEligibleToPromote)
        {
            foreach (Employee employee in employeelist)
            {
                if (IsEligibleToPromote(employee))
                {
                    Console.WriteLine(employee.Name + " Promoted");
                }
            }
        }
    }
    #endregion DelegateIntroduction
}

