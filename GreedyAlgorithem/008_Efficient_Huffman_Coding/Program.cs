using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace _008_Efficient_Huffman_Coding
{
    class Program
    {
        static void Main(string[] args)
        {
            var nodes = new List<HuffmanCodingNode>();
            nodes.Add(new HuffmanCodingNode() { Ch = 'a', Value = 5 });
            nodes.Add(new HuffmanCodingNode() { Ch = 'b', Value = 9 });
            nodes.Add(new HuffmanCodingNode() { Ch = 'c', Value = 12 });
            nodes.Add(new HuffmanCodingNode() { Ch = 'd', Value = 13 });
            nodes.Add(new HuffmanCodingNode() { Ch = 'e', Value = 16 });
            nodes.Add(new HuffmanCodingNode() { Ch = 'f', Value = 45 });
            PrintHuffManCoding(nodes);
        }
        public static void PrintHuffManCoding(List<HuffmanCodingNode> nodes)
        {
            var queue1 = new Queue<HuffmanCodingNode>();
            var queue2 = new Queue<HuffmanCodingNode>();
            foreach (var node in nodes)
            {
                queue1.Enqueue(node);
            }
            while (queue1.Count + queue2.Count > 1)
            {
                var node1 = SelectSmallNode(queue1, queue2);
                var node2 = SelectSmallNode(queue1, queue2);
                var node3 = new HuffmanCodingNode()
                {
                    Value = node1.Value + node2.Value,
                    Left = node1,
                    Right = node2
                };
                queue2.Enqueue(node3);
            }
            var head = queue2.Dequeue();
            head.Print();
        }
        public static HuffmanCodingNode SelectSmallNode(Queue<HuffmanCodingNode> q1, Queue<HuffmanCodingNode> q2)
        {
            if (q1.Count == 0)
            {
                return q2.Dequeue();
            }
            if (q2.Count == 0)
            {
                return q1.Dequeue();
            }
            var node1 = q1.Peek();
            var node2 = q2.Peek();
            if (node1.Value < node2.Value)
            {
                return q1.Dequeue();
            }
            else
            {
                return q2.Dequeue();
            }
        }
    }
}
