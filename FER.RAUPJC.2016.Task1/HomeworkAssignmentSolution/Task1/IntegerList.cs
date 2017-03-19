using System;

namespace Task1
{
    class IntegerList : IIntegerList
    {
        private int _internalMaxSize;
        private int[] _internalStorage;
        public int Count { get; private set; }

        public IntegerList(int initialSize)
        {
            _internalMaxSize = initialSize;
            Count = 0;
            _internalStorage = new int[_internalMaxSize];
        }

        public IntegerList() : this(4)
        {
        }

        public void Add(int item)
        {
            if (Count >= _internalMaxSize)
            {
                _internalMaxSize *= 2;
                Array.Resize(ref _internalStorage, _internalMaxSize);
            }
            _internalStorage[Count] = item;
            Count++;
        }

        public void Clear()
        {
            Count = 0;   // no need to erase data, just overwrite it later
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return true;
                }
            }
            return false;
        }

        public int GetElement(int index)
        {
            if (index < Count)
            {
                return _internalStorage[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int IndexOf(int item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i] == item)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(int item)
        {
            int index = IndexOf(item);
            if (index == -1)
            {
                return false;
            }
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count)
            {
                return false;
            }
            Count--;
            for (int i = index; i < Count; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            return true;
        }
    }
}
