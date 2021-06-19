using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_JobSequence_Disjoint
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
                new JobDetails(){ DeadLine = 7, Profit = 110, Name="d" },
                new JobDetails(){ DeadLine = 1, Profit = 19, Name="b" },
                new JobDetails(){ DeadLine = 2, Profit = 27, Name="c" },
                new JobDetails(){ DeadLine = 1, Profit = 25, Name="d" },
                new JobDetails(){ DeadLine = 3, Profit = 15, Name="e" },
            };
            GetMaximumProfitDisjoint(jobDetails);
        }
        public class Disjoint
        {
            int[] arr;
            public Disjoint(int maxDeadline)
            {
                arr = new int[maxDeadline+1];
                for (int i = 0; i <= maxDeadline; i++)
                {
                    arr[i] = i;
                }
            }
            public int Find(int s)
            {
                if (s == arr[s])
                {
                    return s;
                }
                return arr[s] = Find(s - 1);
            }
            public void Merge(int a, int b)
            {
                arr[b] = a;
            }
        }
        public class Comparer : IComparer<JobDetails>
        {
            public int Compare(JobDetails a, JobDetails b)
            {
                return b.Profit - a.Profit;
            }
        }
        public static void GetMaximumProfitDisjoint(JobDetails[] jobDetails)
        {
            Array.Sort(jobDetails, new Comparer());
            var maxDeadLine = FindMaxDeadline(jobDetails);
            var disJoint = new Disjoint(maxDeadLine);
            for (int i = 0; i < jobDetails.Length; i++)
            {
                var availble = disJoint.Find(jobDetails[i].DeadLine);
                if (availble != 0)
                {
                    disJoint.Merge(disJoint.Find(availble - 1), availble);
                    Console.WriteLine(jobDetails[i].Name);
                }
            }
        }
        public static int FindMaxDeadline(JobDetails[] jobDetails)
        {
            var largestDeadLine = 0;
            for (int i = 1; i < jobDetails.Length; i++)
            {
                if (jobDetails[largestDeadLine].DeadLine < jobDetails[i].DeadLine)
                {
                    largestDeadLine = i;
                }
            }
            return jobDetails[largestDeadLine].DeadLine;
        }
        public class JobDetails
        {
            public int DeadLine { get; set; }
            public int Profit { get; set; }
            public string Name { get; set; }
        }

    }
}
