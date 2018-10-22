using System;
using System.Collections.Generic;

namespace SandBox.Sorting
{
    class Sort<T> : ISort<T> where T : IComparable
    {
        public void Start(IList<T> heap, SortType algorithm)
        {
            if(heap == null) throw new NullReferenceException("Can't order a null sequence");
            if (heap.Count == 1) return;

            switch(algorithm)
            {
                case SortType.Bubble:
                    BubbleSort(heap);
                    break;
                case SortType.Selection:
                    SelectionSort(heap);
                    break;
                case SortType.Insertion:
                    InsertionSort(heap);
                    break;
                case SortType.MergeMemoryCost:
                    MergeSort_MemoryLeaked(heap);
                    break;
                case SortType.MergeTimeCost:
                    MergeSort_TimeLeaked(heap);
                    break;
                default:
                    break;
            }
        }

        public void StartAndValidate(IList<T> heap, SortType algorithm)
        {
            Start(heap, algorithm);
            Console.WriteLine($"Collection is sorted: {heap.ValidateSequence().ToString().ToUpper()}");
        }

        public void BubbleSort(IList<T> heap)
        {
            var unordered = true;
            while (unordered)
            {
                unordered = false;
                for (int i = 1; i <= heap.Count - 1; i++)
                {
                    if (heap[i].CompareTo(heap[i - 1]) < 0)
                    {
                        heap.Flip(i, i - 1);
                        unordered = true;
                    }
                }
            }
        }

        public void SelectionSort(IList<T> heap)
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

                heap.Flip(iUnsorted, iMin);
                iUnsorted++;
            }
        }

        public void InsertionSort(IList<T> heap)
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

        #region MergeSort_MemoryLeaked
        /// Implementation relays on creating subarrays during sorting. Those its time efficient (no
        /// altering of existing arrays), but memory inefficient (numerous of subarrays are created
        /// on each step of the sort).

        public void MergeSort_MemoryLeaked(IList<T> heap)
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

        private List<T> MergeLists(List<T> list1, List<T> list2)
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

        public static void MergeSort_TimeLeaked(IList<T> heap)
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
    }
}
