using Infrastructure.AssetsManager;
using ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Services.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        private PlayerData _player;

        public void LoadPlayer() =>
            _player = Resources.Load<PlayerData>(AssetAddress.PlayerDataPath);

        public PlayerData GetPlayerData() =>
            _player;
    }
}