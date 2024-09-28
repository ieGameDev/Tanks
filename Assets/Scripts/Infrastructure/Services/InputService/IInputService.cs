using Assets.Scripts.Infrastructure.DI;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public interface IInputService : IService
    {
        Vector2 MoveAxis { get; }
        Vector2 RotateAxis { get; }
        bool AttackButtonPressed { get; }
    }
}