using Assets.Scripts.CameraLogic;
using Infrastructure.Factory;
using Infrastructure.GameBootstrap;
using UnityEngine;
using Utils;

namespace Infrastructure.GameStates
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private const string PlayerInitialPointTag = "PlayerInitialPoint";

        private readonly GameStateMachine _gameStateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
            _sceneLoader = sceneLoader;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName, OnLoaded);

        public void Exit()
        {
        }

        private void OnLoaded()
        {
            GameObject player = InitialPlayer();
            CameraFollow(player);

            _gameStateMachine.Enter<GameLoopState>();
        }

        private GameObject InitialPlayer() =>
            _gameFactory.CreatePlayer(GameObject.FindWithTag(PlayerInitialPointTag));

        private void CameraFollow(GameObject player) =>
            Camera.main?.GetComponent<CameraFollow>().Follow(player);

    }
}