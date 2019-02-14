using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using patternLab.Factory.Circle;


namespace patternLab.Factory
{
    public class CircleFactory : IUnitFactory
    {
        //private IObjectBuilder _objectBuilder = new IObjectBuilder();


        public string Name { get; set; }

        public IObjectBuilder ObjectBuilder {
            get
            {
                return new CircleBuilder();
            }
            set
            {

            }
        }

        public void Animate() { }

    }
}
