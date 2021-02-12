using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAnuitex.Util
{
    public class ConvertUtil
    {
        public static int ConvertToIndex(string indexsrt, int upper, int lower)
        {
            int index = Convert.ToInt32(indexsrt);

            if (index > upper || index < lower)
            {
                throw new IndexOutOfRangeException();
            }

            return index;

        }
    }
}
