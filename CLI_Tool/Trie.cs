using System.Collections.Generic;
using System.Linq;

namespace CLI_Tool
{

    public class Trie
    {
        private List<Node> nodeTree;
        private Node rootNode;
        private Node curNode;
        private Node prevNode;

        public Trie()
        {
            nodeTree = new List<Node>();
            rootNode = null;
            curNode = null;
            prevNode = null;
        }

        public void AddAllWords(string[,] delimitedTexts)
        {
            for (int i = 0; i < delimitedTexts.GetLength(0); i++)
            {
                string[] words = delimitedTexts[i, 1].Split(' ');

                //remove dups, as they don't need to be added
                words = words.Distinct().ToArray();

                for (int j = 0; j < words.Length; j++)
                {
                    if (string.IsNullOrEmpty(words[j])) continue;

                    string college = delimitedTexts[i, 0];
                    AddWord(words[j], college);
                }
            }
        }

        public void AddWord(string word, string college)
        {
            int nodeDepth = 0;
            int nodeWidth = 0;

            bool moveToNext = false;
            word = Utils.ConvertWord(word);
            college = college.ToLower().Replace('\r', ' ').Trim();

            curNode = rootNode;

            for (int i = 0; i < word.Length; i++)
            {
                if (curNode is null) //add new node
                {
                    Node newNode;

                    if (i + 1 == word.Length)
                    {
                        //end of word
                        newNode = new Node(word[i], college, new Node.Coords() { Depth = nodeDepth, Width = nodeWidth});
                    }
                    else
                    {
                        newNode = new Node(word[i], new Node.Coords() { Depth = nodeDepth, Width = nodeWidth });
                    }

                    nodeTree.Add(newNode);
                    curNode = newNode;

                    if (rootNode is null)
                    {
                        rootNode = curNode;
                    }

                    //setup links
                    if (prevNode != null)
                    {
                        if (!moveToNext)
                        {
                            prevNode.ChildNode = curNode;
                        }
                        else
                        {
                            prevNode.NextNode = curNode;
                        }
                    }
                    prevNode = curNode;
                    curNode = curNode.ChildNode;
                    nodeDepth++;
                    moveToNext = false;
                }
                else if ((curNode.Char == word[i]) && (i + 1 == word.Length)) //insert college on current node
                {
                    curNode.AddCollege(college);
                }
                else if (curNode.Char == word[i]) //goto child node
                {
                    prevNode = curNode;
                    curNode = curNode.ChildNode;
                    nodeDepth++;
                    moveToNext = false;
                }
                else if (curNode.Char != word[i]) //goto next node
                {
                    prevNode = curNode;
                    curNode = curNode.NextNode;
                    nodeWidth++;
                    moveToNext = true;
                    //repeat same letter in word
                    i--;
                }
            }
        }

        public List<College> FindWord(string word)
        {
            word = Utils.ConvertWord(word);

            curNode = rootNode;

            for (int i = 0; i < word.Length; i++)
            {
                if (curNode != null)
                {
                    if (i + 1 == word.Length)// && curNode.ChildNode == null)
                    {
                        return curNode.Colleges;
                    }
                    else if (curNode.Char == word[i]) //goto child node
                    {
                        prevNode = curNode;
                        curNode = curNode.ChildNode;
                    }
                    else //goto next node
                    {
                        prevNode = curNode;
                        curNode = curNode.NextNode;
                        i--;
                    }
                }
            }
            return null;
        }
    }

    internal class Node
    {
        private Node nextNode;
        //private Node prevNode;
        private Node childNode;
        //private Node parentNode;

        private char @char;
        private List<College> colleges = new List<College>();
        private Coords coords;

        internal struct Coords
        {
            private int depth;
            private int width;

            public int Depth { get => depth; set => depth = value; }
            public int Width { get => width; set => width = value; }
        }

        public Node(char @char)
        {
            this.@char = @char;
            colleges = new List<College>();
            //count = 0;
        }

        public Node(char @char, string college)
        {
            this.@char = @char;
            AddCollege(college);
        }

        public Node(char @char, Coords coords) : this(@char)
        {
            this.coords = coords;
        }

        public Node(char @char, string college, Coords coords) : this(@char, college)
        {
            this.coords = coords;
        }

        internal Node NextNode { get => nextNode; set => nextNode = value; }
        //internal Node PrevNode { get => prevNode; set => prevNode = value; }
        internal Node ChildNode { get => childNode; set => childNode = value; }
        //internal Node ParentNode { get => parentNode; set => parentNode = value; }
        internal char Char { get => @char; }
        public List<College> Colleges { get => colleges; }
        public Coords Coordinates { get => coords; }

        public void AddCollege(string college)
        {
            College foundCollege;
            try
            {
                foundCollege = colleges.Find(x => x.Name == college);
            }
            catch
            {
                foundCollege = null;
            }

            if (foundCollege != null)
            {
                //add college count
                foundCollege.Count++;
            }
            else
            {
                colleges.Add(new College { Name = college, Count = 1 });
            }
        }
    }

    public class College
    {
        private string name;
        private int count;

        public string Name { get => name; set => name = value; }
        public int Count { get => count; set => count = value; }
    }
}
