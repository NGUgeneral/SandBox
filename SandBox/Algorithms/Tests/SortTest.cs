using NUnit.Framework;
using SandBox.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SandBox.Algorithms.Tests
{
	[TestFixture]
	internal class SortTest
	{
		private Sort<int> IntsSorter = new Sort<int>();
		private List<int> SampleSequence = new List<int> { 9, 3, 7, 0, 1, 5, 4, 2, 6, 8 };
		private List<int> LongRandomSequence = Helpers.GetRandomIntSequence(1, 5000);

		public async Task GenericSortTest(SortType sortType, IList<int> sequence)
		{
			var randomSequence = new List<int>();
			randomSequence.AddRange(sequence);
			await IntsSorter.StartAndReturnResult(randomSequence, sortType).ConfigureAwait(false);
			Assert.IsTrue(randomSequence.ValidateSequence());
		}

		[Test]
		public async Task BubbleTest()
				=> await GenericSortTest(SortType.Bubble, SampleSequence).ConfigureAwait(false);

		[Test]
		public async Task SelectionTest()
				=> await GenericSortTest(SortType.Selection, SampleSequence).ConfigureAwait(false);

		[Test]
		public async Task InsertionTest()
				=> await GenericSortTest(SortType.Insertion, SampleSequence).ConfigureAwait(false);

		[Test]
		public async Task MergeMemoryCostTest()
				=> await GenericSortTest(SortType.MergeMemoryCost, SampleSequence).ConfigureAwait(false);

		[Test]
		public async Task MergeTimeCostTest()
				=> await GenericSortTest(SortType.MergeTimeCost, SampleSequence).ConfigureAwait(false);

		[Test]
		public async Task QuickRecursiveTest()
				=> await GenericSortTest(SortType.QuickRecursiveMemoryLeaky, SampleSequence).ConfigureAwait(false);

		[Test]
		public async Task HeapTest()
				=> await GenericSortTest(SortType.HeapTimeCost, SampleSequence).ConfigureAwait(false);

		[Test]
		public async Task BigBubbleTest()
				=> await GenericSortTest(SortType.Bubble, LongRandomSequence).ConfigureAwait(false);

		[Test]
		public async Task BigSelectionTest()
				=> await GenericSortTest(SortType.Selection, LongRandomSequence).ConfigureAwait(false);

		[Test]
		public async Task BigInsertionTest()
				=> await GenericSortTest(SortType.Insertion, LongRandomSequence).ConfigureAwait(false);

		[Test]
		public async Task BigMergeMemoryCostTest()
				=> await GenericSortTest(SortType.MergeMemoryCost, LongRandomSequence).ConfigureAwait(false);

		[Test]
		public async Task BigMergeTimeCostTest()
				=> await GenericSortTest(SortType.MergeTimeCost, LongRandomSequence).ConfigureAwait(false);

		[Test]
		public async Task BigQuickRecursiveTest()
				=> await GenericSortTest(SortType.QuickRecursiveMemoryLeaky, LongRandomSequence).ConfigureAwait(false);

		[Test]
		public async Task BigHeapTest()
				=> await GenericSortTest(SortType.HeapTimeCost, LongRandomSequence).ConfigureAwait(false);
	}
}