using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_JumpGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given an array of non-negative integers nums, you are initially positioned at the first index of the array.
             * Each element in the array represents your maximum jump length at that position.
             * Your goal is to reach the last index in the minimum number of jumps.
             * You can assume that you can always reach the last index.
             */

            /*
             * Input: nums = [2,3,1,1,4]
             * Output: 2
             * Explanation: The minimum number of jumps to reach the last index is 2.
             * Jump 1 step from index 0 to 1, then 3 steps to the last index.
             */

            /*
             * Input: nums = [2,3,0,1,4]
             * Output: 2
             */
            var sln = new Solution();
            var arr = new int[] { };
            var ans = sln.Jump(arr);
            Console.WriteLine(ans);
        }

        public class Solution
        {
            public int Jump(int[] nums)
            {
                var length = nums.Length;
                var dp = new Node[length];
                for (int i = 0; i < length; i++)
                {
                    dp[i] = new Node();
                }
                dp[length - 1].IsReachable = true;

                for (int i = length - 2; i >= 0; i--)
                {
                    for (int j = 1; j <= nums[i] && i + j < length; j++)
                    {
                        if (dp[i + j].IsReachable)
                        {
                            dp[i].IsReachable = true;
                            var val = dp[i + j].Jump + 1;
                            dp[i].Jump = dp[i].Jump == 0 ? val : Math.Min(dp[i].Jump, val);
                        }
                    }
                }

                return dp[0].Jump;
            }
            public class Node
            {
                public bool IsReachable;
                public int Jump;
            }
        }
    }
}
