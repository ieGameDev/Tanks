using System;
using Logic;
using UnityEngine;

namespace Characters.Enemy
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [SerializeField] private float _currentHealth;
        [SerializeField] private float _maxHealth;

        public event Action HealthChanged;

        public float CurrentHealth
        {
            get => _currentHealth;
            set => _currentHealth = value;
        }

        public float MaxHealth
        {
            get => _maxHealth;
            set => _maxHealth = value;
        }

        private void Start() => 
            CurrentHealth = MaxHealth;

        public void TakeDamage(float damage)
        {
            CurrentHealth -= damage;
            HealthChanged?.Invoke();
        }
    }
}