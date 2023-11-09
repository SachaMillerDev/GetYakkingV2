using System;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class ClassicPage : ContentPage
    {
        public ClassicPage()
        {
            InitializeComponent();
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            if (frontView.IsVisible)
            {
                await card.ScaleYTo(0.1, 150, Easing.Linear);
                frontView.IsVisible = false;
                backView.IsVisible = true;
                await card.ScaleYTo(1, 150, Easing.Linear);
            }
            else
            {
                await card.ScaleYTo(0.1, 150, Easing.Linear);
                backView.IsVisible = false;
                frontView.IsVisible = true;
                await card.ScaleYTo(1, 150, Easing.Linear);
            }
        }
    }
}
