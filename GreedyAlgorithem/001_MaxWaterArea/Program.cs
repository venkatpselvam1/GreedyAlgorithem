using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_MaxWaterArea
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of the line i is at (i, ai) and (i, 0). Find two lines, which, together with the x-axis forms a container, such that the container contains the most water.

             * Notice that you may not slant the container.
             */

            /*
             * Input: height = [1,8,6,2,5,4,8,3,7]
             * Output: 49
             * Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7].
             * In this case, the max area of water (blue section) the container can contain is 49.
             */

            /*
             * Input: height = [4,3,2,1,4]
             * Output: 16
             */
            var sln = new Solution();
            var height = new int[]{ 1,8,6,2,5,4,8,3,7 };
            var ans = sln.MaxArea(height);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            public int MaxArea(int[] height)
            {
                var ans = 0;
                var a = 0;
                var b = height.Length - 1;
                while (a < b)
                {
                    ans = Math.Max( Math.Min(height[a], height[b]) * (b-a), ans);
                    if (height[a] > height[b])
                    {
                        b--;
                    }
                    else
                    {
                        a++;
                    }
                }
                return ans;
            }
        }
    }
}
