﻿using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public class MobileInput : InputService
    {
        public override Vector2 MoveAxis => TankInputAxis();

        public override Vector2 RotateAxis => TurretInputAxis();

        public override bool AttackButtonPressed => throw new System.NotImplementedException();
    }
}