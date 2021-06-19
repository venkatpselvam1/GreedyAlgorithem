using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace _007_Huffman_Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
                Steps to build Huffman Tree
                Input is an array of unique characters along with their frequency of occurrences and output is Huffman Tree. 

                Create a leaf node for each unique character and build a min heap of all leaf nodes (Min Heap is used as a priority queue.
                The value of frequency field is used to compare two nodes in min heap. Initially, the least frequent character is at root)
                Extract two nodes with the minimum frequency from the min heap.
 
                Create a new internal node with a frequency equal to the sum of the two nodes frequencies.
                Make the first extracted node as its left child and the other extracted node as its right child. Add this node to the min heap.
                Repeat steps#2 and #3 until the heap contains only one node. The remaining node is the root node and the tree is complete.
                Let us understand the algorithm with an example:
             */

            /*
             character   Frequency
                a            5
                b           9
                c           12
                d           13
                e           16
                f           45
             */

            /*
             character   code-word
                f          0
                c          100
                d          101
                a          1100
                b          1101
                e          111
             */
            var nodes = new List<HuffmanCodingNode>();
            nodes.Add(new HuffmanCodingNode() { Ch='a', Value=5 });
            nodes.Add(new HuffmanCodingNode() { Ch='b', Value=9 });
            nodes.Add(new HuffmanCodingNode() { Ch='c', Value=12 });
            nodes.Add(new HuffmanCodingNode() { Ch='d', Value=13 });
            nodes.Add(new HuffmanCodingNode() { Ch='e', Value=16 });
            nodes.Add(new HuffmanCodingNode() { Ch='f', Value=45 });
            PrintHuffManCoding(nodes);
        }
        public static void PrintHuffManCoding(List<HuffmanCodingNode> nodes)
        {
            while (nodes.Count > 1)
            {
                nodes.Sort(new Comparer());
                var node1 = nodes.Last();
                nodes.Remove(node1);
                var node2 = nodes.Last();
                nodes.Remove(node2);
                var node3 = new HuffmanCodingNode() 
                {
                    Value = node1.Value + node2.Value,
                    Left = node1,
                    Right = node2,
                };
                nodes.Add(node3);
            }
            var head = nodes.First();
            head.Print();

        }
    }
}
