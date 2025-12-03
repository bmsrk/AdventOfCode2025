using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode2025
{
    internal class Day1
    {
        private InputData Data => ParseFile();

        public void Part1()
        {
            int dialPosition = 50;
            int zeroCount = 0;
            const int size = 100;

            foreach (var instruction in Data.dialInstructions)
            {
                char direction = instruction.Item1;
                int number = instruction.Item2;
                if (direction == 'R')
                {
                    dialPosition += number;
                }
                else if (direction == 'L')
                {
                    dialPosition -= number;
                }
                dialPosition = Wrap(dialPosition, size);
                if (dialPosition == 0)
                {
                    zeroCount++;
                }
            }

            Console.WriteLine($"Time it stopped at zero: {zeroCount}");
        }

        public void Part2()
        {
            int dialPosition = 50;
            int zeroPassesCount = 0;
            const int size = 100;

            foreach (var instruction in Data.dialInstructions)
            {
                char direction = instruction.Item1;
                int number = instruction.Item2;
                int step = direction == 'R' ? 1 : -1;

                for (int i = 0; i < number; i++)
                {
                    dialPosition = Wrap(dialPosition + step, size);

                    if (dialPosition == 0)    // conta tanto PASSAGEM quanto PARADA
                        zeroPassesCount++;
                }
            }

            Console.WriteLine($"Time it passed through zero: {zeroPassesCount}");
        }


        int Wrap(int x, int size) => ((x % size) + size) % size;

        private class InputData
        {
            public List<Tuple<char, int>> dialInstructions;

            public InputData()
            {
                dialInstructions = new List<Tuple<char, int>>();
            }
        }

        private InputData ParseFile()
        {
            var returnValue = new InputData();
            var strArr = System.IO.File.ReadAllLines("Day1\\input.txt");

            foreach (var line in strArr)
            {
                char dialDirection = line[0];
                int dialNumber = Convert.ToInt32(line.Substring(1));
                returnValue.dialInstructions.Add(new Tuple<char, int>(dialDirection, dialNumber));
            }

            return returnValue;
        }
    }
}
