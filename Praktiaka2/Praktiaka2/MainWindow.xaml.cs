using System.Windows;

namespace Praktiaka2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Views.MenuPage());
        }
    }
}