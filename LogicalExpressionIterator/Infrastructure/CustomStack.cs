using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalExpressionIterator.Infrastructure
{
    public class CustomStack<T>
    {
        private CustomList<T> _items;

        public int Count => _items.Count;

        public CustomStack()
        {
            _items = new CustomList<T>();
        }

        public void Push(T item)
        {
            _items.Add(item);
        }

        public T Pop()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop an empty stack.");
            }

            T item = _items[_items.Count - 1];
            _items.RemoveAt(_items.Count - 1);
            return item;
        }

        public T Peek()
        {
            if (_items.Count == 0)
            {
                throw new InvalidOperationException("Cannot peek at an empty stack.");
            }

            return _items[_items.Count - 1];
        }

        public bool IsEmpty
        {
            get { return _items.Count == 0; }
        }
    }
}
