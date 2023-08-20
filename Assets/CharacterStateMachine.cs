using UnityEngine;

public class CharacterStateMachine : StateMachine {
    [SerializeField] private float _speed = 5f;

    public IdleState IdleState { get; private set; }
    public MovementState MovementState { get; private set; }
    
    private void Start() {
        IdleState = new IdleState(this);
        MovementState = new MovementState(this, _speed);
        ChangeState(IdleState);
    }

    private void LateUpdate() {
        Debug.Log(CurrentState);
    }

}