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
            playersList.ItemsSource = PlayerDataService.Instance.Players;
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
