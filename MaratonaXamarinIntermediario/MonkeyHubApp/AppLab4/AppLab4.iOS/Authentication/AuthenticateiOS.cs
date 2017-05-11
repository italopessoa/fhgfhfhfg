using AppLab4.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using AppLab4.iOS.Authentication;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateiOS))]
namespace AppLab4.iOS.Authentication
{
    public class AuthenticateiOS : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                return await client.LoginAsync(UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController,provider);
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
