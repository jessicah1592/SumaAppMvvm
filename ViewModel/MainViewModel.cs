using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SumaAppMvvm.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _valor1;
        private string _valor2;
        private string _resultado;

        public string Valor1
        {
            get => _valor1;
            set
            {
                _valor1 = value;
                OnPropertyChanged(nameof(Valor1));
            }
        }

        public string Valor2
        {
            get => _valor2;
            set
            {
                _valor2 = value;
                OnPropertyChanged(nameof(Valor2));
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }

        public ICommand SumarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public MainViewModel()
        {
            SumarCommand = new Command(OnSumar);
            LimpiarCommand = new Command(OnLimpiar);
        }

        private void OnSumar()
        {
            if (string.IsNullOrEmpty(Valor1) || string.IsNullOrEmpty(Valor2))
            {
                Resultado = "Debe ingresar ambos valores.";
                return;
            }

            if (double.TryParse(Valor1, out double val1) && double.TryParse(Valor2, out double val2))
            {
                Resultado = (val1 + val2).ToString();
            }
            else
            {
                Resultado = "Valores inválidos.";
            }
        }

        private void OnLimpiar()
        {
            Valor1 = string.Empty;
            Valor2 = string.Empty;
            Resultado = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
