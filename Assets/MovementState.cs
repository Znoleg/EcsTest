using UnityEngine;

public abstract class BaseState : IState {
	protected readonly IStateMachine StateMachine;

	protected BaseState(IStateMachine stateMachine) {
		StateMachine = stateMachine;
	}

	public abstract void Enter();
	public abstract void LogicTick();
	public abstract void PhysicsTick();
	public abstract void Exit();
}

public class MovementState : BaseState {
	private readonly CharacterStateMachine _characterStateMachine;
	private readonly float _speed;

	public MovementState(CharacterStateMachine characterStateMachine, float speed) : base(characterStateMachine) {
		_characterStateMachine = characterStateMachine;
		_speed = speed;
	}
    
	public override void Enter() {
		Debug.Log($"{_characterStateMachine} entered {nameof(MovementState)}");
	}

	public override void LogicTick() {
		Vector3 direction = default;
        
		if (Input.GetKey(KeyCode.D)) {
			direction = new Vector2(1f, 0f);
		} else if (Input.GetKey(KeyCode.A)) {
			direction = new Vector2(-1f, 0f);
		} else if (Input.GetKey(KeyCode.W)) {
			direction = new Vector2(0f, 1f);
		} else if (Input.GetKey(KeyCode.S)) {
			direction = new Vector2(0f, -1f);
		} else {
			_characterStateMachine.ChangeState(_characterStateMachine.IdleState);
			return;
		}

		_characterStateMachine.transform.position += direction * _speed * Time.deltaTime;
	}

	public override void PhysicsTick() {
        
	}

	public override void Exit() {
		Debug.Log($"{_characterStateMachine} exited {nameof(MovementState)}");
	}
}