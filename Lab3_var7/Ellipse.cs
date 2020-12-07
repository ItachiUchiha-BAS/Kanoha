using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3_var7
{
    class Ellipse : Figure
    {
        public override double GetArea()
        {
            return Area = (Height + Frame) * (Width + Frame) * pi;
        }
    }
}
