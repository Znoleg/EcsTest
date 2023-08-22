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
	private readonly float _speed;
	private readonly Transform _owner;
	private readonly Animator _anim;
	private static readonly int Walk = Animator.StringToHash("walk");
	private static readonly int MoveX = Animator.StringToHash("moveX");
	private static readonly int MoveY = Animator.StringToHash("moveY");

	public MovementState(IStateMachine stateMachine, Transform owner, Animator anim, float speed) : base(stateMachine) {
		_owner = owner;
		_speed = speed;
		_anim = anim;
	}

	public override void Enter() {
		_anim.SetBool(Walk, true);
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
			StateMachine.ChangeState<IdleState>();
			return;
		}

		_anim.SetFloat(MoveX, direction.x);
		_anim.SetFloat(MoveY, direction.y);
		_owner.position += direction * _speed * Time.deltaTime;
	}

	public override void PhysicsTick() { }

	public override void Exit() {
		_anim.SetBool(Walk, false);
		_anim.SetFloat(MoveX, 0f);
		_anim.SetFloat(MoveY, 0f);
	}
}