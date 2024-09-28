using Infrastructure.Services.InputService;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        private CharacterController _characterController;
        private IInputService _input;

        public void Construct(IInputService input) => 
            _input = input;

        private void Awake() => 
            _characterController = GetComponent<CharacterController>();

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (_input.MoveAxis.sqrMagnitude > 0)
            {
                movementVector = Camera.main.transform.TransformDirection(_input.MoveAxis);
                movementVector.y = 0;
                movementVector.Normalize();

                Quaternion targetRotation = Quaternion.LookRotation(movementVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
            }

            movementVector += Physics.gravity;

            _characterController.Move(_movementSpeed * movementVector * Time.deltaTime);
        }
    }
}
