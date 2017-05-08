using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using MonkeyHubApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MonkeyHubApp
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel ViewModel => BindingContext as MainViewModel;
        public MainPage(IMonkeyHubApiService monkeyHubApiService)
        {
            InitializeComponent();
            //var monkeyHubApiService =  DependencyService.Get<IMonkeyHubApiService>()
            BindingContext = new MainViewModel(monkeyHubApiService);

            //lvwTags.ItemSelected += (sender, e) =>
            //{
            //    ViewModel.ShowCategoriaCommand.Execute(e.SelectedItem);
            //};
        }

        public MainPage()
        {
            InitializeComponent();
            var monkeyHubApiService = DependencyService.Get<IMonkeyHubApiService>();
            BindingContext = new MainViewModel(monkeyHubApiService);
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var tag = (sender as ListView)?.SelectedItem as Tag;
            (BindingContext as MainViewModel)?.ShowCategoriaCommand.Execute(tag);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (ViewModel != null)
                await ViewModel.LoadAsync();
        }

       
    }
}
