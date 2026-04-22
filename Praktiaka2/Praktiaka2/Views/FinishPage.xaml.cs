namespace Praktiaka2.Views
{
    public partial class FinishPage : System.Windows.Controls.Page
    {
        public FinishPage()
        {
            InitializeComponent();
        }

        public FinishPage(string playerName, int score) : this()
        {
            
            ResultText.Text = $"{playerName}, вітаємо! \nВаш результат: {score} балів";
        }

        private void ToMenu_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService?.Navigate(new StartPage());
        }
    }
}