using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rightClick
{
    class Sprint
    {
        private List<string> months;
        
        public Sprint(DateTime day)
        {
            //string currentSprint;

            int i = day.DayOfYear;
            int what = (i / 14) - 1;

        }
    }
}
