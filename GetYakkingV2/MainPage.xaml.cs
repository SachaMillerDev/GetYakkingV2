using System;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            InitializeVideoBackground();
        }

        void InitializeVideoBackground()
        {
            var videoHtml = @"
                <html>
                    <body style='margin: 0; padding: 0; overflow: hidden;'>
                        <video width='100%' height='100%' autoplay loop muted>
                            <source src='C:\Users\SachaMiller\Downloads\planksip™ loopable bubble background.mp4' type='video/mp4'>
                        </video>
                    </body>
                </html>";
            VideoBackground.Source = new HtmlWebViewSource { Html = videoHtml };
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
