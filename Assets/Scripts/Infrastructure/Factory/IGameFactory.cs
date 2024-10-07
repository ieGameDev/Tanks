using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CreatePlayer(GameObject initialPoint);
        GameObject CreatePlayerHUD();
    }
}