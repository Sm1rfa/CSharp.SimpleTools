using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace SimpleTools.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private bool isAboutClosed;

        private int selectedTabIndex;

        public RelayCommand AboutCommand { get; set; }

        public CalculatorViewModel CalculatorViewModel { get; set; }

        public TranslateViewModel TranslateViewModel { get; set; }

        public MapViewModel MapViewModel { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.CalculatorViewModel = new CalculatorViewModel();
            this.TranslateViewModel = new TranslateViewModel();
            this.MapViewModel = new MapViewModel();

            this.AboutCommand = new RelayCommand(this.OnAboutExecuted);
        }

        public bool IsAboutClosed
        {
            get
            {
                return this.isAboutClosed;

            }

            set
            {
                this.isAboutClosed = value;
                this.RaisePropertyChanged();
            }
        }

        public int SelectedTabIndex
        {
            get
            {
                return this.selectedTabIndex;
            }

            set
            {
                if (value == this.selectedTabIndex)
                {
                    return;
                }

                this.selectedTabIndex = value;
                this.RaisePropertyChanged();
            }
        }

        private void OnAboutExecuted()
        {
            this.IsAboutClosed = true;
        }
    }
}