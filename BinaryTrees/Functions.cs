using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTrees
{
    class Functions : BinarySearchTree
    {
        // If this is binary search tree, we only have to give the left most value of tree
        //But for this program, we will consider this as Binary tree so we will traverse the whole tree
        // Time Complexity will be O(n)

        public override int MinimumNodeValue(Node treeRoot)
        {

            Node current = treeRoot;

            //Traverse through tree and add it to Array List
            List<int> minValue = new List<int>();
            Stack<Node> stack = new Stack<Node>();


            while (current != null || stack.Count > 0)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.left;

                }
                current = stack.Pop();

                minValue.Add(current.data);

                current = current.right;

            }
            return minValue.Min();

        }

        /*
         Keep going left and right and keep subtracting node value from sum.
         If leaf node is reached check if whatever sum is remaining same as leaf node data.
         Time complexity is O(n) since all nodes are visited
         */
        public override Boolean RootToLeafSum(Node treeRoot, int CompareSum, List<Node> path)
        {
            if (treeRoot == null)
            {
                return false;
            }

            //Check for leaf nodes
            if ((treeRoot.left == null) && (treeRoot.right == null))
           {
                if (treeRoot.data == CompareSum)
                {

                    path.Add(treeRoot);
                    return true;
                }
                else
                {
                    return false;
                }

           }

            if (RootToLeafSum(treeRoot.left, CompareSum - treeRoot.data, path) ||
                RootToLeafSum(treeRoot.right, CompareSum - treeRoot.data, path))

            {
                path.Add(treeRoot);
                return true;
            }


            return false;
        }

        public override Boolean CheckIfBinary(Node treeRoot, int min, int max)
        {
            Node current = treeRoot;
          

            if (current == null) {
                return true;
            }

            //false if this node violates the min/max constraints
            if (current.data < min || current.data > max)
            {
                return false;
            }
               

            /* otherwise check the subtrees recursively 
            tightening the min/max constraints */
            // Allow only distinct values 
            return (CheckIfBinary(current.left, min, current.data - 1) &&
                    CheckIfBinary(current.right, current.data + 1, max));
        }


    }
}
