using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingHours.Model
{
    class ModelDay
    {
        public DateTime Date { get; set; }
        public string Day { get; set; }
        public string TimesDay { get; set; }
        public string TimeDebt { get; set; }
        public string leaveDebt { get; set; }
        public string comingDebt { get; set; }
        public string timeDebt { get; set; }
        public string leaveWorkingOff { get; set; }
        public string comingWorkingOff { get; set; }
        public string timeWorkingOff { get; set; }
        public string balanceValue { get; set; }        
    }
}
