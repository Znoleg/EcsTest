public interface IState {
	void Enter();
	void LogicTick();
	void PhysicsTick();
	void Exit();
}