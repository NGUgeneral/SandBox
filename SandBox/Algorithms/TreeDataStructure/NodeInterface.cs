using System;

namespace SandBox.Algorithms.TreeDataStructure
{
    public class NodeInterface
    {
        public NodeInterface()
        {
            Console.WriteLine("Generating a tree structure and running test samples:");
            var node = GenerateTree().RightChild;
            var leafs = node.GetAllLeafs();
            Console.WriteLine($"Node value: {node.Value}");
            Console.WriteLine($"Root value: {node.Root.Value}");
            Console.WriteLine($"Leaf values:");
            foreach (var leaf in leafs)
                Console.WriteLine($"{leaf.Value}");

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }


        #region TestArea

        public static Node<string> GenerateTree()
        {
            var root = new Node<string> { Value = "1" };

            root.InsertLeftChild(new Node<string> { Value = "1L" });
            root.InsertRightChild(new Node<string> { Value = "1R" });

            root.RightChild.InsertLeftChild(new Node<string> { Value = "1RL" });
            root.RightChild.InsertRightChild(new Node<string> { Value = "1RR" });

            root.RightChild.RightChild.InsertLeftChild(new Node<string> { Value = "1RRL" });
            root.RightChild.RightChild.InsertRightChild(new Node<string> { Value = "1RRR" });

            root.RightChild.RightChild.LeftChild.InsertLeftChild(new Node<string> { Value = "1RRLL" });

            return root;
        }

        private class IntWrapper
        {
            public int Value { get; set; }

            public IntWrapper(int value)
            {
                Value = value;
            }
        }

        #endregion
    }
}
