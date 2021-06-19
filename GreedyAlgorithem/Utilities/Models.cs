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
    }
    public class Comparer : IComparer<HuffmanCodingNode>
    {
        public int Compare(HuffmanCodingNode a, HuffmanCodingNode b)
        {
            return b.Value - a.Value;
        }
    }
}
