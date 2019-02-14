using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternLab
{
    public class Helper
    {
        public static bool MovingDown = true;

        public static int Operator(string op, int a, int b)
        {
            switch(op)
            {
                case "+":
                    return a + b;
                    break;
                case "-":
                    return a - b;
                    break;
                default:
                    return a + b;
            }
        }


    }
}
