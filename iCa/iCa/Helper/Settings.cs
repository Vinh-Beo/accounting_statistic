using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Common
{
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
        public static bool IsRemember
        {
            get => AppSettings.GetValueOrDefault(nameof(IsRemember), true);
            set => AppSettings.AddOrUpdateValue(nameof(IsRemember), value);
        }
        public static bool Language
        {
            get => AppSettings.GetValueOrDefault(nameof(Language), false);
            set => AppSettings.AddOrUpdateValue(nameof(Language), value);
        }
        public static bool IsDarkMode
        {
            get => AppSettings.GetValueOrDefault(nameof(IsDarkMode),false);
            set => AppSettings.AddOrUpdateValue(nameof(IsDarkMode), value);
        }
    }
}
