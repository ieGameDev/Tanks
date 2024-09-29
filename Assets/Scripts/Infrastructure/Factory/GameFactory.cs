using Infrastructure.AssetsManager;
using Infrastructure.DI;
using Infrastructure.Services.InputService;
using Player;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assetProvider;
        private readonly string[] PlayerPaths =
        {
            "Tanks/Tank1"
        };

        private GameObject _player;

        public GameFactory(IAssetsProvider assetProvider) =>
            _assetProvider = assetProvider;

        public GameObject CreatePlayer(GameObject initialPoint)
        {
            _player = _assetProvider.Instantiate(PlayerPaths[0], initialPoint.transform.position + Vector3.up * 0.2f);

            IInputService input = DIContainer.Container.Single<IInputService>();

            PlayerMove playerMovement = _player.GetComponentInChildren<PlayerMove>();
            PlayerTurretRotation playerRotation = _player.GetComponentInChildren<PlayerTurretRotation>();
            playerMovement.Construct(input);
            playerRotation.Construct(input);

            return _player;
        }
    }
}
