using System.Windows;

namespace Praktiaka2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Завантажуємо стартову сторінку в наш Frame
            MainFrame.Navigate(new Views.StartPage());
        }
    }
}