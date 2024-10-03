using UnityEngine;

namespace Logic
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        public void Initialize(Vector3 direction, float speed) => 
            _rigidbody.velocity = direction * speed;

        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}