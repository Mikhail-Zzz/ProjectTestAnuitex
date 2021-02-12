using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex.Menus
{
    public class EmployeeByTypeExecuteMenu : SubMenu<Company>
    {
        protected override string CheckActionTetxt => "Выбирите должность сотрудника";

        private Dictionary<string, Action<Company>> eployeeTypeMenu = new Dictionary<string, Action<Company>>();

        protected override Dictionary<string, Action<Company>> MenuActions => eployeeTypeMenu;

        public EmployeeByTypeExecuteMenu(Action<Company> actionWorker, Action<Company> actionBrigader, Action<Company> actionManager)
        {
            eployeeTypeMenu.Add("Работяга", actionWorker);
            eployeeTypeMenu.Add("Бригадр", actionBrigader);
            eployeeTypeMenu.Add("Мемеджер", actionManager);
        }
    }
}
