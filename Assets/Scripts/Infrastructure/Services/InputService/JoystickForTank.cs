using UnityEngine;

namespace Infrastructure.Services.InputService
{
    public class JoystickForTank : JoystickHandler
    {
        public static Vector2 TankAxis { get; private set; }

        private void Update() => 
            TankAxis = new Vector2(_inputVector.x, _inputVector.y);
    }
}
