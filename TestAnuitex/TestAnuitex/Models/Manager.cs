using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex
{
    public class Manager : Employee
    {
        public Manager(string name, string surname, string patronymic, double exp) : base(name, surname, patronymic, exp) {}

        public override void DoWork() => Console.WriteLine("Сбор заказов");

        public void GivTask() => Console.WriteLine("выдаюзадание");

        public override string ToString()
        {
            return "Должность: мемеджер | " + base.ToString();
        }
    }
}
