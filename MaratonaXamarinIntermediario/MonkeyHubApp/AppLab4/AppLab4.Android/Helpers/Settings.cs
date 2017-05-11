// Helpers/Settings.cs This file was automatically added when you installed the Settings Plugin. If you are not using a PCL then comment this file back in to use it.
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace AppLab4.Droid.Helpers
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

        //#region Setting Constants

        //private const string SettingsKey = "settings_key";
        //private static readonly string SettingsDefault = string.Empty;

        //#endregion


        //public static string GeneralSettings
        //{
        //  get
        //  {
        //    return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
        //  }
        //  set
        //  {
        //    AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
        //  }
        //}

        //private static ISettings AppSettings => CrossSettings.Current;

        const string UserIdKey = "userid";
        static readonly string UserIdDefault = string.Empty;

        const string AuthTokenKey = "authtoken";
        static readonly string AuthTokenDefault = string.Empty;

        public static string AuthToken
        {
            get { return AppSettings.GetValueOrDefault<string>(AuthTokenKey, AuthTokenDefault); }
            set { AppSettings.AddOrUpdateValue<string>(AuthTokenKey, value); }
        }

        public static string UserId
        {
            get { return AppSettings.GetValueOrDefault<string>(UserIdKey, UserIdDefault); }
            set { AppSettings.AddOrUpdateValue<string>(UserIdKey, value); }
        }

        public static bool IsLoggedIn()
        {
            try
            {
                return string.IsNullOrWhiteSpace(UserId);

            }
            catch (System.Exception ex)
            {

                return false;
            }
        }
    }
}