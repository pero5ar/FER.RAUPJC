using System;
using System.Collections;
using System.Collections.Generic;

namespace zadatak4
{
    public class GenericList<X> : IGenericList<X>
    {
        private int _internalMaxSize;
        private X[] _internalStorage;
        private int _iternalSize;
        public int Count
        {
            get
            {
                return _iternalSize;
            }
        }

        public GenericList(int initialSize)
        {
            _internalMaxSize = initialSize;
            _iternalSize = 0;
            _internalStorage = new X[_internalMaxSize];
        }

        public GenericList() : this(4)
        {
        }

        public void Add(X item)
        {
            if (_iternalSize >= _internalMaxSize)
            {
                _internalMaxSize *= 2;
                Array.Resize(ref _internalStorage, _internalMaxSize);
            }
            _internalStorage[_iternalSize] = item;
            _iternalSize++;
        }

        public void Clear()
        {
            _iternalSize = 0;   // no need to erase data, just overwrite it later
        }

        public bool Contains(X item)
        {
            for (int i = 0; i < _iternalSize; i++)
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
            if (index < _iternalSize)
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
            for (int i = 0; i < _iternalSize; i++)
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
            if (index >= _iternalSize)
            {
                return false;
            }
            _iternalSize--;
            for (int i = index; i < _iternalSize; i++)
            {
                _internalStorage[i] = _internalStorage[i + 1];
            }
            return true;
        }

        public IEnumerator<X> GetEnumerator()
        {
            return new GenericListEnumerator<X>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class GenericListEnumerator<T> : IEnumerator<T>
    {
        private IGenericList<T> _collection;
        private int _index;
        private int _size;

        public GenericListEnumerator(IGenericList<T> collection)
        {
            _collection = collection;
            _size = collection.Count;
            _index = 0;
        }
        public bool MoveNext()
        {
            // Zove se prije svake iteracije.
            // Vratite true ako treba ući u iteraciju, false ako ne
            // Hint: čuvajte neko globalno stanje po kojem pratite gdje se
            // nalazimo u kolekciji
            return (_index < _size);
        }
        public T Current
        {
            get
            {
                // Zove se na svakom ulasku u iteraciju
                // Hint: Koristite stanje postavljeno u MoveNext() dijelu
                // kako bi odredili što se zapravo vraća u ovom koraku
                if (MoveNext())
                {
                    return _collection.GetElement(_index++);
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public void Dispose()
        {
            // Ignorirajte
        }
        public void Reset()
        {
            // Ignorirajte
        }
    }
}
