using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private PoolBase<Bullet> _pool;
        private float _damage;

        public void Initialize(PoolBase<Bullet> pool, Vector3 direction, float speed, float damage)
        {
            _pool = pool;
            _damage = damage;
            _rigidbody.velocity = direction * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IHealth>(out IHealth health))
                health.TakeDamage(_damage);
            
            _pool.Return(this);
        }
    }
}