using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary.Test
{
    public class ArrayListTest
    {
        [TestCase(1, new int[] { 5, 10, 15 }, 10)]
        public void GetIndex_WhenIndex_ShouldValueByIndex(int index, int[] actualArray, int expected)
        {
            ArrayList expectedArray = ArrayList.Create(actualArray);

            int actual = expectedArray[index];

            Assert.AreEqual(expected, actual);
        }
        [TestCase(0)]
        public void ArrayListEmptyConstructor_WhenObjectOfAClassIsCreated_LengthEqualsZero(int expected)
        {
            ArrayList actualList = new ArrayList();
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 1)]
        public void ArrayListConstructor_WhenObjectOfAClassIsCreated_Length1(int value, int expected)
        {
            ArrayList actualList = new ArrayList(value);
            int actual = actualList.Length;

            Assert.AreEqual(expected, actual);
        }
        [TestCase(null)]
        public void ArrayList_WhenListPassed_ShouldArgumentNullException(int[] actualArray)
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                ArrayList.Create(null);
            });
        }
        [TestCase(3, new int[] { 1, 2 }, new int[] { 1, 2, 3 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 35 }, new int[] { 1, 2, 35, 1 })]
        [TestCase(1, new int[] { 1 }, new int[] { 1, 1 })]
        [TestCase(40, new int[] { 1, 2, 35, 25, 39, 47, 85, 21, 1, 36, 25 }, new int[] { 1, 2, 35, 25, 39, 47, 85, 21, 1, 36, 25, 40 })]
        [TestCase(3, new int[] { }, new int[] { 3 })]
        public void Add_WhenValuePassed_ShouldAddValueToLast(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 10, 20, 30 }, new int[] { 1 }, new int[] { 1, 10, 20, 30 })]
        public void Add_WhenValuePassed_ShouldAddValue(int[] arrToAdd, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            foreach (var item in arrToAdd)
            {
                actual.Add(item);
            }

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, new int[] { 1, 2 }, new int[] { 3, 1, 2 })]
        [TestCase(5, new int[] { 1, 2, 3, 4 }, new int[] { 5, 1, 2, 3, 4 })]
        [TestCase(1, new int[] { 1, 2, 35 }, new int[] { 1, 1, 2, 35 })]
        [TestCase(3, new int[] { }, new int[] { 3 })]
        public void AddValueToStart_WhenValuePassed_ShouldValueToStart(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.AddValueToStrart(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, 0, new int[] { 1, 2, 3 }, new int[] { 7, 1, 2, 3 })]
        [TestCase(5, 1, new int[] { 1, 2, 3 }, new int[] { 1, 5, 2, 3 })]
        [TestCase(3, 2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 3, 4 })]
        [TestCase(3, 0, new int[] { }, new int[] { 3 })]
        public void AddValueByIndex_WhenValueAndIndexPassed_ShouldAddValueByIndex(int value, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.AddValueByIndex(value, index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3, 5, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 3, 4 })]
        [TestCase(4, 10, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 3, 4 })]
        [TestCase(4, 10, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2, 3, 3, 4 })]
        public void AddValueByIndex_WhenValueAndNotСorrectIndexPassed_ShoulIndexOutOfRangeException(int value, int index, int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.AddValueByIndex(value, index);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 8, 6, 5 }, new int[] { 8, 6 })]
        [TestCase(new int[] { 10, 8, 4 }, new int[] { 10, 8 })]
        [TestCase(new int[] { 10, 8 }, new int[] { 10 })]
        [TestCase(new int[] { 10 }, new int[] { })]
        public void RemoveOneElementFromLast_WhenMethodCalledPassed_ShouldRemoveLast(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveOneElementFromLast();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        public void RemoveOneElementFromLast_WhenMethodCalledPassed_ShouldIndexOutOfRangeException(int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveOneElementFromLast();
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 9, 6, 3 }, new int[] { 6, 3 })]
        [TestCase(new int[] { 12, 6, 3 }, new int[] { 6, 3 })]
        [TestCase(new int[] { 10 }, new int[] { })]
        public void RemoveOneElementFromStart_WhenMethodCalledPassed_ShouldRemoveFirstElem(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveOneElementFromStart();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        public void RemoveOneElementFromStart_WhenMethodCalledPassed_ShouldIndexOutOfRangeException(int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveOneElementFromStart();
            });
        }

        [TestCase(0, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, new int[] { 1, 6, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 2, 5, 3, }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 5, 3, }, new int[] { 1, 2, 5 })]
        [TestCase(0, new int[] { 10 }, new int[] { })]
        [TestCase(0, new int[] { 10, 25 }, new int[] { 25 })]
        public void RemoveOneElementByIndex_WhenElementPassed_ShouldRemoveElement(int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveOneElementByIndex(index);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { }, new int[] { })]
        public void RemoveOneElementByIndex_WhenElementPassed_ShouldIndexOutOfRangeException(int index, int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveOneElementByIndex(index);
            });
        }

        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2 })]
        [TestCase(3, new int[] { 1, 2, 3 }, new int[] { })]
        public void Remove_NElementsFromLast_WhenNElementsPassed_ShouldRemoveNElements(int nvalue, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElementsFromLast(nvalue);


            Assert.AreEqual(expected, actual);
        }

        [TestCase(-3, new int[] { 1, 3, 5, 7 })]
        public void Remove_NElementsFromLast_WhenNElementsPassed_ShouldRemoveArgumentException(int nvalue, int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveNElementsFromLast(nvalue);
            });
        }

        [TestCase(6, new int[] { 1, 3, 5, 7 }, new int[] { 1, 3, 5 })]
        public void Remove_NElementsFromLast_WhenNElementsPassed_ShouldRemoveIndexOutOfRangeException(int nvalue, int[] actualArray, int[] expectedArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveNElementsFromLast(nvalue);
            });
        }

        [TestCase(0, new int[] { 1, 2, 3, 4, 5 }, new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 3, 4, 5 })]
        [TestCase(2, new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3, 4, 5 }, new int[] { 4, 5 })]
        [TestCase(3, new int[] { 1, 2, 3 }, new int[] { })]
        public void RemoveNElementsFromStart_WhenNElementsPassed_ShouldRemoveNElements(int nvalue, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElementsFromStart(nvalue);


            Assert.AreEqual(expected, actual);
        }

        [TestCase(-3, new int[] { 1, 3, 5, 7 })]
        public void Remove_NElementsFromStart_WhenNElementsPassed_ShouldRemoveArgumentException(int nvalue, int[] actualArray)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveNElementsFromStart(nvalue);
            });
        }

        [TestCase(6, new int[] { 1, 3, 5, 7 })]
        public void Remove_NElementsFromStart_WhenNElementsPassed_ShouldRemoveIndexOutOfRangeException(int nvalue, int[] actualArray)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.RemoveNElementsFromStart(nvalue);
            });
        }

        [TestCase(0, 0, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(1, 1, new int[] { 1, 2, 3 }, new int[] { 1, 3 })]
        [TestCase(2, 2, new int[] { 1, 2, 3, 4 }, new int[] { 1, 2 })]
        [TestCase(2, 0, new int[] { 1, 2 }, new int[] { })]
        public void RemoveNElementsByIndex_WhenIndexAndNElementsPassed_ShouldRemoveByIndexNElements(int nvalue, int index, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveNElementsByIndex(nvalue, index);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(2, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)]
        [TestCase(10, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, -1)]
        [TestCase(1, new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(8, new int[] { 8, 2, 3, 4, 5, 6, 7, 8 }, 0)]
        [TestCase(12, new int[] { 8, 2, 3, 4, 5, 6, 7, 12 }, 7)]
        public void GetFirstIndexByValue_WhenValuePassed_ShouldReturnIndex(int value, int[] actualArray, int expected)
        {
            ArrayList array = ArrayList.Create(actualArray);

            int actual = array.GetFirstIndexByValue(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, new int[] { 8, 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 }, new int[] { 7, 6, 5, 4, 3, 2, 1 })]
        [TestCase(new int[] { }, new int[] { })]
        public void GetReverse_WhenMethodCalledPassed_ShouldReversList(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.GetReverse();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 4)]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 7)]
        [TestCase(new int[] { 6, 4, 3, 8, 5 }, 3)]
        public void GetIndexOfMaxElement_WhenMethodCalledPassed_ShouldReturnMaxIndex(int[] actualArray, int expected)
        {
            ArrayList list = ArrayList.Create(actualArray);
            int actual = list.GetIndexOfMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 10)]
        public void GetIndexOfMaxElement_WhenMethodCalledPassed_ShouldArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.GetIndexOfMaxElement();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 0)]
        [TestCase(new int[] { 8, 7, 6, 5, 4, 3, 2, 1 }, 7)]
        [TestCase(new int[] { 15, 6, 8, 12, 1 }, 4)]
        public void GetIndexOfMinElement_WhenMethodCalledPassed_ShouldReturnMaxIndex(int[] actualArray, int expected)
        {
            ArrayList list = ArrayList.Create(actualArray);
            int actual = list.GetIndexOfMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, 10)]
        public void GetIndexOfMinElement_WhenMethodCalledPassed_ShouldArgumentException(int[] actualArray, int expected)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                actual.GetIndexOfMinElement();
            });
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8)]
        [TestCase(new int[] { 3, 5, -2, 28, 16 }, 28)]
        [TestCase(new int[] { 6, 4, -8, 14, 19 }, 19)]
        public void GetValueMaxElement_WhenMethodCalledPassed_ShouldReturnMaxElement(int[] actualArray, int expected)
        {
            ArrayList list = ArrayList.Create(actualArray);
            int actual = list.GetValueMaxElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1)]
        [TestCase(new int[] { 3, 5, -2, 28, 16 }, -2)]
        [TestCase(new int[] { 3, 5, 58, 21, 19 }, 3)]
        public void GetValueMinElement_WhenMethodCalledPassed_ShouldReturnMaxElement(int[] actualArray, int expected)
        {
            ArrayList list = ArrayList.Create(actualArray);
            int actual = list.GetValueMinElement();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 3, -1, 4, 1, 6, 8, 12 }, new int[] { -1, 1, 1, 3, 4, 6, 8, 12 })]
        [TestCase(new int[] { 2, 5, 8, 1, 19, 6, 7 }, new int[] { 1, 2, 5, 6, 7, 8, 19 })]
        public void GetSortAscending_WhenMethodCalledPassed_ShouldSortbyAscending(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.GetSortAscending();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { 1, 3, -1, 4, 1, 6, 8, 12 }, new int[] { 12, 8, 6, 4, 3, 1, 1, -1 })]
        [TestCase(new int[] { 5, 8, 13, 1, 6, 9, 82, 65, 14 }, new int[] { 82, 65, 14, 13, 9, 8, 6, 5, 1 })]
        public void GetDescendingSort_WhenMethodCalledPassed_ShouldSortbyAscending(int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.GetDescendingSort();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(7, new int[] { 7, 1, 2, 3 }, new int[] { 1, 2, 3 })]
        [TestCase(2, new int[] { 1, 5, 2, 3 }, new int[] { 1, 5, 3 })]
        [TestCase(7, new int[] { 1, 2, 3, 7 }, new int[] { 1, 2, 3 })]

        public void RemoveByValueOfTheFirst_WhenElementByValuePassed_ShouldRemoveValue(int value, int[] actualArray, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveByValueOfTheFirst(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 2, 1, 2, 4, 2, 6, 7, 8 }, 2, new int[] { 1, 4, 6, 7, 8 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 8, new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 1, 3, 4, 5, 6, 8, 8 }, 10, new int[] { 1, 1, 3, 4, 5, 6, 8, 8 })]
        [TestCase(new int[] { 3, 3, 3 }, 3, new int[] { })]
        public void RemoveAllByValue_WhenValue_ShouldRemoveAllValue(int[] actualArray, int value, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList expected = ArrayList.Create(expectedArray);

            actual.RemoveByValueAll(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 5, 10, 15, 30 }, new int[] { })]
        [TestCase(new int[] { 5, 1 }, new int[] { })]
        [TestCase(new int[] { 5 }, new int[] { })]
        public void AddListFromLast_WhenListPassed_ShouldArgumentException(int[] actualArray, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                ArrayList list = ArrayList.Create(arrayForList);
                actual.AddListFromLast(list);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { 1, 2, 3 }, new int[] { 1, 2, 3, 1 })]
        [TestCase(new int[] { 6, 4, 9 }, new int[] { 7, 8, 4 }, new int[] { 7, 8, 4, 6, 4, 9 })]
        public void AddListFromStart_WhenListPassed_ThenAddListInFirst(int[] actualArray, int[] arrayForList, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList list = ArrayList.Create(arrayForList);
            ArrayList expectedArrayList = ArrayList.Create(expectedArray);

            actual.AddListFromStart(list);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 5, 10, 15, 30 }, new int[] { })]
        public void AddListFromStart_WhenListPassed_ShouldArgumentException(int[] actualArray, int[] arrayForList)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                ArrayList list = ArrayList.Create(arrayForList);
                actual.AddListFromStart(list);
            });
        }

        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 4, 5, 6 }, new int[] { 1, 2, 4, 5, 6, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 4, 5, 6 }, new int[] { 4, 5, 6, 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3 }, 1, new int[] { 4, 5, 6 }, new int[] { 1, 4, 5, 6, 2, 3 })]
        public void AddListByIndex_WhenListAndIndexPassed_ShouldAddListByIndex(int[] actualArray, int index, int[] arrayForList, int[] expectedArray)
        {
            ArrayList actual = ArrayList.Create(actualArray);
            ArrayList list = ArrayList.Create(arrayForList);
            ArrayList expectedArrayList = ArrayList.Create(expectedArray);

            actual.AddListByIndex(list, index);

            Assert.AreEqual(expectedArrayList, actual);
        }

        [TestCase(new int[] { 5, 10, 15, 30 }, -1, new int[] { 10, 25, 32 })]
        public void AddListByIndex_WhenListPassed_ShouldIndexOutOfRangeException(int[] actualArray, int index, int[] arrayForList)
        {
            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                ArrayList actual = ArrayList.Create(actualArray);
                ArrayList list = ArrayList.Create(arrayForList);
                actual.AddListByIndex(list, index);
            });
        }

        [TestCase(new int[] { 2, 4, 6 }, "2 4 6")]
        [TestCase(new int[] { 5 }, "5")]
        [TestCase(new int[] { }, "")]
        public void ToString_WhenArrayListPassed_ShouldString(int[] array, string expected)
        {
            ArrayList arrayList = ArrayList.Create(array);

            string actual = arrayList.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
