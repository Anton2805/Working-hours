using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Сложение_и_умножение_2
{
    public class MyMathModel : BindableBase
    {
        // Класс ObservableCollection<T> представляет динамическую коллекцию данных,
        // которая выдает уведомления при добавлении и удалении элементов, а также при обновлении списка.
        private readonly ObservableCollection<double> _MyValues = new ObservableCollection<double>();
        // Класс ReadOnlyObservableCollection представляет доступную только для чтения коллекцию ObservableCollection<T>.
        public readonly ReadOnlyObservableCollection<double> MyPublicValues;

        public MyMathModel()
        {
            MyPublicValues = new ReadOnlyObservableCollection<double>(_MyValues);
        }
        public void AddValue(double value)
        {
            _MyValues.Add(value);
            RaisePropertyChanged("Sum");
            RaisePropertyChanged("MultyPly");
        }
        public void RemoveValue(int index)
        {
            if (index >= 0 && index < _MyValues.Count) _MyValues.RemoveAt(index);
            RaisePropertyChanged("Sum");
            RaisePropertyChanged("MultyPly");
        }
        public double Sum => MyPublicValues.Sum();
        public double MultyPly => MyPublicValues.Aggregate((p, x) => p *= x);
    }
    public class MainVM : BindableBase
    {
        readonly MyMathModel _model = new MyMathModel();
        public ReadOnlyObservableCollection<double> MyValues => _model.MyPublicValues;
        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }

        public MainVM()
        {
            // Событие типа PropertyChangedEventHandler. Показывает, что свойства были изменены             
            _model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            AddCommand = new DelegateCommand<string>(str =>
            {
                double ival;
                if (double.TryParse(str, out ival)) _model.AddValue(ival);
            });
            RemoveCommand = new DelegateCommand<int?>(i =>
            {
                if (i.HasValue) _model.RemoveValue(i.Value);
            });
        }
        public double Sum => _model.Sum;
        public double MultyPly
        {
            get
            {
                if (_model.MyPublicValues.Count != 0)
                    return _model.MultyPly;
                return 0.0;
            }
        }
    }
}
