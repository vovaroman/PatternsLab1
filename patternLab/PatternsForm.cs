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
            //map = Map.Map.GetInstance(new Point(0,0), this.Height, this.Width, gs);
            map = Map.Map.GetInstance(new Point(0, 0), this.Height, this.Width, gs);
            // gameField = new Rectangle(new Point(0, 0), new Size(this.Width, this.Height));
        }

        private void PatternsForm_Load(object sender, EventArgs e)
        {            
            //this.BackColor = Color.FromArgb(223, 223, 223);
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
                    //object classInstance = Activator.CreateInstance(typeof(), null);

                    if (parameters.Length == 0)
                    {
                        methodInfo.Invoke(null, null);
                    }
                    else
                    {
                        object[] par = new object[] { "string" };
                        object[] parametersArray = new object[] { par };

                        // The invoke does NOT work;
                        // it throws "Object does not match target type"             
                        //methodInfo.Invoke(null, parameters);
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
            //this.AutoScaleDimensions = new System.Drawing.Size(this.Width, this.Height);
            //this.ClientSize = new Size(this.Height, this.Width);
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
            }

            //gs.FillRectangle(new SolidBrush(Color.BlueViolet), gameField);

            if (!FormLoaded)
            {
                
                for (int i = 0; i < 100; i++)
                {

                    CircleFactory circleFactory = new CircleFactory();
                    CircleBuilder cl = new CircleBuilder(); // circleFactory.ObjectBuilder.BuildObject() as CircleBuilder;
                    cl.timer = this.Timer;
                    cl.formGraphics = gs;
                    cl.ThisObject = new Rectangle(new Random(cl.GetHashCode()).Next(1, 100),                        
                        new Random(cl.GetHashCode()).Next(1,100), 50, 50);
                    cl.ObjectColor = new UserColor(new Random(cl.GetHashCode()).Next(0, 255),
                        new Random(cl.GetHashCode()).Next(0, 255), new Random(cl.GetHashCode()).Next(0, 255));
                    //= new CircleBuilder(gs, new Rectangle(1, 1, 50, 50), new UserColor(24, 255, 24), this.Timer);

                    //CircleBuilder circle = circleFactory.ObjectBuilder.BuildObject() as CircleBuilder;
                    map.MapObjects.Add(cl);
                    Tasks.Add(cl.Animate());

                    FormLoaded = true;
                }
                foreach(CircleBuilder cl in map.MapObjects)
                {
                    cl._thisObject.X = new Random(cl.GetHashCode()).Next(1, 1000);
                    cl._thisObject.Y = new Random(cl.GetHashCode()).Next(1, 1000);
                }

            }
            //}

        }

    }
}
