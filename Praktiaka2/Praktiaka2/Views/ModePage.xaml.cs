using System.Windows;
using System.Windows.Controls;

namespace Praktiaka2.Views
{
    public partial class ModePage : Page
    {
        public ModePage()
        {
            InitializeComponent();
        }

        private void Classic_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new GamePage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}