using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex
{
    public class Worker : Employee
    {
        public Worker(string name, string surname, string patronymic, double exp) : base(name, surname, patronymic, exp) {}

        public override void DoWork() => Console.WriteLine("Выпускаю продукцию");

        public override string ToString()
        {
            return "Должность: работяга | " + base.ToString();
        }
    }
}
