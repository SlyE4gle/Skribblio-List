using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Skribblio_List
{
    static class DeDupeFile
    {
        public static int RemoveDuplicatesFromAndWriteOutToFile(string fileName)
        {
            FileInfo file = new FileInfo(fileName);

            if (!file.Exists)
            {
                throw new FileNotFoundException("File not found", fileName);
            }

            int duplicateCount;
            HashSet<string> entries = GetEntriesFromFile(file, out duplicateCount);

            WriteOutDeDupedEntries(file, entries);

            return duplicateCount;
        }

        private static HashSet<string> GetEntriesFromFile(FileInfo file, out int dupeCount)
        {
            dupeCount = 0;
            string fullText = File.ReadAllText(file.FullName).Trim();

            string[] allWords = fullText.Split(new char[] { ',', '\n' });

            HashSet<string> entries = new HashSet<string>(allWords, StringComparer.OrdinalIgnoreCase);

            dupeCount = allWords.Length - entries.Count;
            return entries;
        }

        private static void WriteOutDeDupedEntries(FileInfo file, HashSet<string> entries)
        {
            string csvOutput = String.Join(",", entries);
            File.WriteAllText(file.FullName, csvOutput, Encoding.ASCII);
        }
    }
}
