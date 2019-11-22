using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    public class Vector
    {
        public Vector() { }
        public Vector(int file, int rank)
        {
            F = file;
            R = rank;
        }
        public int F { get; set; }
        public int R { get; set; }
    }

}
