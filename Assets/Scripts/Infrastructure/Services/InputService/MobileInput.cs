﻿using UnityEngine;

namespace Infrastructure.Services.InputService
{
    public class MobileInput : InputService
    {
        public override Vector2 MoveAxis => TankInputAxis();
        public override Vector2 RotateAxis => TurretInputAxis();
    }
}
