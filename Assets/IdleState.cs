using UnityEngine;

public class IdleState : BaseState {
	private readonly CharacterStateMachine _characterStateMachine;
	
	public IdleState(CharacterStateMachine stateMachine) : base(stateMachine) {
		_characterStateMachine = stateMachine;
	}
    
	public override void Enter() {
		Debug.Log($"{_characterStateMachine} entered {nameof(IdleState)}");
	}

	public override void LogicTick() {
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
			StateMachine.ChangeState(_characterStateMachine.MovementState);
		}
	}

	public override void PhysicsTick() {
	}

	public override void Exit() {
		Debug.Log($"{_characterStateMachine} entered {nameof(IdleState)}");
	}
}