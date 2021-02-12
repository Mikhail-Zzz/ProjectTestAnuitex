using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAnuitex.Util;

namespace TestAnuitex.Menus
{
    public abstract class MenuWithExit<T> : Menu<T>
    {
        protected abstract string ExitText { get; }

        public override void ShowMenu()
        {
            base.ShowMenu();
            Console.WriteLine($"[{MenuActions.Count + 1}] => {ExitText}");
        }

        public override bool ExecuteDialog(T context)
        {
            LastSelectedIndex = ConsoleUtil.ReadComand(MenuActions.Count + 1, 1);

            if (LastSelectedIndex == MenuActions.Count + 1)
                return false;

            MenuActions.ElementAt(LastSelectedIndex - 1).Value(context);

            return true;
        }
    }
}
