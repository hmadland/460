namespace HW3
{
    /// A simple singly linked node class.
    class Node
    {
        object data; // Contents of this node
        Node nextNode; // Reference to next Node in the chain

  
        /// Constructor to create a new Node to be added to the stack chain.
        /// data: The contents to be held within this Node
        /// nextNode: Node that this Node is being placed on top of in the chain.
        public Node(object data, Node nextNode)
        {
            this.data = data;
            this.nextNode = nextNode;
        }

        /// Property to get and set the data contents of this Node.
        public object Data
        {
            get { return data; }
            set { data = value; }
        }

        /// Property to get and set the Node that this Node is being placed on top of in the chain.
        public Node NextNode
        {
            get { return nextNode; }
            set { nextNode = value; }
        }
    }
}