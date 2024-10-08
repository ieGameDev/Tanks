using Infrastructure.AssetsManager;
using Infrastructure.DI;
using Infrastructure.Services.InputService;
using Player;
using ScriptableObjects;
using UnityEngine;

namespace Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetsProvider _assetProvider;

        private GameObject _player;

        public GameFactory(IAssetsProvider assetProvider) =>
            _assetProvider = assetProvider;

        public GameObject CreatePlayer(GameObject initialPoint)
        {
            _player = _assetProvider.Instantiate(AssetAddress.PlayerPath,
                initialPoint.transform.position + Vector3.up * 0.2f);

            IInputService input = DIContainer.Container.Single<IInputService>();

            PlayerData playerData = Resources.Load<PlayerData>(AssetAddress.PlayerDataPath);
            Camera playerCamera = Camera.main;
            
            float movementSpeed = playerData.MovementSpeed;
            float tankRotationSpeed = playerData.RotationSpeed;
            float turretRotationSpeed = playerData.TurretRotationSpeed;
            float cooldown = playerData.AttackCooldown;
            float bulletSpeed = playerData.BulletSpeed;
            float bulletDamage = playerData.Damage;
            int bulletPoolSize = playerData.BulletPoolSize;

            PlayerMove playerMovement = _player.GetComponentInChildren<PlayerMove>();
            PlayerTurretRotation playerRotation = _player.GetComponentInChildren<PlayerTurretRotation>();
            PlayerAttack playerAttack = _player.GetComponentInChildren<PlayerAttack>();

            playerMovement.Construct(input, movementSpeed, tankRotationSpeed, playerCamera);
            playerRotation.Construct(input, turretRotationSpeed, playerCamera);
            playerAttack.Construct(input, _assetProvider, cooldown, bulletSpeed, bulletPoolSize, bulletDamage);

            return _player;
        }

        public GameObject CreatePlayerHUD() => 
            _assetProvider.Instantiate(AssetAddress.PlayerHUDPath);
    }
}