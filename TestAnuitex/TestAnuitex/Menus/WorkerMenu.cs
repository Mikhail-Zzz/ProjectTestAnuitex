using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex.Menus
{
    public class WorkerMenu : SubMenu<Worker>
    {
        public Company Employees { get; private set; }
        public Worker Worker { get; private set; }

        protected override bool LeaveOnSuccess => false;
        protected override string NoContextMessage => "В компании нет работяг!";


        public WorkerMenu(Company employees)
        {
            Employees = employees;
            Worker = employees.GetEmployeesOfType<Worker>().FirstOrDefault();
        }

        private Dictionary<string, Action<Worker>> workerMenuAction = new Dictionary<string, Action<Worker>>()
        {
            { "Выполнять работу",  worker => worker.DoWork() }
        };
        protected override Dictionary<string, Action<Worker>> MenuActions => workerMenuAction;


        public  void ExecuteMenuCycle()
        {
            Console.WriteLine($"Выбран работяга: {Worker.Surname} {Worker.Name}");
            ExecuteMenuCycle(Worker);        
        }
    }
}
