﻿using System;
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

        public CircleBuilder _cbInstance;

        public override int GetHashCode()
        {
            
            int value = base.GetHashCode() + Guid.NewGuid().GetHashCode();
            return value;
        }

        public static CircleBuilder CopyCircle(CircleBuilder tempCircle)
        {
            CircleBuilder temp = new CircleBuilder(tempCircle.formGraphics, tempCircle.ThisObject, tempCircle.ObjectColor,
                tempCircle.timer);

            return temp;
        }
        
        public CircleBuilder() { }

        public CircleBuilder(Graphics fg, System.Drawing.Rectangle rec, UserColor color, Timer timerCustom) {
            //_cbInstance = new CircleBuilder(fg, rec, color, timerCustom);
            formGraphics = fg;
            ThisObject = rec;
            ObjectColor = color;
            timer = timerCustom;
            _cbInstance = this;
        }

        public System.Drawing.Rectangle _thisObject;
        public System.Drawing.Rectangle ThisObject { get { return _thisObject; } set { _thisObject = value; } } 
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
            _cbInstance = new CircleBuilder();
            _cbInstance.timer = timer;
            _cbInstance.ThisObject = ThisObject;
            _cbInstance.formGraphics = formGraphics;
            _cbInstance.ObjectColor = ObjectColor;
            return _cbInstance;
        }

        public void DrawObject()
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red, ObjectColor.Green, ObjectColor.Blue));
            formGraphics.FillEllipse(myBrush, ThisObject);
        }
        
        public virtual Delegate Animate(string mode = "random")
        {
            //switch (mode)
            //{
            //    case "random":
            //        Random random = new Random();
            //        int rand = random.Next(1, 5);
            //        break;
            //}
            //Delegate del1 = new AnimateMethod(Timer_Tick);
            return new AnimateMethod(Timer_Tick);
        }

        public delegate void AnimateMethod(object[] args);

        private bool moving = true;
        private int tick = 0;
        private Random rand = new Random(Guid.NewGuid().GetHashCode());
        private int randValue = 0;
        private void Timer_Tick(object[] args)
        {
            if (tick < rand.Next(1,200) && tick != 0)
            {
                switch (randValue)
                {
                    case 1:
                        Moving("+", "+");
                        break;
                    case 2:
                        Moving("-", "-");
                        break;
                    case 3:
                        Moving("+", "-");
                        break;
                    case 4:
                        Moving("-", "+");
                        break;
                    default:
                        break;
                }
                tick++;
            }
            else
            {
                randValue = rand.Next(1, 5);
                tick = 1;
            }
                       

        }

        private void Moving(string opX, string opY)
        {
            bool coordinates = _thisObject.X < Map.Map.Size.Width + 100 &&
                _thisObject.Y + 100 < Map.Map.Size.Height &&
                _thisObject.X > 100 &&
                _thisObject.Y > 100;

            bool coordY = _thisObject.X > 100 && _thisObject.Y > 100;
            bool coordXYWidth = _thisObject.X < Map.Map.Size.Width + 100;
            bool coordXYHeight = _thisObject.Y < Map.Map.Size.Height + 100;

            #region
            //bool statmentMaxX = _thisObject.X + 100 >= Map.Map.Size.Width;
            //bool statmentMaxY = _thisObject.Y + 100 >= Map.Map.Size.Height;
            //bool statmentMinX = _thisObject.X <= 0;

            //if (statmentMaxX && moving)
            //{
            //    _thisObject.X = Helper.Operator(opX = "-", _thisObject.X, 1);

            //}
            //else if(statmentMaxY && moving)
            //{
            //    _thisObject.Y = Helper.Operator(opY = "-", _thisObject.Y, 1);
            //}
            //else if(statmentMinX && moving)
            //{
            //    _thisObject.X = Helper.Operator(opX = "+", _thisObject.X, 1);
            //}
            //else
            //{
            //    _thisObject.Y = Helper.Operator(opX = "+", _thisObject.Y, 1);
            //}
            #endregion

            if (Helper.MovingDown)
            {
                if (coordinates && moving)
                {
                    _thisObject.X = Helper.Operator(opX, _thisObject.X, 1);
                    _thisObject.Y = Helper.Operator(opY, _thisObject.Y, 1);
                }
                else if (!coordY && moving)
                {
                    _thisObject.X = Helper.Operator(opY = "+", _thisObject.X, 1);
                    _thisObject.Y = Helper.Operator(opX = "+", _thisObject.Y, 1);
                }
                else if ((!coordXYWidth || !coordXYHeight) && moving)
                {
                    if (_thisObject.Y + 100 >= Map.Map.Size.Height)
                    {
                        _thisObject.X = Helper.Operator(opY = "-", _thisObject.X, 1);
                        _thisObject.Y = Helper.Operator(opX = "-", _thisObject.Y, 1);
                        Helper.MovingDown = false;
                    }
                    else
                    {
                        _thisObject.X = Helper.Operator(opY = "-", _thisObject.X, 1);
                        _thisObject.Y = Helper.Operator(opX = "-", _thisObject.Y, 1);
                    }
                }
                else
                {
                    if (_thisObject.X + 100 >= Map.Map.Size.Height)
                    {
                        _thisObject.X = Helper.Operator(opY = "-", _thisObject.X, 1);
                        _thisObject.Y = Helper.Operator(opX = "+", _thisObject.Y, 1);
                        Helper.MovingDown = false;
                    }
                    else
                    {
                        _thisObject.X = Helper.Operator(opY = "-", _thisObject.X, 1);
                        _thisObject.Y = Helper.Operator(opX = "+", _thisObject.Y, 1);
                    }
                }
            }
            else
            {
                if (coordinates && moving)
                {
                    if (_thisObject.Y <= 0)
                    {
                        _thisObject.Y = Helper.Operator(opY = "-", _thisObject.Y, 1);
                        Helper.MovingDown = true;
                    }
                    else
                    {
                        _thisObject.Y = Helper.Operator(opY = "-", _thisObject.Y, 1);
                    }
                }
                else
                {
                    if (_thisObject.Y <= 0)
                    {
                        _thisObject.Y = Helper.Operator(opY = "-", _thisObject.Y, 1);
                        Helper.MovingDown = true;
                    }
                    else
                    {
                        _thisObject.Y = Helper.Operator(opY = "-", _thisObject.Y, 1);
                    }
                }
            }
        }

    }
}