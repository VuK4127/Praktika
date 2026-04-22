using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Praktiaka2.Views
{
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void StartGame_Click(object sender, RoutedEventArgs e)
        {
            // Перехід на сторінку гри
            NavigationService.Navigate(new GamePage());
        }
    }
}