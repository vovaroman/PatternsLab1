using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patternLab.Factory
{
    public interface IUnitFactory
    {
        string Name { get; set; }
        IObjectBuilder ObjectBuilder { get; }       

    }
}
