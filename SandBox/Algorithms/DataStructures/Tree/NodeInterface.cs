using SandBox.Utils;
using System;
using System.Linq;

namespace SandBox.TreeDataStructure
{
	public class NodeInterface
	{
		public NodeInterface()
		{
			var save = true;

			Tree<int> tree;
			if (save)
			{
				tree = GenerateTree(100);
				PersistantSerializer<Tree<int>>.Save("tree", tree);
				Console.WriteLine("Tree saved successfully");
			}
			else
			{
				tree = PersistantSerializer<Tree<int>>.Load("tree");
				Console.WriteLine("Tree loaded successfully");
			}

			Console.WriteLine($"Total number of leaves: {tree.GetAllLeaves().Count()}");

			Console.WriteLine("\nPress any key to exit ...");
			Console.ReadKey();
		}

		#region TestArea

		public static OrderedBinaryTree<int> GenerateBinaryTree(int limit)
		{
			var r = new Random();
			var tree = new OrderedBinaryTree<int>(0);

			while (limit > 0)
			{
				tree.InsertValue(r.Next(-100, 100));
				limit--;
			}

			return tree;
		}

		public static Tree<int> GenerateTree(int limit)
		{
			var r = new Random();
			var tree = new Tree<int>(0);

			while (limit > 0)
			{
				tree.InsertValueTest(r.Next(-100, 100));
				limit--;
			}

			return tree;
		}

		#endregion TestArea
	}
}