using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox
{
    public class NodeValue
    {
        public int IntValue { get; set; }

        public NodeValue(int intValue)
        {
            IntValue = intValue;
        }
    }
    public class Node
    {
        public NodeValue Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node()
        {
                
        }

        public Node(int value) : base()
        {
            Value = new NodeValue(value);
        }

        public Node(int value, Node leftChild, Node rightChild) : this(value)
        {
            LeftChild = leftChild;
            RightChild = rightChild;
        }

        public static Node GetTree128()
        {
            var node41 = new Node(10);
            var node42 = new Node(5);
            var node43 = new Node(10);
            var node44 = new Node(1);

            var node31 = new Node(3, node41, node42);
            var node32 = new Node(0, node42, node43);
            var node33 = new Node(100, node43, node44);

            var node21 = new Node(20, node31, node32);
            var node22 = new Node(5, node32, node33);

            var node11 = new Node(10, node21, node22);

            return node11;
        }

        public static void TestTree()
        {
            int value = 116;
            Node root = GetTree128();
            var result = 0;
            
            while (true)
            {
                result += root.Value.IntValue;
                if(root.RightChild == null) break;
                root = root.RightChild;
            }
                
            Console.WriteLine($"Result of the Tree is {result}, should be {value}. Test passed: {value.Equals(result).ToString().ToUpper()}.");
        }
    }
}
