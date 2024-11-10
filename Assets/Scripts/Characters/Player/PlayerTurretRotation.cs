using Infrastructure.Services.InputService;
using UnityEngine;

namespace Characters.Player
{
    public class PlayerTurretRotation : MonoBehaviour
    {
        [SerializeField] private Transform _transform;

        private Quaternion _currentRotation;
        private GameObject _camera;
        private IInputService _input;
        private float _rotationSpeed;

        public void Construct(IInputService input, float rotationSpeed, GameObject mainCamera)
        {
            _input = input;
            _rotationSpeed = rotationSpeed;
            _camera = mainCamera;
        }

        private void Awake() => 
            _currentRotation = _transform.rotation;

        private void Update()
        {
            if (_input.RotateAxis.sqrMagnitude > 0)
            {
                Vector3 movementVector = _camera.transform.TransformDirection(_input.RotateAxis);
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
