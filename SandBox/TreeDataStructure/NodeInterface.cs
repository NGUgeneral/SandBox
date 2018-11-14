using System;
using SandBox.Utils;

namespace SandBox.TreeDataStructure
{
    public class NodeInterface
    {
        public NodeInterface()
        {
            var save = false;

            BinaryTree<int> tree;
            if (save)
            {
                tree = GenerateBinaryTree(100);

                PersistantSerializer<BinaryTree<int>>.Save("tree", tree);
                Console.WriteLine("Tree saved successfully");
            }
            else
            {
                tree = PersistantSerializer<BinaryTree<int>>.Load("tree");
                Console.WriteLine("Tree loaded successfully");
            }

            Console.WriteLine("\nPress any key to exit ...");
            Console.ReadKey();
        }

        #region TestArea

        public static BinaryTree<int> GenerateBinaryTree(int limit)
        {
            var r = new Random();
            var tree = new BinaryTree<int>(0);

            while (limit > 0)
            {
                tree.InsertValue(r.Next(-100, 100));
                limit--;
            }

            return tree;
        }

        #endregion
    }
}
