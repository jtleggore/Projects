using System;
using System.Collections.Generic;
using CLI_Tool;

namespace CLI_Tool_Exe
{
    class Program
    {
        private static string searchWord;
        private static int count;
        private static string college;
        private static FileDownloader a;
        private static Trie trie;
        private static string filePath = @"C:\Users\jake.leggore\Documents\GitHub\Projects\CLI_Tool\CLI_Tool_Tests\Testdata\FilePaths.txt";

        public static string SearchWord { get => searchWord; set => searchWord = Utils.ConvertWord(value); }
        public static string FilePath { get => filePath; set => filePath = !string.IsNullOrWhiteSpace(value) ? value : filePath; }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the file path:");
            FilePath = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("Enter a search keyword:");
                SearchWord = Console.ReadLine();

                a = new FileDownloader(FilePath);
                a.LoadAllFiles();

                trie = new Trie();
                trie.AddAllWords(a.DelimitedTexts);

                List<College> temp = trie.FindWord(SearchWord);

                if (temp == null)
                {
                    Console.WriteLine("No matches found");
                    continue;
                }
                foreach (College collegeFound in trie.FindWord(SearchWord))
                {
                    college = collegeFound.Name;
                    count = collegeFound.Count;

                    Console.WriteLine($"In {count} review{(count != 1 ? "s" : "")} for {college}");
                }

                Console.WriteLine();
            }
        }
    }
}
