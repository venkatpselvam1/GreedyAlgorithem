using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_JobSequence_Loss_Minimization
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
              We are given N jobs numbered 1 to N. For each activity, let Ti denotes the number of days required to complete the job.
              For each day of delay before starting to work for job i, a loss of Li is incurred.
              We are required to find a sequence to complete the jobs so that overall loss is minimized.
              We can only work on one job at a time.

              If multiple such solutions are possible, then we are required to give the lexicographically least permutation (i.e earliest in dictionary order).
             */

            /*
                Input : L = {3, 1, 2, 4} and 
                T = {4, 1000, 2, 5}
                Output : 3, 4, 1, 2
                Explanation: We should first complete 
                job 3, then jobs 4, 1, 2 respectively.

                Input : L = {1, 2, 3, 5, 6} 
                        T = {2, 4, 1, 3, 2}
                Output : 3, 5, 4, 1, 2 
                Explanation: We should complete jobs 
                3, 5, 4, 1 and then 2 in this order.
             */
        }
    }
}
