using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006_JobSequence_Loss_Minimization_Set_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                We have discussed one loss minimization strategy before: Job Sequencing Problem – Loss Minimization.
                In this article, we will look at another strategy that applies to a slightly different problem.
                We are given a sequence of N goods of production numbered from 1 to N. Each good has a volume denoted by (Vi).
                The constraint is that once a good has been completed its volume starts decaying at a fixed percentage (P) per day.
                All goods decay at the same rate and further each good take one day to complete. 
                We are required to find the order in which the goods should be produced so that the overall volume of goods is maximized.
             */

            /*
                Example-1: 

                Input: 4, 2, 151, 15, 1, 52, 12 and P = 10%
                Output: 222.503
                Solution: In the optimum sequence of jobs, the total volume of goods left at the end of all jobs is 222.503
                Example-2:  

                Input: 3, 1, 41, 52, 15, 4, 1, 63, 12 and P = 20%
                Output: 145.742
             */
            //var jobs = new int[] { 4, 2, 151, 15, 1, 52, 12 };
            //var loss = 10;//10% per day

            var jobs = new int[] { 3, 1, 41, 52, 15, 4, 1, 63, 12 };
            var loss = 20;//10% per day
            Console.WriteLine(GetMinimumLoss(jobs, loss));
        }
        public class Comparer : IComparer<int>
        {
            public int Compare(int a, int b)
            {
                return b - a;
            }
        }
        public static double GetMinimumLoss(int[] jobs, int loss)
        {
            Array.Sort(jobs, new Comparer());
            var ans = 0.0;
            var lossPercent = 1 - loss / 100.0;
            for (int i = 0; i < jobs.Length; i++)
            {
                ans += jobs[i] * Math.Pow(lossPercent, i);
            }
            return ans;
        }
    }
}
