using Assets.Scripts.CameraLogic;
using Infrastructure.Factory;
using UnityEngine;

namespace Infrastructure.GameStates
{
    public class LoadLevelState : IState
    {
        private const string PlayerInitialPointTag = "PlayerInitialPoint";

        private readonly GameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine gameStateMachine, IGameFactory gameFactory)
        {
            _gameStateMachine = gameStateMachine;
            _gameFactory = gameFactory;
        }

        public void Enter()
        {
            OnLoaded();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void OnLoaded()
        {
            GameObject player = InitialPlayer();
            CameraFollow(player);
        }

        private GameObject InitialPlayer() =>
            _gameFactory.CreatePlayer(GameObject.FindWithTag(PlayerInitialPointTag));

        private void CameraFollow(GameObject player) =>
            Camera.main.GetComponent<CameraFollow>().Follow(player);
    }
}