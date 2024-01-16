using System.Collections.ObjectModel;
using GetYakkingV2.Data;

namespace GetYakkingV2;

public class PlayerDataService
{
    private readonly SqlDatabaseService _sql;

    public PlayerDataService(SqlDatabaseService sql)
    {
        _sql = sql;
    }
    private static readonly Lazy<PlayerDataService> _instance = new Lazy<PlayerDataService>(() => new PlayerDataService());
    public static PlayerDataService Instance => _instance.Value;

    public ObservableCollection<Player> Players { get; private set; }

    private PlayerDataService()
    {
        string query = "SELECT TOP (1000) * FROM [dbo].[Questions]";
        _sql.ExecuteQuery(query);
        Players = new ObservableCollection<Player>();
    }
}

