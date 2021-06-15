using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivitySelectionProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Example 1 : Consider the following 3 activities sorted by
            by finish time.
                        start[]  = { 10, 12, 20 };
                        finish[] = { 20, 25, 30 };
            A person can perform at most two activities. The
            maximum set of activities that can be executed
            is { 0, 2 } [These are indexes in start[] and
              finish[] ]

            Example 2 : Consider the following 6 activities
            sorted by by finish time.
                        start[]  = { 1, 3, 0, 5, 8, 5 };
                        finish[] = { 2, 4, 6, 7, 9, 9 };
            A person can perform at most four activities. The
            maximum set of activities that can be executed
            is { 0, 1, 3, 4 } [These are indexes in start[] and
              finish[] ]*/
            /*
             In the above example 1, activity 0 starts at 10 and finishes at 20.
            We can do activity 1, as it starts at 12  which is in b/w 10 and 20.
             */
            //int[] s = { 1, 3, 0, 5, 8, 5 };
            //int[] f = { 2, 4, 6, 7, 9, 9 };
            int[] s = { 5, 0,1, 3, 5, 8, };
            int[] f = { 9, 6,2, 4, 7, 9, };
            PrintMaximumActivity(s, f, 4);
        }

        public static void PrintMaximumActivity(int[] startTimes, int[] finishTimes, int selection)
        {
            SortByFinishTimes(startTimes, finishTimes);
            if (startTimes.Length != finishTimes.Length)
            {
                return;
            }
            int j = 0;
            Console.WriteLine(j);

            for (int i = 1; i <= selection; i++)
            {
                if (startTimes[i] >= finishTimes[j])
                {
                    Console.WriteLine(i);
                    j = 1;
                }
            }
        }
        public static void SortByFinishTimes(int[] startTimes, int[] finishTimes)
        {
            var length = finishTimes.Length;
            var indexOfNotleafNode = (length-1) / 2;
            for (int j = indexOfNotleafNode; j >= 0; j--)
            {
                Heapify(finishTimes, length, j, startTimes);
            }
            for (int i = length - 1; i >= 0; i--)
            {
                Utilities.Helper.Swap(finishTimes, i, 0);
                Utilities.Helper.Swap(startTimes, i, 0);
                Heapify(finishTimes, i, 0, startTimes);
            }
        }
        public static void Heapify(int[] arr, int n, int ind, int[] arr1)
        {
            // left of the index = 2n+1, right of the index = 2n+2
            // parent of the index n => (n-1)/2
            var leftInd = 2 * ind + 1;
            var rightInd = 2 * ind + 2;
            var largestInd = ind;
            if (leftInd < n && arr[largestInd] < arr[leftInd])
            {
                largestInd = leftInd;
            }
            if (rightInd < n && arr[largestInd] < arr[rightInd])
            {
                largestInd = rightInd;
            }
            if (largestInd != ind)
            {
                Utilities.Helper.Swap(arr, largestInd, ind);
                Utilities.Helper.Swap(arr1, largestInd, ind);
                Heapify(arr, n, largestInd, arr1);
            }
        }
    }
}
