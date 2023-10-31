using System;
using Microsoft.Maui.Controls;
using System.Timers;
using Microsoft.Maui.Controls;


namespace GetYakkingV2
{
    public partial class RiskyPage : ContentPage
    {
        private System.Timers.Timer timer;

        public RiskyPage(string message)
        {
            InitializeComponent();
            ShowMessage(message);
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
