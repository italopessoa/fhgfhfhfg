using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Gcm.Client;
using MonkeyHubApp.Droid.Services;

namespace MonkeyHubApp.Droid
{
    [Activity(Label = "MonkeyHubApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static MainActivity instance = null;
        public static MainActivity CurrentActivity => instance;

        protected override void OnCreate(Bundle bundle)
        {
            instance = this;
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            try
            {
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);
                System.Diagnostics.Debug.WriteLine("Registering...");
                GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
            }
            catch (Java.Net.MalformedURLException ex)
            {
                CreateAndShowDialog("There was an error creating the client. verify the URL.","Error");
            }
            catch(Exception ex)
            {
                CreateAndShowDialog(ex.Message, "Error");
            }
        }

        private void CreateAndShowDialog(string message, string title)
        {
            var builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }
    }
}

