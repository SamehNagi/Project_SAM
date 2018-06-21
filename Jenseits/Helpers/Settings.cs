using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Jenseits.Helpers
{
    public static class Settings
    {
        static ISettings AppSettings
        {
            get
            {
                if (CrossSettings.IsSupported)
                    return CrossSettings.Current;

                return null;
            }
        }
        
        public static string UserName
        {
            get => AppSettings.GetValueOrDefault(nameof(UserName), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(UserName), value);
        }
    }
}
