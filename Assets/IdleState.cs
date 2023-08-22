using UnityEngine;

public class IdleState : BaseState {
	public IdleState(IStateMachine stateMachine) : base(stateMachine) { }
    
	public override void Enter() { }

	public override void LogicTick() {
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
			StateMachine.ChangeState<MovementState>();
		}
	}

	public override void PhysicsTick() {
	}

	public override void Exit() { }
}