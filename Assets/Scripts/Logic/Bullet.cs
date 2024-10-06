using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        
        private PoolBase<Bullet> _pool;

        public void Initialize(PoolBase<Bullet> pool, Vector3 direction, float speed)
        {
            _pool = pool;
            _rigidbody.velocity = direction * speed;
        }

        private void OnTriggerEnter(Collider other)
        {
            _pool.Return(this);
        }
    }
}