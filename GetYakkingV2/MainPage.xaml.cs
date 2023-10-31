using System;
using Microsoft.Maui.Controls;
using System.Timers;

namespace GetYakkingV2
{
    public partial class MainPage : ContentPage
    {
        private System.Timers.Timer timer;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnClassicClicked(object sender, EventArgs e)
        {
            ShowMessage("Welcome to classic GetYakking! ...");
        }

        private void OnCouplesClicked(object sender, EventArgs e)
        {
            ShowMessage("Welcome to couples Yakking! ...");
        }

        private void OnRiskyClicked(object sender, EventArgs e)
        {
            ShowMessage("Drunk Yakking is played ...");
        }

        private void ShowMessage(string message)
        {
            messageLabel.Text = message;
            messageLabel.Opacity = 0;
            messageLabel.FadeTo(1, 1000);
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += (sender, e) => messageLabel.FadeTo(0, 1000);
            timer.Start();
        }
    }
}
