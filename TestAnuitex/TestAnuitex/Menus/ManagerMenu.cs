using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex.Menus
{
    public class ManagerMenu : SubMenu<Manager>
    {
        public Company Employees { get; private set; }
        public Manager Manager { get; private set; }

        protected override bool LeaveOnSuccess => false;
        protected override string NoContextMessage => "В компании нет мемеджеров!";

        public ManagerMenu(Company employees)
        {
            Employees = employees;
            Manager = employees.GetEmployeesOfType<Manager>().FirstOrDefault();
        }

        private Dictionary<string, Action<Manager>> managerMenuAction = new Dictionary<string, Action<Manager>>()
        {
            { "Выполнять работу", manager => manager.DoWork() },
            { "Дать задание",  manager => manager.GivTask() }
        };

        protected override Dictionary<string, Action<Manager>> MenuActions => managerMenuAction;

        public void ExecuteMenuCycle()
        {
            Console.WriteLine($"Выбран мемеджер: {Manager.Surname} {Manager.Name}");
            ExecuteMenuCycle(Manager);
        }
    }
}
