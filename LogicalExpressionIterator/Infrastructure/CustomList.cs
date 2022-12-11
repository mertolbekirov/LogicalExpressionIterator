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
        private T[] _items;
        private int _count;

        public CustomList()
        {
            _items = new T[10];
            _count = 0;
        }

        public void Add(T item)
        {
            if (_count == _items.Length)
            {
                T[] newItems = new T[_items.Length * 2];
                Array.Copy(_items, newItems, _items.Length);
                _items = newItems;
            }

            _items[_count] = item;
            _count++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }

                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }

                _items[index] = value;
            }
        }

        public int Count
        {
            get { return _count; }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _count--;
        }

        public T[] ToArray()
        {
            T[] array = new T[_count];
            Array.Copy(_items, array, _count);
            return array;
        }
    }
}