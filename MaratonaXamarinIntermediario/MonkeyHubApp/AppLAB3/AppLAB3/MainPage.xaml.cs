using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLAB3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            btnCarregar.Clicked += async (sender, e) =>
            {
                var tags = await Api.GetTagAsync();
                lvwTags.ItemsSource = tags;
            };
        }
    }
}
