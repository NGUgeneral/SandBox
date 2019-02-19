using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SandBox.TreeDataStructure
{
	[DataContract]
	public class OrderedBinaryTree<T> where T : IComparable
	{
		[DataMember]
		private Node Root { get; set; }

		private IEnumerable<Node> GetAllLeaves
				=> Node.GetAllLeaves(Root);

		private OrderedBinaryTree()
		{
		}

		public OrderedBinaryTree(T value)
		{
			Root = new Node
			{
				Value = value
			};
		}

		public virtual void InsertValue(T value)
		{
			var node = new Node
			{
				Value = value
			};

			InsertNodeRoutine(Root, node);
		}

		private void InsertNodeRoutine(Node parent, Node node)
		{
			if (node.Value.CompareTo(parent.Value) > 0)
			{
				if (parent.RightChild == null)
				{
					parent.InsertRightChild(node);
				}
				else
				{
					if (parent.RightChild.Value.CompareTo(node.Value) > 0)
					{
						parent.InsertRightChild(node);
					}
					else
					{
						InsertNodeRoutine(parent.RightChild, node);
					}
				}
			}
			else
			{
				if (parent.LeftChild == null)
				{
					parent.InsertLeftChild(node);
				}
				else
				{
					if (parent.LeftChild.Value.CompareTo(node.Value) > 0)
					{
						parent.InsertLeftChild(node);
					}
					else
					{
						InsertNodeRoutine(parent.LeftChild, node);
					}
				}
			}
		}

		private Node FindNode(T value, Node root)
		{
			if (root.Value.Equals(value))
				return root;

			if (value.CompareTo(root.Value) > 0)
				return root.RightChild == null ? null : FindNode(value, root.RightChild);

			return root.LeftChild == null ? null : FindNode(value, root.LeftChild);
		}

		[DataContract]
		private class Node
		{
			[DataMember]
			public Node Parent { get; private set; }

			[DataMember]
			public Node LeftChild { get; private set; }

			[DataMember]
			public Node RightChild { get; private set; }

			[DataMember]
			public T Value { get; set; }

			internal int Depth => Parent?.Depth + 1 ?? 1;
			internal bool IsRoot => Parent == null;
			private bool IsLeaf => LeftChild == null && RightChild == null;

			internal static IEnumerable<Node> GetAllLeaves(Node root)
					=> root.GetAllLeavesRoutine();

			private IEnumerable<Node> GetAllLeavesRoutine()
			{
				if (IsLeaf)
				{
					yield return this;
				}
				else
				{
					if (LeftChild != null)
						foreach (var leaf in LeftChild.GetAllLeavesRoutine())
							if (leaf != null)
								yield return leaf;

					if (RightChild != null)
						foreach (var leaf in RightChild.GetAllLeavesRoutine())
							if (leaf != null)
								yield return leaf;
				}
			}

			private Node GetFirstLeaf()
			{
				if (IsLeaf)
					return this;

				var leftBranchLeaf = LeftChild?.GetFirstLeaf();
				if (leftBranchLeaf != null)
					return leftBranchLeaf;

				return RightChild?.GetFirstLeaf();
			}

			public void InsertLeftChild(Node node)
			{
				ReassignParentForNode(node);

				if (LeftChild != null)
					LeftChild.Parent = node.GetFirstLeaf();

				LeftChild = node;
			}

			public void InsertRightChild(Node node)
			{
				ReassignParentForNode(node);

				if (RightChild != null)
					RightChild.Parent = node.GetFirstLeaf();

				RightChild = node;
			}

			private void ReassignParentForNode(Node node)
			{
				if (node.Parent != null)
				{
					if (node.Parent.LeftChild != null && node.Parent.LeftChild.Equals(node))
						node.Parent.LeftChild = null;
					else if (node.Parent.RightChild != null && node.Parent.RightChild.Equals(node))
						node.Parent.RightChild = null;
				}

				node.Parent = this;
			}
		}
	}
}