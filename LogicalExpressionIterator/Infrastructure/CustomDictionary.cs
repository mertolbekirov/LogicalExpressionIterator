using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalExpressionIterator.Infrastructure
{
    public class CustomDictionary<TKey, TValue>
    {
        private class Entry
        {
            public TKey Key { get; set; }
            public TValue Value { get; set; }
        }

        private Entry[] _entries;
        private int _count;

        public CustomDictionary()
        {
            _entries = new Entry[10];
            _count = 0;
        }

        public void Add(TKey key, TValue value)
        {
            // Check if key already exists
            int index = FindKeyIndex(key);
            if (index >= 0)
            {
                throw new ArgumentException("Key already exists in dictionary.");
            }

            // Check if array needs to be resized
            if (_count == _entries.Length)
            {
                Resize();
            }

            // Add new entry to array
            _entries[_count] = new Entry { Key = key, Value = value };
            _count++;
        }

        public TValue Get(TKey key)
        {
            int index = FindKeyIndex(key);
            if (index >= 0)
            {
                return _entries[index].Value;
            }

            throw new ArgumentException("Key does not exist in dictionary.");
        }

        private int FindKeyIndex(TKey key)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_entries[i].Key.Equals(key))
                {
                    return i;
                }
            }

            return -1;
        }

        private void Resize()
        {
            // Create a new array with double the size
            Entry[] newEntries = new Entry[_entries.Length * 2];

            // Copy entries to new array
            for (int i = 0; i < _entries.Length; i++)
            {
                newEntries[i] = _entries[i];
            }

            // Set new array as the entries array
            _entries = newEntries;
        }
    }

}
