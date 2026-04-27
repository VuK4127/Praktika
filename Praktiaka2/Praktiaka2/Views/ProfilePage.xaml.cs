using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Praktiaka2.Models;

namespace Praktiaka2.Views
{
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();

            NicknameBox.Text = UserProfile.Nickname;

            if (UserProfile.AvatarPath != "")
                AvatarBrush.ImageSource = new BitmapImage(new Uri(UserProfile.AvatarPath));
        }

        private void ChangeAvatar_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Зображення|*.png;*.jpg;*.jpeg;*.bmp";

            if (dlg.ShowDialog() == true)
            {
                UserProfile.AvatarPath = dlg.FileName;
                AvatarBrush.ImageSource = new BitmapImage(new Uri(dlg.FileName));
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (NicknameBox.Text.Trim() != "")
                UserProfile.Nickname = NicknameBox.Text.Trim();

            MessageBox.Show("Збережено!");
            NavigationService.GoBack();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}