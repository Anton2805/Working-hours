using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WorkingHours
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Model EditModel { get; set; }
        public List<Model> Result { get; set; }
        public Model Total { get; set; }
        public ICommand AddData { get; set; } // Добавить строку об долге и отработке в лист Result
        public ICommand RemoveData { get; set; } // Удалить строку о долге и отработке из листа Result

        public ViewModel()
        {
            EditModel = new Model();
            Result = new List<Model>();
            AddData = new DelegateCommand(AddResult);
            RemoveData = new DelegateCommand(RemoveResult); // На будущее
        }

        private void RemoveResult(object obj)
        {

        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddResult(object obj)
        {
            Result.Add(EditModel);
        }
    }
}
