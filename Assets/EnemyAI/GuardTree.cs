using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;
using Tree = BehaviourTree.Tree;

namespace EnemyAI {
	public class GuardTree : Tree {
		[SerializeField] private Transform[] _wayPoints;
	
		protected override Node SetupTree() {
			return new Selector(new List<Node> {
				new Sequence(new List<Node> {
					new CheckEnemyInFOVRange(transform),
					new TaskGoToTarget(transform)
				}),
				new TaskPatrol(transform, _wayPoints)
			});
		}
	}
}
