using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using Extensions.TranslateHelper;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace SimpleTools.ViewModel
{
    public class TranslateViewModel : ViewModelBase
    {
        private Translator langTranslator;
        private string textToTrans;
        private string fromLang;
        private string toLang;
        private string translation;
        private Language selectedFrom;
        private Language selectedTo;

        public RelayCommand TranslateCommand { get; set; }
        public RelayCommand CopyTextCommand { get; set; }

        public ObservableCollection<Language> FromLanguageCollection { get; set; }
        public ObservableCollection<Language> ToLanguageCollection { get; set; }

        public TranslateViewModel()
        {
            this.langTranslator = new Translator();
            this.AddLanguagesFrom();
            this.AddLanguagesTo();

            this.TranslateCommand = new RelayCommand(this.TranslateTheText);
            this.CopyTextCommand = new RelayCommand(this.CopyText);
        }

        #region public properties
        public string TextToTranslate
        {
            get
            {
                return this.textToTrans;
            }

            set
            {
                this.textToTrans = value;
                this.RaisePropertyChanged();
            }
        }

        public string FromLanguage
        {
            get
            {
                return this.fromLang;
            }

            set
            {
                this.fromLang = value;
                this.RaisePropertyChanged();
            }
        }

        public string ToLanguage
        {
            get
            {
                return this.toLang;
            }

            set
            {
                this.toLang = value;
                this.RaisePropertyChanged();
            }
        }

        public string TranslatedText
        {
            get
            {
                return this.translation;
            }

            set
            {
                this.translation = value;
                this.RaisePropertyChanged();
            }
        }

        public Language SelectedFrom
        {
            get
            {
                return this.selectedFrom;
            }

            set
            {
                this.selectedFrom = value;
                this.RaisePropertyChanged();
            }
        }

        public Language SelectedTo
        {
            get
            {
                return this.selectedTo;
            }

            set
            {
                this.selectedTo = value;
                this.RaisePropertyChanged();
            }
        }
        #endregion

        private void AddLanguagesFrom()
        {
            this.FromLanguageCollection = new ObservableCollection<Language>();
            foreach (var item in langTranslator.LanguageList)
            {
                this.FromLanguageCollection.Add(item);
            }
        }

        private void AddLanguagesTo()
        {
            this.ToLanguageCollection = new ObservableCollection<Language>();
            foreach (var item in langTranslator.LanguageList)
            {
                this.ToLanguageCollection.Add(item);
            }
        }

        private void CopyText()
        {
            if (string.IsNullOrEmpty(this.TranslatedText))
            {
                MessageBox.Show("No text for copy!");
            }
            else
            {
                Clipboard.SetText(this.TranslatedText);
            }
        }

        private void TranslateTheText()
        {
            if (this.TextToTranslate != string.Empty)
            {
                // this.textToTrans = this.TextToTranslate;
                fromLang = this.SelectedFrom.langCode;
                toLang = SelectedTo.langCode;

                this.TranslatedText = string.Empty;

                Thread td = new Thread(GetTranslation);
                td.Start();
            }
            else
            {
                MessageBox.Show("Enter text to translate.", "Translator", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void GetTranslation()
        {
            translation = langTranslator.GetTranslatedText(textToTrans, fromLang, toLang);
            this.ShowTranslatedText();
            //this.Dispatcher.BeginInvoke(new ThreadStart(ShowTranslatedText), DispatcherPriority.Normal, null);
        }

        private void ShowTranslatedText()
        {
            this.TranslatedText = translation;
        }
    }
}
