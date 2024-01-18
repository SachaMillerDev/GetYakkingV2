using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace GetYakkingV2
{
    public partial class ViewPlayersPage : ContentPage
    {
        public ViewPlayersPage()
        {
            InitializeComponent();
            // Sort the players by score in descending order
            var sortedPlayers = PlayerDataService.Instance.Players
                                .OrderByDescending(player => player.Score)
                                .ToList();

            playersList.ItemsSource = new ObservableCollection<Player>(sortedPlayers);
        }

        private async void OnPlayerTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Player player)
            {
                bool confirm = await DisplayAlert("Confirm", $"Are you sure you want to give a point to {player.Name}?", "Yes", "No");
                if (confirm)
                {
                    player.IncrementScore();
                }
            }
        }
    }
}
