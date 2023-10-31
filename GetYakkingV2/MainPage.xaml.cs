using System;
using Microsoft.Maui.Controls;
using System.Timers;

namespace GetYakkingV2
{
    public partial class MainPage : ContentPage
    {
        System.Timers.Timer timer;

        public MainPage()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000);
            timer.Start();
        }

        private void OnClassicClicked(object sender, EventArgs e)
        {
            // Start Classic game
        }

        private void OnCouplesClicked(object sender, EventArgs e)
        {
            // Start Couples game
        }

        private void OnRiskyClicked(object sender, EventArgs e)
        {
            // Start Risky game
        }
    }
}
