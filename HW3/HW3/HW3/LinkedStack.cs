using System;

namespace HW3
{
    // Singly linked stack implementation of IStackADT.
    class LinkedStack : IStackADT
    {
        private Node topNode;

        // default constructor to make an empty stack.
        public LinkedStack()
        {
            topNode = null;
        }

        // Property to get and set the Node that is on the top of this stack.
        public Node TopNode
        {
            get { return topNode; }
            set { topNode = value; }
        }

        // Empty this stack
        public void Clear()
        {
            this.TopNode = null;
        }

        //check if the stack is empty
        //returns True if this stack is empty, false otherwise
        public bool IsEmpty()
        {
            return this.TopNode == null;
        }

        /** 
         * Return the top item of this stack but don't remove it.
         * returns a reference to the item currently on the top of this stack or null if this stack is empty
        **/
        public object Peek()
        {
            return IsEmpty() ? null : TopNode.Data;
        }

        /**
         * return and remove the top item on this stack
         * returns a reference that was popped and removed from the top of this stack, or null if the stack is empty.
        **/
        public object Pop()
        {
            if (IsEmpty())
            {
                return null;
            }
            object tempTop = TopNode.Data;
            TopNode = TopNode.NextNode;
            return tempTop;
        }

        /**
         * Push an item onto the top of this stack and return back a reference to that newly pushed item.
         * The item to push onto the top of this stack should not be null.
         * Returns a reference to the item that was just added to this stack, or null if the item did not exist.
        **/
       public object Push(object newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            
            Node newNode = new Node(newItem, TopNode);
            TopNode = newNode;
            return newItem;
        }

    }
}
