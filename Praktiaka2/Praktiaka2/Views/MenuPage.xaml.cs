using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Praktiaka2.Models;

namespace Praktiaka2.Views
{
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NicknameText.Text = UserProfile.Nickname;

            if (UserProfile.AvatarPath != "")
                AvatarBrush.ImageSource = new BitmapImage(new Uri(UserProfile.AvatarPath));
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ModePage());
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProfilePage());
        }

        private void Theme_Click(object sender, RoutedEventArgs e)
        {
            var app = (App)Application.Current;
            var existingTheme = app.Resources.MergedDictionaries
                .FirstOrDefault(d => d.Source != null && d.Source.OriginalString.Contains("Theme"));

            if (existingTheme != null) app.Resources.MergedDictionaries.Remove(existingTheme);

            string themeName = (existingTheme == null || existingTheme.Source.OriginalString.Contains("Light"))
                ? "DarkTheme.xaml" : "LightTheme.xaml";

            app.Resources.MergedDictionaries.Insert(0, new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/Resources/{themeName}", UriKind.Absolute)
            });
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}