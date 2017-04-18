using Android.App;
using Android.Widget;
using Android.OS;

namespace MaratonaXamarin.AndroidApp
{
    [Activity(Label = "MaratonaXamarin.AndroidApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            var button = this.FindViewById<Button>(Resource.Id.btnCarregar);
            var listView = this.FindViewById<ListView>(Resource.Id.lvwItens);

            button.Click += (sender, e) =>
            {

            };
        }
    }
}

