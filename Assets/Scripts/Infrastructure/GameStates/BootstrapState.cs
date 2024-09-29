using Infrastructure.AssetsManager;
using Infrastructure.DI;
using Infrastructure.Factory;
using Infrastructure.GameBootstrap;
using Infrastructure.Services.InputService;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class BootstrapState : IState
    {
        private const string InitialScene = "Initial";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly DIContainer _container;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, DIContainer container)
        {
            _gameStateMachine = gameStateMachine;
            _container = container;
            _sceneLoader = sceneLoader;

            RegisterServices();
        }

        public void Enter() =>
            _sceneLoader.Load(InitialScene, EnterLoadLevel);

        public void Exit()
        {
        }

        private void EnterLoadLevel() =>
            _gameStateMachine.Enter<LoadProgressState>();

        private void RegisterServices()
        {
            _container.RegisterSingle(InputService());
            _container.RegisterSingle<IAssetsProvider>(new AssetsProvider());
            _container.RegisterSingle<IGameFactory>(new GameFactory(_container.Single<IAssetsProvider>()));
        }

        private static IInputService InputService()
        {
            if (Application.isEditor)
                return new DesktopInput();
            else
                return new MobileInput();
        }
    }
}