using System;
using System.Collections.Generic;
using System.Text;

namespace List
{
    public class DoubleLinkedList
    {
        private DoubleNode _root;
        private DoubleNode _tail;

        public int Length { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new IndexOutOfRangeException();
                }

                DoubleNode current = _root;

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

                DoubleNode current = _root;

                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                current.Value = value;
            }
        }

        public DoubleLinkedList()
        {
            Length = 0;
            _root = null;
            _tail = null;
        }

        public DoubleLinkedList(int value)
        {
            Length = 1;
            _root = new DoubleNode(value);
            _tail = _root;
        }

        private DoubleLinkedList(int[] values)
        {
            Length = values.Length;

            if (values.Length != 0)
            {
                _root = new DoubleNode(values[0]);
                _tail = _root;

                for (int i = 1; i < values.Length; i++)
                {
                    _tail.Next = new DoubleNode(values[i]);
                    _tail.Next.Previous = _tail;
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }
        }

        public static DoubleLinkedList Create(int[] values)
        {
            if (!(values is null))
            {
                return new DoubleLinkedList(values);
            }

            throw new NullReferenceException("Values is null");
        }

        public void Add(int value)
        {
            if (Length != 0)
            {
                _tail.Next = new DoubleNode(value);
                _tail.Next.Previous = _tail;
                _tail = _tail.Next;

            }
            else
            {
                _root = new DoubleNode(value);
                _tail = _root;
            }

            Length++;
        }

        public void AddValueToStart(int value)
        {
            if (Length != 0)
            {
                DoubleNode first = new DoubleNode(value);

                _root.Previous = first;
                first.Next = _root;
                _root = first;
            }
            else
            {
                _root = new DoubleNode(value);
                _tail = _root;
            }
            Length++;
        }

        public void AddValueByIndex(int value, int index)
        {
            if (index >= 0 && index < Length)
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
                        DoubleNode DoubleNodeByIndex = new DoubleNode(value);
                        DoubleNode current = GetDoubleNodeByIndex(index - 1);

                        DoubleNodeByIndex.Next = current.Next;
                        current.Next = DoubleNodeByIndex;
                    }
                }
                else
                {
                    _root = new DoubleNode(value);
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
            if (Length > 1)
            {
                DoubleNode current = GetDoubleNodeByIndex(Length - 2);
                current.Next = null;
                Length--;
            }
            else if (Length == 1)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveOneElementFromStart()
        {
            if (Length > 1)
            {
                _root = _root.Next;
                Length--;
            }
            else if (Length == 1)
            {
                Length = 0;
                _root = null;
                _tail = null;
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        public void RemoveOneElementByIndex(int index)
        {
            if (index >= 0 && index < Length)
            {
                if (Length != 0)
                {
                    if (index != 0 && index < Length - 1)
                    {
                        DoubleNode current = GetDoubleNodeByIndex(index - 1);

                        current.Next = current.Next.Next;
                        current.Next.Previous = current;
                        Length--;
                    }
                    else if (index == 0)
                    {
                        RemoveOneElementFromStart();
                    }
                    else
                    {
                        RemoveOneElementFromLast();
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
                    DoubleNode current = GetDoubleNodeByIndex(Length - nvalue);
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
                    DoubleNode current = GetDoubleNodeByIndex(nvalue - 1);
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

        public void RemoveNElementsByIndex(int count, int index)
        {
            if (index >= 0 && index < Length)
            {
                if (index == 0)
                {
                    RemoveNElementsFromStart(count);
                }
                else if (index == Length - 1)
                {
                    RemovNElementsFromLast(count);
                }
                else if (count > 0)
                {
                    if (!(count + index >= Length))
                    {
                        DoubleNode startNode = GetDoubleNodeByIndex(index - 1);
                        DoubleNode finishNode = GetDoubleNodeByIndex(index + count);

                        startNode.Next = finishNode;
                        finishNode.Previous = startNode;

                        Length -= count;
                    }
                    else
                    {
                        DoubleNode current = GetDoubleNodeByIndex(index);

                        current.Next = null;
                        _tail = current;
                        Length = index + 1;
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
                DoubleNode current = GetDoubleNodeByIndex(index);

                current.Value = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }

        }

        public int GetFirstIndexByValue(int value)
        {
            DoubleNode current = _root;

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
            DoubleNode current = _root;
            DoubleNode tmp = _tail;
            int value;
            int count = 0;

            while (count != Length / 2)
            {
                value = current.Value;
                current.Value = tmp.Value;
                tmp.Value = value;

                current = current.Next;
                tmp = tmp.Previous;

                ++count;
            }
        }

        public int GetIndexMaxElement()
        {
            if (Length != 0 || this is null)
            {
                DoubleNode current = _root;
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
            if (Length != 0 || this is null)
            {
                DoubleNode current = _root;
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
            return GetDoubleNodeByIndex(GetIndexMaxElement()).Value;
        }

        public int GetValueMinElement()
        {
            return GetDoubleNodeByIndex(GetIndexOfMinElement()).Value;
        }

        public void GetSortAscending()
        {
            for (int i = 0; i < Length; i++)
            {
                int min = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetDoubleNodeByIndex(min).Value > GetDoubleNodeByIndex(j).Value)
                    {
                        min = j;
                    }
                }
                int temp = GetDoubleNodeByIndex(i).Value;
                GetDoubleNodeByIndex(i).Value = GetDoubleNodeByIndex(min).Value;
                GetDoubleNodeByIndex(min).Value = temp;
            }
        }

        public void GetDescendingSort()
        {
            for (int i = 0; i < Length; i++)
            {
                int max = i;

                for (int j = i + 1; j < Length; j++)
                {
                    if (GetDoubleNodeByIndex(max).Value < GetDoubleNodeByIndex(j).Value)
                    {
                        max = j;
                    }
                }

                int temp = GetDoubleNodeByIndex(i).Value;
                GetDoubleNodeByIndex(i).Value = GetDoubleNodeByIndex(max).Value;
                GetDoubleNodeByIndex(max).Value = temp;
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

        public void AddListToTheEnd(DoubleLinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList.Length != 0)
                {
                    _tail.Next = secondList._root;
                    secondList._root.Previous = this._tail;
                    _tail = secondList._tail;
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

        public void AddListToStart(DoubleLinkedList secondList)
        {
            if (Length != 0)
            {
                if (secondList.Length != 0)
                {
                    secondList._tail.Next = _root;
                    _root.Previous = secondList._tail;
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

        public void AddListByIndex(DoubleLinkedList secondList, int index)
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
                            DoubleNode current = GetDoubleNodeByIndex(index - 1);

                            secondList._tail.Next = current.Next;
                            current.Next.Previous = secondList._tail;
                            current.Next = secondList._root;
                            secondList._root.Previous = current;

                            Length += secondList.Length;
                        }
                    }
                    else
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
                DoubleNode current = _root;
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
            if (obj is DoubleLinkedList || obj is null)
            {
                DoubleLinkedList list = (DoubleLinkedList)obj;
                bool isEqual = false;
                if (this.Length == list.Length)
                {
                    isEqual = true;
                    DoubleNode currentThis = this._root;
                    DoubleNode currentList = list._root;
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

        private DoubleNode GetDoubleNodeByIndex(int index)
        {
            DoubleNode current;
            if (index > Length / 2 + 1)
            {
                current = _tail;
                for (int i = Length - 1; i > index; i--)
                {
                    current = current.Previous;
                }
                return current;
            }
            else
            {
                current = _root;
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Length, _root, _tail);
        }
    }
}
