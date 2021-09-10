using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _005_WildcardMatching
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*' where:
             * '?' Matches any single character.
             * '*' Matches any sequence of characters (including the empty sequence).
             * The matching should cover the entire input string (not partial).
             */

            /*
             * Input: s = "aa", p = "a"
             * Output: false
             * Explanation: "a" does not match the entire string "aa".
             */

            /*
             * Input: s = "aa", p = "*"
             * Output: true
             * Explanation: '*' matches any sequence.
             */
            /*
             * Input: s = "acdcb", p = "a*c?b"
             * Output: false
 
             * Input: s = "adceb", p = "*a*b"
             * Output: true
             * Explanation: The first '*' matches the empty sequence, while the second '*' matches the substring "dce".
             
             *Input: s = "cb", p = "?a"
             * Output: false
             * Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'. 
             */
            var sln = new Solution();
            var a = "adceb";
            var b = "*a*b";
            var ans = sln.IsMatch(a, b);
            Console.WriteLine(ans);
        }
        public class Solution
        {
            string s, p;
            public bool IsMatch(string s, string p)
            {
                this.s = s;
                this.p = p;
                return IsMatch(0, 0);
            }
            public bool IsMatch(int i, int j)
            {
                if (s.Length == i)
                {
                    if (p.Length == j)
                    {
                        return true;
                    }

                    return p[j] == '*' ? IsMatch(i, j + 1)  : false;
                }
                else if(p.Length == j)
                {
                    return false;
                }

                // both i and j index are valid
                if (s[i] == p[j] || p[j] == '?')
                {
                    return IsMatch(i+1, j+1);
                }
                if (p[j] == '*')
                {
                    for (int k = i; k <= s.Length; k++)
                    {
                        if (IsMatch(k, j+1))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
