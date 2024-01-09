using System.Collections.ObjectModel;
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

        private void OnPlayerTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item is Player player)
            {
                player.IncrementScore();
            }
        }
    }
}