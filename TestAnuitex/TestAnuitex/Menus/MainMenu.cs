using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAnuitex.Util;

namespace TestAnuitex.Menus
{
    public class MainMenu : MenuWithExit<Company>
    {
        private Dictionary<string, Action<Company>> mainMenuAction = new Dictionary<string, Action<Company>>()
        {
            { "Добавить сотрудника", company => company.AddEmployee(ConsoleUtil.ReadWorker()) },
            { "Удалить сотрудника", company => {
                string s = ConsoleUtil.ReadEployeeProperty<string>("фамилию");
                company.DeleteEmployee(emp => emp.Surname == s);
                }
            },
            {"Найти сотрудника", company => {
                string s = ConsoleUtil.ReadEployeeProperty<string>("фамилию");
                Employee employee = company.FindEmloyee(emp => emp.Surname == s);
                Console.WriteLine(employee == null ? "Нет такого сотрудника" : employee.ToString());
                }
            },
            {"Показать всех сотрудников", company => company.OutputAllEmployee() },
            {"Показать всех сотрудников определенной должности", company => {
                    Action<Company> actionWorker = comp => {
                        Console.WriteLine("Список Работяг");
                        comp.GetEmployeesOfType<Worker>().OutputAllEmployee();
                    };

                    Action<Company> actionBrigader = comp => {
                        Console.WriteLine("Список Бригадиров");
                        comp.GetEmployeesOfType<Brigadier>().OutputAllEmployee();
                    };

                    Action<Company> actionManager = comp => {
                        Console.WriteLine("Список Мемеджеров");
                        comp.GetEmployeesOfType<Worker>().OutputAllEmployee();
                    };

                    new EmployeeByTypeExecuteMenu(actionWorker, actionBrigader, actionManager).ExecuteMenuCycle(company);
                }
            },
            {"Показать количество всех сотрудников определенной должности", company => {

                 new EmployeeByTypeExecuteMenu(
                     comp => Console.WriteLine("Количество рабочих:" + comp.GetEmployeesOfTypeCount<Worker>()),
                     comp => Console.WriteLine("Количество бригадиров:" + comp.GetEmployeesOfTypeCount<Brigadier>()),
                     comp => Console.WriteLine("Количество мемеджеров:" + comp.GetEmployeesOfTypeCount<Manager>())
                ).ExecuteMenuCycle(company);
                }
            },
            {"Выбрать определенную должность", company => new EmployeeTypeSelectMenu().ExecuteMenuCycle(company)}
        };

        protected override bool LeaveOnSuccess => false;
        protected override string ExitText => "Завешить работу с програмой";
        protected override Dictionary<string, Action<Company>> MenuActions => mainMenuAction;
    }
}
