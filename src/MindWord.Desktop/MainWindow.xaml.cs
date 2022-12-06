﻿using MindWord.Desktop.Themes;
using MindWord.Domain.Entities;
using System.Windows;

namespace MindWord.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void rdHome_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new System.Uri("Pages/HomePage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private void rdSettings_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new System.Uri("Pages/SettingsPage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private void Themes_Click(object sender, RoutedEventArgs e)
        {
            if (Themes.IsChecked == true)
                ThemesController.SetTheme(ThemesController.ThemeTypes.Light);
            else
                ThemesController.SetTheme(ThemesController.ThemeTypes.Dark);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void rdWords_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new System.Uri("Pages/WordPage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private void rdGame_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new System.Uri("Pages/GamePage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private void rdTitle_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new System.Uri("Pages/TitlePage.xaml", System.UriKind.RelativeOrAbsolute));
        }

        private void rdTranslate_Click(object sender, RoutedEventArgs e)
        {
            frameContent.Navigate(new System.Uri("Pages/TranslatePage.xaml", System.UriKind.RelativeOrAbsolute));
        }
    }
}
