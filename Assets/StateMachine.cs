using System;
using System.Collections.Generic;

public interface IStateMachine {
    void ChangeState<TState>() where TState : IState;
}

public class StateMachine : IStateMachine {
    private readonly Dictionary<Type, IState> _states = new();

    public IState CurrentState { get; private set; }

    public void ChangeState<TState>() where TState : IState {
        CurrentState?.Exit();
        IState state = _states[typeof(TState)];
        CurrentState = state;
        state.Enter();
    }

    public void InjectState<TState>(IState state) where TState : IState {
        _states.Add(typeof(TState), state);
    }
}
