using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputService
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

                return axis;
            }
        }

        public override Vector2 RotateAxis { get { return TurretInputAxis(); } }

        private static Vector2 DesktopInputAxis() =>
            new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
    }
}
