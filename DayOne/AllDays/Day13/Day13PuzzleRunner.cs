using Days.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllDays.Day13
{
    internal class Day13PuzzleRunner : IPuzzleRunner
    {
        public string RunPartOne(IEnumerable<string> lines)
        {
            var decoder = new Decoder();

            var listOfOrderedPairsIndexes = decoder.Run(lines);

            return listOfOrderedPairsIndexes.Sum().ToString();
        }
        public string RunPartTwo(IEnumerable<string> lines)
        {
            var decoder = new Decoder();

            var listOfOrderedPairsIndexes = decoder.Run(lines);

            return listOfOrderedPairsIndexes.Sum().ToString();
        }
    }
}
