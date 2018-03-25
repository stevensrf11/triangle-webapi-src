using System;
using System.Collections.Generic;

namespace WebApi.Business.Layer.Interfaces.Models.Triangle
{
    /// <summary>
    /// Business layer triangle model interface <see cref="IBLTriangleModel"/>
    /// </summary>
    public interface IBLTriangleModel
    {
        /// <summary>
        /// Row information
        /// </summary>
        string Row { get; }
        /// <summary>
        /// Column information
        /// </summary>
        int Column { get; }
    }
}
