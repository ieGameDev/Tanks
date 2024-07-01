using Assets.Scripts.Infrastructure.Services.InputService;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Bootstrap
{
    public class Game
    {
        public static IInputService Input;

        public Game()
        {
            RegisterInputService();
        }

        private void RegisterInputService()
        {
            if (Application.isEditor)
                Input = new DesktopInput();
            else
                Input = new MobileInput();
        }
    }
}