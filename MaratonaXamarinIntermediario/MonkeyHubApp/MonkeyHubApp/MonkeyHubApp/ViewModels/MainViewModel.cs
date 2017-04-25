using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private string _searchTerm;

        public string SearchTerm
        {
            get { return _searchTerm; }
            set
            {
                if (SetProperty<string>(ref _searchTerm, value))
                    SearchCommand.ChangeCanExecute();
            }
        }


        public Command SearchCommand { get; }

        public MainViewModel()
        {
            SearchCommand = new Command(ExcecuteSearchCommand, CanExcecuteSearchCommand);
        }

        private async void ExcecuteSearchCommand(object obj)
        {
            await Task.Delay(1000);
            bool r = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por {SearchTerm}?", "Sim", "Não");
            if (r)
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Obrigado","Ok");
            else
                await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "De nada", "Ok");
        }

        private bool CanExcecuteSearchCommand(object arg)
        {
            return !string.IsNullOrWhiteSpace(SearchTerm);
        }
    }
}
