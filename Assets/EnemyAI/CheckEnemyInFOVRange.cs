using BehaviourTree;
using UnityEngine;

namespace EnemyAI {
	public class CheckEnemyInFOVRange : Node {
		private readonly Transform _owner;

		public CheckEnemyInFOVRange(Transform owner) {
			_owner = owner;
		}
		
		public override NodeState Evaluate() {
			const float noticeDistance = 3f;
			Node node = Parent;
			Collider2D result = Physics2D.OverlapCircle(_owner.position, noticeDistance, LayerMask.GetMask("Player"));
			if (result != null) {
				node.SetData("target", result.transform);
				return State = NodeState.Success;
			} else if (node.GetData("target") != null) {
				node.SetData("target", null);
			}

			return State = NodeState.Running;
		}
	}
}
