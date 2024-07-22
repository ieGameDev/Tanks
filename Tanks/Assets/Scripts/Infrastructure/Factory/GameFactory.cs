using Assets.Scripts.Infrastructure.AssetsManager;
using Assets.Scripts.Infrastructure.DI;
using Assets.Scripts.Infrastructure.Services.InputService;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string PlayerPath = "Players/Player1";

        private readonly IAssetsProvider _assetProvider;

        private GameObject _player;

        public GameFactory(IAssetsProvider assetProvider) =>
            _assetProvider = assetProvider;

        public GameObject CreatePlayer(GameObject initialPoint)
        {
            _player = _assetProvider.Instantiate(PlayerPath, initialPoint.transform.position + Vector3.up * 1f);

            IInputService input = DIContainer.Container.Single<IInputService>();

            PlayerMove playerMovement = _player.GetComponentInChildren<PlayerMove>();
            PlayerTurretRotation playerRotation = _player.GetComponentInChildren<PlayerTurretRotation>();
            playerMovement.Construct(input);
            playerRotation.Construct(input);

            return _player;
        }
    }
}
