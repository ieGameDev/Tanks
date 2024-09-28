using Infrastructure.AssetsManager;
using Infrastructure.DI;
using Infrastructure.Services.InputService;
using Player;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private const string Player01Path = "Tanks/Tank01";
        private const string Player02Path = "Tanks/Tank02";
        private const string Player03Path = "Tanks/Tank03";
        private const string Player04Path = "Tanks/Tank04";

        private readonly IAssetsProvider _assetProvider;

        private GameObject _player;

        public GameFactory(IAssetsProvider assetProvider) =>
            _assetProvider = assetProvider;

        public GameObject CreatePlayer(GameObject initialPoint)
        {
            _player = _assetProvider.Instantiate(Player01Path, initialPoint.transform.position + Vector3.up * 1f);

            IInputService input = DIContainer.Container.Single<IInputService>();

            PlayerMove playerMovement = _player.GetComponentInChildren<PlayerMove>();
            PlayerTurretRotation playerRotation = _player.GetComponentInChildren<PlayerTurretRotation>();
            playerMovement.Construct(input);
            playerRotation.Construct(input);

            return _player;
        }
    }
}
