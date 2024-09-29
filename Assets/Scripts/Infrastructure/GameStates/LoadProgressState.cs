namespace Infrastructure.GameStates
{
    public class LoadProgressState : IState
    {
        private const string CurrentLevel = "BattleField01";

        private readonly GameStateMachine _gameStateMachine;

        public LoadProgressState(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter() => 
            _gameStateMachine.Enter<LoadLevelState, string>(CurrentLevel);

        public void Exit()
        {
        }
    }
}