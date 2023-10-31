using System;
using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace GetYakkingV2
{
    public partial class ClassicPage : ContentPage
    {
        public ClassicPage()
        {
            InitializeComponent();
        }

        private async void OnButton1Clicked(object sender, EventArgs e)
        {
            messageLabel.Text = "text";
            messageLabel.Opacity = 0;
            await messageLabel.FadeTo(1, 1000);
            await Task.Delay(5000);
            await messageLabel.FadeTo(0, 1000);
        }
    }
}
