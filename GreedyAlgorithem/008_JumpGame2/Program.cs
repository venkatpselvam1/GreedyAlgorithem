using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _008_JumpGame2
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
                return Jump(0).Jump;
            }
            public Node Jump(int ind)
            {

                var ans = new Node();
                if (ind == nums.Length - 1)
                {
                    ans.IsReachable = true;
                    return ans;
                }
                if (ind >= nums.Length)
                {
                    return ans;
                }
                for (int i = 1; i <= nums[ind]; i++)
                {
                    var node = Jump(ind+i);
                    if (node.IsReachable)
                    {
                        ans.Jump = ans.IsReachable ? Math.Min(ans.Jump, node.Jump + 1) : node.Jump+1;
                        ans.IsReachable = true;
                    }
                }
                return ans;
            }
            public class Node
            {
                public bool IsReachable;
                public int Jump;
            }
        }
    }
}
