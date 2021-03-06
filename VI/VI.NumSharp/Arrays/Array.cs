﻿namespace VI.NumSharp.Arrays
{
    public class Array<T>
        where T : class
    {
        private readonly T[] _view;

        public Array(T[] data)
        {
            _view = data;
        }

        public Array(int size)
        {
            _view = new T[size];
        }

        public int Length => _view.Length;

        public T this[int x]
        {
            get
            {
                if (x < 0) x = Length + x;
                return _view[x];
            }
            set
            {
                if (x < 0) x = Length + x;

                _view[x] = value;
            }
        }

        public T[] AsArray => _view;

        public T First => _view[0];
        public T Last => _view[_view.Length - 1];

        public Array<T> Clone()
        {
            return new Array<T>((T[])_view.Clone());
        }

        public override string ToString()
        {
            var str = "[";
            for (var i = 0; i < _view.Length; i++) str += $"{_view[i]},\n ";
            str = str.Remove(str.Length - 2);
            str += "]";
            return str;
        }
    }
}