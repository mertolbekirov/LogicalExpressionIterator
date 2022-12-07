using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalExpressionIterator.Infrastructure
{
    public class CustomList<T>
    {
        private T[] data;
        private int count = 0;
        private int capacity;

        public CustomList(int initialCapacity = 8)
        {
            if (initialCapacity < 1) initialCapacity = 1;
            this.capacity = initialCapacity;
            data = new T[initialCapacity];
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public T GetAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            return data[index];
        }

        public void SetAt(T newElement, int index)
        {
            ThrowIfIndexOutOfRange(index);
            data[index] = newElement;
        }

        public void InsertAt(T newElement, int index)
        {
            ThrowIfIndexOutOfRange(index);
            if (count == capacity)
            {
                Recount();
            }

            for (int i = count; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            data[index] = newElement;
            count++;
        }

        public void DeleteAt(int index)
        {
            ThrowIfIndexOutOfRange(index);
            for (int i = index; i < count - 1; i++)
            {
                data[i] = data[i + 1];
            }

            data[count - 1] = default(T);
            count--;
        }

        public void Add(T newElement)
        {
            if (count == capacity)
            {
                Recount();
            }

            data[count] = newElement;
            count++;
        }

        public bool Contains(T value)
        {
            for (int i = 0; i < count; i++)
            {
                T currentValue = data[i];
                if (currentValue.Equals(value))
                {
                    return true;
                }
            }
            return false;
        }

        public void Clear()
        {
            data = new T[capacity];
            count = 0;
        }

        private void Recount()
        {
            T[] recountd = new T[capacity * 2];
            for (int i = 0; i < capacity; i++)
            {
                recountd[i] = data[i];
            }
            data = recountd;
            capacity = capacity * 2;
        }

        private void ThrowIfIndexOutOfRange(int index)
        {
            if (index > count - 1 || index < 0)
            {
                throw new ArgumentOutOfRangeException(string.Format("The current count of the array is {0}", count));
            }
        }
    }
}