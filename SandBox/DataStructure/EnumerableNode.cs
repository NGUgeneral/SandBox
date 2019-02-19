using System;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace SandBox.DataStructure
{
	public class EnumerableNode<T> : IDisposable
	{
		public T Value { get; }
		public EnumerableNode<T> Next { get; private set; }
		public bool HasNext => Next != null;

		public EnumerableNode(T value)
		{
			Value = value;
		}

		public void LinkTo(EnumerableNode<T> next)
		{
			Next = next;
		}

		public void Unlink()
		{
			Next = null;
		}

		#region IDisposable Implementation

		// Flag: Has Dispose already been called?
		bool disposed = false;
		// Instantiate a SafeHandle instance.
		SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

		// Public implementation of Dispose pattern callable by consumers.
		public void Dispose()
		{ 
			Dispose(true);
			GC.SuppressFinalize(this);           
		}

		// Protected implementation of Dispose pattern.
		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
				return; 
      
			if (disposing) {
				handle.Dispose();
				// Free any other managed objects here.
				//
			}
      
			disposed = true;
		}

		#endregion
	}
}