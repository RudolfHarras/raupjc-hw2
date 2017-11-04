using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
	class GenericListEnumerator<T> : IEnumerator<T> {
		private readonly GenericList<T> _genericList;
		private T _current;

		private int _position = -1;

		public GenericListEnumerator(GenericList<T> genericList) {
			this._genericList = genericList;
			_current = genericList.GetElement(0);
		}
		
		public T Current => _genericList.GetElement(_position);


		object IEnumerator.Current => Current;

		public void Dispose() 
		{
		}

		public bool MoveNext() 
		{
			_position++;
			return _position < _genericList.Count;
		}

		public void Reset()
		{
			_position = -1;
		}
	}
}
