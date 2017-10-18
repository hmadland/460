namespace HW3
{

    /// <summary>
    /// Singly linked stack implementation.
    /// </summary>
    class LinkedStack : IStackADT
    {
        private Node top;

        /// <summary>
        /// Default constructor to make an empty stack.
        /// </summary>
        public LinkedStack()
        {
            top = null;
        }

        /// <summary>
        /// Push an item onto the top of this stack and return back a reference to that newly pushed item.
        /// </summary>
        /// <param name="newItem">The item to push onto the top of the stack. Should not be null</param>
        /// <returns>A reference to the item that was just added to the stack, or null if item did not exist</returns>
        public object Push(object newItem)
        {
            if (newItem == null)
            {
                return null;
            }
            Node newNode = new Node(newItem, top);
           top = newNode;
            return newItem;
        }

        /// <summary>
        /// Return and remove the top item on this stack.
        /// </summary>
        /// <returns>A reference that was popped from the top of the stack, or null if stack is empty</returns>
        public object Pop()
        {
            if (IsEmpty())
            {
                return null;
            }
            object topItem = top.Data;
            top = top.NextNode;
            return topItem;
        }

        /// <summary>
        /// Return the top item of this stack but don't remove it.
        /// </summary>
        /// <returns>A reference to item currently on the top of the stack or null if stack is empty</returns>
        public object Peek()
        {
            return IsEmpty() ? null : top.Data;
        }


        /// <summary>
        /// Check if stack is empty.
        /// </summary>
        /// <returns>True if stack is empty, false if not</returns>
        public bool IsEmpty()
        {
            return this.top == null;
        }

        /// <summary>
        ///  Empty this stack.
        /// </summary>
        public void Clear()
        {
            this.top = null;
        }
    }
}