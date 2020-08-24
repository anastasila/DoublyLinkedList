using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyList
{
    public class DoublyLinkedList
    {
        public DoublyLinkedList() { }

        public DoublyLinkedList(int[] array)
        {
            if (array == null)
                Errors.NullHead();

            Head = new DoublyNode(array[0]);
            Head.Prev = null;
            Tail = Head;
            Length = 1;

            for (int i = 1; i < array.Length; i++)
            {
                Tail.Next = new DoublyNode(array[i]);
                Tail.Next.Prev = Tail;
                Tail = Tail.Next;
            }

            Length = array.Length;
        }

        DoublyNode Head { get; set; }
        DoublyNode Tail { get; set; }
        public int Length { get; set; }

        DoublyNode GetPreIndexNode(int idx)
        {
            if (Head == null)
                return Head;

            DoublyNode indexNode = Head;
            for (int counter = 1; counter < idx; counter++)
            {
                indexNode = indexNode.Next;
            }
            return indexNode;
        }

        DoublyNode GetPreIndexNodeFromTail(int idx)
        {
            if (Tail == null)
                return Tail;

            DoublyNode indexNode = Tail;
            for (int counter = Length; counter > idx; counter--)
            {
                indexNode = indexNode.Prev;
            }

            return indexNode;
        }

        public void AddFirst(int value)
        {
            DoublyNode node = new DoublyNode(value);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head.Prev = node;
                Head = node;
            }
            Length++;
        }

        public void AddFirst(int[] values)
        {
            DoublyLinkedList arrayValues = new DoublyLinkedList(values);

            if (Head == null)
            {
                Head = arrayValues.Head;
                Tail = arrayValues.Tail;
            }
            else
            {
                arrayValues.Tail.Next = Head;
                Head.Prev = arrayValues.Tail;
                Head = arrayValues.Head;
            }

            Length += arrayValues.Length;

        }

        public void AddLast(int value)
        {
            DoublyNode node = new DoublyNode(value);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
            }
            Length++;
        }

        public void AddLast(int[] values)
        {
            DoublyLinkedList arrayValues = new DoublyLinkedList(values);

            if (Head == null)
            {
                Head = arrayValues.Head;
                Tail = arrayValues.Tail;
            }
            else
            {
                Tail.Next = arrayValues.Head;
                arrayValues.Head.Prev = Tail;
                Tail = arrayValues.Tail;
            }

            Length += arrayValues.Length;
        }

        public void AddAt(int idx, int value)
        {
            if (idx < 0)
            {
                Errors.IndexIsIncorrect();
                return;
            }

            if (idx >= Length)
            {
                AddLast(value);
            }
            else if (idx == 0)
            {
                AddFirst(value);
            }
            else
            {
                DoublyNode node = new DoublyNode(value);
                DoublyNode indexNode;
                if (idx <= Length / 2)
                {
                    indexNode = GetPreIndexNode(idx);
                }
                else
                {
                    indexNode = GetPreIndexNodeFromTail(idx);
                }
                node.Next = indexNode.Next;
                node.Next.Prev = node;
                node.Prev = indexNode;
                indexNode.Next = node;
                Length++;
            }
        }

        public void AddAt(int idx, int[] values)
        {
            DoublyLinkedList arrayValues = new DoublyLinkedList(values);

            if (idx < 0)
            {
                Errors.IndexIsIncorrect();
                return;
            }

            if (idx >= Length)
            {
                AddLast(values);
            }
            else if (idx == 0)
            {
                AddFirst(values);
            }
            else
            {
                DoublyNode indexNode;
                if (idx <= Length / 2)
                {
                    indexNode = GetPreIndexNode(idx);
                }
                else
                {
                    indexNode = GetPreIndexNodeFromTail(idx);
                }
                indexNode.Next.Prev = arrayValues.Tail;
                arrayValues.Tail.Next = indexNode.Next;
                arrayValues.Head.Prev = indexNode;
                indexNode.Next = arrayValues.Head;

                Length += arrayValues.Length;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Length];
            DoublyNode node = Head;
            DoublyNode tmp = Tail;
            int i = 0;
            while (i < (Length + 1) / 2)
            {
                array[i] = node.Value;
                node = node.Next;
                array[Length - 1 - i] = tmp.Value;
                tmp = tmp.Prev;
                i++;
            }

            return array;
        }

        public int GetSize()
        {
            return Length;
        }

        public void Set(int idx, int value)
        {
            DoublyNode tmp;
            DoublyNode node = new DoublyNode(value);

            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else if (idx > Length - 1)
            {
                Tail.Next = node;
                node.Prev = Tail;
                Tail = node;
                Length++;
            }
            else if (idx == 0)
            {
                Head.Value = node.Value;
            }
            else if (idx <= Length / 2)
            {
                tmp = GetPreIndexNode(idx + 1);
                tmp.Value = node.Value;
            }
            else
            {
                tmp = GetPreIndexNodeFromTail(idx + 1);
                tmp.Value = node.Value;
            }
        }

        public void RemoveFirst()
        {
            if (Head == null)
            {
                Errors.NullHead();
                return;
            }

            if (Length == 1)
            {
                Head = null;
                Tail = null;
                Length = 0;
            }
            else
            {
                Head = Head.Next;
                Head.Prev = null;
                Length--;
            }
        }

        public void RemoveLast()
        {
            if (Head == Tail)
            {
                Head = null;
                Tail = null;
                Length = 0;
            }
            else
            {
                DoublyNode tmpNode = Tail.Prev;
                Tail.Prev = null;
                Tail = tmpNode;
                tmpNode.Next = null;
                Length--;
            }
        }

        public void RemoveAt(int idx)
        {
            DoublyNode tmpNode;

            if (idx >= Length - 1)
            {
                RemoveLast();
            }
            else if (idx == 0)
            {
                RemoveFirst();
            }
            else if (idx <= Length / 2)
            {
                tmpNode = GetPreIndexNode(idx);
                tmpNode.Next = tmpNode.Next.Next;
                tmpNode.Next.Prev = tmpNode;
                Length--;
            }
            else
            {
                tmpNode = GetPreIndexNodeFromTail(idx);
                tmpNode.Next = tmpNode.Next.Next;
                tmpNode.Next.Prev = tmpNode;
                Length--;
            }
        }

        public void RemoveAll(int val)
        {
            DoublyNode tmpNode = Head;
            int count = 0;

            for (int index = 0; tmpNode.Next != null; index++)
            {
                if (tmpNode.Value == val)
                {
                    RemoveAt(index - count);
                    count++;
                }
                tmpNode = tmpNode.Next;
            }

            if (Tail.Value == val)
            {
                RemoveLast();
            }
        }

        public bool Contains(int val)
        {
            DoublyNode tmpNode = Head;
            DoublyNode prevNode = Tail;
            bool answer = false;

            while (tmpNode.Next != null)
            {
                if (tmpNode.Value == val || prevNode.Value == val)
                {
                    answer = true;
                    return answer;
                }
                tmpNode = tmpNode.Next;
                prevNode = prevNode.Prev;
            }

            return answer;
        }

        public int IndexOf(int val)
        {
            if (Head == null)
            {
                Errors.NullHead();
                return -1;
            }

            int index = -1;
            DoublyNode tmpNode = Head;
            DoublyNode prevNode = Tail;

            for (int i = 0; tmpNode != null; i++)
            {
                if (tmpNode.Value == val)
                {
                    index = i;
                    return index;
                }

                if (prevNode.Value == val)
                {
                    index = Length - i - 1;
                    return index;
                }
                tmpNode = tmpNode.Next;
                prevNode = prevNode.Prev;
            }

            return index;
        }

        public int GetFirst()
        {
            if (Head == null)
            {
                Errors.NullHead();
                return -1;
            }

            int first = Head.Value;
            return first;
        }

        public int GetLast()
        {
            if (Head == null)
            {
                Errors.NullHead();
                return -1;
            }

            int last = Tail.Value;
            return last;
        }

        public int Get(int idx)
        {
            if (Head == null)
            {
                Errors.NullHead();
                return -1;
            }
            else if (idx > Length - 1)
            {
                Errors.IndexIsIncorrect();
                return -1;
            }

            int value;
            DoublyNode tmpNode;

            if (idx == 0)
            {
                value = GetFirst();
            }
            else if (idx <= Length / 2)
            {

                tmpNode = GetPreIndexNode(idx);
                value = tmpNode.Next.Value;
            }
            else
            {
                tmpNode = GetPreIndexNodeFromTail(idx);
                value = tmpNode.Next.Value;
            }

            return value;
        }

        public void Reverse()
        {
            DoublyNode doublyNode = Head;
            DoublyNode tmpNode = null;
            if (doublyNode == null)
                return;

            Tail = doublyNode;

            while (doublyNode != null)
            {
                tmpNode = doublyNode.Prev;
                doublyNode.Prev = doublyNode.Next;
                doublyNode.Next = tmpNode;
                doublyNode = doublyNode.Prev;
            }

            if (tmpNode != null)
            {
                Head = tmpNode.Prev;
            }
        }

        public int IndexOfMax()
        {
            int maxNumber1 = Head.Value;
            int maxNumber2 = Tail.Value;
            int index1 = 0;
            int index2 = Length - 1;
            DoublyNode tmpNode = Head;
            DoublyNode tailNode = Tail;

            for (int i = 0; i < (Length + 1) / 2; i++)
            {
                if (tmpNode.Value > maxNumber1)
                {
                    maxNumber1 = tmpNode.Value;
                    index1 = i;
                }

                if (tailNode.Value > maxNumber2)
                {
                    maxNumber2 = tailNode.Value;
                    index2 = Length - 1 - i;
                }

                tailNode = tailNode.Prev;
                tmpNode = tmpNode.Next;
            }

            if (maxNumber2 > maxNumber1)
                return index2;
            return index1;
        }

        public int IndexOfMin()
        {
            int minNumber1 = Head.Value;
            int minNumber2 = Tail.Value;
            int index1 = 0;
            int index2 = Length - 1;
            DoublyNode tmpNode = Head;
            DoublyNode tailNode = Tail;

            for (int i = 0; i < (Length + 1) / 2; i++)
            {
                if (tmpNode.Value < minNumber1)
                {
                    minNumber1 = tmpNode.Value;
                    index1 = i;
                }

                if (tailNode.Value < minNumber2)
                {
                    minNumber2 = tailNode.Value;
                    index2 = Length - 1 - i;
                }

                tailNode = tailNode.Prev;
                tmpNode = tmpNode.Next;
            }

            if (minNumber2 < minNumber1)
                return index2;
            return index1;
        }

        public int Max()
        {
            int maxNumber1 = Head.Value;
            int maxNumber2 = Tail.Value;
            DoublyNode tmpNode = Head;
            DoublyNode tailNode = Tail;

            for (int i = 0; i < (Length + 1) / 2; i++)
            {
                if (tmpNode.Value > maxNumber1)
                {
                    maxNumber1 = tmpNode.Value;
                }

                if (tailNode.Value > maxNumber2)
                {
                    maxNumber2 = tailNode.Value;
                }

                tailNode = tailNode.Prev;
                tmpNode = tmpNode.Next;
            }

            if (maxNumber2 > maxNumber1)
                return maxNumber2;
            return maxNumber1;
        }

        public int Min()
        {
            int minNumber1 = Head.Value;
            int minNumber2 = Tail.Value;
            DoublyNode tmpNode = Head;
            DoublyNode tailNode = Tail;

            for (int i = 0; i < Length; i++)
            {
                if (tmpNode.Value < minNumber1)
                {
                    minNumber1 = tmpNode.Value;
                }

                if (tailNode.Value < minNumber2)
                {
                    minNumber2 = tailNode.Value;
                }

                tailNode = tailNode.Prev;
                tmpNode = tmpNode.Next;
            }

            if (minNumber2 < minNumber1)
                return minNumber2;
            return minNumber1;
        }

        public void PrintList()
        {
            DoublyNode node = Head;
            while (node != null)
            {
                Console.Write($"{node.Value} \t");
                node = node.Next;
            }
        }

        public void Sort()
        {  
            Head = MergeSort(Head);
            while (Tail.Next != null)
            {
                Tail = Tail.Next;
            }
        }

        public void SortDesc()
        {
            Head = MergeDescSort(Head);
            while (Tail.Next != null)
            {
                Tail = Tail.Next;
            }
        }

        private DoublyNode Split(DoublyNode head)
        {
            DoublyNode fast = head, slow = head;
            while (fast.Next != null &&
                    fast.Next.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            DoublyNode temp = slow.Next;
            slow.Next = null;
            return temp;
        }

        private DoublyNode MergeSort(DoublyNode node)
        {
            if (node == null)
            {
                Tail = node.Prev;
                return node;
            }
            else if (node.Next == null)
            {
                Tail = node;
                return node;
            }
            DoublyNode second = Split(node);

            node = MergeSort(node);
            second = MergeSort(second);

            return Merge(node, second);
        }

        private DoublyNode MergeDescSort(DoublyNode node)
        {
            if (node == null)
            {
                Tail = node.Prev;
                return node;
            }
            else if (node.Next == null)
            {
                Tail = node;
                return node;
            }
            DoublyNode second = Split(node);

            node = MergeDescSort(node);
            second = MergeDescSort(second);

            return MergeDesc(node, second);
        }

        private DoublyNode Merge(DoublyNode first, DoublyNode second)
        {
            if (first == null)
            {
                return second;
            }

            if (second == null)
            {
                return first;
            }

            if (first.Value < second.Value)
            {
                first.Next = Merge(first.Next, second);
                first.Next.Prev = first;
                first.Prev = null;
                return first;
            }
            else
            {
                second.Next = Merge(first, second.Next);
                second.Next.Prev = second;
                second.Prev = null;
                return second;
            }
        }

        private DoublyNode MergeDesc(DoublyNode first, DoublyNode second)
        {
            if (first == null)
            {
                return second;
            }

            if (second == null)
            {
                return first;
            }

            if (first.Value > second.Value)
            {
                first.Next = MergeDesc(first.Next, second);
                first.Next.Prev = first;
                first.Prev = null;
                return first;
            }
            else
            {
                second.Next = MergeDesc(first, second.Next);
                second.Next.Prev = second;
                second.Prev = null;
                return second;
            }
        }
    }
}
