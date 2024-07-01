using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public class DesktopInput : InputService
    {
        public override Vector2 Axis
        {
            get
            {
                Vector2 axis = SimpleInputAxis();

                if (axis == Vector2.zero)
                    axis = DesktopInputAxis();

                return axis;
            }
        }

        private static Vector2 DesktopInputAxis() =>
            new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
    }
}
