﻿using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace GetYakkingV2;

public partial class CouplesPage : ContentPage
{
    private bool areRulesVisible = false;
    private int flipCounter = 0; // Counter for card flips

    public CouplesPage()
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

    private async void OnCardTapped(object sender, EventArgs e)
    {
        await FlipCard(frontView, backView);
    }

    private async void OnBackCardTapped(object sender, EventArgs e)
    {
        await FlipCard(backView, frontView);
    }

    private async Task FlipCard(View fromView, View toView)
    {
        card.Shadow = null;
        await fromView.RotateYTo(90, 250);
        fromView.IsVisible = false;
        toView.IsVisible = true;
        toView.RotationY = -90;
        await toView.RotateYTo(0, 250);

        // Increment flip counter only when flipping to the back view
        if (toView == backView)
        {
            flipCounter++;
        }

        UpdateFlipCounterDisplay();
        ApplyShadowToCard();
    }

    private void ApplyShadowToCard()
    {
        card.Shadow = new Shadow
        {
            Brush = Brush.Black,
            Offset = new Point(10f, 10f),
            Opacity = 0.6f,
            Radius = 10
        };
    }

    private void UpdateFlipCounterDisplay()
    {
        // Update flip counter display only if the back view is visible
        if (backView.IsVisible)
        {
            flipCounterLabel.Text = $"Flips - {flipCounter}";
        }
        else
        {
            flipCounterLabel.Text = string.Empty;
        }
    }
}
