using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree Tree = new BinarySearchTree();
            Tree.insert(50);
            Tree.insert(34);
            Tree.insert(62);
            Tree.insert(82);
            Tree.insert(42);
            Tree.insert(13);
            Tree.insert(15);
            /*             50
                         /   \
                        34     62
                       /  \       \
                     13    42      82 
                       \
                         15                */
            BinarySearchTree RecursiveTree = new BinarySearchTree();
            BinarySearchTree RecursiveTreeFunctions = new BinarySearchTree();

            RecursiveTree = new Traversals();

            Node newNodeR = null;
            newNodeR = RecursiveTree.RecursiveInsert(newNodeR, 50);
            newNodeR = RecursiveTree.RecursiveInsert(newNodeR, 34);
            newNodeR = RecursiveTree.RecursiveInsert(newNodeR, 62);
            newNodeR = RecursiveTree.RecursiveInsert(newNodeR, 82);
            newNodeR = RecursiveTree.RecursiveInsert(newNodeR, 42);
            newNodeR = RecursiveTree.RecursiveInsert(newNodeR, 13);
            newNodeR = RecursiveTree.RecursiveInsert(newNodeR, 15);
            RecursiveTree.root = newNodeR;
            RecursiveTreeFunctions = RecursiveTree;
            Console.WriteLine("Height of the tree is: " + RecursiveTree.SizeofTreeRecursive(RecursiveTree.root));
            Console.WriteLine("Height of the tree is: " + RecursiveTree.SizeofTreeIterativelyorInorderTraversal(RecursiveTree.root));
            Console.WriteLine("Pre-order traversal:");

           RecursiveTree.PreOrderTraversal(RecursiveTree.root);

            Console.WriteLine("Post Order Traversal: ");
           
            RecursiveTree.PostOrderTraversal(RecursiveTree.root);

            Console.WriteLine("Level Order Traversal: ");

            RecursiveTree.LevelOrderTraversalBFS(RecursiveTree.root);

            RecursiveTree = new Functions();
            RecursiveTree.root = newNodeR;
            Console.WriteLine("Minimum value in Binary Tree: " + RecursiveTree.MinimumNodeValue(RecursiveTree.root));

            Console.ReadLine();
        }
    }
}
