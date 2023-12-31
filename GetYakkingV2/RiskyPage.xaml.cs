﻿using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class RiskyPage : ContentPage
    {
        private bool areRulesVisible = false;
        private int flipCounter = 0; // Counter for card flips

        public RiskyPage()
        {
            InitializeComponent();
        }

        private async Task AnimateButton(Button button)
        {
            // Scale up slightly over a longer duration
            await button.ScaleTo(1.1, 100, Easing.Linear);
            // Scale back to original size
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


        private async void OnCardTapped(object sender, EventArgs e)
        {
            card.Shadow = null; // Disable the shadow during the flip animation

            await frontView.RotateYTo(90, 250); // Rotate to 90 degrees
            frontView.IsVisible = false;
            backView.IsVisible = true;
            backView.RotationY = -90; // Set rotation to -90 degrees for backView
            await backView.RotateYTo(0, 250); // Rotate to 0 degrees
            flipCounter++;
            UpdateFlipCounterDisplay();

            card.Shadow = new Shadow // Re-enable the shadow after the flip animation completes
            {
                Brush = Brush.Black,
                Offset = new Point(5f, 5f),
                Opacity = 0.8f,
                Radius = 10
            };
        }

        private async void OnBackCardTapped(object sender, EventArgs e)
        {
            card.Shadow = null; // Disable the shadow during the flip animation

            await backView.RotateYTo(90, 250); // Rotate to 90 degrees
            backView.IsVisible = false;
            frontView.IsVisible = true;
            frontView.RotationY = -90; // Set rotation to -90 degrees for frontView
            await frontView.RotateYTo(0, 250); // Rotate to 0 degrees

            card.Shadow = new Shadow // Re-enable the shadow after the flip animation completes
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
