using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class AddPlayerPage : ContentPage
    {
        ObservableCollection<Player> players = new ObservableCollection<Player>();

        public AddPlayerPage()
        {
            InitializeComponent();
            playersList.ItemsSource = players;
        }

        private void OnPlayerNameEntryCompleted(object sender, EventArgs e)
        {
            var playerName = playerNameEntry.Text;
            if (!string.IsNullOrWhiteSpace(playerName))
            {
                players.Add(new Player(playerName));
                playerNameEntry.Text = string.Empty; // Clear the entry
            }
        }

        private void UpdatePlayersList()
        {
            if (players.Count == 0)
            {
                // Display "add your first player" message
            }
            else
            {
                // Update the ListView with players
                playersList.ItemsSource = players;
            }
        }
    }
}
