using System;
using System.Collections.Generic;
using System.Text;

namespace AreaOfShapes
{
    class Triangle
    {
        public float Base { get; set; }
        public float Height { get; set; }

        public double AreaOfTriangle()
        {
            return 0.5 * Base * Height;
        }
    }
}
