using System;

namespace HW3
{

    /// <summary>
    /// Interface defining a Stack.
    /// </summary>
 
    public interface IStackADT
    {

        /// <summary>
        /// Push item onto the top of the stack.You cannot push an object that 
        /// does not exist and an error will occur. Pushing an object that isn't 
        /// an item will cause an error. Operation returns a reference to the item being pushed.
        /// </summary>
        /// <param name="newItem"> Object to push onto top of the stack. Shouldn't be null.</param>
        /// <returns>A reference to the object pushed or null if newItem == null.</returns>
        Object Push(Object newItem);

        /// <summary>
        /// Remove and return top item on stack. If the stac is empty this operation
        /// should cause an error. Returns a refernce to item removed.
        /// </summary>
        /// <returns>A reference that was popped and removed from the stack or null if the stack is empty.</returns>
        Object Pop();

        /// <summary>
        /// Returns the top item but does not remove it. Normally results in an error if the stack is empty. 
        /// An acceptable alternative is to return something which the user 
        /// can use to check to see if the stack was in fact empty.
        /// </summary>
        /// <returns>A reference to the item currently on the top of the stack or null if the stack is empty.</returns>
        Object Peek();

        /// <summary>
        /// Query the stack to see if it is empty or not. Cannot produce an error.
        /// </summary>
        /// <returns>True if the stack is empty, false otherwise.</returns>
        bool IsEmpty();

        /// <summary>
        /// Reset the stack by emptying it. The exact technique used to 
        /// clear the stack is up to the implementor. The use should pay
        /// attention to what this behavior is.
        /// </summary>
        void Clear();
    }
}

