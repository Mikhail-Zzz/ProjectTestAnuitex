using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex
{
    public static class CompanyExtensions
    {
        public static bool IsContainsWorker( this Company employees, Employee employee)
        {
            return employees.Contains<Employee>(employee);
        }

        public static bool IsContainsWorker(this Company employees, Predicate<Employee> predicate)
        {
            return employees.FindEmloyee(predicate) != null;
        }

        public static Employee FindEmloyee(this Company employees, Predicate<Employee> predicate)
        {
            return employees.FirstOrDefault(employee => predicate(employee));
        }
        public static IEnumerable<TEmployee> GetEmployeesOfType<TEmployee>(this Company employees)
            where TEmployee : Employee
        {
            return employees.OfType<TEmployee>();
        }

        public static int GetEmployeesOfTypeCount<TEmployee>(this Company employees)
            where TEmployee : Employee
        {
            return employees.GetEmployeesOfType<TEmployee>().Count();
        }

        public static void OutputAllEmployee(this IEnumerable<Employee> employees)
        {
            if(employees.Count() == 0)
                Console.WriteLine("Список пуст");
            else
            {
                foreach (Employee employee in employees)
                {
                    Console.WriteLine(employee.ToString());
                }
            }                
        }


    }
}
