using System;
using Microsoft.Maui.Controls;
using System.Timers;
using Microsoft.Maui.Graphics;
using Microsoft.AspNetCore.Components.Web;

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
        public void OnDraw(object sender, DrawEventArgs e)
        {
            var canvas = e.Canvas;
            // Draw bubbles here using canvas.DrawCircle(), etc.
            for (int i = 0; i < 10; i++)  // Create 10 bubbles
            {
                float x = (float)new Random().Next(0, 100);
                float y = (float)new Random().Next(0, 100);
                canvas.FillColor = Colors.Pink;
                canvas.DrawCircle(x, y, 25);
            }
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
