using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.Factory
{
    public interface IGameFactory : IService
    {
        GameObject CameraContainer { get; set; }
        
        GameObject CreateCameraContainer();
        GameObject CreatePlayer(GameObject initialPoint);
        GameObject CreatePlayerHUD();
    }
}