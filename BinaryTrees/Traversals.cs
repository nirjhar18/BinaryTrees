using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class Traversals : BinarySearchTree
    {
        //Size of the tree and Inorder Traversal of Tree
        // 1) Create an empty stack S.
        // 2) Initialize current node as root
        // 3) Push the current node to S and set current = current->left until current is NULL
        // 4) If current is NULL and stack is not empty then
        //   a) Pop the top item from stack.
        // b) Print the popped item, set current = popped_item->right
        // c) Go to step 3.
        // 5) If current is NULL or stack is empty then we are done.
        //  Let us consider the below tree for example
        //            1
        //          /   \
        //        2      3
        //      /  \
        //    4     5

        //Step 1 Creates an empty stack: S = NULL

        //Step 2 sets current as address of root: current -> 1

        //Step 3 Pushes the current node and set current = current->left until current is NULL
        //     current -> 1
        //     push 1: Stack S -> 1
        //     current -> 2
        //     push 2: Stack S -> 2, 1
        //     current -> 4
        //     push 4: Stack S -> 4, 2, 1
        //     current = NULL

        //Step 4 pops from S
        //     a) Pop 4: Stack S -> 2, 1
        //     b) print "4"
        //     c) current = NULL /*right of 4 */ and go to step 3
        //Since current is NULL step 3 doesn't do anything. 

        //Step 4 pops again.
        //     a) Pop 2: Stack S -> 1
        //     b) print "2"
        //     c) current -> 5/*right of 2 */ and go to step 3

        //Step 3 pushes 5 to stack and makes current NULL
        //     Stack S -> 5, 1
        //     current = NULL

        //Step 4 pops from S
        //     a) Pop 5: Stack S -> 1
        //     b) print "5"
        //     c) current = NULL /*right of 5 */ and go to step 3
        //Since current is NULL step 3 doesn't do anything

        //Step 4 pops again.
        //     a) Pop 1: Stack S -> NULL
        //     b) print "1"
        //     c) current -> 3 /*right of 5 */  

        //Step 3 pushes 3 to stack and makes current NULL
        //     Stack S -> 3
        //     current = NULL

        //Step 4 pops from S
        //     a) Pop 3: Stack S -> NULL
        //     b) print "3"
        //     c) current = NULL /*right of 3 */

        //Traversal is done now as stack S is empty and current is NULL.
        public override int SizeofTreeIterativelyorInorderTraversal(Node treeRoot)
        {
            int size = 0;

            if (treeRoot == null)
            {
                return 0;
            }

            //In-Order Traversal
            Stack<Node> stack = new Stack<Node>();
            Node current = treeRoot;
            
            //Traverse the tree
            while (current != null || stack.Count > 0)
            {
                /*Reach the left most node of current*/
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;
                }

                /*Current is null at this point*/

                current = stack.Pop();

                size = size + 1;

                Console.WriteLine(current.data);

                /*We have traversed left subtree of node, now we will traverse right subtree.*/
                current = current.right;
            }
  
            return size;
        }

        //VLR: Visit (Root), Left, Right
        public override void PreOrderTraversal(Node treeRoot)
        {
            Node current = treeRoot;
            Stack<Node> stack = new Stack<Node>();

            while(current != null || stack.Count > 0)
            {
                while (current != null) { 
                stack.Push(current);

                Console.WriteLine(current.data);
                current = current.left;
             }

                /*Current is null at this point*/
                current = stack.Pop();

                /*We have traversed left subtree of node, now we will traverse right subtree.*/
                current = current.right;
            }
   

        }

        //LRV: Left, right, Visit(Root)
        /*
         1. Push root to first stack.
         2. Loop while first stack is not empty
              2.1 Pop a node from first stack and push it to second stack
              2.2 Push left and right children of the popped node to first stack
         3. Print contents of second stack */
        public override void PostOrderTraversal(Node treeRoot) {

            Node current = treeRoot;

            Stack<Node> stack1 = new Stack<Node>();
            Stack<Node> stack2 = new Stack<Node>();
            Node MoveToSecond;

            //Push root to first stack.
            stack1.Push(current);

            //Loop while first stack is not empty
            while (stack1.Count > 0)
            {
                //Pop a node from first stack and push it to second stack
                MoveToSecond = stack1.Pop();
                stack2.Push(MoveToSecond);

                //Push left and right children of the popped node to first stack
                if (MoveToSecond.left != null) {
                stack1.Push(MoveToSecond.left);
                }

                if (MoveToSecond.right != null)
                {
                    stack1.Push(MoveToSecond.right);
                }
            }

            //Print contents of second stack
            foreach (Node i in stack2)
            {
                Console.WriteLine(i.data);
            }
        }

        // Recursive Post Order
       public void printPostorderRecursion(Node treeRoot)

        { 
        if (treeRoot == null) 
            return;

            // first recur on left subtree 
            printPostorderRecursion(treeRoot.left);

            // then recur on right subtree 
            printPostorderRecursion(treeRoot.right);

        // now deal with the node 
        Console.WriteLine(treeRoot.data + " ");
    }

        // Recursive Pre Order
        public void printPreorderRecursion(Node treeRoot)
        {
            if (treeRoot == null)
                return;

            /* first print data of node */
            Console.WriteLine(treeRoot.data + " ");

            /* then recur on left sutree */
            printPreorderRecursion(treeRoot.left);

            /* now recur on right subtree */
            printPreorderRecursion(treeRoot.right);
        }

        //Recursive Inorder
        public void printInorder(Node treenode)
        {
            if (treenode == null)
                return;

            /* first recur on left child */
            printInorder(treenode.left);

            /* then print the data of node */
           Console.WriteLine(treenode.data + " ");

            /* now recur on right child */
            printInorder(treenode.right);
        }

        //Level Order traversal. Also called breadth first search
        public override void LevelOrderTraversalBFS(Node treeRoot)
        {
            Node current = treeRoot;
           
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(current);

            while (queue.Count > 0)
            {
                current = queue.Dequeue();
                 Console.WriteLine(current.data);
                if (current.left != null)
                {
                    queue.Enqueue(current.left);
                }
                if (current.right != null)
                {
                    queue.Enqueue(current.right);
                }

            }

        }

    }
}
