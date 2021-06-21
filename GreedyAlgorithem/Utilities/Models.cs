using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class HuffmanCodingNode
    {
        private const char DefautChar = '-';

        public HuffmanCodingNode()
        {
            Ch = DefautChar;
        }
        public int Value;
        public char Ch;
        public HuffmanCodingNode Left;
        public HuffmanCodingNode Right;
        public void Print()
        {
            Print(this, string.Empty);
        }
        public Dictionary<char, string> GetDict()
        {
            var dict = new Dictionary<char, string>();
            PopulateDict(this, string.Empty, dict);
            return dict;
        }
        private void Print(HuffmanCodingNode node, string s)
        {
            if (node == null)
            {
                return;
            }
            if (node.Left == null && node.Right == null && node.Ch != DefautChar)
            {
                Console.WriteLine(node.Ch + " : " + s);
                return;
            }

            Print(node.Left, s + "0");
            Print(node.Right, s + "1");
        }
        private void PopulateDict(HuffmanCodingNode node, string s, Dictionary<char, string> dict)
        {
            if (node == null)
            {
                return;
            }
            if (node.Left == null && node.Right == null && node.Ch != DefautChar)
            {
                Console.WriteLine(node.Ch + " : " + s);
                dict.Add(node.Ch, s);
                return;
            }

            PopulateDict(node.Left, s + "0", dict);
            PopulateDict(node.Right, s + "1", dict);
        }
    }
    public class Comparer : IComparer<HuffmanCodingNode>
    {
        public int Compare(HuffmanCodingNode a, HuffmanCodingNode b)
        {
            return b.Value - a.Value;
        }
    }
}
