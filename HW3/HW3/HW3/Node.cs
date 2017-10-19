namespace HW3
{
    /// <summary>
    /// A  singly linked node class.
    /// </summary>
    class Node
    {
        object data; // The payload
        Node nextNode; // Reference to next Node in the chain


        /// <summary>
        /// Constructor to create a new Node to be added to the stack chain.
        /// </summary>
        /// <param name="data">The contents to be held within this Node</param>
        /// <param name="nextNode">Node that this Node is being placed on top of in the chain.</param>
        public Node(object data, Node nextNode)
        {
            this.data = data;
            this.nextNode = nextNode;
        }

        /// <summary>
        /// Property to get and set the data contents of this Node.
        /// </summary>
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        /// <summary>
        /// Property to get and set the Node that this Node is being placed on top of in the chain.
        /// </summary>
        public Node NextNode
        {
            get { return nextNode; }
            set { nextNode = value; }
        }
    }
}