﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{

    public  class Tester
    {
        public  void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");
            try
            {
                string mismatchPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches =
                    GetLinesWithPossibleMissmatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read");
            }
            catch (FileNotFoundException)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
            }
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"\Mismatches.txt";
            return finalPath;
        }

        private string[] GetLinesWithPossibleMissmatches(string[] actualOutputLines, string[] expectedOutputLines, out bool hasMismatch)
        {
            hasMismatch = false;
            string output = string.Empty;            
            int minOutputLines = actualOutputLines.Length;

            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMismatch = true;
                minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }

            string[] mismatches = new string[minOutputLines];
            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];

                if (!actualLine.Equals(expectedLine))
                {
                    output = string.Format("Mismatch at  line {0} -- expected: \"{1}\", actual \"{2}\"", index, expectedLine, actualLine);
                    output += Environment.NewLine;
                    hasMismatch = true;
                }
                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }
                mismatches[index] = output;
            }
            return mismatches;
        }

        private void PrintOutput(string[] mismatches, bool hasMismatch, string mismatchesPath)
        {
            if (hasMismatch)
            {
                foreach (var line in mismatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);

                }
                try
                {
                    File.WriteAllLines(mismatchesPath, mismatches);
                }
                catch (DirectoryNotFoundException)
                {
                    OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidPath);
                }
                return;
            }
            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no mismatches.");
           
        }
    }
}

