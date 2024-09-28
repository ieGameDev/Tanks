using UnityEngine;

namespace Infrastructure.Services.InputService
{
    public class MobileInput : global::Infrastructure.Services.InputService.InputService
    {
        public override Vector2 MoveAxis => TankInputAxis();

        public override Vector2 RotateAxis => TurretInputAxis();

        public override bool AttackButtonPressed => throw new System.NotImplementedException();
    }
}
