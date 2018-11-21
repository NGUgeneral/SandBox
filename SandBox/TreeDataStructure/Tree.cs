using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace SandBox.TreeDataStructure
{
	[DataContract]
	public class Tree<T>
	{
		[DataMember]
		private Node Root { get; set; }

		private Tree()
		{
		}

		public Tree(T value)
		{
			Root = Node.GenerateNode(value);
		}

		public void RemoveSubtree(Node subTree)
		{
			subTree.Parent.RemoveChild(subTree);
		}

		public IEnumerable<Node> GetAllLeaves()
		{
			return Root.GetAllLeavesRoutine();
		}

		public void InsertValueTest(T value)
		{
			var r = new Random();
			var id = Guid.NewGuid().ToString();

			var node = new Node(value, id);

			var depth = r.Next(1, GetAllLeaves().Max(x => x.Depth) + 1);
			var parent = Root;

			while (depth > 1)
			{
				parent = parent.Children[r.Next(0, parent.Children.Count)];
				depth--;
			}
			parent.InsertChild(node);
		}

		[DataContract]
		public class Node
		{
			[DataMember]
			public string Id { get; }

			[DataMember]
			public T Value { get; set; }

			[DataMember]
			public Node Parent { get; set; }

			[DataMember]
			public List<Node> Children { get; } = new List<Node>();

			public bool IsRoot => Parent == null;
			public bool IsLeaf => !Children.Any();
			public int Depth => Parent?.Depth + 1 ?? 1;

			private Node()
			{
			}

			public Node(T value, string id)
			{
				Id = id;
				Value = value;
			}

			public void InsertChild(Node node)
			{
				node.Parent = this;
				Children.Add(node);
			}

			public void RemoveChild(Node node)
			{
				Children.Remove(node);
			}

			internal static Node GenerateNode(T value)
			{
				var id = Guid.NewGuid().ToString();
				var node = new Node(value, id);

				return node;
			}

			internal IEnumerable<Node> GetAllLeavesRoutine()
			{
				if (IsLeaf)
				{
					yield return this;
				}
				else
				{
					foreach (var child in Children)
						foreach (var leaf in child.GetAllLeavesRoutine())
							yield return leaf;
				}
			}
		}
	}
}