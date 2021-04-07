using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    /// <summary>
    /// Generic useful tree structure that can be extended to add specific functionality
    /// </summary>
    /// <typeparam name="T">Type of Node value</typeparam>
    public class Tree<T>
    {
        private Node _rootNode;
        private Node _currentNode;

        public Node RootNode
        {
            get { return _rootNode; }
        }

        public Node CurrentNode
        {
            get { return _currentNode; }
        }

        public Tree()
        {
            _rootNode = new Node();
            _rootNode.Depth = 0;
            _currentNode = _rootNode;
        }

        public Tree(string nodeName, T nodeValue)
        {
            _rootNode = new Node(nodeName, nodeValue);
            _rootNode.Depth = 0;
            _currentNode = _rootNode;
        }

        public bool GoToNextNode()
        {
            if (_currentNode.ParentNode != null)
            {
                //todo: find out if this is inefficient
                int indexOfCurrent = _currentNode.ParentNode.ChildNodes.IndexOf(_currentNode);

                GoToParentNode();
                return GoToChildNode(indexOfCurrent + 1);
            }

            return false;
        }

        public bool GoToPreviousNode()
        {
            if (_currentNode.ParentNode != null)
            {
                //todo: find out if this is inefficient
                int indexOfCurrent = _currentNode.ParentNode.ChildNodes.IndexOf(_currentNode);

                GoToParentNode();
                return GoToChildNode(indexOfCurrent - 1);
            }

            return false;
        }

        public bool GoToChildNode(int indexOfChild)
        {
            if (_currentNode.ChildNodes != null)
            {
                if (indexOfChild >= 0 && _currentNode.ChildNodes.Count >= indexOfChild + 1)
                {
                    _currentNode = _currentNode.ChildNodes[indexOfChild];

                    return true;
                }
            }

            return false;
        }

        public bool GoToFirstChildNode()
        {
            return GoToChildNode(0);
        }

        public bool GoToLastChildNode()
        {
            return GoToChildNode(_currentNode.ChildNodes != null ? _currentNode.ChildNodes.Count - 1 : 0);
        }

        public bool GoToParentNode()
        {
            if (_currentNode.ParentNode != null)
            {
                _currentNode = _currentNode.ParentNode;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Link child to parent and parent to child
        /// </summary>
        /// <param name="childNode"></param>
        public bool AddChildNode(Node childNode)
        {
            if (childNode.ParentNode == null)
            {
                childNode.Depth = _currentNode.Depth + 1;
                _currentNode.ChildNodes.Add(childNode);
                childNode.ParentNode = _currentNode;

                return true;
            }
            else
            {
                //todo: add error
                return false;
            }
        }

        /// <summary>
        /// Link child to parent and parent to child
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeValue"></param>
        public bool AddChildNode(string nodeName, T nodeValue)
        {
            Node childNode = new Node(nodeName, nodeValue);
            childNode.Depth = _currentNode.Depth + 1;
            return AddChildNode(childNode);
        }

        /// <summary>
        /// Link children to parent and parent to children
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeValue"></param>
        /*public bool AddChildNodes(params Node[] childNodes)
        {
            foreach (Node node in childNodes)
            {
                AddChildNode(node);
            }
            Node childNode = new Node(nodeName, nodeValue);
            childNode.Depth = _currentNode.Depth + 1;
            return AddChildNode(childNode);
        }*/

        public bool RemoveChildNode(Node deletedNode)
        {
            return _currentNode.ChildNodes.Remove(deletedNode);
        }

        public void DepthFirstTraversal(Action<Node> action)
        {
            action(_currentNode);

            foreach (Node childNode in _currentNode.ChildNodes)
            {
                _currentNode = childNode;
                DepthFirstTraversal(action);
            }
        }

        public void PrintTreeNode(Node node)
        {
            Console.WriteLine(string.Format("Node: {0}, Value: {1}", node.Name, node.Value));
            Log.Trace(string.Format("Node: {0}, Value: {1}", node.Name, node.Value));
        }

        public class Node
        {
            private string _name;
            private T _value;
            private uint? _depth = null;

            private Node _parentNode;
            private List<Node> _childNodes;

            public Node()
            {
                _parentNode = null;
                _childNodes = new List<Node>();
            }

            public Node(string nodeName, T nodeValue)
            {
                _name = nodeName;
                _value = nodeValue;

                _parentNode = null;
                _childNodes = new List<Node>();
            }


            public string Name
            {
                get { return _name; }
                set { _name = Name; }
            }

            public T Value
            {
                get { return _value; }
                set { _value = Value; }
            }

            public uint? Depth
            {
                get { return _depth; }
                set { _depth = Depth; }
            }

            public Node ParentNode
            {
                get { return _parentNode; }
                set { _parentNode = ParentNode; }
            }

            public List<Node> ChildNodes
            {
                get { return _childNodes; }
            }

            public Node this[int index]
            {
                get { return _childNodes[index]; }
                set { _childNodes[index] = this; }
            }
        }
    }
}
