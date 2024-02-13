using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
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
            Stream stream = assembly.GetManifestResourceStream("GetYakkingV2.Questions.ClassicQuestions.json");
            if (stream == null)
            {
                throw new FileNotFoundException("Embedded resource not found.");
            }
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
                DisplayQuestion(); // Update the question text
                questionLabel.IsVisible = true; // Show the question label after flip
            }
            else
            {
                questionLabel.IsVisible = false; // Hide the question label after flip
            }

            UpdateFlipCounterDisplay();
            ApplyShadowToCard();
        }



        private void ShowQuestion()
        {
            questionLabel.IsVisible = true;
            DisplayQuestion();
        }

        private void HideQuestion()
        {
            questionLabel.IsVisible = false;
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
            flipCounterLabel.IsVisible = false;
        }

        private void DisplayQuestion()
        {
            if (questions != null && questions.Any()) // Check if the list is not null or empty
            {
                var question = questions.FirstOrDefault();
                questionLabel.Text = question?.QuestionText; // Changed from Question to QuestionText
            }
        }


    }

    public class Question
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string QuestionText { get; set; } // Changed from Text to Question
        public int Rank { get; set; }
    }

}
