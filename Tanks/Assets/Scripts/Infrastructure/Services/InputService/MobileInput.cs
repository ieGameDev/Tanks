using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public class MobileInput : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}
