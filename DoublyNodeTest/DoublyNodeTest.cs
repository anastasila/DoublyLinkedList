using NUnit.Framework;
using DoublyList;

namespace DoublyNodeTest
{
    public class DoublyNodeTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]

        [TestCase(new int[] { 1, 2, 3, 0 }, 3, new int[] { 3, 1, 2, 3, 0 })]
        [TestCase(new int[] { }, 0, new int[] { })]
        [TestCase(new int[] { 1 }, 1, new int[] { 1, 1 })]
        [TestCase(new int[] { 200, 0, 0, 0, 0 }, 1, new int[] { 1, 200, 0, 0, 0, 0 })]
        public void AddFirstTest(int[] _array, int val, int[] expected)
        {
            try
            {
                DoublyLinkedList dl = new DoublyLinkedList(_array);
                dl.AddFirst(val);
                int[] actual = dl.ToArray();

                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.NullHead());
            }
        }

        [TestCase(new int[] { 1, 2, 3, 0 }, new int[] { 98, 99, 100 }, new int[] { 98, 99, 100, 1, 2, 3, 0 })]
        [TestCase(new int[] { 1 }, new int[] { 98, 99, 100 }, new int[] { 98, 99, 100, 1 })]
        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, new int[] { 98, 99, 100 }, new int[] { 98, 99, 100, 200, 400, 600, 800, 1000 })]
        public void AddFirstArrayTest(int[] _array, int[] vals, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.AddFirst(vals);
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 5, new int[] { 200, 400, 600, 800, 1000, 5 })]
        [TestCase(new int[] { 200, 400, 600, 800 }, 4, new int[] { 200, 400, 600, 800, 4 })]
        [TestCase(new int[] { 1 }, 52, new int[] { 1, 52 })]
        public void AddLastTest(int[] _array, int val, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.AddLast(val);
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, new int[] { 98, 99, 100 }, new int[] { 200, 400, 600, 800, 1000, 98, 99, 100 })]
        [TestCase(new int[] { 200, 400, 600, 800 }, new int[] { 98, 99, 100 }, new int[] { 200, 400, 600, 800, 98, 99, 100 })]
        [TestCase(new int[] { 1 }, new int[] { 98, 99, 100 }, new int[] { 1, 98, 99, 100 })]
        public void AddLastArrayTest(int[] _array, int[] vals, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.AddLast(vals);
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 2, 5, new int[] { 200, 400, 5, 600, 800, 1000 })]
        [TestCase(new int[] { 200, 400, 600, 800 }, 1, 4, new int[] { 200, 4, 400, 600, 800 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 9, 4, new int[] { 200, 400, 600, 800, 0, 4 })]
        [TestCase(new int[] { 1 }, 0, 52, new int[] { 52, 1 })]
        public void AddAtTest(int[] _array, int idx, int val, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.AddAt(idx, val);
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 2, new int[] { 98, 99, 100 }, new int[] { 200, 400, 98, 99, 100, 600, 800, 1000 })]
        [TestCase(new int[] { 200, 400, 600, 800 }, 1, new int[] { 98, 99, 100 }, new int[] { 200, 98, 99, 100, 400, 600, 800 })]
        [TestCase(new int[] { 200, 400, 600, 800 }, 9, new int[] { 98, 99, 100 }, new int[] { 200, 400, 600, 800, 98, 99, 100 })]
        [TestCase(new int[] { 1 }, -10, new int[] { 98, 99, 100 }, new int[] { 1 })]
        [TestCase(new int[] { 1 }, 0, new int[] { 98, 99, 100 }, new int[] { 98, 99, 100, 1 })]
        [TestCase(new int[] { 200 }, 1, new int[] { 98, 99, 100 }, new int[] { 200, 98, 99, 100 })]
        public void AddAtArrayTest(int[] _array, int idx, int[] vals, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            try
            {
                dl.AddAt(idx, vals);
                int[] actual = dl.ToArray();
                Assert.AreEqual(expected, actual);
            }
            catch
            {
                Assert.Throws<System.Exception>(() => Errors.IndexIsIncorrect());
            }
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 5)]
        [TestCase(new int[] { 200, 400, 600, 800 }, 4)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetSizeTest(int[] _array, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.GetSize();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 2, 5, new int[] { 200, 400, 5, 800, 1000 })]
        [TestCase(new int[] { 200, 400, 600, 800, 0 }, 1, 4, new int[] { 200, 4, 600, 800, 0 })]
        [TestCase(new int[] { 200, 400, 600, 800 }, 9, 4, new int[] { 200, 400, 600, 800, 4 })]
        [TestCase(new int[] { 200, 400, 600, 800 }, 3, -504, new int[] { 200, 400, 600, -504 })]
        [TestCase(new int[] { 1 }, 0, 52, new int[] { 52 })]
        public void SetTest(int[] _array, int idx, int val, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.Set(idx, val);
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, new int[] { 400, 600, 800, 1000 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 2, 3 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveFirstTest(int[] _array, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.RemoveFirst();
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, new int[] { 200, 400, 600, 800 })]
        [TestCase(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [TestCase(new int[] { 1 }, new int[] { })]
        public void RemoveLastTest(int[] _array, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.RemoveLast();
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 2, new int[] { 200, 400, 800, 1000 })]
        [TestCase(new int[] { 1, 2, 3 }, 2, new int[] { 1, 2 })]
        [TestCase(new int[] { 1, 2, 3 }, 0, new int[] { 2, 3 })]
        [TestCase(new int[] { 1 }, 0, new int[] { })]
        public void RemoveAtTest(int[] _array, int idx, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.RemoveAt(idx);
            int[] actual = dl.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 600, new int[] { 200, 400, 800, 1000 })]
        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 12, new int[] { 200, 400, 600, 800, 1000 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -4, new int[] { -8, -7, -98, -125, -987, -8 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -8, new int[] { -4, -7, -4, -98, -125, -4, -987 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 11, new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 })]
        public void RemoveAllValueTest(int[] _array, int val, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.RemoveAll(val);
            int[] actual = dl.ToArray();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -4, true)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -8, true)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987 }, -987, true)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 11, false)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 0, false)]
        public void ContainsTest(int[] _array, int val, bool expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            bool actual = dl.Contains(val);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -4, 0)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -8, 8)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987 }, -987, 7)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 11, -1)]
        public void IndexOfTest(int[] _array, int val, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.IndexOf(val);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000, 0, 0, 0 }, 200)]
        [TestCase(new int[] { 1, 2, 3, 0 }, 1)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetFirstTest(int[] _array, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.GetFirst();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 1000)]
        [TestCase(new int[] { 1, 2, 3 }, 3)]
        [TestCase(new int[] { 1 }, 1)]
        public void GetLastTest(int[] _array, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.GetLast();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, 3, 800)]
        [TestCase(new int[] { 1, 2, 3, 0 }, 1, 2)]
        [TestCase(new int[] { 1 }, 0, 1)]
        public void GetTest(int[] _array, int idx, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.Get(idx);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 600, 800, 1000 }, new int[] { 1000, 800, 600, 400, 200 })]
        [TestCase(new int[] { 1, 4, 3, 0 }, new int[] { 0, 3, 4, 1 })]
        [TestCase(new int[] { 1 }, new int[] { 1 })]
        public void ReverseTest(int[] _array, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.Reverse();
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 1624, 800, 1000 }, 2)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, 0)]
        [TestCase(new int[] { -12, -8, -7, -4, -98, -125, -4, -987, -8 }, 3)]
        public void IndexOfMaxTest(int[] _array, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.IndexOfMax();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 1624, 800, 1000 }, 0)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8, 0 }, 7)]
        [TestCase(new int[] { -12, -8, -7, -4, -98, -125, -4, -87, -8359 }, 8)]
        public void IndexOfMinTest(int[] _array, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.IndexOfMin();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 1624, 800, 1000 }, 1624)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, -4)]
        [TestCase(new int[] { -12, -8, -7, -4, -98, -125, -4, -987, -8 }, -4)]
        public void MaxTest(int[] _array, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.Max();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 200, 400, 1624, 800, 1000 }, 200)]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8, 0 }, -987)]
        [TestCase(new int[] { -12, -8, -7, -4, -98, -125, -4, -87, -8359 }, -8359)]
        public void MinTest(int[] _array, int expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            int actual = dl.Min();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 600, 1000, 200, 800, 400 }, new int[] { 200, 400, 600, 800, 1000 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, new int[] { -987, -125, -98, -8, -8, -7, -4, -4, -4 })]
        [TestCase(new int[] { -4, -8, -7, 0, -98, 125, -4, -987, -8 }, new int[] { -987, -98, -8, -8, -7, -4, -4, 0, 125 })]
        [TestCase(new int[] { 600 }, new int[] { 600 })]
        public void SortTest(int[] _array, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.Sort();
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 600, 1000, 200, 800, 400 }, new int[] { 1000, 800, 600, 400, 200 })]
        [TestCase(new int[] { -4, -8, -7, -4, -98, -125, -4, -987, -8 }, new int[] { -4, -4, -4, -7, -8, -8, -98, -125, -987 })]
        [TestCase(new int[] { -4, -8, -7, 0, -98, 125, -4, -987, -8 }, new int[] { 125, 0, -4, -4, -7, -8, -8, -98, -987 })]
        [TestCase(new int[] { 600 }, new int[] { 600 })]
        public void SortDescTest(int[] _array, int[] expected)
        {
            DoublyLinkedList dl = new DoublyLinkedList(_array);
            dl.SortDesc();
            int[] actual = dl.ToArray();

            Assert.AreEqual(expected, actual);
        }
    }
}