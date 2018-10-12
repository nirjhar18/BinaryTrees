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

    }
}
