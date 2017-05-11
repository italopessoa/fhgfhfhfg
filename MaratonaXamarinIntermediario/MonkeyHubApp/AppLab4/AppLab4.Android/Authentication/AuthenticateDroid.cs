using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppLab4.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using AppLab4.Droid.Authentication;
using AppLab4.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateDroid))]
namespace AppLab4.Droid.Authentication
{
    public class AuthenticateDroid : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                var user = await client.LoginAsync(Xamarin.Forms.Forms.Context, provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}