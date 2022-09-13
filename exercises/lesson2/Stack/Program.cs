using System;

namespace Stack
{
    internal class Program
    {
        static int[] stack = new int[50];
        static int top = -1;

        static void Main(string[] args)
        {
            int? popNum;

            Push(2);
            Push(4);
            Push(6);

            PrintStack();
           
            if ((popNum = Pop()) != null)
            {
                Console.WriteLine($"Pop of {popNum} completed!");
            }

            PrintStack();

            if ((popNum = Pop()) != null)
            {
                Console.WriteLine($"Pop of {popNum} completed!");
            }
            if ((popNum = Pop()) != null)
            {
                Console.WriteLine($"Pop of {popNum} completed!");
            }
            if ((popNum = Pop()) != null)
            {
                Console.WriteLine($"Pop of {popNum} completed!");
            }
        }

        public static void Push(int num)
        {
            if (IsFull())
            {
                Console.WriteLine("Stack is full! Push operation can not be done.");
            }
            else
            {
                stack[++top] = num;
                Console.WriteLine($"Push of {num} completed!");
            }
        }

        public static int? Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty! Pop operation can not be done.");
                return null;
            }
            else
            {
                return stack[top--];    
            }
        }

        public static bool IsFull()
        {
            return (top == (stack.Length - 1));
        }

        public static bool IsEmpty()
        {
            return (top == -1);
        }

        public static void PrintStack()
        {
            Console.WriteLine("Stack:");

            for (int i = top; i > -1; i--)
            {
                Console.WriteLine(stack[i]);
            }

            Console.WriteLine();
        }
    }
}