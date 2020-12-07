using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3_var7
{
    class FigureCompare : IComparer<Figure>
    {
        public int Compare(Figure first, Figure second)
        {
            if (first.Area > second.Area)
            {
                return 1;
            }
            else if (first.Area < second.Area)
            {
                return -1;
            }
            else
            {
                if (first.Frame > second.Frame)
                {
                    return 1;
                }
                else if (first.Frame < second.Frame)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}