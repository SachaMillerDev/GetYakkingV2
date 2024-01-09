using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class ViewPlayersPage : ContentPage
    {
        ObservableCollection<Player> players = new ObservableCollection<Player>();

        public ViewPlayersPage()
        {
            InitializeComponent();
            playersList.ItemsSource = players;
            UpdatePlayersList();
        }

        private void OnPlayerTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Player player)
            {
                player.IncrementScore();
                UpdatePlayersList();
            }
        }

        private void UpdatePlayersList()
        {
            playersList.ItemsSource = null;
            playersList.ItemsSource = players;
        }
    }
}
