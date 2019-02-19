namespace SandBox.Algorithms.DataStructures
{
	public class LinkedList<T>
	{
		public EnumerableNode<T> Root { get; set; }
		public bool Any => 
			Root != null;

		public EnumerableNode<T> Head => 
			Any ? GetHead(Root) : Root;

		private static EnumerableNode<T> GetHead(EnumerableNode<T> node)
		{
			return node.HasNext ? GetHead(node.Next) : node;
		}

		public void Append(T value)
		{
			var newNode = new EnumerableNode<T>(value);

			if (Any)
			{
				newNode.LinkTo(Head);
			}
			else
			{
				Root = newNode;
			}
		}

		public void Remove(EnumerableNode<T> node)
		{
			if (!Any)
			{
				return;
			}

			var focus = Root;
			if (focus.Equals(node))
			{
				Root = null;
			}
			else
			{
				var previous = focus;
				focus = previous.Next;

				while (focus != null)
				{
					if (focus.Equals(node))
					{
						previous.LinkTo(node.Next);
						break;
					}
				
					previous = focus;
					focus = previous.Next;
				}
			}

			node.Unlink();
			node.Dispose();
		}
	}
}
