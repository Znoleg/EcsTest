using UnityEngine;

public class CharacterStateMachine : MonoBehaviour {
    [SerializeField] private float _speed = 5f;
    [SerializeField] private Animator _animator;

    private StateMachine _stateMachine;
    
    private void Awake() {
        _stateMachine = new StateMachine();
        _stateMachine.InjectState<IdleState>(new IdleState(_stateMachine));
        _stateMachine.InjectState<MovementState>(new MovementState(_stateMachine, transform, _animator, _speed));
        _stateMachine.ChangeState<IdleState>();
    }

    private void Update() {
        _stateMachine.CurrentState?.LogicTick();
    }

    private void FixedUpdate() {
        _stateMachine.CurrentState?.PhysicsTick();
    }
}