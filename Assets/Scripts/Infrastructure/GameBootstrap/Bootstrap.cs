using Infrastructure.DI;
using Infrastructure.GameStates;
using UnityEngine;

namespace Infrastructure.GameBootstrap
{
    public class Bootstrap : MonoBehaviour, ICoroutineRunner
    {
        private GameStateMachine _stateMachine;

        private void Awake()
        {
            _stateMachine = new GameStateMachine(new SceneLoader(this), DIContainer.Container);
            _stateMachine.Enter<BootstrapState>();

            DontDestroyOnLoad(this);
        }
    }
}