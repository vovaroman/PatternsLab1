using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using patternLab.Map;

namespace patternLab.Factory.Circle
{
    class CircleBuilder : AbstractObject, IObjectBuilder
    {

        public new CircleBuilder _cbInstance;
        public static CircleBuilder CopyCircle(CircleBuilder tempCircle)
        {
            CircleBuilder temp = new CircleBuilder(tempCircle.formGraphics, tempCircle.ThisObject, tempCircle.ObjectColor,
                tempCircle.timer);

            return temp;
        }
        
        public CircleBuilder() { }

        public CircleBuilder(Graphics fg, System.Drawing.Rectangle rec, UserColor color, Timer timerCustom) {
            formGraphics = fg;
            ThisObject = rec;
            ObjectColor = color;
            timer = timerCustom;
            _cbInstance = this;
        }
        public static void ColorizeCircles(CircleBuilder circle)
        {
            circle._cbInstance.ChangeColor();
        }

        public void DrawObject()
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red, ObjectColor.Green, ObjectColor.Blue));
            formGraphics.FillEllipse(myBrush, ThisObject);
        }
        
        

    }
}
