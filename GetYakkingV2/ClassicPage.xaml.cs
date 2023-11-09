using System;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class ClassicPage : ContentPage
    {
        public ClassicPage()
        {
            InitializeComponent();
        }

        private async void OnCardTapped(object sender, EventArgs e)
        {
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

        private void OnRulesClicked(object sender, EventArgs e)
        {
            // Hide the card and show the rules
            card.IsVisible = false;
            rulesLabel.IsVisible = true;
        }

    }
}
