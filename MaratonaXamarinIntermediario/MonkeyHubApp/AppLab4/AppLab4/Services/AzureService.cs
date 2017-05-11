using AppLab4.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLab4.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "";
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
        }

        public async Task<MobileServiceUser> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if(user == null)
            {
                Device.BeginInvokeOnMainThread(async ()=>
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Não conseguimos efetuar o seu login, tente novamente", "OK");
                });

                return null;
            }

            return user;
        }
    }
}
