using DG.Tweening;
using Infrastructure.AssetsManager;
using Infrastructure.Services.InputService;
using Logic;
using Unity.VisualScripting;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;

        private IInputService _inputService;
        private IAssetsProvider _assetProvider;
        private PoolBase<Bullet> _bulletPool;
        private Camera _camera;
        private float _attackCooldown;
        private float _bulletSpeed;
        private float _bulletDamage;
        private float _lastShootTime;

        public void Construct(IInputService inputService, IAssetsProvider assetProvider, float attackCooldown,
            float bulletSpeed, int poolSize, float damage, Camera camera)
        {
            _inputService = inputService;
            _assetProvider = assetProvider;
            _attackCooldown = attackCooldown;
            _bulletSpeed = bulletSpeed;
            _bulletDamage = damage;
            _camera = camera;
            
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
            bullet.Initialize(_bulletPool, _firePoint.forward, _bulletSpeed, _bulletDamage);
            
            ShakeCamera();
        }

        private void ShakeCamera()
        {
            _camera?
                .DOShakePosition(0.12f, 0.05f, 5, 45f, true, ShakeRandomnessMode.Harmonic)
                .SetEase(Ease.InOutBounce);

            _camera?
                .DOShakeRotation(0.12f, 0.03f, 5, 45f, true, ShakeRandomnessMode.Harmonic)
                .SetEase(Ease.InOutBounce);
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