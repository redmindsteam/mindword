using System;
using System.IO;
using System.Windows;

namespace MindWord.Desktop.Themes
{
    public class ThemesController
    {
        public static ThemeTypes CurrentTheme { get; set; }

        public enum ThemeTypes
        {
            Light, Dark
        }

        public static ResourceDictionary ThemeDictionary
        {
            get { return Application.Current.Resources.MergedDictionaries[0]; }
            set { Application.Current.Resources.MergedDictionaries[0] = value; }
        }

        public static ResourceDictionary MaterialDictionary
        {
            get { return Application.Current.Resources.MergedDictionaries[2]; }
            set { Application.Current.Resources.MergedDictionaries[2] = value; }
        }

        private static void ChangeTheme(Uri uri, Uri uri2)
        {
            ThemeDictionary.Source = uri ;
            MaterialDictionary.Source = uri2;
        }

        public static void SetTheme(ThemeTypes theme)
        {
            string themeName = null!;
            CurrentTheme = theme;
            switch (theme)
            {
                case ThemeTypes.Dark: themeName = "Dark"; break;
                case ThemeTypes.Light: themeName = "Light"; break;
            }

            try
            {
                if (!string.IsNullOrEmpty(themeName))
                {
                    var str = new FileInfo($"../../../Themes/{themeName}Theme.xaml").FullName;
                    var str2 = new FileInfo($"/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.{themeName}.xaml").FullName;
                    ChangeTheme(new Uri(str), new Uri(str2));

                }
            }
            catch { }
        }
    }
}
