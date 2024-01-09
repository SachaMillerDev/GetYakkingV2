using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace GetYakkingV2;

public partial class ClassicPage : ContentPage
{
    private bool areRulesVisible = false;
    private int flipCounter = 0; // Counter for card flips
    private Stopwatch backViewTimer = new Stopwatch(); // Timer for back view
    private bool timerRunning = false; // Flag to indicate if the timer is running

    public ClassicPage()
    {
        InitializeComponent();
        Device.StartTimer(TimeSpan.FromSeconds(1), () => {
            if (timerRunning)
            {
                UpdateTimeDisplay();
            }
            return true; // Keep the timer running
        });
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
    await Navigation.PushAsync(new ScoreboardPage());
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

        if (toView == backView)
        {
            flipCounter++;
            backViewTimer.Restart(); // Reset and start the timer
            timerRunning = true;
        }
        else if (fromView == backView)
        {
            backViewTimer.Stop();
            timerRunning = false;
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
        if (backView.IsVisible)
        {
            flipCounterLabel.Text = $"Flips - {flipCounter}";
            specialMessageLabel.Text = flipCounter % 5 == 0 ? "Preferred card showing now" : string.Empty;
            UpdateTimeDisplay();
        }
        else
        {
            flipCounterLabel.Text = string.Empty;
            specialMessageLabel.Text = string.Empty;
            timeLabel.Text = string.Empty;
        }
    }

    private void UpdateTimeDisplay()
    {
        if (backView.IsVisible)
        {
            TimeSpan timeSpent = backViewTimer.Elapsed;
            timeLabel.Text = $"Time: {timeSpent:mm\\:ss}";
        }
    }
}
