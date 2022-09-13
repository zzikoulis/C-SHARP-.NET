using System;

namespace Queue
{
    internal class Program
    {
        static int[] queue = new int[50];
        static int last = -1;

        static void Main(string[] args)
        {
            int? deQueueNum;

            EnQueue(2);
            EnQueue(4);
            EnQueue(6);

            PrintQueue();

            if ((deQueueNum = DeQueue()) != null)
            {
                Console.WriteLine($"DeQueue of {deQueueNum} completed!");
            }

            PrintQueue();

            if ((deQueueNum = DeQueue()) != null)
            {
                Console.WriteLine($"DeQueue of {deQueueNum} completed!");
            }
            if ((deQueueNum = DeQueue()) != null)
            {
                Console.WriteLine($"DeQueue of {deQueueNum} completed!");
            }
            if ((deQueueNum = DeQueue()) != null)
            {
                Console.WriteLine($"DeQueue of {deQueueNum} completed!");
            }
        }

        public static void EnQueue(int num)
        {
            if (IsFull())
            {
                Console.WriteLine("Queue is full! EnQueue operation can not be done.");
            }
            else
            {
                queue[++last] = num;
                Console.WriteLine($"EnQueue of {num} completed!");
            }
        }

        public static int? DeQueue()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Queue is empty! DeQueue operation can not be done.");
                return null;
            }
            else
            {
                int num = queue[0];
                for (int i = 0; i < last; i++)
                {
                    queue[i] = queue[i + 1];
                }
                last--;
                return num;
            }
        }

        public static bool IsFull()
        {
            return (last == (queue.Length - 1));
        }

        public static bool IsEmpty()
        {
            return (last == -1);
        }

        public static void PrintQueue()
        {
            Console.WriteLine("Queue:");

            for (int i = 0; i <= last; i++)
            {
                Console.WriteLine(queue[i]);
            }

            Console.WriteLine();
        }
    }
}