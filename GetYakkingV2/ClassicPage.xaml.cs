using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class ClassicPage : ContentPage
    {
        private bool areRulesVisible = false;
        private int flipCounter = 0; // Counter for card flips

        public ClassicPage()
        {
            InitializeComponent();
        }

        private async Task AnimateButton(Button button)
        {
            await button.ScaleTo(1.5, 100, Easing.Linear);
            await button.ScaleTo(1.0, 100, Easing.Linear);
        }

        private async void OnRulesClicked(object sender, EventArgs e)
        {
            await AnimateButton((Button)sender);
            areRulesVisible = !areRulesVisible;
            card.IsVisible = !areRulesVisible;
            rulesLabel.IsVisible = areRulesVisible;
            rulesButton.Text = areRulesVisible ? "Hide" : "Rules";
        }

        private async void OnScoreClicked(object sender, EventArgs e)
        {
            await AnimateButton((Button)sender);
            // Add logic for Score button click
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            card.Shadow = null;
            await frontView.RotateYTo(90, 250);
            frontView.IsVisible = false;
            backView.IsVisible = true;
            flipCounterLabel.IsVisible = true; // Show flip counter on back card
            backView.RotationY = -90;
            await backView.RotateYTo(0, 250);
            flipCounter++;
            UpdateFlipCounterDisplay();
            card.Shadow = new Shadow
            {
                Brush = Brush.Black,
                Offset = new Point(5f, 5f),
                Opacity = 0.8f,
                Radius = 10
            };
        }

        private async void OnBackCardTapped(object sender, EventArgs e)
        {
            card.Shadow = null;
            await backView.RotateYTo(90, 250);
            backView.IsVisible = false;
            frontView.IsVisible = true;
            flipCounterLabel.IsVisible = false; // Hide flip counter when front card is visible
            frontView.RotationY = -90;
            await frontView.RotateYTo(0, 250);
            card.Shadow = new Shadow
            {
                Brush = Brush.Black,
                Offset = new Point(5f, 5f),
                Opacity = 0.8f,
                Radius = 10
            };
        }

        private void UpdateFlipCounterDisplay()
        {
            flipCounterLabel.Text = $"Flips - {flipCounter}";
        }
    }
}
