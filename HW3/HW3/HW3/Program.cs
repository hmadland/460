﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3
{
    class Calculator
    {
        //structure for holding the operands from the postfix calculation
        private IStackADT stack = new LinkedStack();


        private IStackADT Stack
        {
            get { return stack; }
        }

        static void Main(string[] args)
         {
            Calculator calc = new Calculator();
            bool calculateAgain = true;
            Console.Write("Postfix Calculator. Recognizes these operators: + - * /");
            while (calculateAgain)
            {
                calculateAgain = calc.Calculate();
            }
            Console.Write("Bye");

         }



        private bool Calculate()
        {
            Console.Write("Please enter q to quit program\n");
            string input, output = "";

            input = Console.ReadLine();

            //check if user wants to quit
            if (input.Trim().ToLower().StartsWith("q"))
            {
                return false;
            }

            //Calculate
            try
            {
                output = EvaluatePostFixInput(input);
            }
            catch (ArgumentException ex)
            {
                output = ex.Message;
            }
            Console.Write("\n\t>>>" + input + "=" + output);
            return true;
        }

        /**
         * Evaluate an arithmetic expression written in postfix form.
         *  param name="input" Postfix mathematical expression input by the user as a string.</param>
         *  returns Answer as a string.
         **/
         
        private string EvaluatePostFixInput(string input)
        {
            if (input == null || input.Equals(""))
                throw new ArgumentException("Null or empty string not valid postfix expressions");
            Stack.Clear(); //clears stack before new calculation
            int stackCount = 0; //keep track of number of operands in the stack

            double a, b, c, x; //temp variables for operands answer and TryParse


            string[] variables = input.Trim().Split(' ');
            foreach (string v in variables)
            {
                //check if it's a number and push to stack 
                if(Double.TryParse(v, out x))
                {
                    StackPush((x));
                    stackCount++;
                }
                else //if an operator or other character
                {
                    if (v.Length > 1)
                        throw new ArgumentException("Input Error: " + v + "is not an allowed number or operator");

                    // it may be an operator so pop two values off the stack and perform the indicated operation
                    if (Stack.IsEmpty())
                        throw new ArgumentException("Improper input format. Stack became empty when expecting second operand");
                    b = (double)Stack.Pop();
                    if (Stack.IsEmpty())
                        throw new ArgumentException("Improper input format. Stack became empty when expecting first operand. ");
                    a = (double)Stack.Pop();
                    // Send values to another method to perform operations.
                    c = Evaluate(a, b, v, ref stackCount);
                    //Push answer from operation back onto the stack.
                    Stack.Push(c);
                }
            } //end foreach

            //bug fix: If only one thing left on stack, that is the answer, otherwise the user input the wrong number of operators
            if(stackCount > 1)
                throw new ArgumentException("Input Error: Improper operand to operator ratio.");
            return Stack.Pop().ToString();
        }

        /// <summary>
        /// Perform arithmetic.
        /// </summary>
        /// <param name="a">First operand</param>
        /// <param name="b">Second operand</param>
        /// <param name="v">Operator</param>
        /// <param name="stackCount">Number of items on stack, passed by reference.</param>
        /// <returns>The answer</returns>
        
        private double Evaluate(double a, double b, string v, ref int stackCount)
        {
            double c = 0.0;
            if (v.Equals("+"))
                c = (a + b);
            else if (v.Equals("-"))
                c = (a - b);
            else if (v.Equals("/"))
            {
                try
                {
                    c = (a / b);
                    if (Double.IsNegativeInfinity(c)) || Double.IsPositiveInfinity(c))
                        throw new ArgumentException("Can't divide by zero.");
                }
                catch (ArithmeticException ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }
            else
                throw new ArgumentException("Improper operator: " + v + ", is not one of +, -, *, or /");

            stackCount--; //operation successful, so will have one less item on stack
            return c;
        }
    } // end class Calculator
}
