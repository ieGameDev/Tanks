using Infrastructure.DI;
using UnityEngine;

namespace Infrastructure.Services.InputService
{
    public interface IInputService : IService
    {
        Vector2 MoveAxis { get; }
        Vector2 RotateAxis { get; }
        bool AttackButtonPressed();
    }
}