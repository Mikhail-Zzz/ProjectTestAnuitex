using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex
{
    class Program
    {
        private static Action<Company>[] MainMenuActions = new Action<Company>[7]
        {
            company => company.AddEmployee(ReadWorker()),
            company => {
                string s = ReadEployeeProperty<string>("фамилию");
                company.DeleteEmployee(emp => emp.Surname == s);
            },
            company => {
                string s = ReadEployeeProperty<string>("фамилию");
                Employee employee = company.FindEmloyee(emp => emp.Surname == s);
                Console.WriteLine(employee == null ? "Нет такого сотрудника" : employee.ToString());
            },
            company => company.OutputAllEmployee(),
            company => {
                Action actionWorker = () => {
                    Console.WriteLine("Список Работяг");
                    company.GetEmployeesOfType<Worker>().OutputAllEmployee();
                };

                Action actionBrigader = () => {
                    Console.WriteLine("Список Бригадиров");
                    company.GetEmployeesOfType<Brigadier>().OutputAllEmployee();
                };

                Action actionManager = () => {
                    Console.WriteLine("Список Мемеджеров");
                    company.GetEmployeesOfType<Worker>().OutputAllEmployee();
                };

                ReadEmployeeTypeAndExecuteAction(actionWorker, actionBrigader, actionManager);
            },
            company => {
                ReadEmployeeTypeAndExecuteAction(
                    () => Console.WriteLine("Количество рабочих:" + company.GetEmployeesOfTypeCount<Worker>()),
                    () => Console.WriteLine("Количество бригадиров:" + company.GetEmployeesOfTypeCount<Brigadier>()),
                    () => Console.WriteLine("Количество мемеджеров:" + company.GetEmployeesOfTypeCount<Manager>())
                );
            },
            company => {
                ReadEmployeeTypeAndExecuteAction(
                    () => ExecuteWorkerMenu(company),
                    () => ExecuteBrigaderMenu(company),
                    () => ExecuteManagerMenu(company)
                );
            }
        };
        private static Action<Company, Worker>[] WorkerMenuActions = new Action<Company, Worker>[1]
        {
            (company, worker) => worker.DoWork()
        };
        private static Action<Company, Brigadier>[] BrigaderMenuActions = new Action<Company, Brigadier>[2]
        {
            (company, brigader) => brigader.DoWork(),
            (company, brigader) => brigader.CheckWorker()
        };
        private static Action<Company, Manager>[] ManagerMenuActions = new Action<Company, Manager>[2]
        {
            (company, brigader) => brigader.DoWork(),
            (company, brigader) => brigader.GivTask()
        };

        static void Main(string[] args)
        {
            Company employees = new Company();

            InitMenuCycle(MainMenuActions.Select<Action<Company>, Action>(action => () => action(employees)).ToArray(), ShowMainMenu);
        }

        public static void ShowMainMenu()
        {
            Console.WriteLine("[1] => Добавить сотрудника\n" +
                              "[2] => Удалить сотрудника\n" +
                              "[3] => Найти сотрудника\n" +
                              "[4] => Показать всех сотрудников\n" +
                              "[5] => Показать всех сотрудников определенной должности\n" +
                              "[6] => Показать количество всех сотрудников определенной должности\n" +
                              "[7] => Выбрать определенную должность\n" +
                              "[8] => Завершить работу с программой");
        }

        public static Employee ReadWorker()
        {
            Employee employee = null;
            ShowTypeEmployee();

            int index = ReadComand(4, 1);

            if (index == 4)
                return null;

            string s = ReadEployeeProperty<string>("фамилию");
            string n = ReadEployeeProperty<string>("имя");
            string p = ReadEployeeProperty<string>("отчество");

            double exp = ReadEployeeProperty<double>("опыт работы");

            switch (index)
            {
                case 1:
                    employee = new Worker(n, s, p, exp);
                    break;
                case 2:
                    employee = new Brigadier(n, s, p, exp);
                    break;
                case 3:
                    employee = new Manager(n, s, p, exp);
                    break;
            }

            return employee;
        }

        public static T ReadEployeeProperty<T>(string propertyName)
        {
            Console.Write($"Введите {propertyName} сотрудника: ");
            return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
        }

        public static void ReadEmployeeTypeAndExecuteAction(Action actionWorker, Action actionBrigader, Action actionManager)
        {
            ShowTypeEmployee();
            int index = ReadComand(4, 1);

            if (index == 4)
                return;

            switch (index)
            {
                case 1:
                    actionWorker();
                    break;
                case 2:
                    actionBrigader();
                    break;
                case 3:
                    actionManager();
                    break;
            }
        }

        public static void ShowTypeEmployee()
        {
            Console.WriteLine("[1] => Работяга\n" +
                              "[2] => Бригадир\n" +
                              "[3] => Менеджер\n" +
                              "[4] => Вернуться в главное меню");
        }

        public static void ShowWorkerMenu()
        {
            Console.WriteLine("[1] => Выполнять работу\n" +
                              "[2] => Вернуться в главное меню");
        }

        public static void ExecuteWorkerMenu(Company employees)
        {
            Worker worker = employees.GetEmployeesOfType<Worker>().FirstOrDefault();
            if (worker == null)
            {
                Console.WriteLine("В компании нет работяг!");
                return;
            }
            Console.WriteLine($"Выбран работяга: {worker.Surname} {worker.Name}");

            InitMenuCycle(WorkerMenuActions.Select<Action<Company, Worker>, Action>(
                action => () => action(employees, worker)).ToArray(), ShowWorkerMenu
            );
        }

        public static void ShowBrigaderMenu()
        {
            Console.WriteLine("[1] => Выполнять работу\n" +
                              "[2] => Проверить работяг\n" +
                              "[3] => Вернуться в главное меню");
        }

        public static void ExecuteBrigaderMenu(Company employees)
        {
            Brigadier brigadier = employees.GetEmployeesOfType<Brigadier>().FirstOrDefault();
            if (brigadier == null)
            {
                Console.WriteLine("В компании нет бригадиров!");
                return;
            }
            Console.WriteLine($"Выбран бригадир: {brigadier.Surname} {brigadier.Name}");

            InitMenuCycle(BrigaderMenuActions.Select<Action<Company, Brigadier>, Action>(
                action => () => action(employees, brigadier)).ToArray(), ShowBrigaderMenu
            );
        }

        public static void ShowManagerMenu()
        {
            Console.WriteLine("[1] => Выполнять работу\n" +
                              "[2] => Дать задание\n" +
                              "[3] => Вернуться в главное меню");
        }

        public static void ExecuteManagerMenu(Company employees)
        {
            Manager manager = employees.GetEmployeesOfType<Manager>().FirstOrDefault();
            if (manager == null)
            {
                Console.WriteLine("В компании нет мемеджеров!");
                return;
            }
            Console.WriteLine($"Выбран мемеджер: {manager.Surname} {manager.Name}");

            InitMenuCycle(ManagerMenuActions.Select<Action<Company, Manager>, Action>(
                action => () => action(employees, manager)).ToArray(), ShowManagerMenu
            );
        }

        public static int ConvertToIndex(string indexsrt, int upper, int lower)
        {
            int index = Convert.ToInt32(indexsrt);

            if (index > upper || index < lower)
            {
                throw new IndexOutOfRangeException();
            }

            return index;

        }

        public static int ReadComand(int upper, int lower)
        {
            try
            {
                Console.Write("Ваш выбор: ");
                return ConvertToIndex(Console.ReadLine(), upper, lower);
            }
            catch (FormatException)
            {
                Console.WriteLine("НЕ верный формат ввода");
                return ReadComand(upper, lower);

            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("НЕ верная операция");
                return ReadComand(upper, lower);
            }
        }

        public static void InitMenuCycle(Action[] actions, Action showMenu)
        {
            while (true)
            {
                Console.WriteLine("Выбирите действие");
                showMenu();

                int index = ReadComand(actions.Length + 1, 1);
                if (index == actions.Length + 1)
                    break;

                actions[index - 1]();
            }
        }
    }
}
