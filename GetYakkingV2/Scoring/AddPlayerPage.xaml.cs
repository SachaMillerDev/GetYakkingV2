public partial class AddPlayerPage : ContentPage
{
    public AddPlayerPage()
    {
        InitializeComponent();
        UpdatePlayersList();
    }

    private void OnPlayerNameEntryCompleted(object sender, EventArgs e)
    {
        var playerName = playerNameEntry.Text;
        // Add logic to add player
        UpdatePlayersList();
    }

    private void UpdatePlayersList()
    {
        // Update the players list
        // If no players, display "add your first player"
    }
}
