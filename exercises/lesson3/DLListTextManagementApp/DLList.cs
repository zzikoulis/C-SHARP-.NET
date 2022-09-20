using System;

namespace DLLTextManagementApp
{
    internal class DLList<T>
    {
        public GenericNode<T>? Head { get; set; }
        public GenericNode<T>? Tail { get; set; }

        public DLList()
        {
            Head = null;
            Tail = null;
        }

        private bool IsEmpty()
        {
            return ((Head == null) && (Tail == null));
        }

        public void InsertFirst(T t)
        {
            GenericNode<T> tmp = new() { 
                Value = t,
                Next = null, 
                Prev = null, 
                Count = 1 
            };

            if (IsEmpty())
            {
                Tail = tmp;
            }

            Head = tmp;
        }

        public void InsertLast(T t)
        {
            if (IsEmpty())
            {
                InsertFirst(t);
                return;
            }

            GenericNode<T> tmp = new()
            {
                Value = t,
                Next = null,
                Prev = Tail,
                Count = 1
            };

            Tail!.Next = tmp;

            Tail = tmp;
        }

        public void Traverse(int countTotal)
        {
            if (IsEmpty())
            {
                Console.WriteLine("Empty List");
                return;
            }

            Console.WriteLine($"TotalChars: {countTotal}");
            for (GenericNode<T> node = Head!; node != null; node = node.Next!)
            {
                Console.WriteLine($"Value: {node.Value}, Count: {node.Count}, Frequency: {((double)node.Count / countTotal):P}");
            }
        }

        public GenericNode<T>? GetNodePosition(T t)
        {
            GenericNode<T> tmp = Head!;
            while (tmp != null)
            {
                if (tmp.Value!.Equals(t))
                {
                    return tmp;
                }
                tmp = tmp.Next;
            }

            return null;
        }

        public void IncreaseCount(GenericNode<T> node)
        {
            node.Count++;
        }

        private void Swap(GenericNode<T> iNode, GenericNode<T> jNode)
        {
            T tempVal = iNode.Value;
            int tempCount = iNode.Count;

            iNode.Value = jNode.Value;
            iNode.Count = jNode.Count;

            jNode.Value = tempVal;
            jNode.Count = tempCount;
        }

        public void SortByValAsc()
        {
            for (GenericNode<T> iNode = Head; iNode != null; iNode = iNode.Next)
            {
                T minVal = iNode.Value;
                GenericNode<T> minPos = iNode;

                for (GenericNode<T> jNode = iNode; jNode != null; jNode = jNode.Next)
                {
                    if (jNode.Value is char)
                    {
                        if (Convert.ToChar(jNode.Value) < Convert.ToChar(minVal))
                        {
                            minVal = jNode.Value;
                            minPos = jNode;
                        }
                    }
                }
                Swap(iNode, minPos);
            }
        }

        public void SortByFrequencyDesc()
        {
            for (GenericNode<T> iNode = Head; iNode != null; iNode = iNode.Next)
            {
                int minVal = iNode.Count;
                GenericNode<T> minPos = iNode;

                for (GenericNode<T> jNode = iNode; jNode != null; jNode = jNode.Next)
                {
                    if (jNode.Count > minVal)
                    {
                        minVal = jNode.Count;
                        minPos = jNode;
                    }
                }
                Swap(iNode, minPos);
            }
        }
    }
}
