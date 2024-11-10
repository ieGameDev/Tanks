using Characters.Player;
using Infrastructure.AssetsManager;
using Infrastructure.Services.InputService;
using Infrastructure.Services.StaticData;
using Player;
using ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assetProvider;
        private readonly IInputService _inputService;
        private readonly IStaticDataService _staticData;

        private GameObject _player;

        public GameObject CameraContainer { get; set; }

        public GameFactory(IAssetsProvider assetProvider, IInputService inputService, IStaticDataService staticData)
        {
            _assetProvider = assetProvider;
            _inputService = inputService;
            _staticData = staticData;
        }

        public GameObject CreateCameraContainer()
        {
            CameraContainer = _assetProvider.Instantiate(AssetAddress.CameraContainerPath);
            return CameraContainer;
        }

        public GameObject CreatePlayer(GameObject initialPoint)
        {
            _player = _assetProvider.Instantiate(AssetAddress.PlayerPath,
                initialPoint.transform.position + Vector3.up * 0.2f);

            Camera camera = Camera.main;
            PlayerMove playerMovement = _player.GetComponentInChildren<PlayerMove>();
            PlayerTurretRotation playerRotation = _player.GetComponentInChildren<PlayerTurretRotation>();
            PlayerAttack playerAttack = _player.GetComponentInChildren<PlayerAttack>();
            PlayerData playerData = _staticData.GetPlayerData();

            float movementSpeed = playerData.MovementSpeed;
            float tankRotationSpeed = playerData.RotationSpeed;
            float turretRotationSpeed = playerData.TurretRotationSpeed;
            float cooldown = playerData.AttackCooldown;
            float bulletSpeed = playerData.BulletSpeed;
            float bulletDamage = playerData.Damage;
            int bulletPoolSize = playerData.BulletPoolSize;

            playerMovement.Construct(_inputService, movementSpeed, tankRotationSpeed, CameraContainer);
            playerRotation.Construct(_inputService, turretRotationSpeed, CameraContainer);
            playerAttack.Construct(_inputService, _assetProvider, cooldown, bulletSpeed, bulletPoolSize, bulletDamage,
                camera);

            return _player;
        }

        public GameObject CreatePlayerHUD() =>
            _assetProvider.Instantiate(AssetAddress.PlayerHUDPath);
    }
}