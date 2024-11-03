using Infrastructure.DI;
using ScriptableObjects;

namespace Infrastructure.Services.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadPlayer();
        PlayerData GetPlayerData();
    }
}