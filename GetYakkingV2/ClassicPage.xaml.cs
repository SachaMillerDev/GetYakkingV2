using System;
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

        private void OnRulesClicked(object sender, EventArgs e)
        {
            areRulesVisible = !areRulesVisible;
            card.IsVisible = !areRulesVisible;
            rulesLabel.IsVisible = areRulesVisible;
            // Update the text of the rules button based on the state
            rulesButton.Text = areRulesVisible ? " Hide " : " Rules ";
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
            flipCounter++; // Increment the flip counter
            UpdateFlipCounterDisplay(); // Update the display of the flip counter

            if (frontView.IsVisible)
            {
                await frontView.RotateYTo(-90, 250); // Rotate halfway
                frontView.IsVisible = false;
                backView.IsVisible = true;
                backView.RotationY = -270; // Set rotation to -270 degrees to prepare for flip back
                await backView.RotateYTo(-360, 250); // Rotate the rest of the way
            }
            else
            {
                await backView.RotateYTo(-270, 250); // Rotate halfway
                backView.IsVisible = false;
                frontView.IsVisible = true;
                frontView.RotationY = -90; // Set rotation to -90 degrees to prepare for flip back
                await frontView.RotateYTo(0, 250); // Rotate the rest of the way
            }
        }

        private void UpdateFlipCounterDisplay()
        {
            // Assuming you have a Label in your XAML for displaying the flip count
            flipCounterLabel.Text = $"Flips - {flipCounter}";
        }
    }
}
