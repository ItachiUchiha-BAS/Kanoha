using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3_var7
{
    class Circle : Figure
    {
        public override double GetArea()
        {
            return Area = (Width + Frame) * (Height + Frame) * pi;
        }
    }
}
