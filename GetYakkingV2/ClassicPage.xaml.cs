using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Timers;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class ClassicPage : ContentPage
    {
        private bool areRulesVisible = false;
        private int flipCounter = 0; // Counter for card flips
        private List<Question> questions, unrankedQuestions, rankedQuestions;
        private Question currentQuestion;
        private int questionDisplayCount = 0;
        private System.Timers.Timer rankTimer;


        public ClassicPage()
        {
            InitializeComponent();
            LoadQuestions();
            SetupTimer();
            DisplayQuestion();
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
                unrankedQuestions = new List<Question>(questions);
                rankedQuestions = new List<Question>();
            }
        }

        private void SetupTimer()
        {
            rankTimer = new System.Timers.Timer(20000);
            rankTimer.Elapsed += OnTimedEvent;
            rankTimer.AutoReset = true;
            rankTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (currentQuestion != null)
                {
                    currentQuestion.Rank += 1;
                    IncrementCategoryRank(currentQuestion.Category);
                    // Optionally update UI here
                }
            });
        }

        private void IncrementCategoryRank(string category)
        {
            bool incremented = false;
            foreach (var question in questions.Where(q => q.Category == category))
            {
                if (question == currentQuestion || !incremented)
                {
                    question.Rank += 1;
                    incremented = true; // Ensure other questions in the category are incremented only once
                }
            }
        }

        private void DisplayQuestion()
        {
            questionDisplayCount++;
            Question questionToDisplay;

            if (questionDisplayCount % 5 == 0 && rankedQuestions.Any())
            {
                questionToDisplay = SelectRandomQuestion(rankedQuestions);
            }
            else
            {
                questionToDisplay = SelectRandomQuestion(unrankedQuestions);
            }

            if (questionToDisplay != null)
            {
                currentQuestion = questionToDisplay;
                questionLabel.Text = currentQuestion.QuestionText;
                questionLabel.IsVisible = true;

                if (unrankedQuestions.Contains(questionToDisplay))
                {
                    unrankedQuestions.Remove(questionToDisplay);
                    rankedQuestions.Add(questionToDisplay);
                }
            }
        }

        private Question SelectRandomQuestion(List<Question> questionsList)
        {
            if (!questionsList.Any())
            {
                return null;
            }

            var random = new Random();
            int index = random.Next(questionsList.Count);
            return questionsList[index];
        }

        public class Question
        {
            public string Id { get; set; }
            public string Category { get; set; }
            public string QuestionText { get; set; }
            public int Rank { get; set; }
        }
    }
}
