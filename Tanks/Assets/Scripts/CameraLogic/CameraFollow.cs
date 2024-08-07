﻿using UnityEngine;

namespace Assets.Scripts.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _rotationAngleX;
        [SerializeField] private float _distance;
        [SerializeField] private float _smoothTime;

        private Transform _player;
        private Vector3 _currentVelocity;

        private void LateUpdate()
        {
            if (_player == null)
                return;

            Quaternion rotation = Quaternion.Euler(_rotationAngleX, 0, 0);

            Vector3 targetPosition = rotation * new Vector3(0, 0, -_distance) + _player.position;

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, _smoothTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _smoothTime);
        }

        public void Follow(GameObject following) =>
            _player = following.transform;
    }
}
