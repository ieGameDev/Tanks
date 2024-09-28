using UnityEngine;

namespace Infrastructure.Services.InputService
{
    public class JoystickForTankTurret : JoystickHandler
    {
        public static Vector2 TurretAxis { get; private set; }

        private void Update() => 
            TurretAxis = new Vector2(_inputVector.x, _inputVector.y);
    }
}
