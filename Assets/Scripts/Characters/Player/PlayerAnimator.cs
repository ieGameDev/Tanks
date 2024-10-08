using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;

        public void PlayRide(bool ride) => 
            _playerAnimator.SetBool("Ride", ride);
    }
}
