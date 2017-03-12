using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    class BinaryTree
    {
        private Node _root;

        public Node root
        {
            get { return _root; }
            set { _root = value; }
        }
        int steps = 0;

        public void add(Node newNode, Node currNode)
        {
            if(_root == null)
            {
                _root = newNode;
                return;
            }
            if(newNode.data > currNode.data)
            {
                if (currNode.right == null)
                    currNode.right = newNode;
                else
                    add(newNode, currNode.right);
            }
            else
            {
                if (currNode.left == null)
                    currNode.left = newNode;
                else
                    add(newNode, currNode.left);
            }
        }

        public Node search(Node currNode, int i)
        {
            steps++;
            if (currNode.data == i)
            {
                return currNode;
            }
            else
            {
                if(i > currNode.data)
                {
                    if (currNode.right == null)
                        return null;
                    else
                        return search(currNode.right, i);
                }
                else
                {
                    if (currNode.left == null)
                        return null;
                    else
                        return search(currNode.left, i);
                }
            }
            //return currNode;
        }
        public int searchInt(int i)
        {
            Node foundNode = search(_root, i);
            if (foundNode != null)
            {
                Console.WriteLine("gefunden: " + foundNode.data);
                return steps;
            }
            else
                return 0;
        }

        public void addInt(int i)
        {
            add(new Node(i), _root);
        }
        public void preOrder(Node curNode)
        {
            Console.Write(curNode.data + " ");

            if (curNode.left != null)
                preOrder(curNode.left);

            if (curNode.right != null)
                preOrder(curNode.right);
        }
        public void printPreOrder()
        {
            preOrder(_root);
        }

        public void inOrder(Node curNode)
        {
            if (curNode.left != null)
                inOrder(curNode.left);

            Console.Write(curNode.data + " ");

            if (curNode.right != null)
                inOrder(curNode.right);
        }
        public void printInOrder()
        {
            inOrder(_root);
        }

        public void postOrder(Node curNode)
        {
            if (curNode.left != null)
                postOrder(curNode.left);
            
            if (curNode.right != null)
                postOrder(curNode.right);

            Console.Write(curNode.data + " ");
        }
        public void printPostOrder()
        {
            postOrder(_root);
        }

        public void min()
        {
            Node curNode = _root;
            while (curNode.left != null)
                curNode = curNode.left;
            Console.WriteLine("Min: " + curNode.data);
        }

        public void max()
        {
            Node curNode = _root;
            while (curNode.right != null)
                curNode = curNode.right;
            Console.WriteLine("Max: " + curNode.data);
        }


    }


    class Node
    {
        private int _data;
        public int data
        {
            get { return _data; }
            set { _data = value; }
        }


        private Node _right;

        public Node right
        {
            get { return _right; }
            set { _right = value; }
        }

        private Node _left;

        public Node left
        {
            get { return _left; }
            set { _left = value; }
        }

        public Node(int i)
        {
            _data = i;
        }

    }
}
