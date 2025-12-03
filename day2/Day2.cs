using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2025
{
    internal class Day2
    {
        private InputData Data => ParseFile();

        public void Part1()
        {
            var invalidNumbers = new List<long>();

            foreach (var range in Data.ranges)
            {
                var numbersArr = GetRange(range.Item1, range.Item2 - range.Item1 + 1).ToArray();

                foreach (var number in numbersArr)
                {
                    if (!IsValidPart1(number))
                        invalidNumbers.Add(number);
                }
            }

            Console.WriteLine($"Invalid numbers Count { invalidNumbers.Count }");
            Console.WriteLine($"Sum of invalid numbers: { invalidNumbers.Sum().ToString() }");
        }

        public void Part2()
        {
            var invalidNumbers = new List<long>();

            foreach (var range in Data.ranges)
            {
                var numbersArr = GetRange(range.Item1, range.Item2 - range.Item1 + 1).ToArray();

                foreach (var number in numbersArr)
                {
                    if (IsInvalidPart2(number))
                        invalidNumbers.Add(number);
                }
            }

            Console.WriteLine($"Invalid numbers Count {invalidNumbers.Count}");
            Console.WriteLine($"Sum of invalid numbers: {invalidNumbers.Sum().ToString()}");
        }
        private static IEnumerable<long> GetRange(long start, long count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), "Count must be non-negative.");

            for (long i = 0; i < count; i++)
                yield return start + i;
        }

        public static bool IsValidPart1(long number)
        {
            var str = number.ToString();
            if (str.Length % 2 != 0)
                return true; // odd-length numbers are valid

            var halfLength = str.Length / 2;
            var firstHalf = str.Substring(0, halfLength);
            var secondHalf = str.Substring(halfLength, halfLength);

            return firstHalf != secondHalf;
        }

        public static bool IsInvalidPart2(long number)
        {
            string s = number.ToString();
            return Regex.IsMatch(s, @"^(\d+)\1+$"); // returns true if number is invalid
        }

        private class InputData
        {
            public List<Tuple<long, long>> ranges;

            public InputData()
            {
                ranges = new List<Tuple<long, long>>();
            }
        }

        private InputData ParseFile()
        {
            var returnValue = new InputData();
            var strContent = System.IO.File.ReadAllText("Day2\\input.txt");
            var strArr = strContent.Split(",", StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in strArr)
            {
                int indexOfDash = line.IndexOf('-');
                var firstNumber = long.Parse(line.Substring(0, indexOfDash));
                var secondNumber = long.Parse(line.Substring(indexOfDash+1, line.Length -1 - indexOfDash));
                returnValue.ranges.Add(new Tuple<long, long>(firstNumber, secondNumber));
            }

            return returnValue;
        }
    }
}
