using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class LinkedList
    {
        private Node _root;
        private Node _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                return current.Value;
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                Node current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }

                current.Value = value;
            }
        }

        public LinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            Length = 1;
            _root = new Node(value);
            _tail = _root;
        }

        private LinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }
        public static LinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new LinkedList(values);
            }

            throw new NullReferenceException("Values is null");
        }

        public void Add(int value)
        {
            if (Length != 0)
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
            }
            Length++;
        }
        public void AddValueToStart(int value)
        {
            if (Length != 0)
            {
                Length++;

                Node first = new Node(value);

                first.Next = _root;
                _root = first;
            }
            else
            {
                _root = new Node(value);
                _tail = _root;
                Length++;
            }
        }

        public void AddValueByIndex(int value, int index)
        {
            if (index >= 0 && index <= Length)
            {
                if (Length != 0)
                {
                    if (index == 0)
                    {
                        AddValueToStart(value);
                        Length--;
                    }
                    else
                    {
                        Node nodeByIndex = new Node(value);

                        Node current = GetNodeByIndex(index - 1);

                        nodeByIndex.Next = current.Next;
                        current.Next = nodeByIndex;
                    }
                }
                else
                {
                    _root = new Node(value);
                    _tail = _root;
                }

                Length++;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public void RemoveOneElementFromLast()
        {
            RemoveOneElementByIndex(Length - 1);
        }

        public void RemoveOneElementFromStart()
        {
            if (Length == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            else if (Length == 1)
            {
                _root = null;
            }
            else
            {
                _root = _root.Next;
            }

            --Length;
        }

        public void RemoveOneElementByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (Length != 0)
                {
                    if (index != 0)
                    {
                        Node current = _root;

                        for (int i = 1; i < index; i++)
                        {
                            current = current.Next;
                        }

                        current.Next = current.Next.Next;

                        Length--;
                    }
                    else
                    {
                        RemoveOneElementFromStart();
                    }
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemovNElementsFromLast(int nvalue)
        {
            if (nvalue < Length)
            {
                if (!(nvalue < 0))
                {
                    Node current = GetNodeByIndex(Length - nvalue);
                    current.Next = _tail;

                    Length -= nvalue;
                }
                else
                {
                    throw new ArgumentException("Invalid value!");
                }
            }
            else if (nvalue == Length)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void RemoveNElementsFromStart(int nvalue)
        {
            if (nvalue < Length)
            {
                if (!(nvalue < 0))
                {
                    Node current = GetNodeByIndex(nvalue - 1);
                    _root = current.Next;

                    Length -= nvalue;
                }
                else
                {
                    throw new ArgumentException("Invalid value!");
                }
            }
            else if (nvalue == Length)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                throw new IndexOutOfRangeException("Out of range!");
            }
        }

        public void RemoveNElementsByIndex(int nvalue, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    RemoveNElementsFromStart(nvalue);
                }
                else if (index == Length - 1)
                {
                    RemovNElementsFromLast(nvalue);
                }
                else if (nvalue > 0)
                {
                    if (!(nvalue + index >= Length))
                    {
                        Node startNode = GetNodeByIndex(index - 1);
                        Node finishNode = GetNodeByIndex(index + nvalue);

                        startNode.Next = finishNode;

                        Length -= nvalue;
                    }
                    else
                    {
                        Node current = GetNodeByIndex(index);

                        current.Next = null;
                        _tail = current;
                        Length = index;
                    }
                }
                else
                {
                    throw new ArgumentException("Invalid value!");
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public void GetChangeByIndex(int index, int value)
        {
            if (index >= 0 && index < Length)
            {
                Node current = GetNodeByIndex(index);

                current.Value = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int GetFirstIndexByValue(int value)
        {
            Node current = _root;

            for (int i = 0; i < Length; i++)
            {
                if (current.Value == value)
                {
                    return i;
                }

                current = current.Next;
            }

            return -1;
        }

        public void Revers()
        {
            if (!(this is null))
            {
                if (Length > 1)
                {
                    Node prev = null;
                    Node current = _root;
                    while (current != null)
                    {
                        Node next = current.Next;
                        current.Next = prev;
                        prev = current;
                        current = next;
                    }

                    _tail = _root;
                    _root = prev;
                }
                else
                {
                    Length = 0;
                    _root = null;
                    _tail = null;
                }
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public int GetIndexMaxElement()
        {
            if (Length != 0)
            {
                Node current = _root;
                int maxIndex = 0;
                int temp = 0;

                for (int i = 0; i < Length; i++)
                {
                    if (temp < current.Value)
                    {
                        maxIndex = i;
                        temp = current.Value;
                    }

                    current = current.Next;
                }

                return maxIndex;
            }
            else
            {
                throw new ArgumentException("List is null");
            }
        }

        public int GetIndexOfMinElement()
        {
            if (Length != 0)
            {
                Node current = _root;
                int minIndex = 0;
                int temp = current.Value;

                for (int i = 0; i < Length; i++)
                {
                    if (temp > current.Value)
                    {
                        minIndex = i;
                        temp = current.Value;
                    }

                    current = current.Next;
                }

                return minIndex;
            }
            else
            {
                throw new ArgumentException("List is null");
            }
        }

        public int GetValueMaxElement()
        {
            return GetNodeByIndex(GetIndexMaxElement()).Value;
        }
        public int GetValueMinElement()
        {
            return GetNodeByIndex(GetIndexOfMinElement()).Value;
        }

        public void GetSortAscending()
        {
            for (int i = 0; i < Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetNodeByIndex(min).Value > GetNodeByIndex(j).Value)
                    {
                        min = j;
                    }
                }

                int temp = GetNodeByIndex(i).Value;
                GetNodeByIndex(i).Value = GetNodeByIndex(min).Value;
                GetNodeByIndex(min).Value = temp;
            }
        }

        public void GetDescendingSort()
        {
            for (int i = 0; i < Length; i++)
            {
                int max = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetNodeByIndex(max).Value < GetNodeByIndex(j).Value)
                    {
                        max = j;
                    }
                }

                int temp = GetNodeByIndex(i).Value;
                GetNodeByIndex(i).Value = GetNodeByIndex(max).Value;
                GetNodeByIndex(max).Value = temp;
            }
        }

        public void RemoveByValueFirst(int value)
        {
            int index = GetFirstIndexByValue(value);

            if (!(value == -1))
            {
                RemoveOneElementByIndex(index);
            }
        }

        public void RemoveByValueAll(int value)
        {
            int indexOfElements = GetFirstIndexByValue(value);

            while (indexOfElements != -1)
            {
                RemoveOneElementByIndex(indexOfElements);
                indexOfElements = GetFirstIndexByValue(value);
            }
        }

        public void AddListToTheEnd(LinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList.Length != 0)
                {
                    _tail.Next = secondList._root;
                    Length += secondList.Length;

                }
                else
                {
                    throw new ArgumentException("No elements in list!");
                }
            }
            else
            {
                _root = secondList._root;
                _tail = secondList._tail;

                Length = secondList.Length;
            }
        }

        public void AddListToStart(LinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList.Length != 0)
                {
                    secondList._tail.Next = _root;
                    _root = secondList._root;

                    Length += secondList.Length;
                }
                else
                {
                    throw new ArgumentException("No elements in list!");

                }
            }
            else
            {
                _root = secondList._root;
                _tail = secondList._tail;

                Length = secondList.Length;
            }
        }

        public void AddListByIndex(LinkedList secondList, int index)
        {
            if (!(secondList is null) && secondList.Length != 0)
            {
                if (index >= 0 && index < Length)
                {
                    if (Length != 0)
                    {
                        if (index == 0)
                        {
                            AddListToStart(secondList);
                        }
                        else
                        {
                            Node current = GetNodeByIndex(index - 1);

                            secondList._tail.Next = current.Next;
                            current.Next = secondList._root;

                            Length += secondList.Length;
                        }
                    }
                    else//
                    {
                        _root = secondList._root;
                        _tail = secondList._tail;

                        Length = secondList.Length;
                    }
                }
                else
                {
                    throw new IndexOutOfRangeException("Out of range!");
                }
            }
            else
            {
                throw new ArgumentException("No elements in list!");
            }
        }

        public override string ToString()
        {
            if (Length != 0)
            {
                Node current = _root;
                string s = current.Value + " ";

                while (!(current.Next is null))
                {
                    current = current.Next;
                    s += current.Value + " ";
                }

                return s;
            }
            else
            {
                return String.Empty;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is LinkedList || obj is null)
            {
                LinkedList list = (LinkedList)obj;
                bool isEqual = false;
                if (this.Length == list.Length)
                {
                    isEqual = true;
                    Node currentThis = this._root;
                    Node currentList = list._root;
                    while (!(currentThis is null))
                    {
                        if (currentThis.Value != currentList.Value)
                        {
                            isEqual = false;
                            break;
                        }

                        currentThis = currentThis.Next;
                        currentList = currentList.Next;
                    }
                }

                return isEqual;
            }

            throw new ArgumentException("obj is not List");
        }

        private Node GetNodeByIndex(int index)
        {
            Node current = _root;

            for (int i = 1; i <= index; i++)
            {
                current = current.Next;
            }

            return current;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Length, _root, _tail);
        }
    }
}
