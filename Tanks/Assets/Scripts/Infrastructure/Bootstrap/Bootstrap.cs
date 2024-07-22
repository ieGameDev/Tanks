using Assets.Scripts.Infrastructure.Services.InputService;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        public static IInputService Input;

        private void Awake()
        {
            RegisterInputService();
            DontDestroyOnLoad(this);
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