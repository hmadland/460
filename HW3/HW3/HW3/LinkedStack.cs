namespace HW3
{

    /// <summary>
    /// Singly linked stack implementation.
    /// </summary>
    class LinkedStack : IStackADT
    {
        private Node topNode;

        /// <summary>
        /// Default constructor to make an empty stack.
        /// </summary>
        public LinkedStack()
        {
            topNode = null;
        }

        /// <summary>
        /// Property to get and set Node at the top of this stack.
        /// </summary>
        public Node TopNode
        {
            get { return topNode; }
            set { topNode = value; }
        }

        /// <summary>
        ///  Empty this stack.
        /// </summary>
        public void Clear()
        {
            this.TopNode = null;
        }

      
        /// <summary>
        /// Check if stack is empty.
        /// </summary>
        /// <returns>True if stack is empty, false if not</returns>
        public bool IsEmpty()
        {
            return this.TopNode == null;
        }

        /// <summary>
        /// Return the top item of this stack but don't remove it.
        /// </summary>
        /// <returns>A reference to item currently on the top of the stack or null if stack is empty</returns>
        public object Peek()
        {
            return IsEmpty() ? null : TopNode.Data;
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
            object tempTop = TopNode.Data;
            TopNode = TopNode.NextNode;
            return tempTop;
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
            Node newNode = new Node(newItem, TopNode);
            TopNode = newNode;
            return newItem;
        }
    }
}