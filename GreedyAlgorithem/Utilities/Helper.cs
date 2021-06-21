using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Helper
    {
        public static void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static List<HuffmanCodingNode> GetHuffMancoding(string str)
        {
            var dictionary = new Dictionary<char, int>();
            foreach (var item in str)
            {
                if (dictionary.ContainsKey(item))
                {
                    dictionary[item] += 1;
                }
                else
                {
                    dictionary.Add(item, 1);
                }
            }
            List<HuffmanCodingNode> huffmanCodingNodes = new List<HuffmanCodingNode>();
            foreach (var item in dictionary)
            {
                huffmanCodingNodes.Add(new HuffmanCodingNode() { Ch = item.Key, Value = item.Value});
            }
            huffmanCodingNodes.Sort(new Comparer());
            return huffmanCodingNodes;
        }
    }
}
