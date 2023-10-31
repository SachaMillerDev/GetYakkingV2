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
            await Navigation.PushAsync(new ClassicPage("Welcome to classic GetYakking! ..."));
        }

        private async void OnCouplesClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CouplesPage("Welcome to couples Yakking! ..."));
        }

        private async void OnRiskyClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RiskyPage("Drunk Yakking is played ..."));
        }
    }
}
