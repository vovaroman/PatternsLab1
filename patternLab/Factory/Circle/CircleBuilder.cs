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
    class CircleBuilder : IObjectBuilder
    {

        public CircleBuilder(Graphics fg, System.Drawing.Rectangle rec, UserColor color, Timer timerCustom) { formGraphics = fg; ThisObject = rec; ObjectColor = color; timer = timerCustom;  }

        private static System.Drawing.Rectangle _thisObject;
        public static System.Drawing.Rectangle ThisObject { get { return _thisObject; } set { _thisObject = value; } } 
        public Graphics formGraphics {get;set;}

        public Timer timer { get; set; }
        public UserColor ObjectColor { get; set; }
        public virtual void ChangeColor()
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red, ObjectColor.Green, ObjectColor.Blue));
            formGraphics.FillEllipse(myBrush, ThisObject);
        }
        public virtual IObjectBuilder BuildObject()
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red,ObjectColor.Green,ObjectColor.Blue));
            formGraphics.FillEllipse(myBrush, ThisObject);
            return this;
        }

        public void DrawObject()
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red, ObjectColor.Green, ObjectColor.Blue));
            formGraphics.FillEllipse(myBrush, ThisObject);
        }


        public virtual Delegate Animate(string mode = "random")
        {
            switch (mode)
            {
                case "random":
                    Random random = new Random();
                    break;
            }
            //Delegate del1 = new AnimateMethod(Timer_Tick);
            return new AnimateMethod(Timer_Tick);
        }

        public delegate void AnimateMethod(object[] args);

        private bool moving = true;
        private void Timer_Tick(object[] args)
        {
            bool coordinates = _thisObject.X < Map.Map.Size.Width + 100 && _thisObject.Y + 100 < Map.Map.Size.Height;
            if (coordinates && moving)
            {               
                _thisObject.X += 1;
                _thisObject.Y += 1;
            }
            else if(!coordinates)
            {
                moving = false;
                _thisObject.X -= 1;
                _thisObject.Y -= 1;

            }
            

        }
    }
}
