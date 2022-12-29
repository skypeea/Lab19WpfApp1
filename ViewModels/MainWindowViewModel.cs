using Lab19WpfApp1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace Lab19WpfApp1.ViewModels
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        
        void OnPropertyChanged([CallerMemberName]string PropertyName=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private string display=null;
        public string Display
        {
            get => display;
            set
            {
                display = value;
                OnPropertyChanged();
            }
        }
        private int num1;
        public int Num1
        {
            get => num1;
            set
            {

            }
        }
        //ввод данных
        public ICommand AddToDisplayCommand { get; } 
        private void OnAddToDisplayCommandExecute(object p)
        {
            if (Display == double.NaN.ToString() || Display == "0")
            {
                Display = "";
            }
            Display += p as string;
        }
        private bool CanAddToDIsplayCommandExecuted(object p)
        {
            return true;
        }
        //Вычисление строки
        public ICommand SolveCommand { get; }
        private void OnSolveCommand(object p)
        {
            var expression = Display;
            Display = Arithmetics.Parse(expression).ToString();
        }
        private bool CanSolveCommandExecuted(object p)
        {
            return true;
        }
      
        //Очистка строки ввода
        public ICommand ResetCommand { get; }
        private void OnResetCommandEcexute(object p)
        {
            Display = "";
        }
        private bool CanResetCommandExecuted(object p)
        {
            return true;
        }

        //backspace
        public ICommand EraseCommand { get; }
        private void OnEraseCommandExecuted(object p)
        {
           Display = Display.Remove((Display.Length - 1), 1);
        }
        private bool CanEraseCommandExecuted(object p)
        {
            if (Display == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        public MainWindowViewModel()
        {
            
            AddToDisplayCommand = new RelayCommand(OnAddToDisplayCommandExecute, CanAddToDIsplayCommandExecuted);
            SolveCommand = new RelayCommand(OnSolveCommand, CanSolveCommandExecuted);
            ResetCommand = new RelayCommand(OnResetCommandEcexute, CanResetCommandExecuted);
            EraseCommand = new RelayCommand(OnEraseCommandExecuted, CanEraseCommandExecuted);
        }
    }
}
