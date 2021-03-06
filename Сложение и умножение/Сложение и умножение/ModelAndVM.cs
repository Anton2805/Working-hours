﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сложение_и_умножение
{
    class ModelAndVM : INotifyPropertyChanged
    {
        public ObservableCollection<double> _MyValues = new ObservableCollection<double>();
        public ReadOnlyObservableCollection<double> MyPublicValues;
        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ModelAndVM()
        {
            MyPublicValues = new ReadOnlyObservableCollection<double>(_MyValues);
            AddCommand = new DelegateCommand<string>(str =>
            {
                double ival;
                if (double.TryParse(str, out ival)) AddValue(ival);
            });
            RemoveCommand = new DelegateCommand<int?>(i =>
            {
                if (i.HasValue) RemoveValue(i.Value);
            });
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void AddValue(double value)
        {
            _MyValues.Add(value);
            AllPropertyChanged();
        }
        public void RemoveValue(int index)
        {
            if (index >= 0 && index < _MyValues.Count)
                _MyValues.RemoveAt(index);
            AllPropertyChanged();
        }
        public void AllPropertyChanged()
        {
            string[] namesPropertyChanged = { "Sum", "MultyPly" };
            foreach (var item in namesPropertyChanged)
                OnPropertyChanged(item);
        }
        public double Sum => MyPublicValues.Sum();
        public double MultyPly
        {
            get
            {
                if (MyPublicValues.Count != 0)
                    return MyPublicValues.Aggregate((p, x) => p *= x);
                return 0.0;
            }
        }
    }
}
