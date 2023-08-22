using BehaviourTree;
using UnityEngine;

namespace EnemyAI {
	public class TaskGoToTarget : Node {
		private readonly Transform _owner;

		public TaskGoToTarget(Transform owner) {
			_owner = owner;
		}
		
		public override NodeState Evaluate() {
			Transform target = (Transform)GetData("target");
			if (target == null) {
				return State = NodeState.Failure;
			}

			const float magnitude = 0.1f;
			if (Vector3.Distance(_owner.position, target.position) <= magnitude) {
				return State = NodeState.Success;
			}

			const float speed = 1f;
			_owner.position = Vector3.MoveTowards(_owner.position, target.position, speed * Time.deltaTime);
			return State = NodeState.Running;
		}
	}
}