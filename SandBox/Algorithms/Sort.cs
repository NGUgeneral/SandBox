using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SandBox.Utils;

namespace SandBox.Algorithms
{
    class Sort<T> where T : IComparable
    {
        public async Task<IList<T>> StartAndReturnResult(IList<T> heap, SortType algorithm)
        {
            if (heap == null) throw new NullReferenceException("Can't order a null sequence");
            if (heap.Count == 1) return heap;

            switch (algorithm)
            {
                case SortType.Bubble:
                    await BubbleSort(heap).ConfigureAwait(true);
                    break;
                case SortType.Selection:
                    await SelectionSort(heap).ConfigureAwait(true);
                    break;
                case SortType.Insertion:
                    await InsertionSort(heap).ConfigureAwait(true);
                    break;
                case SortType.MergeMemoryCost:
                    await MergeSort_MemoryLeaked(heap).ConfigureAwait(true);
                    break;
                case SortType.MergeTimeCost:
                    await MergeSort_TimeLeaked(heap).ConfigureAwait(true);
                    break;
                case SortType.QuickRecursiveMemoryLeaky:
                    await QuickSortRecursiveMemoryLeaky(heap).ConfigureAwait(true);
                    break;
                case SortType.HeapTimeCost:
                    await HeapSortTimeLeak(heap).ConfigureAwait(true);
                    break;
            }

            return heap;
        }

        #region SimpleSorts

        public async Task BubbleSort(IList<T> heap)
        {
            var unordered = true;
            while (unordered)
            {
                unordered = false;
                for (int i = 1; i <= heap.Count - 1; i++)
                {
                    if (heap[i].CompareTo(heap[i - 1]) < 0)
                    {
                        heap.Swap(i, i - 1);
                        unordered = true;
                    }
                }
            }
        }

        public async Task SelectionSort(IList<T> heap)
        {
            int iUnsorted = 0;
            while (iUnsorted < heap.Count)
            {
                int iMin = iUnsorted;
                for (int i = iUnsorted; i < heap.Count; i++)
                {
                    if (heap[i].CompareTo(heap[iMin]) < 0)
                        iMin = i;
                }

                heap.Swap(iUnsorted, iMin);
                iUnsorted++;
            }
        }

        public async Task InsertionSort(IList<T> heap)
        {
            for (int i = 1; i < heap.Count; i++)
            {
                var iNew = i;
                for (int j = i - 1; j >= 0; j--)
                {
                    if (heap[i].CompareTo(heap[j]) < 0)
                        iNew = j;
                }
                heap.MoveTo(i, iNew);
            }
        }

        #endregion

        #region MergeSort_MemoryLeaked
        /// Implementation relays on creating sub-arrays during sorting. Those its time efficient (no
        /// altering of existing arrays), but memory inefficient (numerous of sub-arrays are created
        /// on each step of the sort).

        public async Task MergeSort_MemoryLeaked(IList<T> heap)
        {
            var holder = new List<List<T>>();
            foreach (var item in heap)
            {
                holder.Add(new List<T> { item });
            }

            while (holder.Count > 1)
            {
                for (int i = 0; i < holder.Count - 1; i++)
                {
                    var merged = MergeLists(holder[i], holder[i + 1]);
                    holder.RemoveAt(i);
                    holder.RemoveAt(i);
                    holder.Insert(i, merged);
                }
            }

            for (int i = 0; i < heap.Count; i++)
            {
                heap[i] = holder[0][i];
            }
        }

        private static List<T> MergeLists(List<T> list1, List<T> list2)
        {
            var result = new List<T>();

            var i1 = 0;
            var i2 = 0;

            while (true)
            {
                if (list1[i1].CompareTo(list2[i2]) < 0)
                {
                    result.Add(list1[i1]);
                    i1++;
                    if (i1 == list1.Count)
                    {
                        while (i2 < list2.Count)
                        {
                            result.Add(list2[i2]);
                            i2++;
                        }
                    }
                }
                else
                {
                    result.Add(list2[i2]);
                    i2++;
                    if (i2 == list2.Count)
                    {
                        while (i1 < list1.Count)
                        {
                            result.Add(list1[i1]);
                            i1++;
                        }
                    }
                }

                if (result.Count == list1.Count + list2.Count) break;
            }

            return result;
        }
        #endregion

        #region MergeSort_TimeLeaked
        /// Implementation works with a single instance of entities and move them around via
        /// inserting and removing items of existing list. Those - it is memory efficient (since no
        /// sub arrays are created) but time inefficient, since inserting into same array is time consuming.

        public async Task MergeSort_TimeLeaked(IList<T> heap)
        {
            var c = 1;
            while (c < heap.Count)
            {
                for (int i = 0; i < heap.Count; i += c * 2)
                {
                    var width1 = c;
                    var width2 = i + c * 2 < heap.Count ? c : heap.Count - (i + c);
                    if (width1 != width2)
                    {
                        if(width2 < 1) continue;
                    }
                    Merge(heap, i, width1, width2);
                }   

                c *= 2;
            }
        }

        private static void Merge(IList<T> list, int iStart, int width1, int width2)
        {
            var i1 = iStart;
            var i2 = iStart + width1;

            while (i1 != i2)
            {
                if (list[i2].CompareTo(list[i1]) < 0)
                {
                    list.MoveTo(i2, i1);
                    if (i2 < iStart + width1 + width2 - 1) i2++;
                }
                i1++;

                if (i1 == i2 && i2 < iStart + width1 + width2 - 1) i2++;
            }
        }

        #endregion

        #region QuickSortRecursiveMemoryLeaky
        /// <summary>
        /// Able to resolve 1 000 000 items sort in around 1-2 minutes
        /// </summary>
        /// <param name="heap"></param>
        public async Task QuickSortRecursiveMemoryLeaky(IList<T> heap)
        {
            var res = QuickSortIteration(CalculateQuickSortStepArguments(heap));

            heap.Clear();
            foreach (var item in res)
                heap.Add(item);
        }

        private Tuple<List<T>, T, List<T>> CalculateQuickSortStepArguments(IList<T> heap)
        {
            if(heap.Count == 0) return null;
            var left = new List<T>();
            var right = new List<T>();

            for (int i = 0; i < heap.Count / 2; i++)
                left.Add(heap[i]);

            for (int i = heap.Count / 2 + 1; i < heap.Count; i++)
                right.Add(heap[i]);

            return new Tuple<List<T>, T, List<T>>(left, heap[heap.Count / 2], right);
        }

        private List<T> QuickSortIteration(Tuple<List<T>, T, List<T>> args)
        {
            if (args == null) return new List<T>();
            var lHeap = args.Item1;
            var pivot = args.Item2;
            var rHeap = args.Item3;

            if(lHeap.Count == 0 && rHeap.Count == 0) return new List<T>{ pivot };

            var result = new List<T>();

            for (int i = 0; i < lHeap.Count; i++)
            {
                if (lHeap[i].CompareTo(pivot) > 0)
                {
                    //This insertion makes sort unstable.
                    rHeap.Add(lHeap[i]);
                    lHeap.RemoveAt(i);
                    i--;
                }
            }

            for (var i = 0;  i < rHeap.Count; i++)
            {
                if (rHeap[i].CompareTo(pivot) < 1)
                {
                    lHeap.Add(rHeap[i]);
                    rHeap.RemoveAt(i);
                    i--;
                }
            }

            result.AddRange(QuickSortIteration(CalculateQuickSortStepArguments(lHeap)));
            result.Add(pivot);
            result.AddRange(QuickSortIteration(CalculateQuickSortStepArguments(rHeap)));

            return result;
        }

        #endregion

        #region HeapSort
        ///TODO: works but very slow. Diagnostics point to GetParentIndex(i) from CompareParent;
        public async Task HeapSortTimeLeak(IList<T> heap)
        {
            var unsorted = heap.Count;
            while (unsorted > 1)
            {
                var i = (unsorted - 1) % 2 != 0 ? unsorted - 2 : unsorted - 3;
                while (i >= 0)
                {
                    if (i < unsorted) CompareParent(heap, GetGreaterItemIndex(heap, i, i+1), unsorted);
                    i -= 2;
                }

                heap.Swap(0, unsorted - 1);
                unsorted--;
            }
        }

        public static void CompareParent(IList<T> heap, int i, int lim)
        {
            var ip = GetParentIndex(i);
            if (ip < 0) return;

            if (heap[i].CompareTo(heap[ip]) > 0)
            {
                heap.Swap(i, ip);
                var res = CompareChild(heap, i, lim);
                while (res != null)
                    res = CompareChild(heap, res.Value, lim);
            }
        }

        public static int? CompareChild(IList<T> heap, int ip, int lim)
        {
            var ilc = GetLeftChildIndex(ip);
            if (ilc >= lim) return null;
            
            var i = ilc + 1 >= lim ? ilc : GetGreaterItemIndex(heap, ilc, ilc + 1);

            if (heap[i].CompareTo(heap[ip]) > 0)
            {
                heap.Swap(i, ip);
                return i;
            }

            return null;
        }

        private static int GetGreaterItemIndex(IList<T> heap, int i1, int i2)
        {
            return heap[i1].CompareTo(heap[i2]) > 0 ? i1 : i2;
        }

        public static int GetParentIndex(int i)
            => (i + 1)/2 - 1;

        private static int GetLeftChildIndex(int i)
            => i * 2 + 1;

        #endregion
    }
}
