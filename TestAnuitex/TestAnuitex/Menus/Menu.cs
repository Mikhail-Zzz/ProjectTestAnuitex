using System;
using System.Collections.Generic;
using System.Linq;
using TestAnuitex.Util;

namespace TestAnuitex
{
    public abstract class Menu<T>
    {
        public int LastSelectedIndex { get; protected set; }
        protected abstract Dictionary<string, Action<T>> MenuActions { get; }

        protected virtual bool LeaveOnSuccess => true;
        protected virtual string NoContextMessage => "Контекст не задан";
        protected virtual string CheckActionTetxt => "Выбирите действие";

        public virtual void ShowMenu()
        {
            for (int i = 0; i < MenuActions.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] => {MenuActions.ElementAt(i).Key}");
            }
        }

        public void ExecuteMenuCycle(T context)
        {
            while (true)
            {
                Console.WriteLine(CheckActionTetxt);
                ShowMenu();

                if (!ExecuteDialog(context))
                    break;

                if (LeaveOnSuccess)
                    break;
            }
        }

        public virtual bool ExecuteDialog(T context)
        {
            if (context == null)
            {
                Console.WriteLine(NoContextMessage);
                return false;
            }

            LastSelectedIndex = ConsoleUtil.ReadComand(MenuActions.Count, 1);

            MenuActions.ElementAt(LastSelectedIndex - 1).Value(context);

            return true;
        }
    }
}
