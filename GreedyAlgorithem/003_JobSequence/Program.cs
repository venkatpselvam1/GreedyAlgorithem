using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_JobSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Given an array of jobs where every job has a deadline and associated profit if the job is finished before the deadline. 
            It is also given that every job takes a single unit of time, so the minimum possible deadline for any job is 1.
            How to maximize total profit if only one job can be scheduled at a time.
             */
            /*
             Input: Four Jobs with following 
                deadlines and profits
                JobID  Deadline  Profit
                  a      4        20   
                  b      1        10
                  c      1        40  
                  d      1        30
                Output: Following is maximum 
                profit sequence of jobs
                        c, a   


             Input:  Five Jobs with following
                deadlines and profits
                JobID   Deadline  Profit
                  a       2        100
                  b       1        19
                  c       2        27
                  d       1        25
                  e       3        15
                Output: Following is maximum 
                profit sequence of jobs
                        c, a, e
             */

            /*
             Description:
                For the day 1: we can any of the 3 jobs in b,c,d => to maximize the profit we choose c(40)
                For the day 2: we can choose only a. Because can be done on day 2 as deadline is completed.
             */
            JobDetails[] jobDetails1 = new JobDetails[] {
                new JobDetails(){ DeadLine = 1, Profit = 40, Name="c" },
                new JobDetails(){ DeadLine = 1, Profit = 30, Name="d" },
                new JobDetails(){ DeadLine = 1, Profit = 10, Name="b" },
                new JobDetails(){ DeadLine = 4, Profit = 20, Name="a" },
            };
            JobDetails[] jobDetails = new JobDetails[] {
                new JobDetails(){ DeadLine = 2, Profit = 100, Name="a" },
                new JobDetails(){ DeadLine = 1, Profit = 19, Name="b" },
                new JobDetails(){ DeadLine = 2, Profit = 27, Name="c" },
                new JobDetails(){ DeadLine = 1, Profit = 25, Name="d" },
                new JobDetails(){ DeadLine = 3, Profit = 15, Name="e" },
            };
            GetMaximumProfit(jobDetails);
        }
        public class Comparer : IComparer<JobDetails>{
            public int Compare(JobDetails x, JobDetails y)
            {
                return y.Profit - x.Profit;
            }
        }
    public static void GetMaximumProfit(JobDetails[] jobDetails)
        {
            if (jobDetails.Length == 0)
            {
                Console.WriteLine("No jobs is given");
            }
            Array.Sort(jobDetails, comparer: new Comparer());
            //InsertionSort(jobDetails);

            var ans = new JobDetails[jobDetails.Length];
            for (int i = 0; i < jobDetails.Length; i++)
            {
                var j = jobDetails[i].DeadLine - 1;
                while (j >= 0 && ans[j] != null)
                {
                    j--;
                }
                if (j >= 0)
                {
                    ans[j] = jobDetails[i];

                }
            }
            for (int k = 0; k < ans.Length; k++)
            {
                if (ans[k] != null)
                {
                    Console.WriteLine(ans[k].Name);
                }
            }
        }
        public class JobDetails
        {
            public int DeadLine { get; set; }
            public int Profit { get; set; }
            public string Name { get; set; }
        }
    }
}
