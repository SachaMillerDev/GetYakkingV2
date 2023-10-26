using System;
using Microsoft.Maui.Controls;
using System.Timers;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace GetYakkingV2
{
    public partial class MainPage : ContentPage
    {
        System.Timers.Timer timer;
        List<SKPoint> bubbles = new List<SKPoint>();

        public MainPage()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000);
            timer.Elapsed += CreateBubble;
            timer.Start();
        }

        private void CreateBubble(object sender, ElapsedEventArgs e)
        {
            Random rand = new Random();
            SKPoint newBubble = new SKPoint(rand.Next(0, 300), 600);
            bubbles.Add(newBubble);

            // Invalidate the SkiaSharp canvas to trigger a redraw
            BubbleCanvas.InvalidateSurface();
        }

        private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            foreach (var bubble in bubbles)
            {
                canvas.DrawCircle(bubble, 25, new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.Blue
                });
            }

            // Update bubble positions for next draw
            for (int i = 0; i < bubbles.Count; i++)
            {
                bubbles[i] = new SKPoint(bubbles[i].X, bubbles[i].Y - 5);
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
