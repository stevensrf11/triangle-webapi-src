using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Business.Layer.Interfaces.Models.Triangle
{
    /// <summary>
    /// Business layer vertice model interface <see cref="IBLModel"/>
    /// </summary>
    public interface IBLTriangleVerticeModel : IBLModel
    {
        /// <summary>
        /// X vertex
        /// </summary>
        double XValue { get;  }
        /// <summary>
        /// Y vertex value
        /// </summary>
        double YValue { get; }
    }
}
