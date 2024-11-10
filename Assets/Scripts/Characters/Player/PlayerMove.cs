using Infrastructure.Services.InputService;
using Player;
using UnityEngine;

namespace Characters.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private PlayerAnimator _animator;
        
        private CharacterController _characterController;
        private GameObject _camera;
        
        private IInputService _input;
        private float _movementSpeed;
        private float _rotationSpeed;

        public void Construct(IInputService input, float movementSpeed, float rotationSpeed, GameObject followCamera)
        {
            _input = input;
            _movementSpeed = movementSpeed;
            _rotationSpeed = rotationSpeed;
            _camera = followCamera;
        }

        private void Awake() => 
            _characterController = GetComponent<CharacterController>();

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            bool isMoving = _input.MoveAxis.sqrMagnitude > 0;
            _animator.PlayRide(isMoving);

            if (isMoving)
            {
                movementVector = _camera.transform.TransformDirection(_input.MoveAxis);
                movementVector.y = 0;
                movementVector.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(movementVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }

            movementVector += Physics.gravity;

            _characterController.Move(movementVector * (_movementSpeed * Time.deltaTime));
        }
    }
}
