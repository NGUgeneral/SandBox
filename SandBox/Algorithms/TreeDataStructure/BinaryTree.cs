using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBox.Algorithms.TreeDataStructure
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryNode<T> Root { get; private set; }

        public BinaryTree()
        {
            Root = new BinaryNode<T>();
        }

        public BinaryTree(BinaryNode<T> root)
        {
            Root = root;
        }

        public BinaryTree(T value)
        {
            Root = new BinaryNode<T>
            {
                Value = value
            };
        }

        public void InsertValue(T value)
        {
            var node = new BinaryNode<T>
            {
                Value = value
            };

            InsertNode(node);
        }

        public void InsertNode(BinaryNode<T> node)
        {
            throw new NotImplementedException();
        }
    }
}
