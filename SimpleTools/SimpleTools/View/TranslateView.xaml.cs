using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace SimpleTools.View
{
    /// <summary>
    /// Interaction logic for TranslateView.xaml
    /// </summary>
    public partial class TranslateView : UserControl
    {
        public TranslateView()
        {
            InitializeComponent();
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            Process.Start("http://translate.yandex.com/");
        }
    }
}
