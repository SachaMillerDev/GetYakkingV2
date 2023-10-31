using System;
using Microsoft.Maui.Controls;
using System.Timers;
using Xamarin.Forms;

namespace GetYakkingV2
{
    public partial class MainPage : ContentPage
    {
        System.Timers.Timer timer;

        public MainPage()
        {
            InitializeComponent();
            messageLabel = new Label { Opacity = 0 };
            MainGrid.Children.Add(messageLabel);
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
            timer = new Timer(5000);
            timer.Elapsed += (sender, e) => messageLabel.FadeTo(0, 1000);
            timer.Start();
        }
    }
}
}
