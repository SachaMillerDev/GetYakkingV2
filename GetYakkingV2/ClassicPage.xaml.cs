using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class ClassicPage : ContentPage
    {
        private bool areRulesVisible = false;
        private int flipCounter = 0; // Counter for card flips
        private List<Question> questions;

        public ClassicPage()
        {
            InitializeComponent();
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(ClassicPage)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("C:\\Users\\SachaMiller\\source\\repos\\GetYakkingV2\\GetYakkingV2\\Questions\\ClassicQuestions.json");
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();
                questions = JsonSerializer.Deserialize<List<Question>>(jsonString);
            }
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
            DisplayQuestion();
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
            }
            else
            {
                flipCounterLabel.Text = string.Empty;
            }
        }

        private void DisplayQuestion()
        {
            var question = questions.FirstOrDefault(); // Replace with your logic
            questionLabel.Text = question?.Text; // Set the text of the label to the question
        }
    }

    public class Question
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
        public int Rank { get; set; }
    }
}
