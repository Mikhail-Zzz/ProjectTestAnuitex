using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex
{
    public class Brigadier : Employee
    {
        public Brigadier(string name, string surname, string patronymic, double exp) : base(name, surname, patronymic, exp) {}

        public override void DoWork() => Console.WriteLine("Закупка материалов");

        public void CheckWorker() => Console.WriteLine("проверяю рабочих");

        public override string ToString()
        {
            return "Должность: бригадир | " + base.ToString();
        }
    }
}
