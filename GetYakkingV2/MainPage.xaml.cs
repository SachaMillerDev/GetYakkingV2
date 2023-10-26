using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Timers;
using Android.Graphics;
using Microsoft.Maui.Controls.Shapes;

namespace GetYakkingV2
{
    public partial class MainPage : ContentPage
    {
        System.Timers.Timer timer;


        public MainPage()
        {
            InitializeComponent();
            timer = new Timer(1000); // Create a bubble every 1 second
            timer.Elapsed += CreateBubble;
            timer.Start();
        }

        private void CreateBubble(object sender, ElapsedEventArgs e)
        {
            Device.InvokeOnMainThreadAsync(() =>
            {
                // Create a new bubble
                var bubble = new Ellipse
                {
                    WidthRequest = 50,
                    HeightRequest = 50,
                    Fill = Brushes.Blue,
                    Stroke = Brushes.White,
                    StrokeThickness = 2
                };

                // Add the bubble to the Canvas
                BubbleCanvas.Children.Add(bubble);
                Canvas.SetLeft(bubble, new Random().Next(0, 300)); // Random starting position
                Canvas.SetTop(bubble, 600); // Start at the bottom

                // Animate the bubble upwards
                var animation = new Animation(callback: d => Canvas.SetTop(bubble, 600 - d),
                                              start: 0,
                                              end: 600,
                                              easing: Easing.Linear);

                animation.Commit(this, "BubbleAnimation", length: 5000, finished: (d, b) => BubbleCanvas.Children.Remove(bubble));
            });
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
