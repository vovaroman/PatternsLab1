using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternLab.Factory.Rectangle
{
    public class RectangleBuilder:IObjectBuilder
    {
        public UserColor ObjectColor { get; set; }

        public Graphics formGraphics { get; set; }

        public void ChangeColor() { }
        public IObjectBuilder BuildObject() { return this; }
    }
}
