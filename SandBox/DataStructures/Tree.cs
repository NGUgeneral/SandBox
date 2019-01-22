using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace SandBox.DataStructures
{
	public class Tree
	{

	}

	public class Node
	{
		public object Value { get; set; }
		private Node Parent { get; set; }
		private List<Node> Children = new List<Node>();
		public int Depth => GetDepth();
		private Node Root => GetRoot();
		public int TreeHeight => Leafs.Max(x => x.Depth);
		public List<Node> Leafs => GetLeafs();

		public void AddNode(Node parent, Node node)
		{
			parent.Children.Add(node);
		}

		public void RemoveNode(Node node)
		{
			node.Parent.Children.Remove(node);
		}

		private List<Node> GetLeafs()
		{
			var root = Root;
			var leafs = new List<Node>();
			GetLeafsDo(root, root, leafs);
			return leafs;
		}

		private void GetLeafsDo(Node node, Node root, List<Node> leafs)
		{
			if (!node.Children.Any())
			{
				lock (root)
				{
					leafs.Add(node);
				}
			}
			else
			{
				foreach (var child in node.Children)
					GetLeafsDo(child, root, leafs);
			}
		}

		private int GetDepth()
		{
			var depth = 0;
			var node = this;

			while (true)
			{
				if(node.Parent == null)
					break;

				node = node.Parent;
				depth++;
			}

			return depth;
		}

		private Node GetRoot()
		{
				return Parent == null ?
					this :
					Parent.GetRoot();
		}
	}
}
