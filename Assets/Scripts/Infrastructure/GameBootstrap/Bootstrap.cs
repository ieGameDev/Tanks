using Infrastructure.DI;
using Infrastructure.GameStates;
using UnityEngine;

namespace Infrastructure.GameBootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        public GameStateMachine StateMachine;

        private void Awake()
        {
            StateMachine = new GameStateMachine(DIContainer.Container);
            StateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}