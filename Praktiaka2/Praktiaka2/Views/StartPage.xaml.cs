using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Praktiaka2.Views
{
    public partial class StartPage : Page
    {
        public StartPage() => InitializeComponent();

        private void Start_Click(object sender, RoutedEventArgs e) =>
            NavigationService.Navigate(new GamePage());

        private void ThemeToggle_Click(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            var existingTheme = app.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Theme"));

            if (existingTheme != null) app.Resources.MergedDictionaries.Remove(existingTheme);

            string themeName = (existingTheme == null || existingTheme.Source.OriginalString.Contains("Light"))
                ? "DarkTheme.xaml" : "LightTheme.xaml";

            // Використовуємо Pack URI для стабільності
            string uriPath = $"pack://application:,,,/Resources/{themeName}";

            app.Resources.MergedDictionaries.Insert(0, new ResourceDictionary
            {
                Source = new Uri(uriPath, UriKind.Absolute)
            });
        }
    }
}