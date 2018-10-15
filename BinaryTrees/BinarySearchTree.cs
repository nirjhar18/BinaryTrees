using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTrees
{

    class Node
    {
        //Data of the Node
        public int data;

        //Left and right child
        public Node left;
        public Node right;

        //Default Constructor
        public Node()
        {

        }

        //Constructor with data
        public Node (int item)
        {
            data = item;
            left = null;
            right = null;
        }


    }
    class BinarySearchTree
    {
        public Node root;

        //Default Constructor
        public BinarySearchTree()
        {

            root = null;
        }

        //Constructor with data
        public BinarySearchTree(int item)
        {
            root = new Node(item);
        }

        //Insert new node iteratively. Create a new Node that is being inserted and add value to data parameter
        //Check if root is null to add new node as root node. Else Start traversing from root node
        // If New node data is less than root node, go to left side of tree and check if left is null. If it is null
        // then insert new node on left. If not, then make the current node to be left of current and keep traversing
        public void insert(int value)
        {
            Node newNode = new Node();
            newNode.data = value;

            Node current;
            if (root == null)
            {
                root = newNode;
            }

            else
            {
                current = root;

                while (true)
                {

                 if (current.data > value)
                    {

                        if (current.left == null) {
                            current.left = newNode;
                            break;
                        }
                        else
                        {
                            current = current.left;

                        }
                    }
                    else
                    {
                        if (current.right == null)
                        {
                            current.right = newNode;
                            break;
                        }
                        else
                        {
                            current = current.right;

                        }
                    }

                }
            }

        }

        //Insert new node recursively. Create a new node and add value to its data. If node is null, 
        // add it as new node. Otherwise, if it is less than root node, recursively run the program on left hand side
        //If it is greater than root node, recursively run the program on right hand side. 

        public Node RecursiveInsert(Node node, int value)
        {

            Node newNode = new Node();

            newNode.data = value;

            if (node == null) {
                node = newNode;
            } 
            else if (node.data > value)
                {
                node.left = RecursiveInsert(node.left, value);
                }
                 else
                {
                node.right =  RecursiveInsert(node.right, value);
                }
            return node;
           }

        public void delete(int value )
        {
            Node current;
            current = root;
            bool leftTree = false;
            bool rightTree = false;

            Stack<Node> stack = new Stack<Node>();

            if (root == null)
            {
                Console.WriteLine("No Node");
            }

            //Check if value is in left or right subtree
            if (current.data > value)
            {
                leftTree = true;
            }
            else
            {
                rightTree = true;
            }

           //Loop through tree to find value to be deleted and store parents in a stack
          while (current.data != value)
            {
                if (current.data > value)
                {
                    stack.Push(current);
                    current = current.left;
                             
                }
                else
                {
                    stack.Push(current);
                    current = current.right;
                   
                }

            }

          // Current is the node to be deleted. 
            if (current.right != null)
            {
                Node Parent = stack.Pop();

         // Check if you are on right side and parent is the root node.
                if (rightTree == true && root.data == Parent.data)
                {
                    Parent.right = current.right;
                }
                else
                {
                    Parent.left = current.right;
                }
               
            }

            else if (current.left != null)
            {
                    Node Parent = stack.Pop();
                    Parent.left = current.left;
            }

            //Leaf Node
            else
            {
                Node Parent = stack.Pop();
                if (Parent.right.data == current.data)
                {
                    Parent.right = null;
                }
                else
                {
                    Parent.left = null;
                }
                

            }

        }

        //Height of the tree. Recursively find the size of left and right tree.
        public int SizeofTreeRecursive(Node treeRoot)
        {
            int treeHeight = 0;
         

            if (treeRoot == null)
            {
                treeHeight = 0;
               
                Debug.WriteLine("Root's Height:" + treeHeight);
            }
            else
            {
                return SizeofTreeRecursive(treeRoot.left) + SizeofTreeRecursive(treeRoot.right) + 1;
                
            }

            return treeHeight;

        }

        //Virtual function. Traversals are implemented in child class
        public virtual int  SizeofTreeIterativelyorInorderTraversal(Node treeRoot)
        {
            return 1;
        }

        //Pre-order Traversal
        public virtual void PreOrderTraversal(Node treeRoot)
        {

        }

        //Post-order Traversal
        public virtual void PostOrderTraversal(Node treeRoot) { }

        //Level Order Traversal(BFS)
        public virtual void LevelOrderTraversalBFS(Node treeRoot) { }

        // Find minimum value in binary tree
        public virtual int MinimumNodeValue(Node treeRoot) { return 1; }

        //Given a sum, check the path that equals this Sum. Last node should be leaf node.
        public virtual Boolean RootToLeafSum(Node treeRoot, int CompareSum,List<Node> path) { return false; }

        //Check if Binary tree is Binary search tree
        public virtual Boolean CheckIfBinary(Node treeRoot,int min, int max) { return false; }

        // To do: AVL Tree

        // To do: Red Black Tree

    }

}

