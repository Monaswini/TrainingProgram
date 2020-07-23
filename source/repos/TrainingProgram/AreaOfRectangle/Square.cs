using System;
using System.Collections.Generic;
using System.Text;

namespace AreaOfShapes
{
    public class Square
    {
        public float Side { get; set; }

        public double AreaOfSquare()
        {
            return Side * Side;
        }
    }
}
