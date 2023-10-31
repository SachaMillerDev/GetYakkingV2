using System;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnClassicClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClassicPage());
        }

        private async void OnCouplesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CouplesPage());
        }

        private async void OnRiskyClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RiskyPage());
        }
    }
}
