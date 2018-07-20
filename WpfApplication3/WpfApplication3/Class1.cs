using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class ModelAndVm:BindableBase
    {
        private readonly ObservableCollection<double> _MyValues = new ObservableCollection<double>();
        public readonly ReadOnlyObservableCollection<double> MyPublicValues;
        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        public ModelAndVm()
        {
            MyPublicValues = new ReadOnlyObservableCollection<double>(_MyValues);
            AddCommand = new DelegateCommand<string>(str =>
            {
                double ival;
                if (double.TryParse(str, out ival)) AddValue(ival);
                PropertyChanged += _MyValues.Sum();

            });
            RemoveCommand = new DelegateCommand<int?>(i =>
            {
                if (i.HasValue) RemoveValue(i.Value);
            });
        }
        public void AddValue(double value)
        {
            _MyValues.Add(value);

        }
        public void RemoveValue(int index)
        {
            if (index >= 0 && index < _MyValues.Count)
                _MyValues.RemoveAt(index);
        }

    };
}
