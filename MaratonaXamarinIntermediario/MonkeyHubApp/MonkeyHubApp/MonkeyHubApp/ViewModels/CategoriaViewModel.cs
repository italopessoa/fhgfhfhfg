using MonkeyHubApp.Models;
using MonkeyHubApp.Services;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace MonkeyHubApp.ViewModels
{
    public class CategoriaViewModel : BaseViewModel
    {
        private readonly IMonkeyHubApiService _monkeyHubApiService;
        private readonly Tag _tag;

        public ObservableCollection<Content> Contents { get; }
        public Command<Content> ShowContentCommand { get; }

        public CategoriaViewModel(IMonkeyHubApiService monkeyHubApiService, Tag tag)
        {
            _monkeyHubApiService = monkeyHubApiService;
            _tag = tag;

            Contents = new ObservableCollection<Content>();
            ShowContentCommand = new Command<Content>(ExecuteShowContentCommand);
        }

        private async void ExecuteShowContentCommand(Content content)
        {
            await PushAsync<ContentWebViewModel>(content);
        }

        public async Task LoadAsync()
        {
            var contents = await _monkeyHubApiService.GetContentByTagIdAsync(_tag.Id);
            Contents.Clear();
            foreach (var content in contents)
            {
                Contents.Add(content);
            }
        }
    }
}
