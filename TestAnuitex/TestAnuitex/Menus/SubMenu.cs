using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex.Menus
{
    public abstract class SubMenu<T> : MenuWithExit<T>
    {
        protected override string ExitText => "Вернуться в перыдущее меню";
    }
}
