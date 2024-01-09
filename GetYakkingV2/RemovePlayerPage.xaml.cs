public partial class RemovePlayerPage : ContentPage
{
    public RemovePlayerPage()
    {
        InitializeComponent();
        UpdatePlayersList();
    }

    private async void OnPlayerTapped(object sender, ItemTappedEventArgs e)
    {
        var player = e.Item as Player; // Assuming 'Player' is your model
        var response = await DisplayAlert("Confirm", "Are you sure you want to remove this player?", "Yes", "No");
        if (response)
        {
            // Logic to remove player
            UpdatePlayersList();
        }
    }

    private void UpdatePlayersList()
    {
        // Update the players list
    }
}
