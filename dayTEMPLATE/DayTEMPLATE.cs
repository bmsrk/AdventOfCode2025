using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2025
{
    internal class DayTEMPLATE
    {
        private InputData Data => ParseFile();

        public void Part1()
        {

        }

        public void Part2()
        {

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
            var strContent = System.IO.File.ReadAllText("Day3\\input.txt");
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
