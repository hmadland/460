using System;

namespace HW3
{
    using System;

    namespace HW3
    {
        /// <summary>
        /// Command line postfix calculator.
        /// </summary>
        class Calculator
        {
            // Our data structure used to hold the operands for the postfix calculation.
           
            private IStackADT stack = new LinkedStack();
   
           private IStackADT Stack
            {
              get { return stack; }
            }

            /// <summary>
            /// Entry point method. 
            /// </summary>
            /// <param name="args">The command line arguments.</param>
            static void Main(string[] args)
            {
                Calculator calc = new Calculator();
                bool calculateAgain = true;
                Console.Write("\nPostfix Calculator. Recognizes these operators: + - * / \n");
                while (calculateAgain)
                {
                    calculateAgain = calc.Calculate();
                }
                Console.Write("Bye.");
            }

            /// <summary>
            /// Get input string from user and perform calculation, returning true when
            /// finished.If the user wishes to quit this method returns false.
            /// </summary>
            /// <returns>True if a calculation succeeded, false if the usere wishes to quit.</returns>
            private bool Calculate()
            {
                Console.Write("Please enter q to quit\n ");
                string input, output = "";

                input = Console.ReadLine();
                // See if user wants to quit.
                if (input.Trim().ToLower().StartsWith("q"))
                {
                    return false;
                }
                // do calculation
                try
                {
                    output = EvaluatePostFixInput(input);
                }
                catch (ArgumentException x)
                {
                    output = x.Message;
                }
                Console.Write("\n\t>>> " + input + " = " + output +  "\n");
                return true;
            }

            /// <summary>
            /// Evaluate an arithmetic expression written in postfix form.
            /// </summary>
            /// <param name="input">Postfix mathematical expression input by the user as a string.</param>
            /// <returns>Answer as a string.</returns>
            private string EvaluatePostFixInput(string input)
            {
                if (input == null || input.Equals(""))
                    throw new ArgumentException("Null or the empty string are not valid postfix expressions.");
                Stack.Clear(); // Clear the stack before doing a new calculation.
                int stackCount = 0; // Track the number of operands in the stack.

                double a, b, c, s; // Temporary variables for operands, answer, and TryParse

                string[] variables = input.Trim().Split(' ');
                foreach (string var in variables)
                {
                    // if number push it on the stack
                    if (Double.TryParse(var, out s))
                    {
                        Stack.Push((s));
                        stackCount++;
                    }
                    else // Must be operator or some other character or word.
                    {
                        if (var.Length > 1)
                            throw new ArgumentException("Input Error: " + var + " is not an allowed number or operator");
                        // may be an operator, so pop two values off stack and perform operation
                        if (Stack.IsEmpty())
                            throw new ArgumentException("Improper input format. Stack became empty when expecting second operand.");
                        b = (double)Stack.Pop();
                        if (Stack.IsEmpty())
                            throw new ArgumentException("Improper input format. Stack became empty when expecting first operand.");
                        a = (double)Stack.Pop();
                        // Send values to another method to perform operation.
                        c = DoOperation(a, b, var, ref stackCount);
                        // Push answer from operation back onto the stack.
                        Stack.Push(c);
                    }
                } // end foreach

                return Stack.Pop().ToString();
            }

            /// <summary>
            /// Perform arithmetic.
            /// </summary>
            /// <param name="a">First operand</param>
            /// <param name="b">Second operand</param>
            /// <param name="s">Operator</param>
            /// <param name="count">Number of items on stack.</param>
            /// <returns>The answer</returns>
            private double DoOperation(double a, double b, string s, ref int count)
            {
                double c = 0.0;
                if (s.Equals("+"))
                    c = (a + b);
                else if (s.Equals("-"))
                    c = (a - b);
                else if (s.Equals("*"))
                    c = (a * b);
                else if (s.Equals("/"))
                {
                    try
                    {
                        c = (a / b);
                        if (Double.IsNegativeInfinity(c) || Double.IsPositiveInfinity(c))
                            throw new ArgumentException("Can't divide by zero.");
                    }
                    catch (ArithmeticException x)
                    {
                        throw new ArgumentException(x.Message);
                    }
                }
                else
                    throw new ArgumentException("Improper operator: " + s + ", is not one of +, -, *, or / \n");

                count--; // operation successful, one less item on stack
                return c;
            }
        } // end class Calculator
    }

}
