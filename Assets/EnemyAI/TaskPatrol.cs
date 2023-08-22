using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;

namespace EnemyAI {
	public class TaskPatrol : Node {
		private readonly Transform _owner;
		private readonly IReadOnlyList<Transform> _waypoints;
		private int _wayPointIndex = 0;

		public TaskPatrol(Transform owner, IReadOnlyList<Transform> waypoints) {
			_owner = owner;
			_waypoints = waypoints;
		}

		public override NodeState Evaluate() {
			Transform waypoint = _waypoints[_wayPointIndex];
			const float speed = 1f;
			const float stopMagnitude = 0.1f;

			if (Vector3.Distance(_owner.position, waypoint.position) <= stopMagnitude) {
				int waypointCount = _waypoints.Count;
				_wayPointIndex = (_wayPointIndex + 1) % waypointCount;
			}
			
			_owner.position = Vector3.MoveTowards(_owner.position, waypoint.position, speed * Time.deltaTime);
			return State = NodeState.Running;
		}
	}
}
