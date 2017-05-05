using System;
using System.Collections.ObjectModel;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace SimpleTools.ViewModel
{
    public class CalculatorViewModel : ViewModelBase
    {
        #region private fields
        private decimal percentFrom;
        private decimal sumFrom;
        private decimal resultFrom;
        private decimal percentForSum;
        private decimal sumForSum;
        private decimal resultForSum;
        private decimal num1;
        private decimal num2;
        private decimal numResult;
        private string selectedOption;
        #endregion

        public RelayCommand CalculatePercentFromCommand { get; set; }
        public RelayCommand CalculateSumFromPercentegeCommand { get; set; }
        public RelayCommand BasicCalculationCommand { get; set; }

        public ObservableCollection<string> OptionList { get; set; }

        public CalculatorViewModel()
        {
            this.CalculatePercentFromCommand = new RelayCommand(this.PercentOfSum);
            this.CalculateSumFromPercentegeCommand = new RelayCommand(this.SumOfPercentege);
            this.BasicCalculationCommand = new RelayCommand(this.BasicCalculation);

            this.OptionList = new ObservableCollection<string>{ "+", "-", "*", "/"};
        }

        #region public properties
        public decimal PercentFrom
        {
            get
            {
                return this.percentFrom;
            }

            set
            {
                this.percentFrom = value;
                this.RaisePropertyChanged();
            }
        }

        public decimal SumFrom
        {
            get
            {
                return this.sumFrom;
            }

            set
            {
                this.sumFrom = value;
                this.RaisePropertyChanged();
            }
        }

        public decimal ResultFrom
        {
            get
            {
                return this.resultFrom;
            }

            set
            {
                this.resultFrom = value;
                this.RaisePropertyChanged();
            }
        }

        public decimal PercentForSum
        {
            get
            {
                return this.percentForSum;
            }

            set
            {
                this.percentForSum = value;
                this.RaisePropertyChanged();
            }
        }

        public decimal SumForSum
        {
            get
            {
                return this.sumForSum;
            }

            set
            {
                this.sumForSum = value;
                this.RaisePropertyChanged();
            }
        }

        public decimal ResultForSum
        {
            get
            {
                return this.resultForSum;
            }

            set
            {
                this.resultForSum = value;
                this.RaisePropertyChanged();
            }
        }

        public decimal Number1
        {
            get
            {
                return this.num1;
            }

            set
            {
                this.num1 = value;
                this.RaisePropertyChanged();
            }
        }

        public decimal Number2
        {
            get
            {
                return this.num2;
            }

            set
            {
                this.num2 = value;
                this.RaisePropertyChanged();
            }
        }

        public decimal NumberResult
        {
            get
            {
                return this.numResult;
            }

            set
            {
                this.numResult = value;
                this.RaisePropertyChanged();
            }
        }

        public string SelectedOption
        {
            get
            {
                return this.selectedOption;

            }

            set
            {
                this.selectedOption = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        private void PercentOfSum()
        {
            var result = this.PercentFrom / this.SumFrom * 100;
            this.ResultFrom = Math.Round(result, 2);
        }

        private void SumOfPercentege()
        {
            var result = this.SumForSum / (100 / this.PercentForSum);
            this.ResultForSum = Math.Round(result, 2);
        }

        private void BasicCalculation()
        {
            switch (this.SelectedOption)
            {
                case "+":
                    this.NumberResult = this.Number1 + this.Number2;
                    break;
                case "-":
                    this.NumberResult = this.Number1 - this.Number2;
                    break;
                case "*":
                    this.NumberResult = this.Number1 * this.Number2;
                    break;
                case "/":
                    this.NumberResult = this.Number1 / this.Number2;
                    break;
                default:
                    MessageBox.Show("Enter values!", "Info");
                    break;
            }
        }
    }
}
