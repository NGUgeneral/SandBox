using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SandBox.Algorithms.TreeDataStructure
{
    [DataContract]
    public class BinaryNode<T>
    {
        [DataMember]
        public BinaryNode<T> Parent { get; private set; }
        [DataMember]
        public BinaryNode<T> LeftChild { get; private set; }
        [DataMember]
        public BinaryNode<T> RightChild { get; private set; }
        [DataMember]
        public T Value { get; set; }

        public bool IsRoot => Parent == null;
        public bool IsLeaf => LeftChild == null && RightChild == null;
        public int Depth => Parent?.Depth + 1 ?? 1;
        public BinaryNode<T> Root => IsRoot ? this : Parent.Root;
        
        public IEnumerable<BinaryNode<T>> GetAllLeafs()
            => Root.GetAllLeafsRoutine();

        private IEnumerable<BinaryNode<T>> GetAllLeafsRoutine()
        {
            if (IsLeaf)
            {
                yield return this;
            }
            else
            {
                if(LeftChild != null)
                    foreach (var leaf in LeftChild.GetAllLeafsRoutine())
                        if (leaf != null)
                            yield return leaf;

                if(RightChild != null)
                    foreach (var leaf in RightChild.GetAllLeafsRoutine())
                        if (leaf != null)
                            yield return leaf;
            }    
        }

        private BinaryNode<T> GetFirstLeaf()
        {
            if (IsLeaf)
                return this;

            var leftBranchLeaf = LeftChild?.GetFirstLeaf();
            if(leftBranchLeaf != null)
                return leftBranchLeaf;

            return RightChild?.GetFirstLeaf();
        }

        public void InsertLeftChild(BinaryNode<T> binaryNode)
        {
            ReassignParentForNode(binaryNode);

            if (LeftChild != null)
                LeftChild.Parent = binaryNode.GetFirstLeaf();

            LeftChild = binaryNode;
        }

        public void InsertRightChild(BinaryNode<T> binaryNode)
        {
            ReassignParentForNode(binaryNode);

            if (RightChild != null)
                RightChild.Parent = binaryNode.GetFirstLeaf();

            RightChild = binaryNode;
        }

        private void ReassignParentForNode(BinaryNode<T> binaryNode)
        {
            if (binaryNode.Parent != null)
            {
                if (binaryNode.Parent.LeftChild != null && binaryNode.Parent.LeftChild.Equals(binaryNode))
                    binaryNode.Parent.LeftChild = null;
                else if (binaryNode.Parent.RightChild != null && binaryNode.Parent.RightChild.Equals(binaryNode))
                    binaryNode.Parent.RightChild = null;
            }

            binaryNode.Parent = this;
        }
    }
}
