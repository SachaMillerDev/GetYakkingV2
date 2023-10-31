using System;
using Microsoft.Maui.Controls;
using System.Timers;
using Microsoft.Maui.Controls;


namespace GetYakkingV2
{
    public partial class CouplesPage : ContentPage
    {

        public CouplesPage(string message)
        {
            InitializeComponent();
            ShowMessage("Your initial message here");
        }

        private async void ShowMessage(string message)
        {
            messageLabel.Text = message;
            messageLabel.Opacity = 0;
            await messageLabel.FadeTo(1, 1000);
            await Task.Delay(5000);
            await messageLabel.FadeTo(0, 1000);
        }
    }
}
