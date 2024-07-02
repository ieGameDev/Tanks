using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.InputService
{
    public interface IInputService
    {
        Vector2 MoveAxis { get; }
        Vector2 RotateAxis { get; }
    }
}