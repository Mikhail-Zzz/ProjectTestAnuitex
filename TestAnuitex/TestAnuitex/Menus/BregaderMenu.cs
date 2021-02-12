using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex.Menus
{
    class BregaderMenu : SubMenu<Brigadier>
    {
        public Company Employees { get; private set; }
        public Brigadier Brigadier { get; private set; }

        protected override bool LeaveOnSuccess => false;
        protected override string NoContextMessage => "В компании нет бригадиров!";

        public BregaderMenu(Company employees)
        {
            Employees = employees;
            Brigadier = employees.GetEmployeesOfType<Brigadier>().FirstOrDefault();
        }

        private Dictionary<string, Action<Brigadier>> bregaderMenuAction = new Dictionary<string, Action<Brigadier>>()
        {
            { "Выполнять работу", manager => manager.DoWork() },
            { "Дать задание",  manager => manager.CheckWorker() }
        };

        protected override Dictionary<string, Action<Brigadier>> MenuActions => bregaderMenuAction;

        public void ExecuteMenuCycle()
        {
            Console.WriteLine($"Выбран бригадир: {Brigadier.Surname} {Brigadier.Name}");
            ExecuteMenuCycle(Brigadier);
        }
    }
}
