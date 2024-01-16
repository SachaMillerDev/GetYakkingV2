﻿using System.Collections.ObjectModel;
using GetYakkingV2.DB_Helper;

namespace GetYakkingV2
{
    public class PlayerDataService
    {
        private readonly DatabaseContext _context;

        public PlayerDataService(DatabaseContext context)
        {
            _context = context;
        }
        private static readonly Lazy<PlayerDataService> _instance = new Lazy<PlayerDataService>(() => new PlayerDataService());
        public static PlayerDataService Instance => _instance.Value;

        public ObservableCollection<Player> Players { get; private set; }

        private PlayerDataService()
        {
            Players = new ObservableCollection<Player>();
        }
    }
}

