using System;

using System.Linq;
using TestAnuitex.Menus;

namespace TestAnuitex
{
    class Program
    {
        static void Main(string[] args)
        {
            Company employees = new Company();

            MainMenu menu = new MainMenu();

            menu.ExecuteMenuCycle(employees);
        }
    }
}
