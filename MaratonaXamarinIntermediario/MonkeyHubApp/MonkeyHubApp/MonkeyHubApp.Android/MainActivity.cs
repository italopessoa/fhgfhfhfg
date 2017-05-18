using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Gcm.Client;
using MonkeyHubApp.Droid.Services;
using Android.Content;
using Android.Support.V4.App;
using Android.Media;

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
            /*
            try
            {
                GcmClient.CheckDevice(this);
                GcmClient.CheckManifest(this);
                //System.Diagnostics.Debug.WriteLine("Registering...");
                GcmClient.Register(this, PushHandlerBroadcastReceiver.SENDER_IDS);
            }
            catch (Java.Net.MalformedURLException ex)
            {
                CreateAndShowDialog("There was an error creating the client. verify the URL.","Error");
            }
            catch(Exception ex)
            {
                CreateAndShowDialog(ex.Message, "Error");
            }*/
            CreateNotification("TUTUTU PAA", "DEU CERTO");
        }

        private void CreateAndShowDialog(string message, string title)
        {
            var builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }

        private void CreateNotification(string title, string desc)
        {
            //create notification
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            //create an intent to show ui
            var uiIntent = new Intent(this, typeof(MainActivity));

            //use notification builder
            NotificationCompat.Builder builder = new NotificationCompat.Builder(this);

            //Create the notification
            //we use the pending intent, passing our ui intent over which will get called
            //when the notification is tapped.
            var notification = builder.SetContentIntent(PendingIntent.GetActivity(this, 0, uiIntent, 0))

               .SetSmallIcon(Android.Resource.Drawable.SymActionEmail)
                .SetTicker(title)
                .SetContentTitle(title)
                .SetContentText(desc)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))//set the notification sound
                //http://stackoverflow.com/questions/39174818/vibrate-on-push-notification
                // Each element then alternates between delay, vibrate, sleep, vibrate, sleep
                .SetPriority((int)NotificationPriority.High)
                .SetVibrate(new long[] { 200, 300, 200, 300, 500 })
                .SetAutoCancel(true).Build();//Auto cancel will remove the notification once the user touches it

            notificationManager.Notify(1, notification);
        }
    }
}

