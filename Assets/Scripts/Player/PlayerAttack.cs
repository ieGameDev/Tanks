using Infrastructure.AssetsManager;
using Infrastructure.Services.InputService;
using Logic;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        private IInputService _inputService;
        private IAssetsProvider _assetProvider;
        private PoolBase<Bullet> _bulletPool;
        private float _attackCooldown;
        private float _bulletSpeed;
        private float _lastShootTime;

        public void Construct(IInputService inputService, IAssetsProvider assetProvider, float attackCooldown,
            float bulletSpeed, int poolSize)
        {
            _inputService = inputService;
            _assetProvider = assetProvider;
            _attackCooldown = attackCooldown;
            _bulletSpeed = bulletSpeed;
            _bulletPool = new PoolBase<Bullet>(PreloadBullet, GetAction, ReturnAction, poolSize);
        }

        private void Update() =>
            Attack();

        private void Attack()
        {
            if (!CanShoot() || !_inputService.AttackButtonPressed())
                return;

            Shoot();
            _lastShootTime = Time.time;
        }

        private void Shoot()
        {
            Bullet bullet = _bulletPool.Get();
            bullet.transform.position = _firePoint.position;
            bullet.Initialize(_bulletPool, _firePoint.forward, _bulletSpeed);
        }

        private bool CanShoot() =>
            Time.time >= _lastShootTime + _attackCooldown;

        private Bullet PreloadBullet()
        {
            GameObject bulletObject = _assetProvider.Instantiate(AssetAddress.BulletPath, Vector3.zero);
            Bullet bullet = bulletObject.GetComponent<Bullet>();
            return bullet;
        }

        private void GetAction(Bullet bullet) => 
            bullet.gameObject.SetActive(true);

        private void ReturnAction(Bullet bullet) => 
            bullet.gameObject.SetActive(false);
    }
}