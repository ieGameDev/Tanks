﻿using UnityEngine;

namespace Infrastructure.Services.InputService
{
    public abstract class InputService : IInputService
    {
        protected const string Horizontal = "Horizontal";
        protected const string Vertical = "Vertical";

        public abstract Vector2 MoveAxis { get; }
        public abstract Vector2 RotateAxis { get; }
        public bool AttackButtonPressed() => FireButton.FireAxis;

        protected static Vector2 TankInputAxis() =>
            JoystickForTank.TankAxis;

        protected static Vector2 TurretInputAxis() =>
            JoystickForTankTurret.TurretAxis;
    }
}