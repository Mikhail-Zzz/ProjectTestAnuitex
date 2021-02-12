using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex.Menus
{
    public class EmployeeTypeSelectMenu : EmployeeByTypeExecuteMenu
    {
        private static Action<Company> actionWorker = company => new WorkerMenu(company).ExecuteMenuCycle();
        private static Action<Company> actionBrigader = company => new BregaderMenu(company).ExecuteMenuCycle();
        private static Action<Company> actionManager = company => new ManagerMenu(company).ExecuteMenuCycle();

        public EmployeeTypeSelectMenu() : base(actionWorker, actionBrigader, actionManager) { }
    }
}
