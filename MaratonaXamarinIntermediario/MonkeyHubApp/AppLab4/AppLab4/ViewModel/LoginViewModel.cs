using AppLab4.Helpers;
using AppLab4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppLab4.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        AzureService azureService;
        INavigation navigation;

        ICommand loginCommand;
        public ICommand LoginCommand => loginCommand ?? (loginCommand = new Command(async () => await ExecuteLoginCommandAsync()));

        public LoginViewModel()
        {
            azureService = DependencyService.Get<AzureService>();
            //navigation = nav;
            Title = "Social Login demo";
        }

        private async Task ExecuteLoginCommandAsync()
        {
            if (IsBusy || !(await LoginAsync()))
            {
                return;
            }
            else
            {
                var mainPage = new MainPage();
                try
                {
                    await Application.Current.MainPage.Navigation.PushAsync(mainPage);
                }catch(Exception ex)
                {
                    throw ex;
                }
                RemovePageFromStack();
            }
        }

        private void RemovePageFromStack()
        {
            try
            {

            var existingPages = Application.Current.MainPage.Navigation.NavigationStack.ToList();
            foreach (var page in existingPages)
            {
                if (page.GetType() == typeof(LoginPage))
                        Application.Current.MainPage.Navigation.RemovePage(page);
            }
            }
            catch( Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> LoginAsync()
        {
            if (Settings.IsLoggedIn())
                return Task.FromResult(true);
            return azureService.LoginAsync();
        }
    }
}
