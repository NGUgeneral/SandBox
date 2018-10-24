using System.Collections.Generic;

namespace SandBox.Sorting
{
    interface ISort<T>
    {
        void  Start(IList<T> heap, SortType sortingAlgorithm);

        void StartAndValidate(IList<T> heap, SortType sortingAlgorithm);
    }

    public enum SortType
    {
        Bubble = 1,
        Selection = 2,
        Insertion = 3,
        MergeMemoryCost = 4,
        MergeTimeCost = 5,
        QuickRecursiveMemoryLeaky = 6,
        HeapTimeCost = 7,
    }

}
