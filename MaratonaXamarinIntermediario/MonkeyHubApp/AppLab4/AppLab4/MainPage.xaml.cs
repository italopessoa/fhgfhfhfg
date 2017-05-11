using AppLab4.Helpers;
using AppLab4.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLab4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
            Title = "Página Autenticada";
        }
    }

    public class MainPageViewModel : BaseViewModel
    {
        public string UserId => Settings.UserId;
        public string Token => Settings.AuthToken;
    }
}
