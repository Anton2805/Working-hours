using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WorkingHours
{
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        DateTime _date;
        string _day;
        string _timesDay;
        string _timesDebt;
        string _leaveDebt;
        string _comingDebt;
        string _comingWorkingOff;
        string _leaveWorkingOff;
        string _timeWorkingOff;
        string _totalTime;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime Date // Дата долга или отработки
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged("Date");
            }
        }
        public string Day // День недели долга или отработки
        {
            get { return _day; }
            set
            {
                _day = value;
                OnPropertyChanged("Day");
            }
        }
        public string TimesDay // Время суток, в течение которого произошли либо долг, либо отработка
        {
            get { return _timesDay; }
            set
            {
                _timesDay = value;
                OnPropertyChanged("TimesDay");
            }
        }
        public string TimeDebt // Продолжительность долга
        {
            get { return _timesDebt; }
            set
            {
                _timesDebt = value;
                OnPropertyChanged("TimeDebt");
            }
        }
        public string LeaveDebt // Уход в рабочее время
        {
            get { return _leaveDebt; }
            set
            {
                _leaveDebt = value;
                OnPropertyChanged("LeaveDebt");
            }
        }
        public string ComingDebt // Приход в рабочее время
        {
            get { return _comingDebt; }
            set
            {
                _comingDebt = value;
                OnPropertyChanged("ComingDebt");
            }
        }
        public string ComingWorkingOff // Приход на отработку
        {
            get { return _comingWorkingOff; }
            set
            {
                _comingWorkingOff = value;
                OnPropertyChanged("ComingWorkingOff");
            }
        }
        public string LeaveWorkingOff // Уход с отработки
        {
            get { return _leaveWorkingOff; }
            set
            {
                _leaveWorkingOff = value;
                OnPropertyChanged("LeaveWorkingOff");
            }
        }
        public string TimeWorkingOff // Время отработки
        {
            get { return _timeWorkingOff; }
            set
            {
                _timeWorkingOff = value;
                OnPropertyChanged("TimeWorkingOff");
            }
        }
        public string TotalTime // Дебет времени на текущий момент
        {
            get { return _totalTime; }
            set
            {
                _totalTime = value;
                OnPropertyChanged("TotalTime");
            }
        }
    }
}
