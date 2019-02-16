using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace patternLab.Factory.Rectangle
{
    public class RectangleBuilder: AbstractObject, IObjectBuilder
    {
        public new RectangleBuilder _cbInstance;
        public static RectangleBuilder CopyRectangle(RectangleBuilder tempRectangle)
        {
            RectangleBuilder temp = new RectangleBuilder(tempRectangle.formGraphics, tempRectangle.ThisObject, tempRectangle.ObjectColor,
                tempRectangle.timer);

            return temp;
        }

        public RectangleBuilder() { }

        public RectangleBuilder(Graphics fg, System.Drawing.Rectangle rec, UserColor color, Timer timerCustom)
        {
            formGraphics = fg;
            ThisObject = rec;
            ObjectColor = color;
            timer = timerCustom;
            _cbInstance = this;
        }

        public void DrawObject()
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red, ObjectColor.Green, ObjectColor.Blue));
            formGraphics.FillRectangle(myBrush, ThisObject);
        }
    }
}
