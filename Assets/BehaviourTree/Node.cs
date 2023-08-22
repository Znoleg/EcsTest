using System;
using System.Collections.Generic;

namespace BehaviourTree {
	public enum NodeState {
		Running,
		Success,
		Failure
	}

	public class Node {
		public Node Parent { get; set; }
		protected NodeState State { get; set; }
		protected readonly List<Node> Children = new();

		private readonly Dictionary<string, object> _data = new();

		public Node() {
			Parent = null;
		}

		public Node(List<Node> children) {
			foreach (Node node in children) {
				Attach(node);	
			}
		}

		public virtual NodeState Evaluate() => NodeState.Failure;

		public void SetData(string key, object value) {
			_data[key] = value;
		}
		
		public object GetData(string key) {
			if (_data.TryGetValue(key, out object value)) {
				return value;
			}

			Node node = Parent;
			while (node != null) {
				value = node.GetData(key);
				if (value != null) {
					return value;
				}
				
				node = node.Parent;
			}

			return null;
		}

		public bool ClearData(string key) {
			if (_data.ContainsKey(key)) {
				_data.Remove(key);
				return true;
			}
			
			Node node = Parent;
			while (node != null) {
				bool cleared = node.ClearData(key);
				if (cleared) {
					return true;
				}
				
				node = node.Parent;
			}

			return false;
		}

		private void Attach(Node node) {
			node.Parent = this;
			Children.Add(node);
		}
	}
}
