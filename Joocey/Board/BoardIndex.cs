using System;

using Core;

namespace Board
{
    public class BoardIndex
    {
        private int _file;
        private int _rank;

        public BoardIndex(BoardIndex toCopy)
        {
            _file = toCopy.File;
            _rank = toCopy.Rank;
        }
        public BoardIndex(int file, int rank) { _file = file; _rank = rank; }
        public BoardIndex Get()
        {
            return new BoardIndex(this);
        }

        public int File
        {
            get
            {
                return _file;
            }
        }
        public int Rank
        {
            get
            {
                return _rank;
            }
        }
        public SQ Square
        {
            get
            {
                var x = _file - 1;
                var y = Math.Abs(_rank - 8);
                var v = (x + (y * 8));
                if (v >= 0 && v < 64)
                {
                    return (SQ)v;
                }
                else
                {
                    return SQ.xx;
                }
            }
        }
        public BoardIndex Add(Vector v)
        {
            if (_file + v.F > 0 && _file + v.F < 9 && _rank + v.R > 0 && _rank + v.R < 9)
            {
                _file += v.F;
                _rank += v.R;
            }
            else
            {
                _file = 9;
                _rank = 1;
            }
            return this;
        }
    }
}
