using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class RemovePlayerPage : ContentPage
    {
        ObservableCollection<Player> players = new ObservableCollection<Player>();

        public RemovePlayerPage()
        {
            InitializeComponent();
            playersList.ItemsSource = players;
            UpdatePlayersList();
        }

        private async void OnPlayerTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Player player)
            {
                var response = await DisplayAlert("Confirm", $"Are you sure you want to remove {player.Name}?", "Yes", "No");
                if (response)
                {
                    players.Remove(player);
                    UpdatePlayersList();
                }
            }
        }

        private void UpdatePlayersList()
        {
            playersList.ItemsSource = players;
        }
    }
}
