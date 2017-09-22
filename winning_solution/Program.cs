using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BrilliantCut
{
    class Program
    {
        static void Main(string[] args)
        {
            string jsonFileContent = File.ReadAllText(Directory.GetCurrentDirectory().ToString() + "\\input.json");
            Dictionary<string, GemstoneProperties> gemstones = JsonConvert.DeserializeObject<Dictionary<string, GemstoneProperties>>(jsonFileContent);

            // Fill the max value lookup tables for gemstone types
            gemstones.Values.ToList().ForEach(gemstoneProps => gemstoneProps.CalculateMaxValues());

            int bestCutSum = 0;
            foreach (GemstoneProperties gemstoneProps in gemstones.Values)
            {
                bestCutSum += gemstoneProps.rawChunks
                    .Select(chunkSize => gemstoneProps.maxValueForSize[chunkSize])
                    .Sum();
            }
            Console.WriteLine($"Optimal cut value sum is { bestCutSum }");
        }
    }

    class GemstoneProperties
    {
        public IList<SizeValuePair> cuts { get; set; }
        public IList<int> rawChunks { get; set; }
        
        public int[] maxValueForSize;

        /// <summary>
        /// Fills maxValueForSize lookup table using a dynamic programming approach where
        /// for each possible gemstone size the algorithm checks if it's better to keep it
        /// in one part or split it in two smaller chunks.
        /// </summary>
        public void CalculateMaxValues()
        {
            int maxChunkSize = rawChunks.Max();
            maxValueForSize = new int[maxChunkSize + 1];

            // Calculate a lookup table with maximal values for each chunk size in range 0...maxChunkSize
            for (int gsSize = 0; gsSize <= maxChunkSize; gsSize++)
            {
                // Initial assumption: there is no way to cut the gem, maximum loss
                int bestValueFound = -gsSize;

                // Find out if gsSize is one of the pre-defined gemstone sizes with a value
                cuts
                    .Where(svp => svp.size == gsSize)
                    .Select(svp => svp.value)
                    .ToList() // Empty list if no match was found
                    .ForEach(value => bestValueFound = value);

                // Find out if division in two chunks increases the value
                for (int gsPartSize = 1; gsPartSize <= gsSize / 2; gsPartSize++)
                {
                    bestValueFound = Math.Max(bestValueFound, maxValueForSize[gsPartSize] + maxValueForSize[gsSize - gsPartSize]);
                }

                maxValueForSize[gsSize] = bestValueFound;
            }
        }
        
    }

    class SizeValuePair
    {
        public int size { get; set; }
        public int value { get; set; }
    }
}
