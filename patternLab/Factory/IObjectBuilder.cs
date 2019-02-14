using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternLab.Factory
{
    public interface IObjectBuilder
    {       
        Graphics formGraphics { get; set; }
        IObjectBuilder BuildObject();
        UserColor ObjectColor { get; set; }

        void ChangeColor();


    }
}
