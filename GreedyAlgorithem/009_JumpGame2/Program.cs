using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _009_JumpGame2
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
            ////////////////////////////////////////////////////////////////////////////////////////
            // this is another example for DP with memoziation. Before we saw the tabulation.
            // This solution will time out as we didn't use the dynamic programming, we simplified the problem here.
            ////////////////////////////////////////////////////////////////////////////////////////
            var sln = new Solution();
            var arr = new int[] { 2, 3, 1, 1, 4 };
            var ans = sln.Jump(arr);
            Console.WriteLine(ans);
        }

        public class Solution
        {
            int[] nums;
            public int Jump(int[] nums)
            {
                this.nums = nums;
                var dp = new Node[nums.Length];
                for (int i = 0; i < dp.Length; i++)
                {
                    dp[i] = new Node();
                }
                dp[nums.Length - 1].IsReachable = true;
                MinJump(0, dp);
                return dp[0].Value;
            }
            public void MinJump(int ind, Node[] dp)
            {
                if (dp[ind].IsReachable.HasValue)
                {
                    return;
                }
                for (int i = 1; i <= nums[ind] && ind + i < nums.Length; i++)
                {
                    MinJump(ind+i, dp);
                    if (dp[ind+i].IsReachable.HasValue && dp[ind + i].IsReachable.Value)
                    {
                        dp[ind].Value = dp[ind].IsReachable.HasValue && dp[ind].IsReachable.Value ? Math.Min(dp[ind + i].Value + 1, dp[ind].Value) : dp[ind+i].Value+1;
                        dp[ind].IsReachable = true;
                    }
                }
            }
            public class Node
            {
                public bool? IsReachable;
                public int Value;
            }
        }
    }
}
