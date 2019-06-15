using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetterTilePossibilities
{
    class Solution
    {
        public int NumTilePossibilities(string tiles)
        {
            var dic = new Dictionary<char, int>();

            foreach (var tile in tiles)
            {
                if (dic.ContainsKey(tile))
                    dic[tile]++;
                else
                    dic.Add(tile, 1);
            }

            var result = 0;

            for (var i = 1; i <= tiles.Length; i++)
            {
                var partialDic = new Dictionary<char, int>(dic);
                var partialResult = GetCombinations(partialDic, i);
                result += partialResult;
            }

            return result;
        }

        private int GetCombinations(Dictionary<char, int> dic, int length)
        {
            if (length == 1)
                return dic.Count;

            var result = 0;

            foreach (var c in dic.Keys.ToArray())
            {
                var partialDic = new Dictionary<char, int>(dic);
                partialDic[c]--;

                if (partialDic[c] == 0)
                    partialDic.Remove(c);

                result += GetCombinations(partialDic, length - 1);
            }

            return result;
        }

        private int Factorial(int n)
        {
            if (n == 0 || n == 1)
                return 1;

            return n * this.Factorial(n - 1);
        }
    }
}
