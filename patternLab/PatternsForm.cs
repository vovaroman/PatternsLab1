using patternLab.Factory;
using patternLab.Factory.Circle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using patternLab.Map;
using patternLab.Factory.Rectangle;

namespace patternLab
{
    public partial class PatternsForm : Form
    {
        public Graphics gs; //= this.CreateGraphics();

        Map.Map map;
        public PatternsForm()
        {
            InitializeComponent();
            gs = this.CreateGraphics();
            map = Map.Map.GetInstance(new Point(0, 0), this.Height, this.Width, gs);
        }

        private void PatternsForm_Load(object sender, EventArgs e)
        {            
        }
        public List<Delegate> Tasks = new List<Delegate>();

        public void OnTimer(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(i++,i,i);
            try
            {
                foreach (var task in Tasks.ToList())
                {
                    object[] args = { "random" };
                    object arg = null;
                    MethodInfo methodInfo = task.GetMethodInfo();
                    ParameterInfo[] parameters = methodInfo.GetParameters();

                    if (parameters.Length == 0)
                    {
                        methodInfo.Invoke(null, null);
                    }
                    else
                    {
                        object[] par = new object[] { "string" };
                        object[] parametersArray = new object[] { par };
                        task.DynamicInvoke(parametersArray);
                        
                    }
                }

                this.Refresh();
            }
            catch(Exception ex) { }
            
        }
        public bool FormLoaded = false;

        private void PatternOnResize(object sender, EventArgs e)
        {
            Map.Map.Size.Height = this.Height;
            Map.Map.Size.Width = this.Width;
        }

        private void PatternsForm_Paint(object sender, PaintEventArgs e)
        {
            gs = e.Graphics;
            Map.Map.Graphics = e.Graphics;
            
            map.DrawMap();

            foreach(IObjectBuilder bl in map.MapObjects)
            {
                if(bl is CircleBuilder)
                {
                    bl.formGraphics = e.Graphics;
                    (bl as CircleBuilder).DrawObject();
                }
                else
                {
                    bl.formGraphics = e.Graphics;
                    (bl as RectangleBuilder).DrawObject();
                }
            }

            if (!FormLoaded)
            {
                IUnitFactory factory = new CircleFactory();                
                for (int i = 0; i < 50; i++)
                {
                    if (i > 25)
                        factory = new RectangleFactory();
                    if (factory is CircleFactory)
                    {
                        IObjectBuilder cl = factory.ObjectBuilder as CircleBuilder;
                        CircleBuilder temp = CircleBuilder.CopyCircle(cl as CircleBuilder);
                        (cl as CircleBuilder).Draw(cl, map, Tasks);
                        temp.Draw(temp, map, Tasks);
                    }
                    else
                    {
                        IObjectBuilder cl = factory.ObjectBuilder as Factory.Rectangle.RectangleBuilder;
                        (cl as Factory.Rectangle.RectangleBuilder).Draw(cl, map, Tasks);
                    }
                    FormLoaded = true;
                }
                foreach(IObjectBuilder cl in map.MapObjects)
                {
                    if (cl is CircleBuilder)
                    {
                        (cl as CircleBuilder)._thisObject.X = new Random(cl.GetHashCode()).Next(1, 1000);
                        (cl as CircleBuilder)._thisObject.Y = new Random(cl.GetHashCode()).Next(1, 1000);
                    }
                    else
                    {
                        (cl as RectangleBuilder)._thisObject.X = new Random(cl.GetHashCode()).Next(1, 1000);
                        (cl as RectangleBuilder)._thisObject.Y = new Random(cl.GetHashCode()).Next(1, 1000);
                    }
                }

            }

        }

    }
}
