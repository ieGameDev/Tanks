using Infrastructure.AssetsManager;
using Infrastructure.Services.InputService;
using Logic;
using UnityEngine;

namespace Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private const string BulletPath = "Tanks/Bullet";
        
        [SerializeField] private float _attackCooldown = 0.5f;
        [SerializeField] private float _bulletSpeed = 15f;
        [SerializeField] private Transform _firePoint;

        private float _lastShootTime;
        private IInputService _inputService;
        private IAssetsProvider _assetProvider;

        public void Construct(IInputService inputService, IAssetsProvider assetProvider)
        {
            _assetProvider = assetProvider;
            _inputService = inputService;
        }

        private void Update() => 
            Attack();

        private void Attack()
        {
            if (CanShoot() && _inputService.AttackButtonPressed)
            {
                Shoot();
                _lastShootTime = Time.time;
            }
        }

        private void Shoot()
        {
            GameObject bullet = _assetProvider.Instantiate(BulletPath, _firePoint.position);
            Bullet bulletComponent = bullet.GetComponent<Bullet>();
            bulletComponent.Initialize(_firePoint.forward, _bulletSpeed);
        }

        private bool CanShoot() => 
            Time.time >= _lastShootTime + _attackCooldown;
    }
}