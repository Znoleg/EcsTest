using UnityEngine;

public interface IStateMachine {
    void ChangeState(IState state);
}

public abstract class StateMachine : MonoBehaviour, IStateMachine {
    public IState CurrentState { get; private set; }

    public void ChangeState(IState state) {
        CurrentState?.Exit();
        state.Enter();
        CurrentState = state;
    }

    private void Update() {
        CurrentState?.LogicTick();
    }

    private void FixedUpdate() {
        CurrentState?.PhysicsTick();
    }
}
