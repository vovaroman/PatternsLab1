using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patternLab.Factory.Rectangle;


namespace patternLab.Factory
{
    public class RectangleFactory : IUnitFactory
    {
        public string Name { get; set; }
        public IObjectBuilder ObjectBuilder {
            get
            {
                return new RectangleBuilder();
            }
            set
            {

            }
        }

    }
}
