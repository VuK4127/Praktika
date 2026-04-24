using System.Windows;
using System.Windows.Controls;

namespace Praktiaka2.Views
{
    public partial class FinishPage : Page
    {
        public FinishPage() => InitializeComponent();

        public FinishPage(string name, int score) : this()
        {
            ResultText.Text = $"{name}, ти набрав {score} балів!";
        }

        private void ToMenu_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StartPage());
        }
    }
}