using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects")]
    public class PlayerData : ScriptableObject
    {
        [Header("Tank Data")]
        public float MovementSpeed;
        public float RotationSpeed;
        public float TurretRotationSpeed;
        
        [Header("Bullet Data")]
        public float BulletSpeed;
        public float AttackCooldown;
        public float Damage;
        
        [Header("Bullet Pool Data")]
        public int BulletPoolSize;
    }
}