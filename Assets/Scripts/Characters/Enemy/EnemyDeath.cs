using System;
using System.Collections;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        [SerializeField] private EnemyHealth _enemyHealth;

        public event Action OnDeath;

        private void Awake() =>
            _enemyHealth.HealthChanged += Damage;

        private void OnDestroy() =>
            _enemyHealth.HealthChanged -= Damage;

        private void Damage()
        {
            if (_enemyHealth.CurrentHealth <= 0)
                Die();
        }

        private void Die()
        {
            _enemyHealth.HealthChanged -= Damage;
            OnDeath?.Invoke();

            Debug.Log("Enemy Death");
            StartCoroutine(Death());
        }

        private IEnumerator Death()
        {
            yield return new WaitForSeconds(1f);
            Destroy(gameObject);
        }
    }
}