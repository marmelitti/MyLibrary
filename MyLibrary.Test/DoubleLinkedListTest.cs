using List;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Test
{
    public class DoubleLinkedListTest
    {
        [TestCase(1, new int[] { 5, 10, 15 }, 10)]
        public void GetIndex_WhenIndex_ShouldValueByIndex(int index, int[] actualArray, int expected)
        {
            DoubleLinkedList expectedArray = DoubleLinkedList.Create(actualArray);


            int actual = expectedArray[index];

            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        public void DoubleLinkedListEmptyConstructor_WhenObjectOfAClassIsCreated_LengthEqualsZero(int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList();
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 1)]
        public void DoubleLinkedListConstructor_WhenObjectOfAClassIsCreated_Length1(int value, int expected)
        {
            DoubleLinkedList actualList = new DoubleLinkedList(value);
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }
        [TestCase(null)]
        public void DoubleLinkedList_WhenListPassed_ShouldArgumentNullException(int[] actualArray)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                DoubleLinkedList.Create(null);
            });
        }

        [TestCase(3, new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        public void AddValue_WhenValuePassed_ShouldAddValueToLast(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

            actual.Add(value);

            Assert.AreEqual(DoubleLinkedList.Create(expectedArray), actual);
        }

        [TestCase(3, new int[] { 1, 2 }, new int[] { 3, 1, 2 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 5, 1, 2, 3, 4 })]
        [TestCase(1, new int[] { }, new int[] { 1 })]
        public void AddValueToStart__WhenValuePassed_ShouldAddValueToStart(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

            actual.AddValueToStart(value);

            Assert.AreEqual(DoubleLinkedList.Create(expectedArray), actual);
        }

        [TestCase(7, 0, new int[] { 1, 2, 3 }, new int[] { 7, 1, 2, 3 })]
        [TestCase(5, 1, new int[] { 1, 2, 3 }, new int[] { 1, 5, 2, 3 })]
        [TestCase(4, 3, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 4 })]
        public void AddValueByIndex_WhenValueAndIndex_ShouldAddValueByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.AddValueByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -2, 7, new int[] { 7, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, 7, 10, new int[] { 1, 2, 3, 4, 5, 6, 10 })]
        public void AddByIndex_WhenValueAndIndexPassed_ShouldIndexOutOfRangeException(int[] actualArray, int index, int value, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

                actual.AddValueByIndex(index, value);
            });
        }


        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 3, 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveOneElementFromLast_WhenListPassed_ShouldRemoveLastElem(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveOneElementFromLast();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveOneElementFromLast_WhenListPassed_ShouldNullReferenceException(int[] actualArray)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveOneElementFromLast();
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 2, 1 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveOneElementFromStart_WhenListPassed_ShouldRemoveFirst(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveOneElementFromStart();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void RemoveOneElementFromStart_WhenListPassed_ShouldNullReferenceException(int[] actualArray)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveOneElementFromStart();
            });
        }

        [TestCase(0, new int[] { 1 }, new int[] { })]
        [TestCase(0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 4, 5 })]
        [TestCase(4, new int[] { 5, 4, 3, 2, 1 }, new int[] { 5, 4, 3, 2 })]

        public void RemoveOneElementByIndex_WhenIndexPassed_ShouldRemoveElementByIndex(int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveOneElementByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -1)]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, 6)]
        public void RemoveOneElementByIndex_WhenIndexPassed_ShouldIndexOutOfRangeException(int[] actualArray, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveOneElementByIndex(index);
            });
        }

        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1 })]

        public void Remove_NElementsFromLast_WhenNElementsPassed_ShouldRemoveNElements(int nvalue, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemovNElementsFromLast(nvalue);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, -2)]
        public void RemovNElementsFromLast_WhenNElementsPassed_ShouldReturnArgumentException(int[] actualArray, int nElements)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemovNElementsFromLast(nElements);
            });
        }

        [TestCase(new int[] { 3, 2, 1 }, 5)]
        public void RemovNElementsFromLast_WhenNElementsPassed_ShouldIndexOutOfRangeException(int[] actualArray, int nElements)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemovNElementsFromLast(nElements);
            });
        }

        [TestCase(5, new int[] { 1, 2, 3, 4, 5 }, new int[] { })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(4, new int[] { 1, 2, 3, 4, 5 }, new int[] { 5 })]
        public void RemoveNElementsFromStart_WhenNElementsPassed_ShouldRemoveNElements(int nvalue, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveNElementsFromStart(nvalue);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 3, 4, 5 }, -1)]
        public void RemovNElementsFromStart_WhenNElementsPassed_ShouldArgumentException(int[] actualArray, int nElements)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveNElementsFromStart(nElements);
            });
        }

        [TestCase(new int[] { 11, 12, 13 }, 10)]
        public void RemovNElementsFromStart_WhenNElementsPassed_ShouldIndexOutOfRangeException(int[] actualArray, int nElements)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemovNElementsFromLast(nElements);
            });
        }

        [TestCase(1, 0, new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 5 })]
        [TestCase(3, 0, new int[] { 1, 2, 3 }, new int[] { })]
        [TestCase(3, 1, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(3, 1, new int[] { 1, 2, 3 }, new int[] { 1, 2 })]

        public void RemoveNElementsByIndex_WhenIndexAndNElementsPassed_ShouldRemoveByIndexNElements(int nvalue, int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveNElementsByIndex(nvalue, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 7, 8, 9 }, -1, 1)]
        public void RemoveNElementsByIndex_WhenNElementsPassed_ShouldArgumentException(int[] actualArray, int nElements, int index)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveNElementsByIndex(nElements, index);
            });
        }

        [TestCase(new int[] { 1, 5, 3 }, 2, 4)]
        public void RemoveNElementsByIndex_WhenNElementsPassed_ShouldIndexOutOfRangeException(int[] actualArray, int nElements, int index)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.RemoveNElementsByIndex(nElements, index);
            });
        }

        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)]
        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, -1)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(8, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        public void GetFirstIndexByValue_WhenValuePassed_ShouldIndex(int value, int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 2, 4, 5, 6, 7, 8 })]
        [TestCase(10, 0, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 10, 2, 3, 4, 5, 6, 7, 8 })]
        [TestCase(1, 7, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 1, 2, 3, 4, 5, 6, 7, 1 })]

        public void GetChangeByIndex_WhenValuePassed_ShouldIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.GetChangeByIndex(index, value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0, 4, 7 }, 5, 13)]
        public void GetChangeByIndex_WhenIndexAndNElementsPassed_ShouldIndexOutOfRangeException(int[] actualArray, int index, int value)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);

                actual.GetChangeByIndex(index, value);
            });
        }


        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 3, 2, 1 })]
        [TestCase(new int[] { 7, 8 }, new int[] { 8, 7 })]

        public void Revers_WhenListPassed_ShouldRevers(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.Revers();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 3, 6, 5 }, 2)]
        [TestCase(new int[] { 8, 2, 5, 5, 1 }, 0)]
        [TestCase(new int[] { 1, 2, 3, 1, 5, 6, 7, 9 }, 7)]
        public void GetIndexMaxElement_WhenMethodCalledPassed_ShouldReturnMaxIndex(int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.GetIndexMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 3)]
        public void GetIndexMaxElement_WhenMethodCalledPassed_ShouldArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList list = DoubleLinkedList.Create(actualArray);
                int actual = list.GetIndexMaxElement();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7, 1 }, 6)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 2)]
        public void GetIndexOfMinElement_WhenMethodCalledPassed_ShouldMinIndex(int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.GetIndexOfMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 5)]
        public void GetIndexOfMinElement_WhenMethodCalledPassed_ShouldArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList list = DoubleLinkedList.Create(actualArray);
                int actual = list.GetIndexOfMinElement();
            });
        }

        [TestCase(new int[] { 7, 2, 3, 4, 5 }, 7)]
        [TestCase(new int[] { 0, 3, 4, 5, 6, 7, 9 }, 9)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 6)]
        public void GetValueMaxElement_WhenMethodCalledPassed_ShouldMaxIndex(int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.GetValueMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 1)]
        [TestCase(new int[] { 2, 3, 4, 5, 6, 7, 1 }, 1)]
        [TestCase(new int[] { 2, 6, 1, 4, 5 }, 1)]
        public void GetValueMinElement_WhenMethodCalledPassed_ShouldValueOfMinElem(int[] actualArray, int expected)
        {
            DoubleLinkedList index = DoubleLinkedList.Create(actualArray);
            int actual = index.GetValueMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 3, -1, 4, 1, 6, 8, 12 }, new int[] { -1, 1, 1, 3, 4, 6, 8, 12 })]
        public void GetSortAscending_WhenMethodCalledPassed_ShouldSortbyAscending(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.GetSortAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 3, -1, 4, 1, 6, 8, 12 }, new int[] { 12, 8, 6, 4, 3, 1, 1, -1 })]
        [TestCase(new int[] { 5, 8, 13, 1, 6, 9, 82, 65, 14 }, new int[] { 82, 65, 14, 13, 9, 8, 6, 5, 1 })]
        public void GetDescendingSort_WhenMethodCalled_SortbyAscending(int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.GetDescendingSort();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 5, 2, 3 }, new int[] { 1, 5, 3 })]
        [TestCase(7, new int[] { 1, 2, 3, 7 }, new int[] { 1, 2, 3 })]

        public void Remove_ElementByValue_WhenValuePassed_ShouldRemoveValue(int value, int[] actualArray, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveByValueFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 2, 4, 2, 6, 7, 8 }, 2, new int[] { 1, 4, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 10, new int[] { 1, 1, 3, 4, 5, 6, 8, 8 })]
        [TestCase(new int[] { 3, 3, 3 }, 3, new int[] { })]
        public void RemoveAllByValue_WhenValuePassed_ShouldRemoveAllValue(int[] actualArray, int value, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList expected = DoubleLinkedList.Create(expectedArray);

            actual.RemoveByValueAll(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1 }, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 1, 2, 3, 4, 5, 6 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        public void AddListToTheEnd_WhenListPassed_ShouldAddListToTheEnd(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
            DoubleLinkedList expectedArrayList = DoubleLinkedList.Create(expectedArray);

            actual.AddListToTheEnd(list);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        public void AddListToTheEnd_WhenMethodCalledPassed_ShouldArgumentException(int[] actualArray, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
                actual.AddListToTheEnd(list);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 10 }, new int[] { 10, 1, 2, 3 })]
        public void AddListToStart_WhenListPassed_ShouldAddLisToStart(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
            DoubleLinkedList expectedArrayList = DoubleLinkedList.Create(expectedArray);

            actual.AddListToStart(list);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { })]
        public void AddListToStart_WhenMethodCalledPassed_ShouldArgumentException(int[] actualArray, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
                actual.AddListToStart(list);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4 }, 1, new int[] { 5, 6, 7 }, new int[] { 1, 5, 6, 7, 2, 3, 4 })]
        public void AddByIndex_WhenListAndIndexPassed_ShouldAddListByIndex(int[] actualArray, int index, int[] arrayForList, int[] expectedArray)
        {
            DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
            DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
            DoubleLinkedList expectedArrayList = DoubleLinkedList.Create(expectedArray);

            actual.AddListByIndex(list, index);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { })]
        public void AddListByIndex_WhenMethodCalledPassed_ShouldArgumentException(int[] actualArray, int index, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
                actual.AddListByIndex(list, index);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 5, new int[] { 5, 7, 9 })]
        public void AddListByIndex_WhenMethodCalledPassed_ShouldIndexOutOfRangeException(int[] actualArray, int index, int[] arrayForList)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                DoubleLinkedList actual = DoubleLinkedList.Create(actualArray);
                DoubleLinkedList list = DoubleLinkedList.Create(arrayForList);
                actual.AddListByIndex(list, index);
            });
        }

        [TestCase(new int[] { 2, 4, 6 }, "2 4 6 ")]
        [TestCase(new int[] { 5 }, "5 ")]
        [TestCase(new int[] { }, "")]
        public void ToString_WhenArrayListPassed_ShouldString(int[] array, string expected)
        {
            DoubleLinkedList doubleLinkedList = DoubleLinkedList.Create(array);

            string actual = doubleLinkedList.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
