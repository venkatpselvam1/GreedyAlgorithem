using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace _009_Huffman_Decoding
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "GeeksforGeeks";
            var dict = GetHufmanCodingDict(str);
            var encodedStr = EncodeStr(str, dict);
            var decodedStr = DecodeStr(encodedStr, dict);
            Console.WriteLine(str == decodedStr);
        }
        public static Dictionary<char, string> GetHufmanCodingDict(string str)
        {
            var nodes = Utilities.Helper.GetHuffMancoding(str);
            var dict = PrintHuffManCoding(nodes);
            return dict;
        }
        public static string EncodeStr(string str, Dictionary<char, string> dict)
        {
            string encodedStr = string.Empty;
            foreach (var item in str)
            {
                encodedStr += dict[item];
            }
            return encodedStr;
        }
        public static string DecodeStr(string str, Dictionary<char, string> dict)
        {
            string ans = string.Empty;
            while (str.Length > 0)
            {
                foreach (var item in dict)
                {
                    if (str.StartsWith(item.Value))
                    {
                        str = str.Substring(item.Value.Length);
                        ans += item.Key;
                        break;
                    }
                }
            }
            return ans;
        }
        public static Dictionary<char, string> PrintHuffManCoding(List<HuffmanCodingNode> nodes)
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
                    Left = node2,
                    Right = node1
                };
                queue2.Enqueue(node3);
            }
            var head = queue2.Dequeue();
            var an = head.GetDict();
            
            return an;
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
