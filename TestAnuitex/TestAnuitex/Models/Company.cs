using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex
{
    public class Company : IEnumerable<Employee>
    {
        private List<Employee> employees = new List<Employee>();

        public Company() {}

        public static Company operator+(Company company ,Employee employee)
        {
            company.AddEmployee(employee);

            return company;
        }

        public static Company operator -(Company company, Employee employee)
        {
            company.AddEmployee(employee);

            return company;
        }

        public void AddEmployee(Employee employee)
        {
            employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public void DeleteEmployee(string name)
        {
            DeleteEmployee(emp => emp.Name == name);
        }

        public void DeleteEmployee(double lowerExperienceBound)
        {
            DeleteEmployee(emp => emp.Experience < lowerExperienceBound);
        }

        public void DeleteEmployee(Predicate<Employee> predicate)
        {
            employees.RemoveAll(predicate);
        }

        public IEnumerator<Employee> GetEnumerator()
        {
            return employees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }


}
