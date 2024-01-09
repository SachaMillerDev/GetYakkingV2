namespace GetYakkingV2
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }

        // Constructor
        public Player(string name)
        {
            Name = name;
            Score = 0; // Default score
        }

        // Method to increment the score
        public void IncrementScore()
        {
            Score++;
        }
    }
}
