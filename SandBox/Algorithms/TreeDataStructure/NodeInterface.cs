using System;

namespace SandBox.Algorithms.TreeDataStructure
{
    public class NodeInterface
    {
        public NodeInterface()
        {
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        #region TestArea

        public static BinaryTree<int> GenerateBinaryTree()
        {
            var tree = new BinaryTree<int>(15);

            tree.InsertValue(7);
            tree.InsertValue(3);
            tree.InsertValue(9);
            tree.InsertValue(71);
            tree.InsertValue(17);
            tree.InsertValue(11);
            tree.InsertValue(4);
            tree.InsertValue(5);
            tree.InsertValue(10);
            tree.InsertValue(0);
            tree.InsertValue(12);
            tree.InsertValue(36);
            tree.InsertValue(14);
            tree.InsertValue(15);
            tree.InsertValue(17);
            tree.InsertValue(-54);
            tree.InsertValue(54);

            return tree;
        }

        #endregion
    }
}
