using System.ComponentModel;

namespace GetYakkingV2
{
    public class Player : INotifyPropertyChanged
    {
        private string _name;
        private int _score;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnPropertyChanged(nameof(Score));
            }
        }

        public Player(string name)
        {
            Name = name;
            Score = 0;
        }

        public void IncrementScore()
        {
            Score++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
