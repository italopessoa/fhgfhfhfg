using Android.App;
using Android.Widget;
using Android.OS;
using MaratonaXamarin.Shared;
using System;
using System.Linq;

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

            button.Click += async (sender, e) =>
            {
                var api = new UserApi();
                var users = await api.ListAsync(new Developer
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "italo",
                    Email = "italo@italo.com",
                    City="Quixadá",
                    State = "CE"
                });

                listView.Adapter = new ArrayAdapter(this, 
                    Android.Resource.Layout.SimpleListItemSingleChoice,
                    users.OrderBy(y => y.Name).Select(x=> String.Format("{0}{1}",x.Id,x.Name)).ToArray()
                    );
            };
        }
    }
}

