using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLI_Tool;
using NUnit.Framework;

namespace CLI_Tool_Tests
{
    public class FileDownloaderTests
    {
        string filePath = @"C:\Users\jake.leggore\Documents\GitHub\Projects\CLI_Tool\CLI_Tool_Tests\Testdata\FilePaths.txt";
        FileDownloader a;
        Trie testTrie;

        [OneTimeSetUp]
        public void Setup()
        {
            a = new FileDownloader(filePath);
            a.LoadAllFiles();

            testTrie = new Trie();
            testTrie.AddAllWords(a.DelimitedTexts);

        }

        [Test]
        public void TestDelimetedTextsLength()
        {
            Assert.That(a.DelimitedTexts, Has.Length.EqualTo(100));
        }

        [TestCase("pitt")]
        [TestCase("class")]
        public void FindWords(string word)
        {
            List<College> collegesFound = testTrie.FindWord(word);
            Assert.That(collegesFound.Count > 0);
        }

    }
    public class TrieTests
    {
        Trie testTrie;

        [OneTimeSetUp]
        public void Setup()
        {
            testTrie = new Trie();

            testTrie.AddWord("Cowballs", "test college");
            testTrie.AddWord("Cowbell", "test College 2");
            testTrie.AddWord("Cow", "test college");
        }

        [Test, Order(1)]
        public void AddWords()
        {

            //Assert.Pass();
        }

        [TestCase("Cowbell", "test college 2")]
        [TestCase("Cow", "test college")]
        [TestCase("Car", null)]
        public void FindWords(string word, string expectedResult)
        {
            System.Collections.Generic.List<College> collegesFound = testTrie.FindWord(word);

            if (expectedResult is null)
            {
                Assert.That(collegesFound is null);
            }
            else
            {
                Assert.That(collegesFound[0].Name == expectedResult);
            }
        }
    }
}
