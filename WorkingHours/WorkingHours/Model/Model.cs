using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public string TimeDebt { get; set; } // Продолжительность долга
        public string LeaveDebt { get; set; } // Уход в рабочее время
        public string ComingDebt { get; set; } // Приход в рабочее время       
        public string ComingWorkingOff { get; set; } // Приход на отработку
        public string LeaveWorkingOff { get; set; } // Уход с отработки
        public string TimeWorkingOff { get; set; } // Время отработки
        public string TotalTime { get; set; } // Дебет времени на текущий момент

    }
    class ViewModel
    {
        public Model EditModel { get; set; }
        public List<Model> Result { get; set; }
        public Model Total { get; set; }
        public ICommand Add { get; set; }
    }
}
