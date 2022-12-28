using Lab19WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Lab19WpfApp1.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        
        void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        
        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }

        private double lenght;
        public double Lenght
        {
            get => lenght;
            set
            {
                lenght = value;
                OnPropertyChanged();
            }
        }
        public ICommand GetLenghtCommand { get; }
        private void OnGetLenghtCommandExecute(object p) //выполнение команды
        {
            Lenght = Arithmetics.GetLenght(Radius);
        }
        private bool CanGetLenghtCommandExecuted(object p)
        {
            return true;
        }
        public MainWindowViewModel()
        {
            GetLenghtCommand = new RelayCommand(OnGetLenghtCommandExecute, CanGetLenghtCommandExecuted);
        }
    }
}
