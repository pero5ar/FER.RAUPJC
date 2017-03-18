using System;

namespace Task2
{
    public class GenericList<X> : IGenericList<X>
    {
        private int _internalMaxSize;
        private X[] _internalStorage;
        public int Count { get; private set; }

        public GenericList(int initialSize)
        {
            _internalMaxSize = initialSize;
            Count = 0;
            _internalStorage = new X[_internalMaxSize];
        }

        public GenericList() : this(4)
        {
        }

        public void Add(X item)
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

        public bool Contains(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public X GetElement(int index)
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

        public int IndexOf(X item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_internalStorage[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool Remove(X item)
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
