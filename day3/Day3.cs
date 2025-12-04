using System;
using System.Collections.Generic;
using System.Numerics;


namespace AdventOfCode2025
{
    internal class Day3
    {
        private InputData Data => ParseFile();

        public void Part1()
        {
            int totalJoltage = Data.banks
                .Select(bank =>
                {
                    var digits = bank.Select(c => c - '0').ToArray();

                    var maxJoltage = (from i in Enumerable.Range(0, digits.Length - 1)
                                      from j in Enumerable.Range(i + 1, digits.Length - i - 1)
                                      select digits[i] * 10 + digits[j])
                                     .Max();

                    return maxJoltage;
                })
                .Sum();

            Console.WriteLine($"Total output joltage = {totalJoltage}");
        }
        

        public void Part2()
        {
            BigInteger total = 0;
            foreach (var bank in Data.banks)
            {
                total += BigInteger.Parse(GetMaxSubsequence(bank, 12));
            }
            Console.WriteLine($"Total output joltage = {total}");
        }

        static string GetMaxSubsequence(string s, int k)
        {
            var stack = new List<char>();
            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                char c = s[i];

                while (stack.Count > 0 && stack[stack.Count - 1] < c && (stack.Count - 1 + (n - i)) >= k)
                {
                    stack.RemoveAt(stack.Count - 1);
                }
                if (stack.Count < k)
                {
                    stack.Add(c);
                }
            }

            return new string(stack.ToArray());
        }

        private class InputData
        {
            public List<string> banks;

            public InputData()
            {
                banks = new List<string>();
            }
        }

        private InputData ParseFile()
        {
            var returnValue = new InputData();
            var strArr = System.IO.File.ReadAllLines("Day3\\input.txt");

            foreach (var line in strArr)
            {
                returnValue.banks.Add(line);
            }

            return returnValue;
        }
    }
}
