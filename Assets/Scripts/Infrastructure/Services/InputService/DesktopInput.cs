using UnityEngine;

namespace Infrastructure.Services.InputService
{
    public class DesktopInput : InputService
    {
        public override Vector2 MoveAxis
        {
            get
            {
                Vector2 axis = TankInputAxis();

                if (axis == Vector2.zero)
                    axis = DesktopInputAxis();

                return axis.normalized;
            }
        }

        public override Vector2 RotateAxis => TurretInputAxis();
        private static Vector2 DesktopInputAxis() => new(Input.GetAxisRaw(Horizontal), Input.GetAxisRaw(Vertical));
    }
}
