using System;
using TestAnuitex.Menus;


namespace TestAnuitex.Util
{
    public class ConsoleUtil
    {
        public static int ReadComand(int upper, int lower)
        {
            try
            {
                Console.Write("Ваш выбор: ");
                return ConvertUtil.ConvertToIndex(Console.ReadLine(), upper, lower);
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

        public static Employee ReadWorker()
        {
            Employee employee = null;

            EmployeeByTypeExecuteMenu employeeByType = new EmployeeByTypeExecuteMenu(
                    company => { return; },
                    company => { return; },
                    company => { return; }
                );

            employeeByType.ExecuteMenuCycle(null);

            if (employeeByType.LastSelectedIndex == 4)
                return null;

            string s = ReadEployeeProperty<string>("фамилию");
            string n = ReadEployeeProperty<string>("имя");
            string p = ReadEployeeProperty<string>("отчество");

            double exp = ReadEployeeProperty<double>("опыт работы");

            switch (employeeByType.LastSelectedIndex)
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
            try
            {
                Console.Write($"Введите {propertyName} сотрудника: ");
                return (T)Convert.ChangeType(Console.ReadLine(), typeof(T));
            }
            catch(FormatException)
            {
                Console.WriteLine("Неверный ввод!");
                return ReadEployeeProperty<T>(propertyName);
            }
        }
    }
}
