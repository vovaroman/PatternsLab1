using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace patternLab.Factory
{
    public abstract class AbstractObject : IObjectBuilder
    {
        public AbstractObject _cbInstance;

        public override int GetHashCode()
        {

            int value = base.GetHashCode() + Guid.NewGuid().GetHashCode();
            return value;
        }

        public System.Drawing.Rectangle _thisObject;
        public System.Drawing.Rectangle ThisObject { get { return _thisObject; } set { _thisObject = value; } }
        public Graphics formGraphics { get; set; }

        public Timer timer { get; set; }
        public UserColor ObjectColor { get; set; }
        public virtual void ChangeColor()
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red, ObjectColor.Green, ObjectColor.Blue));
            formGraphics.FillEllipse(myBrush, ThisObject);
        }
        public virtual IObjectBuilder BuildObject()
        {
            SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red, ObjectColor.Green, ObjectColor.Blue));
            formGraphics.FillEllipse(myBrush, ThisObject);
            _cbInstance.timer = timer;
            _cbInstance.ThisObject = ThisObject;
            _cbInstance.formGraphics = formGraphics;
            _cbInstance.ObjectColor = ObjectColor;
            return _cbInstance;
        }

        public void Draw(IObjectBuilder cl, Map.Map map, List<Delegate> Tasks)
        {
            ThisObject = new System.Drawing.Rectangle(new Random(cl.GetHashCode()).Next(1, 100),
                new Random(cl.GetHashCode()).Next(1, 100), 50, 50);
            cl.ObjectColor = new UserColor(new Random(cl.GetHashCode()).Next(0, 255),
                new Random(cl.GetHashCode()).Next(0, 255), new Random(cl.GetHashCode()).Next(0, 255));
            map.MapObjects.Add(cl);
            if (cl is Circle.CircleBuilder)
                Tasks.Add((cl as Circle.CircleBuilder).Animate());
            else if(cl is Rectangle.RectangleBuilder)
                Tasks.Add((cl as Rectangle.RectangleBuilder).Animate());
        }

        //public void DrawObject()
        //{
        //    SolidBrush myBrush = new SolidBrush(System.Drawing.Color.FromArgb(ObjectColor.Red, ObjectColor.Green, ObjectColor.Blue));
        //    formGraphics.FillEllipse(myBrush, ThisObject);
        //}

        

        public virtual Delegate Animate(string mode = "random")
        {
            return new AnimateMethod(Timer_Tick);
        }

        public delegate void AnimateMethod(object[] args);

        public bool moving = true;
        public int tick = 0;
        public Random rand = new Random(Guid.NewGuid().GetHashCode());
        public int randValue = 0;
        public void Timer_Tick(object[] args)
        {
            if (tick < rand.Next(1, 200) && tick != 0)
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

        public void Moving(string opX, string opY)
        {
            bool coordinates = _thisObject.X < Map.Map.Size.Width + 100 &&
                _thisObject.Y + 100 < Map.Map.Size.Height &&
                _thisObject.X > 100 &&
                _thisObject.Y > 100;

            bool coordY = _thisObject.X > 100 && _thisObject.Y > 100;
            bool coordXYWidth = _thisObject.X < Map.Map.Size.Width + 100;
            bool coordXYHeight = _thisObject.Y < Map.Map.Size.Height + 100;


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
