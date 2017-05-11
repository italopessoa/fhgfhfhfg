using AppLab4.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using AppLab4.iOS.Authentication;
using AppLab4.Helpers;

[assembly: Xamarin.Forms.Dependency(typeof(AuthenticateiOS))]
namespace AppLab4.iOS.Authentication
{
    public class AuthenticateiOS : IAuthentication
    {
        public async Task<MobileServiceUser> Authenticate(MobileServiceClient client, MobileServiceAuthenticationProvider provider)
        {
            try
            {
                var current = GetController();
                var user = await client.LoginAsync(current, provider);
                //var user = await client.LoginAsync(UIKit.UIApplication.SharedApplication.KeyWindow.RootViewController,provider);
                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            if (root == null) return null;

            var current = root;
            while (current.PresentedViewController != null)
            {
                current = current.PresentedViewController;
            }

            return current;
        }
    }
}
