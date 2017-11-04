using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment2
{
    public class GenericList<T> : IGenericList<T>
    {
		private T[] _internalStorage;

	    public GenericList()
	    {
		    _internalStorage = new T[4];
	    }


		public void Add(T item) 
		{
			if (Count >= _internalStorage.Length - 1) 
			{
				Array.Resize(ref _internalStorage, _internalStorage.Length * 2);
			}
			_internalStorage[Count++] = item;
		}

		public bool Remove(T item)
        {
			int index = IndexOf(item);
			if (index == -1) return false;

	        return RemoveAt(index);
        }


		public bool RemoveAt(int index)
        {
			if (index > Count) 
			{
		        throw new IndexOutOfRangeException();
	        }
	        for (int i = index; i < Count; i++) 
			{
		        _internalStorage[i] = _internalStorage[i + 1];
	        }
	        Count--;
	        return true;
		}

        public T GetElement(int index)
        {
	        if (index <= Count) 
			{
				return _internalStorage[index];
			}
	        throw new IndexOutOfRangeException();
        }

        public int IndexOf(T item)
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

	    public int Count { get; private set; } = 0;

	    public void Clear()
        {
			for (int i = 0; i < Count; i++)
			{
				RemoveAt(i);
			}
	        Count = 0;
		}

        public bool Contains(T item)
        {
	        int index = IndexOf(item);
	        return index != -1;
        }

	    public IEnumerator<T> GetEnumerator()
	    {
		    return new GenericListEnumerator<T>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
	    {
		    return GetEnumerator();
	    }
    }
}
