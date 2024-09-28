using Assets.Scripts.Infrastructure.DI;
using Assets.Scripts.Infrastructure.Factory;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.GameStates
{
    public class GameStateMachine
    {
        private Dictionary<Type, IState> _states;
        private IState _activeState;

        public GameStateMachine(DIContainer container)
        {
            _states = new Dictionary<Type, IState>()
            {
                [typeof(BootstrapState)] = new BootstrapState(this, container),
                [typeof(LoadLevelState)] = new LoadLevelState(this, container.Single<IGameFactory>()),
                [typeof(GameLoopState)] = new GameLoopState(),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        private TState ChangeState<TState>() where TState : class, IState
        {
            TState state = GetStated<TState>();
            _activeState = state;

            return state;
        }

        private TState GetStated<TState>() where TState : class, IState =>
            _states[typeof(TState)] as TState;
    }
}
