using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        public Command AboutCommand { get; }

        public Command<Tag> ShowCategoriaCommand { get; }

        public ObservableCollection<Tag> Tags { get; }

        private readonly IMonkeyHubApiService _monkeyHubApiService;

        public MainViewModel(IMonkeyHubApiService monkeyHubApiService)
        {
            _monkeyHubApiService = monkeyHubApiService;
            SearchCommand = new Command(ExcecuteSearchCommand);//, CanExcecuteSearchCommand);
            AboutCommand = new Command(ExecutaAboutCommand);

            ShowCategoriaCommand = new Command<Tag>(ExecuteShowCategoriaCommand);

            Tags = new ObservableCollection<Tag>();
        }

        public async Task LoadAsync()
        {
            var tags = await _monkeyHubApiService.GetTagsAsync();

            //System.Diagnostics.Debug.WriteLine("FOUND {0} TAGS", tags.Count);
            Tags.Clear();
            foreach (var tag in tags)
            {
                Tags.Add(tag);
            }

            OnPropertyChanged(nameof(Tags));
        }

        private async void ExecuteShowCategoriaCommand(Tag tag)
        {
            await PushAsync<CategoriaViewModel>(_monkeyHubApiService,tag);
        }


        //private const string BaseUrl = "https://monkey-hub-api.azurewebsites.net/api/";

        private async void ExcecuteSearchCommand(object obj)
        {
            await PushAsync<SearchViewModel>(_monkeyHubApiService);
            //await Task.Delay(1000);
            //bool r = await App.Current.MainPage.DisplayAlert("MonkeyHubApp", $"Você pesquisou por {SearchTerm}?", "Sim", "Não");
            //if (r)
            //{
            //    await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "Obrigado", "Ok");
            //    List<Tag> res = await _monkeyHubApiService.GetTagsAsync();
            //    foreach (Tag item in res)
            //    {
            //        Tags.Add(item);
            //    }
            //}
            //else
            //{
            //    await App.Current.MainPage.DisplayAlert("MonkeyHubApp", "De nada", "Ok");
            //    //Resultados.Add("Não");
            //}
        }

        private bool CanExcecuteSearchCommand(object arg)
        {
            return !string.IsNullOrWhiteSpace(SearchTerm);
        }

        private async void ExecutaAboutCommand(object obj)
        {
            await PushAsync<AboutViewModel>();
        }
    }
}
