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

        private static void ChangeTheme(Uri uri)
        {
            ThemeDictionary.Source = uri ;
        }

        public static void SetTheme(ThemeTypes theme)
        {
            string themeName = null!;
            CurrentTheme = theme;
            switch (theme)
            {
                case ThemeTypes.Dark: themeName = "DarkTheme"; break;
                case ThemeTypes.Light: themeName = "LightTheme"; break;
            }

            try
            {
                if (!string.IsNullOrEmpty(themeName))
                {
                    var str = new FileInfo($"../../../Themes/{themeName}.xaml").FullName;
                    ChangeTheme(new Uri(str));
                }
            }
            catch { }
        }
    }
}
