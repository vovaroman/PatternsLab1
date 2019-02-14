using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patternLab.Factory;
using System.Drawing;

namespace patternLab.Map
{
    public class Map
    {
        private static Map MapObject;
        public static Graphics Graphics;
        private static Point PointStart;

        public static Size Size;
        private Map(Point p,int height, int width)
        {
            Size = new Size(width, height);
            PointStart = p;
            GameField = new Rectangle(PointStart, Size);
            Graphics.FillRectangle(new SolidBrush(Color.OldLace), GameField);
        }

        public void DrawMap()
        {
            GameField = new Rectangle(PointStart, Size);
            Graphics.FillRectangle(new SolidBrush(Color.OldLace), GameField);
        }

        public static Map GetInstance(Point p, int height, int width, Graphics gs)
        {
            if (MapObject == null)
            {
                Graphics = gs;
                MapObject = new Map(p, height, width);
                return MapObject;
            }
            else
                return MapObject;
        }

        public List<IObjectBuilder> MapObjects = new List<IObjectBuilder>();

        public Rectangle GameField;


    }
}
