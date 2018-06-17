using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingHours.Model
{
    class Model
    {
        /// <summary>
        /// Дата долга или отработки
        /// </summary>
        public DateTime Date { get; set; } // Дата долга или отработки
        public string Day { get; set; } // День недели долга или отработки
        public string TimesDay { get; set; } // Время суток, в течение которого произошли либо долг, либо отрботка
        public string timeDebt { get; set; } // Продолжительность долга
        public string leaveDebt { get; set; } // Уход в рабочее время
        public string comingDebt { get; set; } // Приход в рабочее время       
        public string comingWorkingOff { get; set; } // Приход на отработку
        public string leaveWorkingOff { get; set; } // Уход с отработки
        public string timeWorkingOff { get; set; } // Время отработки
        public string totalTime { get; set; } // Дебет времени на текущий момент
    }
}
