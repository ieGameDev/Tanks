using Assets.Scripts.Infrastructure.Bootstrap;
using Assets.Scripts.Infrastructure.Services.InputService;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerTurretRotation : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private Transform _transform;

        private IInputService _input;
        private Quaternion _currentRotation;

        private void Awake()
        {
            _input = Game.Input;
            _currentRotation = _transform.rotation;
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_input.RotateAxis.sqrMagnitude > 0)
            {
                movementVector = Camera.main.transform.TransformDirection(_input.RotateAxis);
                movementVector.y = 0;
                movementVector.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(movementVector);
                _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);

                _currentRotation = _transform.rotation;
            }
            else
                _transform.rotation = _currentRotation;
        }
    }
}
