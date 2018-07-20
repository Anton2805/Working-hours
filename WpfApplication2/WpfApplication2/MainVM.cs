using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfApplication2
{
    public class MyMathModel : BindableBase
    {
        // Класс ObservableCollection<T> представляет динамическую коллекцию данных,
        // которая выдает уведомления при добавлении и удалении элементов, а также при обновлении списка.
        private readonly ObservableCollection<int> _MyValues = new ObservableCollection<int>();
        // Класс ReadOnlyObservableCollection представляет доступную только для чтения коллекцию ObservableCollection<T>.
        public readonly ReadOnlyObservableCollection<int> MyPublicValues;
        public MyMathModel()
        {
            MyPublicValues = new ReadOnlyObservableCollection<int>(_MyValues);
        }
        public void AddValue(int value)
        {
            _MyValues.Add(value);
            RaisePropertyChanged("Sum");
        }
        public void RemoveValue(int index)
        {
            if (index >= 0 && index < _MyValues.Count) _MyValues.RemoveAt(index);
            RaisePropertyChanged("Sum");
        }
        public int Sum => MyPublicValues.Sum();
    }
    public class MainVM : BindableBase
    {

        readonly MyMathModel _model = new MyMathModel();
        public MainVM()
        {
            // Событие типа PropertyChangedEventHandler. Показывает, что свойства были изменены 
            _model.PropertyChanged += (s, e) => { RaisePropertyChanged(e.PropertyName); };
            AddCommand = new DelegateCommand<string>(str =>
            {
                int ival;
                if (int.TryParse(str, out ival)) _model.AddValue(ival);
            });
            RemoveCommand = new DelegateCommand<int?>(i =>
            {
                if (i.HasValue) _model.RemoveValue(i.Value);
            });
        }
        public DelegateCommand<string> AddCommand { get; }
        public DelegateCommand<int?> RemoveCommand { get; }
        public int Sum => _model.Sum;
        public ReadOnlyObservableCollection<int> MyValues => _model.MyPublicValues;
    }
}
