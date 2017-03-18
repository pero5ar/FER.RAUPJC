using System;

namespace zadatak1
{
    public class IntegerList : IIntegerList
    {
        private int _internalMaxSize;
        private int[] _internalStorage;
        private int _internalSize;
        public int Count
        {
            get
            {
                return _internalSize;
            }
        }

        public IntegerList(int initialSize)
        {
            _internalMaxSize = initialSize;
            _internalSize = 0;
            _internalStorage = new int[_internalMaxSize];
        }

        public IntegerList() : this(4)
        {
        }

        public void Add(int item)
        {
            if(_internalSize >= _internalMaxSize)
            {
                _internalMaxSize *= 2;
                Array.Resize(ref _internalStorage, _internalMaxSize);
            }
            _internalStorage[_internalSize] = item;
            _internalSize++;
        }

        public void Clear()
        {
            _internalSize = 0;   // no need to erase data, just overwrite it later
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < _internalSize; i++)
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
            if (index < _internalSize)
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
            for (int i = 0; i < _internalSize; i++)
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
            if(index == -1)
            {
                return false;
            }
            return RemoveAt(index);
        }

        public bool RemoveAt(int index)
        {
            if (index >= _internalSize)
            {
                return false;
            }
            _internalSize--;
            for (int i = index; i < _internalSize; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            return true;
        }
    }
}
