using AppLab4.Authentication;
using AppLab4.Helpers;
using AppLab4.Services;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(AzureService))]
namespace AppLab4.Services
{
    public class AzureService
    {
        static readonly string AppUrl = "";
        public MobileServiceClient Client { get; set; } = null;

        public void Initialize()
        {
            Client = new MobileServiceClient(AppUrl);
            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.Authenticate(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.UserId = string.Empty;
                Settings.AuthToken = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops", "Não conseguimos efetuar o seu login, tente novamente", "OK");
                });

                return false;
            }
            else
            {
                Settings.UserId = user.UserId;
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
            }
            return true;
        }
    }
}
