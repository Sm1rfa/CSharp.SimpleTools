using System.Windows;
using System.Windows.Controls;

namespace SimpleTools.View
{
    /// <summary>
    /// Interaction logic for AboutView.xaml
    /// </summary>
    public partial class AboutView : UserControl
    {
        public AboutView()
        {
            InitializeComponent();
        }

        private void Hyperlink_OnClick(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://softcreative.biz");
        }
    }
}
